namespace EquipManager.Services.Interfaces.Data.EmployeeSizeCharts;

/// <summary> Контракт реализации паттерна Repository над логикой
/// управления данными сущности базы данных <see cref="EmployeeSizeChart"/>.</summary>
public interface IEmployeeSizeChartsRepositoryService
{
    /// <summary> Асинхронное создание <see cref="EmployeeSizeChart"/> в базе данных.</summary>
    /// <param name="entity">Объект сущности, данные которого будут занесены в базу данных.</param>
    Task CreateAsync(EmployeeSizeChart entity);

    /// <summary> Асинхронное изменение <see cref="EmployeeSizeChart"/> в базе данных.</summary>
    /// <param name="entity">Объект сущности, данные которого будут изменены.</param>
    Task UpdateAsync(EmployeeSizeChart entity);

    /// <summary> Асинхронное удаление <see cref="EmployeeSizeChart"/> из базы данных.</summary>
    /// <remarks>Объекты сущностей, которые имеют ссылку на удаляемый объект, тоже будут удалены.</remarks>
    /// <param name="id">Идентификатор.</param>
    Task DeleteAsync(int id);
}