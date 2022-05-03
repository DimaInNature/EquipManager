namespace EquipManager.Infra.Core.ViewModels;

/// <summary> <see langword="abstract"/> <see langword="class"/> модели представления. 
/// Реализует <see langword="interface"/> <see cref="INotifyPropertyChanged"/>.</summary>
public abstract class BaseViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    public void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}