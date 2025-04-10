using System;
using System.Reactive;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace JessenSoft.AxentFlow.UI.ViewModels;

/// <summary>
/// A demo ViewModel for testing MudBlazor and ReactiveUI binding.
/// </summary>
public class DemoViewModel : ReactiveObject
{
    /// <summary>
    /// User-entered text, bound to the input field.
    /// </summary>
    [Reactive] public string TextInput { get; set; } = "";

    /// <summary>
    /// Command that gets triggered on submit.
    /// </summary>
    public ReactiveCommand<Unit, Unit> SubmitCommand { get; }

    public DemoViewModel()
    {
        SubmitCommand = ReactiveCommand.Create(() =>
        {
            // Business logic goes here
            Console.WriteLine($"Submitted: {TextInput}");
        });
    }
}