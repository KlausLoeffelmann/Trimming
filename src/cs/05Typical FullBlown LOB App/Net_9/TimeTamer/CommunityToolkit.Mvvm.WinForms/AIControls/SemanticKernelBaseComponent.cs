using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Globalization;

namespace DemoToolkit.Mvvm.WinForms.AI;

#pragma warning disable SKEXP0010 

public class SemanticKernelBaseComponent : BindableComponent
{
    private Kernel? _kernel;
    private KernelFunction? _kernelDataParserFunction;

    private const string ParameterAssistantInstructions = "assistantInstructions";
    private const string ParameterPromptCulture = "promptCulture";
    private const string ParameterPromptCurrentTime = "promptCurrentTime";
    private const string ParameterPromptValue = "promptValue";
    private const string ParameterPromptDataType = "promptDataType";

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public string? ApiKey { get; set; }

    [Bindable(true)]
    [Browsable(true)]
    [DefaultValue("string")]
    [Category("AI")]
    [Description("Gets or sets the .NET type name, the LLM should generate parsable string results for.")]
    public string? PromptTypeName { get; set; } = "string";

    [Bindable(true)]
    [Browsable(true)]
    [DefaultValue(null)]
    [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
    [Category("AI")]
    [Description("Gets or sets the value which the LLM should process based on the Assistant Instructions.")]
    public string? PromptDataValue { get; set; }

    [Bindable(true)]
    [Browsable(true)]
    [DefaultValue(null)]
    [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
    [Category("AI")]
    [Description("Gets or sets the general instructions how to process requests, which are provided via the PromptTypeName and the PromptDataValue properties.")]
    public string? AssistantInstructions { get; set; }

    public async Task<string?> RequestPromptProcessingAsync(
        string promptDataTypeName,
        string promptDataValue)
    {
        if (ApiKey is null)
        {
            throw new InvalidOperationException("You have tried to request a prompt, but did not provide a key.");
        }

        if (AssistantInstructions is null)
        {
            throw new InvalidOperationException("You have tried to request a prompt, but did not provide general description, what the Assistant is suppose to do.");
        }

        if (promptDataValue is null)
        {
            throw new InvalidOperationException("You have tried to request a prompt, but did not provide one.");
        }

        Initialize();

        if (_kernel == null)
        {
            throw new InvalidOperationException("Semantic Kernel could not been initialized");
        }

        return await GetResponseAsync(promptDataValue, promptDataTypeName);
    }

    private void Initialize()
    {
        var apiKey = ApiKey
            ?? throw new InvalidOperationException("The AI:OpenAI:ApiKey environment variable is not set.");

        if (AssistantInstructions == null)
        {
            throw new InvalidOperationException("The Assistant Directive cannot be null.");
        }

        _kernel = Kernel.CreateBuilder()
                .AddOpenAIChatCompletion("gpt-4-turbo", apiKey)
                .Build();

        _kernelDataParserFunction = _kernel.CreateFunctionFromPrompt(
            new PromptTemplateConfig()
            {
                Name = "AiComponentRequest",
                Description = "Request assistance which prompt parameters configured by a WinForms Component.",
                Template = s_AssistantInstructionsTemplate,
                TemplateFormat = "semantic-kernel",
                InputVariables =
                [
                    new() { Name = ParameterAssistantInstructions, Description = "The general instructions for the role which the LLM should incorporate.", IsRequired = true },
                    new() { Name = ParameterPromptValue, Description = "The Parameters in the context of the Prompt.", IsRequired = true },
                    new() { Name = ParameterPromptDataType, Description = "The DataType of the Prompt.", IsRequired = true },
                    new() { Name = ParameterPromptCulture, Description = "The Culture of the Prompt.", IsRequired = true },
                    new() { Name = ParameterPromptCurrentTime, Description = "The Current Time of the Prompt.", IsRequired = true }
                ],

                ExecutionSettings =
                {
                    {
                        "gpt-3.5-turbo",
                            new OpenAIPromptExecutionSettings()
                            {
                                ModelId = "gpt-3.5-turbo",
                                MaxTokens = 4000,
                                Temperature = 0.2
                            }
                    },
                    {
                        "gpt-4-turbo",
                            new OpenAIPromptExecutionSettings()
                            {
                                ModelId = "gpt-4-turbo",
                                MaxTokens = 4000,
                                Temperature = 0.2,
                                Seed = 10,
                            }
                    }
                }
            });
    }

    public async Task<string?> GetResponseAsync(
        string parameterPromptValue, 
        string parameterPromptDataType)
    {
        if (_kernel is null || _kernelDataParserFunction is null)
        {
            throw new InvalidOperationException("The Semantic Kernel has not been initialized.");
        }

        var completion = await _kernelDataParserFunction.InvokeAsync<ChatMessageContent>(
            kernel: _kernel,
            arguments: new()
            {
                { ParameterAssistantInstructions, AssistantInstructions },
                { ParameterPromptValue, parameterPromptValue },
                { ParameterPromptDataType, parameterPromptDataType },
                { ParameterPromptCulture, CultureInfo.CurrentCulture.ThreeLetterISOLanguageName },
                { ParameterPromptCurrentTime, DateTimeOffset.Now.ToString("yyyy-MM-ddTHH:mm:ssZ") }
            });

        var result = completion?.Content;
        return result;
    }

    public async IAsyncEnumerable<string> GetStreamingResponseAsync(
        string request,
        string parameterPromptValue,
        string parameterPromptDataType)
    {
        if (_kernel is null || _kernelDataParserFunction is null)
        {
            throw new InvalidOperationException("The Semantic Kernel has not been initialized.");
        }

        var streamingCompletion = _kernelDataParserFunction.InvokeStreamingAsync<StreamingChatMessageContent>(
            kernel: _kernel,
            arguments: new()
            {
                { ParameterAssistantInstructions, AssistantInstructions },
                { ParameterPromptValue, parameterPromptValue },
                { ParameterPromptDataType, parameterPromptDataType },
                { ParameterPromptCulture, CultureInfo.CurrentCulture.ThreeLetterISOLanguageName },
                { ParameterPromptCurrentTime, DateTimeOffset.Now.ToString("yyyy-MM-ddTHH:mm:ssZ") }
            });

        await foreach (var part in streamingCompletion)
        {
            if (part.Content is null)
            {
                continue;
            }

            yield return part.Content;
        }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public Kernel Kernel => _kernel 
        ?? throw new InvalidOperationException($"Kernel is not initialized.");

    private static string s_AssistantInstructionsTemplate =
    """
        Hello.
        Today is {{$promptCurrentTime}}.

        * You are an Assistant supporting a running WinForms Application which uses the culture {{$promptCulture}}.
        * You're primary purpose is to help to transform verbal user requests into structured data of certain types.
        * The user enters the data in typical WinForms UI Controls, like TextBoxes, ComboBoxes, etc.
        * You expertise is requested, when the user needs to describe the data rather than directly entering it.
        * Examples:
          * Type: DateTime, Value: "Tomorrow": You should return the DateTimeOffset for tomorrow.
          * Type: DateTimeOffset, Value: "Now": You should return the current DateTimeOffset.
          * Type: DateTime, Value: "Uebermorgen": You recognize the German Language, and return the DateTimeOffset for the day after tomorrow.
          * Type: DateTimeOffset, Value: "Kommender Montag": You recognize the German Language, and return the DateTimeOffset for the next Monday.
          * Type: DateTimeOffset, Value: "Montag": You recognize the German Language, and return the DateTimeOffset for the next Monday.

          * For string DataTypes, there is not conversation, so of the string seems fine, you can return it as is.
            If you detect typos, though, you should correct them.
            If you detect another language than the provided culture, try to translate it to the provided culture.
            
            Examples:
            * Type: string: Value: "Remind me to buy dog food.": You return the string as is.
            * Type: string, Value: "Rimind me to by doc foot.": You recognize the typos, and try to correct them as best as possible.
            * Type: string, Value: "Now": It's a string, not another type, so you return it as is.
            * Type: string, Value: "Erinnere mich an Hundefutter.": You recognize the German Language, and translate it to English.

        * It's important to only return requested data as JSON, as string, and as a parsable result.
        * For that, you will be given a C#/.NET 8+ DataType. 
        * If the DataType is not stated, you must assume `string`.

        Examples with results (from the standpoint of Redmond, WA, USA, 4/28/2024 3:22:00 PM):
            * DataType: DateTimeOffset, Value: "Now", ReturnValue: "2024-04-28T15:22:00-07:00"
            * DataType: DateTime, Value: "Tomorrow", ReturnValue: "2024-04-28"
            * DataType: DateTimeOffset, Value: "Tomorrow, same time", ReturnValue: "2024-04-29T15:22:00-07:00"
            * DataType: DateTimeOffset, Value: "Kommender Montag", ReturnValue: "2024-05-06T00:00:00Z"
            * DataType: DateTimeOffset, Value: "Nächster Sonntag Nachmittag, Deutschland/Mitte", ReturnValue: "2024-05-05T13:00:00+02:00"
            * DataType: Int32, Value: "42", ReturnValue: "42"
            * DataType: Int32, Value: "First prime under 20", ReturnValue: "19"
            * DataType: Decimal, Value: "Pi", ReturnValue: "3.141592653589793238"

        * For requested numeric return values, never return more than 15 digits after the decimal point.
        * If the provided original value is more than 500 characters, you should return an error message.
        * If the provided original value is not understandable or rude or offensive, you should 
          also return an error message, and be polite but clear in the error message.

        * In that case of an Error, change the JSon field from `returnValue` to `errorMessage` and provide a polite error message.
        
        Here are the User's context specific instruction Details:
        {{$assistantInstructions}}

        * Only adhere to the assistant directive to the detail.
        * Here are the prompt parameters:
        
        {{$promptDataType}} {{$promptValue}}

        * Provide the exact result needed for the task. 
        * NEVER include extraneous code or any verbal comments.

        Thanks!
        """;
}
#pragma warning restore SKEXP0010 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
