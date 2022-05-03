namespace EquipManager.Services.Interfaces.UI.Desktop.Popups;

public interface IMessageBoxService
{
    void Show(string text, string caption, MessageBoxImage icon,
        MessageBoxButton button = MessageBoxButton.OK);
}