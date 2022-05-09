namespace EquipManager.Services.Interfaces.Data.PPEContracts;

/// <summary> Контракт реализации паттерна Repository над логикой
/// управления данными сущности базы данных <see cref="PPEContract"/>.</summary>
public interface IPPEContractRepositoryService
{
    /// <summary> Асинхронно получить список всех <see cref="PPEContract"/> из базы данных.</summary>
    /// <returns>Коллекция со всеми объектами <see cref="PPEContract"/>.</returns>
    Task<List<PPEContract>?> GetPPEContractListAsync();

    /// <summary> Асинхронно получить <see cref="PPEContract"/> по
    /// его <paramref name="id"/> из базы данных.</summary>
    /// <param name="id">Идентификатор.</param>
    /// <returns><see langword="null"/> если искомого объекта не существует.</returns>
    Task<PPEContract?> GetPPEContractAsync(int id);

    /// <summary> Асинхронное создание <see cref="PPEContract"/> в базе данных.</summary>
    /// <param name="entity">Объект сущности, данные которого будут занесены в базу данных.</param>
    Task CreateAsync(PPEContract entity);

    /// <summary> Асинхронное изменение <see cref="PPEContract"/> в базе данных.</summary>
    /// <param name="entity">Объект сущности, данные которого будут изменены.</param>
    Task UpdateAsync(PPEContract entity);

    /// <summary> Асинхронное удаление <see cref="PPEContract"/> из базы данных.</summary>
    /// <remarks>Объекты сущностей, которые имеют ссылку на удаляемый объект, тоже будут удалены.</remarks>
    /// <param name="id">Идентификатор.</param>
    Task DeleteAsync(int id);
}