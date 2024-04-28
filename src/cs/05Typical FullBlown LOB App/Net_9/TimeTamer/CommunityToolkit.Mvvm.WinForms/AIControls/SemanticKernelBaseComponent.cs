using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using System.ComponentModel;
using System.Globalization;

namespace DemoToolkit.Mvvm.WinForms.AI;

#pragma warning disable SKEXP0010 

public class SemanticKernelBaseComponent : BindableComponent
{
    private Kernel? _kernel;
    private KernelFunction? _kernelDataParserFunction;

    private const string ParameterRequest = "request";
    private const string ParameterAssistantInstructions = "assistantInstructions";
    private const string ParameterPromptCulture = "promptCulture";
    private const string ParameterPromptCurrentTime = "promptCurrentTime";
    private const string ParameterPromptValue = "promptValue";
    private const string ParameterPromptDataType = "promptDataType";

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public string? ApiKey { get; set; }

    public string? AssistantInstructions { get; set; }

    public async Task<string?> RequestPromptProcessingAsync(
        string userRequest,
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

        return await GetResponseAsync(userRequest, promptDataValue, promptDataTypeName);
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
                    new() { Name = ParameterRequest, Description = "The user's request.", IsRequired = true },
                    new() { Name = ParameterPromptValue, Description = "The Parameters in the context of the Prompt.", IsRequired = false }
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
        string request, 
        string parameterPromptValue, 
        string parameterPromptDataType)
    {
        if (_kernel is null || _kernelDataParserFunction is null)
        {
            throw new InvalidOperationException("The Semantic Kernel has not been initialized.");
        }

        var completion = await _kernelDataParserFunction.InvokeAsync<StreamingChatMessageContent>(
            kernel: _kernel,
            arguments: new()
            {
                { ParameterAssistantInstructions, AssistantInstructions },
                { ParameterRequest, request },
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
                { ParameterRequest, request },
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
        Today is {{promptCurrentTime}}.

        * You are an Assistant supporting a running WinForms Application which uses the culture {{promptCulture}}.
        * You're primary purpose is to help to transform verbal user requests into structured data of certain types.
        * The user enters the data in typical WinForms UI Controls, like TextBoxes, ComboBoxes, etc.
        * You expertise is requested, when the user needs to describe the data rather than directly entering it.
        * Examples:
          * Type: DateTime, Value: "Tomorrow": You should return the DateTimeOffset for tomorrow.
          * Type: DateTimeOffset, Value: "Now": You should return the current DateTimeOffset.
          * Type: string, Value: "Now": If not otherwise stated, you return the string "Now", but correct typos or grammar issues.
          * Type: string, Value: "Erinnere mich an Hundefutter.": You recognize the German Language, and translate it to English.
          * Type: string, Value: "Rimind me to by doc foot.": You recognize the typos, and try to correct them as best as possible.
          * Type: DateTime, Value: "Uebermorgen": You recognize the German Language, and return the DateTimeOffset for the day after tomorrow.
          * Type: DateTimeOffset, Value: "Kommender Montag": You recognize the German Language, and return the DateTimeOffset for the next Monday.
          * Type: DateTimeOffset, Value: "Nächsten Montag": You recognize the German Language, and return the DateTimeOffset for the next Monday.
          * Type: DateTimeOffset, Value: "Montag": You recognize the German Language, and return the DateTimeOffset for the next Monday.

        * It's important to only return requested data as JSON, as string, and as a parsable result.
        * For that, you will be given a C#/.NET 8+ DataType. 
        * If the DataType is not stated, you must assume `string`.

        Examples:
            * DataType: DateTimeOffset, Value: "Now", ReturnValue: "2024-01-01T00:00:00Z"
            * DataType: DateTimeOffset, Value: "Tomorrow", ReturnValue: "2024-01-02T00:00:00Z"
            * DataType: DateTimeOffset, Value: "Kommender Montag", ReturnValue: "2024-01-08T00:00:00Z"
            * DataType: Int32, Value: "42", ReturnValue: "42"
            * DataType: Int32, Value: "First prime under 20", ReturnValue: "19"
            * DataType: Decimal, Value: "Pi", ReturnValue: "3.141592653589793238"

        * For requested numeric return values, never return more than 15 digits after the decimal point.
        * If the provided original value is more than 500 characters, you should return an error message,
          which needs to be included in asterisks like "** [Error Message Description] **" in the ReturnValue.
        * If the provided original value is not understandable or rude or offensive, you should 
          also return an error message, and be polite but clear in the error message.
        
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
