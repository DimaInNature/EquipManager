namespace EquipManager.Services.Interfaces.Application.ViewModels;

/// <summary> Контракт модели представления.</summary>
/// <typeparam name="TView">Представление, к которому будет привязана модель представления.</typeparam>
public interface IViewModel<TView> where TView : ContentControl { }