namespace EquipManager.Services.Data.Employees;

/// <summary> Реализация паттерна Facade над логикой
/// управления данными <see cref="PPE"/>.</summary>
public sealed class EmployeeFacadeService
    : IEmployeeFacadeService
{
    private readonly IEmployeeRepositoryService _employeeRepository;

    private readonly IEmployeeSizeChartsRepositoryService _employeeSizeChartsRepository;

    public EmployeeFacadeService(IEmployeeRepositoryService employeeRepository,
        IEmployeeSizeChartsRepositoryService employeeSizeChartsRepository) =>
        (_employeeRepository, _employeeSizeChartsRepository) = (employeeRepository, employeeSizeChartsRepository);

    /// <summary> Асинхронно получить список всех 
    /// <see cref="Employee"/> из базы данных.</summary>
    /// <returns>Коллекцию всех <see cref="Employee"/>.</returns>
    public async Task<List<Employee>> GetEmployeeListAsync() =>
       await _employeeRepository.GetEmployeeListAsync() ?? new();

    /// <summary> Асинхронно получить <see cref="Employee"/>
    /// по его <paramref name="id"/> из базы данных.</summary>
    /// <param name="id">Идентификатор.</param>
    /// <returns><see langword="null"/> если искомого объекта не существует.</returns>
    public async Task<Employee?> GetEmployeeAsync(int id) =>
        await _employeeRepository.GetEmployeeAsync(id);

    /// <summary> Асинхронное создание <see cref="Employee"/> и
    /// принадлежащей ему <see cref="EmployeeSizeChart"/> в базе данных.</summary>
    /// <param name="employeeModel">Объект - кортеж, объединяющий в
    /// себе <see cref="Employee"/> и его <see cref="EmployeeSizeChart"/>.</param>
    public async Task CreateAsync((Employee employee, EmployeeSizeChart sizeChart) employeeModel)
    {
        Employee employee = employeeModel.employee;

        EmployeeSizeChart sizeChart = employeeModel.sizeChart;

        if (employee is null || sizeChart is null) return;

        await _employeeSizeChartsRepository.CreateAsync(sizeChart);

        employee.EmployeeSizeChartId = sizeChart.Id;

        await _employeeRepository.CreateAsync(employee);
    }

    /// <summary> Асинхронное изменение <see cref="Employee"/> и
    /// принадлежащей ему <see cref="EmployeeSizeChart"/> в базе данных.</summary>
    /// <param name="employeeModel">Объект - кортеж, объединяющий в
    /// себе <see cref="Employee"/> и его <see cref="EmployeeSizeChart"/>.</param>
    public async Task UpdateAsync((Employee employee, EmployeeSizeChart sizeChart) employeeModel)
    {
        if (employeeModel.employee is null || employeeModel.sizeChart is null) return;

        await _employeeRepository.UpdateAsync(entity: employeeModel.employee);

        await _employeeSizeChartsRepository.UpdateAsync(entity: employeeModel.sizeChart);
    }

    /// <summary> Асинхронное удаление <see cref="Employee"/> и
    /// принадлежащей ему <see cref="EmployeeSizeChart"/> из базы данных.</summary>
    /// <param name="id">Идентификатор.</param>
    public async Task DeleteAsync(int id)
    {
        if (id < 0) return;

        await _employeeRepository.DeleteAsync(id);
    }
}