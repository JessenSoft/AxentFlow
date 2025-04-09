using System.Reactive;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

public class DemoViewModel : ReactiveObject
{
    [Reactive] public string TextInput { get; set; }
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