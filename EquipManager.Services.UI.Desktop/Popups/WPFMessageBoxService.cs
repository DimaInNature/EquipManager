namespace EquipManager.Services.UI.Desktop.Popups;

/// <summary> Сервис, отвечающий за работу <see cref="MessageBox"/>
/// в рамках паттерна MVVM.</summary>
/// <remarks>Вызывающим клиентом должно быть приложение на WPF.</remarks>
public sealed class WPFMessageBoxService : IMessageBoxService
{
    /// <summary> Вызвать всплывающее окно.</summary>
    /// <param name="text">Сообщение в окне.</param>
    /// <param name="caption">Заголовок окна.</param>
    /// <param name="icon">Иконка окна.</param>
    /// <param name="button">Отображаемая кнопка.</param>
    public void Show(string text, string caption,
        MessageBoxImage icon, MessageBoxButton button = MessageBoxButton.OK) =>
        MessageBox.Show(
            messageBoxText: text,
            caption: caption,
            button: button,
            icon: icon);
}