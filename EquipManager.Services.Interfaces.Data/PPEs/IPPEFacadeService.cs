namespace EquipManager.Services.Interfaces.Data.PPEs;

/// <summary> Контракт реализации паттерна Facade над логикой
/// управления данными <see cref="PPE"/>.</summary>
public interface IPPEFacadeService
{
    /// <summary> Асинхронно получить список всех <see cref="PPE"/> из базы данных.</summary>
    /// <returns>Коллекция со всеми объектами <see cref="PPE"/>.</returns>
    Task<List<PPE>> GetPPEListAsync();

    /// <summary> Асинхронно получить <see cref="PPE"/> по
    /// его <paramref name="id"/> из базы данных.</summary>
    /// <param name="id">Идентификатор.</param>
    /// <returns><see langword="null"/> если искомого объекта не существует.</returns>
    Task<PPE?> GetPPEAsync(int id);

    /// <summary> Асинхронное создание <see cref="PPE"/> в базе данных.</summary>
    /// <param name="entity">Объект сущности, данные которого будут занесены в базу данных.</param>
    Task CreateAsync(PPE entity);

    /// <summary> Асинхронное изменение <see cref="PPE"/> в базе данных.</summary>
    /// <param name="entity">Объект сущности, данные которого будут изменены.</param>
    Task UpdateAsync(PPE entity);

    /// <summary> Асинхронное удаление <see cref="PPE"/> из базы данных.</summary>
    /// <remarks>Объекты сущностей, которые имеют ссылку на удаляемый объект, тоже будут удалены.</remarks>
    /// <param name="id">Идентификатор.</param>
    Task DeleteAsync(int id);
}