using System.ComponentModel;
using System.Drawing.Text;

namespace DemoToolkit.Mvvm.WinForms.Controls;

public class SpinnerControl : Label
{
    public event EventHandler? IsSpinningChanged;

    private const string BootFontPath = "Boot\\Fonts_EX";
    private const string FontFileName = "segoe_slboot_EX.ttf";

    // Just to know, how this works: This...
    private char[] _simpleCharArray = CharSequence(65..96);
    // ...would produce the following string:
    // "ABCDEFGHIJKLMNOPQRSTUVWXYZ[\]^_`abcdefghijklmnopqrstuvwxyz{|}~"

    // Well - there is a special Font in the Windows Folder, that - if we
    // use a certain range of characters - will be doing something really cool!
    // Keep that in mind, when you're trying this!
    private char[] _charParts = CharSequence(0xE052..0xE0CB);

    private PrivateFontCollection _fontCollection;
    private bool _isSpinning;
    private CancellationTokenSource? _cancellationTokenSource;

    public SpinnerControl()
    {
        DoubleBuffered = true;
        _fontCollection = new PrivateFontCollection();
        _isSpinning = false;
        Text = "";
        LoadBootFontFromBootFolder();
    }

    private void LoadBootFontFromBootFolder()
    {
        string windowsFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
        string bootFolderPath = Path.Combine(windowsFolderPath, BootFontPath);
        _fontCollection.AddFontFile(Path.Combine(bootFolderPath, FontFileName));
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    [Bindable(true)]
    [Browsable(true)]
    public bool IsSpinning
    {
        get => _isSpinning;
        set
        {
            if (_isSpinning == value)
            {
                return;
            }

            _isSpinning = value;
            OnIsSpinningChanged(EventArgs.Empty);
        }
    }

    protected async virtual void OnIsSpinningChanged(EventArgs e)
    {
        IsSpinningChanged?.Invoke(this, e);

        if (_cancellationTokenSource is not null)
        {
            _cancellationTokenSource.Cancel();
            _cancellationTokenSource.Dispose();
            _cancellationTokenSource = null;
            Text = " ";

            return;
        }

        _cancellationTokenSource = new CancellationTokenSource();
        await SpinAsync(_cancellationTokenSource.Token);
    }

    // Using the new WinForms API: Control.InvokeAsync
    private async Task SpinAsync(CancellationToken cancellationToken)
    {
        var timer = new PeriodicTimer(TimeSpan.FromMilliseconds(20));

        try
        {
            int partCount = 0;

            while (await timer.WaitForNextTickAsync(cancellationToken))
            {
                if (cancellationToken.IsCancellationRequested) 
                    break;

                if (IsHandleCreated)
                {
                    // In test-phase for .NET 9: Control.InvokeAsync.
                    await this.InvokeAsync(
                        async () => await DrawSpinnerPartAsync(
                            partCount++,
                            cancellationToken),
                        cancellationToken);

                    partCount %= _charParts.Length;
                }
            }
        }
        catch (OperationCanceledException)
        {
        }
        finally
        {
            timer?.Dispose();
        }
    }

    private async Task DrawSpinnerPartAsync(int partCount, CancellationToken cancellationToken)
    {
        Text = _charParts[partCount].ToString();
        try
        {
            await Task.Delay(20, cancellationToken);
        }
        catch (OperationCanceledException)
        {
        }
    }

    protected override void OnCreateControl()
    {
        base.OnCreateControl();
        Text = " ";

        if (IsAncestorSiteInDesignMode)
        {
            return;
        }

        Font = new Font(_fontCollection.Families[0], Font.Size + 2);
        ForeColor = Application.SystemColors.HighlightText;
    }

    private static char[] CharSequence(Range range)
    => Enumerable
        .Range(
            start: range.Start.Value,
            count: range.End.Value - range.Start.Value + 1)
        .Select(i => (char)i)
        .ToArray();
}
