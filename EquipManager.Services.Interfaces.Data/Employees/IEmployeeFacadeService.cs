namespace EquipManager.Services.Interfaces.Data.Employees;

/// <summary> Контракт реализации паттерна Facade над логикой
/// управления данными <see cref="Employee"/> и <see cref="EmployeeSizeChart"/>.</summary>
public interface IEmployeeFacadeService
{
    /// <summary> Асинхронно получить список всех 
    /// <see cref="Employee"/> из базы данных.</summary>
    /// <returns>Коллекцию всех <see cref="Employee"/>.</returns>
    Task<List<Employee>> GetEmployeeListAsync();

    /// <summary> Асинхронно получить <see cref="Employee"/>
    /// по его <paramref name="id"/> из базы данных.</summary>
    /// <param name="id">Идентификатор.</param>
    /// <returns><see langword="null"/> если искомого объекта не существует.</returns>
    Task<Employee?> GetEmployeeAsync(int id);

    /// <summary> Асинхронное создание <see cref="Employee"/> и
    /// принадлежащей ему <see cref="EmployeeSizeChart"/> в базе данных.</summary>
    /// <param name="employeeModel">Объект - кортеж, объединяющий в
    /// себе <see cref="Employee"/> и его <see cref="EmployeeSizeChart"/>.</param>
    Task CreateAsync((Employee employee, EmployeeSizeChart sizeChart) employeeModel);

    /// <summary> Асинхронное изменение <see cref="Employee"/> и
    /// принадлежащей ему <see cref="EmployeeSizeChart"/> в базе данных.</summary>
    /// <param name="employeeModel">Объект - кортеж, объединяющий в
    /// себе <see cref="Employee"/> и его <see cref="EmployeeSizeChart"/>.</param>
    Task UpdateAsync((Employee employee, EmployeeSizeChart sizeChart) employeeModel);

    /// <summary> Асинхронное удаление <see cref="Employee"/> и
    /// принадлежащей ему <see cref="EmployeeSizeChart"/> из базы данных.</summary>
    /// <param name="id">Идентификатор.</param>
    Task DeleteAsync(int id);
}