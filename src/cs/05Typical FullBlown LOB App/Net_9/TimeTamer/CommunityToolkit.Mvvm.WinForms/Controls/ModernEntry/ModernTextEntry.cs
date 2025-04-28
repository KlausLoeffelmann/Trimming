using DemoToolkit.Mvvm.WinForms.AI;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing.Design;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace DemoToolkit.Mvvm.WinForms.Controls.ModernEntry;

/// <summary>
///  Represents a base class for a modern text entry control.
/// </summary>
/// <typeparam name="T">The type of the value.</typeparam>
public abstract partial class ModernTextEntry<T>
    : Panel, ModernTextEntry<T>.IModernTextEntry
{
    public event EventHandler<RequestApiKeyEventArgs>? RequestApiKey;

    private SpinnerControl? _spinner;
    private SemanticKernelBaseComponent? _skComponent;
    private bool _validationEventSuspended;
    private string _apiKey = default!;

    /// <summary>
    ///  Occurs when the text, which the user initially entered, changed.
    /// </summary>
    public event EventHandler? OriginalInputTextChanged;

    /// <summary>
    ///  Occurs when the text box padding has changed.
    /// </summary>
    public event EventHandler? TextBoxPaddingChanged;

    /// <summary>
    ///  Occurs when the value has changed.
    /// </summary>
    public event EventHandler? ValueChanged;

    /// <summary>
    /// Occurs when the validation result has changed.
    /// </summary>
    public event EventHandler? ValidationResultChanged;

    private const int DefaultPenWidth = 2;
    private static readonly Padding DefaultTextBoxPadding = new(8, 4, 8, 4);

    private readonly ModernTextEntryTextBox _textBox;
    private Pen _foreColorPen;
    private Padding _textBoxPadding;
    private string? _originalInputText;
    private string? _validationResult;
    private ToolTip? _tooltip;

    /// <summary>
    /// Initializes a new instance of the <see cref="ModernTextEntry{T}"/> class.
    /// </summary>
    public ModernTextEntry()
    {
        BorderStyle = BorderStyle.None;
        DoubleBuffered = true;
        ResizeRedraw = true;
        TabStop = false;
        TextBoxPadding = DefaultTextBoxPadding;

        SuspendLayout();

        _foreColorPen = new Pen(ForeColor, DefaultPenWidth);

        _textBox = new ModernTextEntryTextBox(this)
        {
            TabStop = true,
            Name=this.Name + "_TextBox",
        };

        _textBox.TextChanged += (s, e) =>
        {
            Debug.Print($"Internal TextBox changed!");
        };

        Controls.Add((Control)_textBox);

        ResumeLayout(true);

        _skComponent = new SemanticKernelBaseComponent()
        {
            // For the most cases, we don't need further instructions,
            // but they cannot be null.
            AssistantInstructions = string.Empty
        };
    }

    protected override void OnEnter(EventArgs e)
    {
        base.OnEnter(e);
        _textBox.Focus();
    }

    /// <summary>
    ///  Deriving class need to implement this method to format (convert) the value to a string.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <returns>Converted value. Preferably in a format which can be parsed back.</returns>
    public abstract string FormatValue(T value);

    public abstract (bool parseSucceeded, T result) TryParseValue(
        string text,
        bool fromAi = false);

    /// <summary>
    ///  Deriving classes need to implement this method to parse the text into the specific value.
    /// </summary>
    /// <param name="text">The original text, which needs to be converted into the value.</param>
    /// <param name="value">The converted value.</param>
    /// <returns></returns>
    public virtual async Task<(bool, T)> TryParseValueAsync(string text)
    {
        var (parseSucceeded, result) = TryParseValue(text);

        if (parseSucceeded)
        {
            return (true, result);
        }

        if (!MakeItIntelligent 
            || _skComponent is not SemanticKernelBaseComponent skComponent)
        {
            return TryParseValue(text);
        }

        if (string.IsNullOrEmpty(skComponent.ApiKey))
        {
            throw new ArgumentException("The Semantic Kernel ApiKey property is not set.");
        }

        if (Spinner is { })
        {
            Spinner.IsSpinning = true;
        }

        ValidationResult = $"{ValidationResult} - Asking for suggestions! [{DateTime.Now:HH:mm:ss}]";

        try
        {
            SuspendValidationEvent();

            // *******************************************************************************
            // Here is where we're calling the OpenAI-(ChatGPT-4-Turbo in the case)-configured
            // Semantic Kernel component:
            // *******************************************************************************
            var resultString = await skComponent.RequestPromptProcessingAsync(
                typeof(T).Name,
                text);

            if (string.IsNullOrWhiteSpace(resultString))
            {
                ValidationResult = "The request did not yield a result!";
                return (false, default!);
            }

            // Let's try to JSON-parse the result:
            return TryParseJsonResultString(resultString);
        }

        finally
        {
            if (Spinner is { })
            {
                Spinner.IsSpinning = false;
            }

            ResumeValidationEvent();
        }
    }

    // Generic method to send a message and parse the JSON response to a specific type.
    public (bool, T) TryParseJsonResultString(string llmReturnString)
    {
        ArgumentNullException.ThrowIfNullOrWhiteSpace(llmReturnString);

        try
        {
            (bool succeeded, string jsonResultString) = CheckAndRemoveCodeTags(llmReturnString);
            using JsonDocument doc = JsonDocument.Parse(jsonResultString);
            JsonElement root = doc.RootElement;

            if (root.TryGetProperty("returnValue", out JsonElement returnValueElement))
            {
                string rawValue = returnValueElement.GetString()!;
                T parsedValue = TryParseValue(rawValue, true).result;
                ValidationResult = string.Empty;

                return (true, parsedValue);
            }
            else if (root.TryGetProperty("errorMessage", out JsonElement errorMessageElement))
            {
                string errorMessage = errorMessageElement.GetString()!;
                ValidationResult = $"We got an issue processing the results:\n{errorMessage}";

                return (false, default!);
            }
            else
            {
                ValidationResult = $"We got an issue processing the results:\nThe returned data was unclear.";
                return (false, default!);
            }
        }
        catch (JsonException jEx)
        {
            ValidationResult = $"We got an issue processing the results:\n{jEx.Message}";

            return (false, default!);
        }
        catch (Exception ex)
        {
            ValidationResult = $"We got an issue processing the results:\n{ex.Message}";

            return (false, default!);
        }
    }

    // Method to check for and remove code tags from a string.
    public static (bool, string) CheckAndRemoveCodeTags(string input)
    {
        // Regex pattern to match code blocks with optional language specifier
        var regex = new Regex(@"^```[a-zA-Z]*\s*\n?([\s\S]*?)\n?```$");
        var match = regex.Match(input);

        if (match.Success)
        {
            // Remove the code tags and trim any excess whitespace/newlines
            return (true, match.Groups[1].Value.Trim());
        }
        return (false, input);
    }

    protected virtual bool ProvidesAiSupport => false;

    /// <inheritdoc/>
    protected async override void OnValidating(CancelEventArgs e)
    {
        if (_validationEventSuspended)
        {
            return;
        }

        if (ProvidesAiSupport && string.IsNullOrWhiteSpace(_apiKey))
        {
            RequestApiKeyInternal();
        }

        try
        {
            // We never will cancel this event, since we need to validate asynchronously.
            // So, "holding" the focus doesn't make sense. Instead, we're delaying or preventing
            // updating the value, if the validation fails, in which case, we would set the
            // ValidationResult property.
            // base.OnValidating(e);

            // TODO: Introduce cancellation token, so another validation would cancel the current one.
            // TODO: Also, cancel the parsing, if the control receives a new value or another keystroke.
            var (parseSucceeded, returnValue) = await TryParseValueAsync(_textBox.Text);

            if (parseSucceeded)
            {
                ValueInternal = returnValue;
                ValidationResult = string.Empty;
                OnValueChanged();

                return;
            }
        }
        catch (Exception ex)
        {
            // TODO: Give a derived control the chance to provide a more detailed error message.
            ValidationResult = "Could not retrieve a value based on the context provided.";
            Debug.Print($"Validation failed for {Name}: {ex.Message}");
            ValueInternal = default!;
        }
    }

    protected T ValueInternal
    {
        get => ((ModernTextEntry<T>.IModernTextEntry)this).Value;
        set
        {
            SuspendValidationEvent();
            ((ModernTextEntry<T>.IModernTextEntry)this).Value = value;
            ResumeValidationEvent();
        }
    }

    // We need to raise the event, so Binding works in both directions.
    protected virtual void OnValueChanged()
        => ValueChanged?.Invoke(this, EventArgs.Empty);

    // Passing this just on from the internal TextBox:
    void IModernTextEntry.OnValueChangedInternal(CancelEventArgs e)
        => OnValueChanged();

    private void RequestApiKeyInternal()
    {
        if (!ProvidesAiSupport || !string.IsNullOrWhiteSpace(_apiKey))
        {
            return;
        }

        var eventArgs = new RequestApiKeyEventArgs();

        RequestApiKey?.Invoke(this, eventArgs);

        if (!string.IsNullOrWhiteSpace(eventArgs.ApiKey))
        {
            _apiKey = eventArgs.ApiKey;
            if (_skComponent is { })
            {
                _skComponent.ApiKey = _apiKey;
            }
        }
    }

    /// <summary>
    ///  Gets or sets the original input text.
    /// </summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    [Bindable(true)]
    [Browsable(true)]
    [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
    public string? OriginalInputText
    {
        get => _originalInputText;
        set
        {
            if (_originalInputText == value)
            {
                return;
            }

            _originalInputText = value;
            OnOriginalInputTextChanged(EventArgs.Empty);
        }
    }

    private bool ShouldSerializeOriginalInputText()
    => _originalInputText is not null;

    private void ResetOriginalInputText()
        => OriginalInputText = null;

    protected virtual void OnOriginalInputTextChanged(EventArgs e)
        => OriginalInputTextChanged?.Invoke(this, e);

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Bindable(false)]
    [Browsable(false)]
    public string? ValidationResult
    {
        get => _validationResult;
        set
        {
            if (_validationResult == value)
            {
                return;
            }

            _validationResult = value;

            if (!String.IsNullOrWhiteSpace(_validationResult))
            {
                ((IModernTextEntry)this).CachedValue = (default!, false);
            }

            OnValidationResultChangedInternal();
            OnValidationResultChanged(EventArgs.Empty);
        }
    }

    protected virtual void OnValidationResultChanged(EventArgs e)
        => ValidationResultChanged?.Invoke(this, e);

    private void OnValidationResultChangedInternal()
    {
        _tooltip?.Dispose();

        if (!string.IsNullOrWhiteSpace(_validationResult))
        {
            _tooltip = new ToolTip();
            if (ValidationResult?.IndexOf('[') > -1)
            {
                _tooltip.ToolTipTitle = "Connecting...";
            }

            bool hasTitle = !string.IsNullOrWhiteSpace(_tooltip.ToolTipTitle);

            _tooltip.Show(
                text: ValidationResult,
                window: this,
                x: 0,
                y: !hasTitle
                    ? -50
                    : -80,
                duration: !hasTitle
                    ? 6000
                    : 3500);
        }
    }

    // Our cached value, once to was validated.
    (T actualValue, bool isCached) IModernTextEntry.CachedValue { get; set; }

    // Provide access to the internal TextBox - we're limiting this via the Interface.
    ModernTextEntryTextBox IModernTextEntry.TextBoxInternal
        => _textBox;

    // Passing this just on from the internal TextBox:
    void IModernTextEntry.OnValidatingInternal(CancelEventArgs e)
        => OnValidating(e);

    internal void ResumeValidationEvent()
        => _validationEventSuspended = false;

    internal void SuspendValidationEvent()
        => _validationEventSuspended = true;

    protected override void CreateHandle()
    {
        base.CreateHandle();

        if (!Application.IsDarkModeEnabled)
        {
            _textBox.BorderStyle = BorderStyle.Fixed3D;
        }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    [Browsable(true)]
    public Padding TextBoxPadding
    {
        get => _textBoxPadding;
        set
        {
            if (_textBoxPadding == value)
            {
                return;
            }

            _textBoxPadding = value;
            OnTextBoxPaddingChanged(EventArgs.Empty);
        }
    }

    protected virtual void OnTextBoxPaddingChanged(EventArgs e)
    => TextBoxPaddingChanged?.Invoke(this, e);

    private bool ShouldSerializeTextBoxPadding()
        => _textBoxPadding != DefaultTextBoxPadding;

    private void ResetTextBoxPadding()
        => TextBoxPadding = DefaultTextBoxPadding;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    [Browsable(true)]
    [DefaultValue(false)]
    [Category("AI Supported")]
    public bool MakeItIntelligent { get; set; }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    [Browsable(true)]
    [Bindable(false)]
    [DefaultValue(null)]
    public SpinnerControl? Spinner
    {
        get => _spinner;
        set
        {
            if (_spinner == value)
            {
                return;
            }

            _spinner = value;
        }
    }
}
