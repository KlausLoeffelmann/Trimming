using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using System.ComponentModel;

namespace CommunityToolkit.Mvvm.WinForms.AI;

#pragma warning disable SKEXP0010 

public class SemanticKernelBaseComponent : BindableComponent
{
    private Kernel? _kernel;
    private KernelFunction? _codeGenFunction;

    private const string ParameterRequest = "request";
    private const string ParameterAssistantInstructions = "assistantInstructions";
    private const string ParameterPromptParameters = "promptParameters";

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public string? ApiKey { get; set; }

    public string? AssistantInstructions { get; set; }

    public async Task<string?> RequestPromptProcessingAsync(string userRequest, string promptParameters)
    {
        if (ApiKey is null)
        {
            throw new InvalidOperationException("You have tried to request a prompt, but did not provide a key.");
        }

        if (AssistantInstructions is null)
        {
            throw new InvalidOperationException("You have tried to request a prompt, but did not provide general description, what the Assistant is suppose to do.");
        }

        if (promptParameters is null)
        {
            throw new InvalidOperationException("You have tried to request a prompt, but did not provide one.");
        }

        Initialize();

        if (_kernel == null)
        {
            throw new InvalidOperationException("Semantic Kernel could not been initialized");
        }

        return await GetResponseAsync(userRequest, promptParameters);
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

        _codeGenFunction = _kernel.CreateFunctionFromPrompt(
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
                    new() { Name = ParameterPromptParameters, Description = "The Parameters in the context of the Prompt.", IsRequired = false }
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

    public async Task<string?> GetResponseAsync(string request, string requestPromptParameters)
    {
        if (_kernel is null || _codeGenFunction is null)
        {
            throw new InvalidOperationException("The Semantic Kernel has not been initialized.");
        }

        var completion = await _codeGenFunction.InvokeAsync<StreamingChatMessageContent>(
            kernel: _kernel,
            arguments: new()
            {
                { ParameterAssistantInstructions, AssistantInstructions },
                { ParameterRequest, request },
                { ParameterPromptParameters, requestPromptParameters }
            });

        var result = completion?.Content;
        return result;
    }

    public async IAsyncEnumerable<string> GetStreamingResponseAsync(string request, string requestPromptParameters)
    {
        if (_kernel is null || _codeGenFunction is null)
        {
            throw new InvalidOperationException("The Semantic Kernel has not been initialized.");
        }

        var streamingCompletion = _codeGenFunction.InvokeStreamingAsync<StreamingChatMessageContent>(
            kernel: _kernel,
            arguments: new()
            {
                { ParameterAssistantInstructions, AssistantInstructions },
                { ParameterRequest, request },
                { ParameterPromptParameters, requestPromptParameters }
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
        {{$assistantInstructions}}

        * Only adhere to the assistant directive to the detail.
        * If the request needs further parameters, here are those:
        
        ```JSON
        {{$promptParameters}}
        ```

        * Provide the exact result needed for the task. 
        * NEVER include extraneous code or any verbal comments.

        Here is the code generation request; deliver complete, useful data:

        {{$request}}

        Thanks!
        """;
}
#pragma warning restore SKEXP0010 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
