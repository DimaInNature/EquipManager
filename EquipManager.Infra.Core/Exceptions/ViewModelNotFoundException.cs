namespace EquipManager.Infra.Core.Exceptions;

public class ViewModelNotFoundException : Exception
{
    public ViewModelNotFoundException() : base() { }

    public ViewModelNotFoundException(string message) : base(message) { }
}