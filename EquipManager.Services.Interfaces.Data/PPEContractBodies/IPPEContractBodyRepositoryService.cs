namespace EquipManager.Services.Interfaces.Data.PPEContractBodies;

/// <summary> Контракт реализации паттерна Repository над логикой
/// управления данными сущности базы данных <see cref="PPEContractBody"/>.</summary>
public interface IPPEContractBodyRepositoryService
{
    /// <summary> Асинхронное создание <see cref="PPEContractBody"/> в базе данных.</summary>
    /// <param name="entity">Объект сущности, данные которого будут занесены в базу данных.</param>
    Task CreateAsync(PPEContractBody entity);

    /// <summary> Асинхронное изменение <see cref="PPEContractBody"/> в базе данных.</summary>
    /// <param name="entity">Объект сущности, данные которого будут изменены.</param>
    Task UpdateAsync(PPEContractBody entity);

    /// <summary> Асинхронное удаление <see cref="PPEContractBody"/> из базы данных.</summary>
    /// <remarks>Объекты сущностей, которые имеют ссылку на удаляемый объект, тоже будут удалены.</remarks>
    /// <param name="id">Идентификатор.</param>
    Task DeleteAsync(int id);
}