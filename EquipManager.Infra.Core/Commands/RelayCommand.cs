namespace EquipManager.Infra.Core.Commands;

public sealed class RelayCommand : ICommand
{
    private readonly Action<object>? _execute;

    private readonly Func<object, bool>? _canExecute;

    public event EventHandler? CanExecuteChanged
    {
        add { CommandManager.RequerySuggested += value; }
        remove { CommandManager.RequerySuggested -= value; }
    }

    public bool CanExecute(object? parameter) =>
        parameter is null || _canExecute is null || _canExecute(parameter);

    public RelayCommand(Action<object>? executeAction,
      Func<object, bool>? canExecuteFunc) =>
      (_canExecute, _execute) = (canExecuteFunc, executeAction);

    public void Execute(object parameter) => _execute?.Invoke(parameter);
}