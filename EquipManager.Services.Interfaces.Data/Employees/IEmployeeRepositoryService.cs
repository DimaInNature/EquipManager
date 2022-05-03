namespace EquipManager.Services.Interfaces.Data.Employees;

/// <summary> Контракт реализации паттерна Repository над логикой
/// управления данными сущности базы данных <see cref="Employee"/>.</summary>
public interface IEmployeeRepositoryService
{
    /// <summary> Асинхронно получить список всех <see cref="Employee"/> из базы данных.</summary>
    /// <returns>Коллекция со всеми объектами <see cref="Employee"/>.</returns>
    Task<List<Employee>?> GetEmployeeListAsync();

    /// <summary> Асинхронно получить <see cref="Employee"/> по
    /// его <paramref name="id"/> из базы данных.</summary>
    /// <param name="id">Идентификатор.</param>
    /// <returns><see langword="null"/> если искомого объекта не существует.</returns>
    Task<Employee?> GetEmployeeAsync(int id);

    /// <summary> Асинхронное создание <see cref="Employee"/> в базе данных.</summary>
    /// <param name="entity">Объект сущности, данные которого будут занесены в базу данных.</param>
    Task CreateAsync(Employee entity);

    /// <summary> Асинхронное изменение <see cref="Employee"/> в базе данных.</summary>
    /// <param name="entity">Объект сущности, данные которого будут изменены.</param>
    Task UpdateAsync(Employee entity);

    /// <summary> Асинхронное удаление <see cref="Employee"/> из базы данных.</summary>
    /// <remarks>Объекты сущностей, которые имеют ссылку на удаляемый объект, тоже будут удалены.</remarks>
    /// <param name="id">Идентификатор.</param>
    Task DeleteAsync(int id);
}