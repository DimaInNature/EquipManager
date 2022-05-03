namespace EquipManager.Services.Data.Employees;

/// <summary> Реализация паттерна Repository сущности базы данных
/// <see cref="Employee"/>.</summary>
public sealed class EmployeeRepositoryService
    : IEmployeeRepositoryService
{
    private readonly IMediator _mediator;

    public EmployeeRepositoryService(IMediator mediator) => _mediator = mediator;

    /// <summary> Асинхронно получить список всех сотрудников из базы данных.</summary>
    /// <returns>Коллекция со всеми объектами <see cref="Employee"/>.</returns>
    public async Task<List<Employee>?> GetEmployeeListAsync() =>
        await _mediator.Send(request: new GetEmployeeListQuery());

    /// <summary> Асинхронно получить <see cref="Employee"/> по
    /// его <paramref name="id"/> из базы данных.</summary>
    /// <param name="id">Идентификатор.</param>
    /// <returns><see langword="null"/> если искомого объекта не существует.</returns>
    public async Task<Employee?> GetEmployeeAsync(int id) =>
       await _mediator.Send(request: new GetEmployeeByIdQuery());

    /// <summary> Асинхронное создание <see cref="Employee"/> в базе данных.</summary>
    /// <param name="entity">Объект сущности, данные которого будут занесены в базу данных.</param>
    public async Task CreateAsync(Employee entity) =>
        await _mediator.Send(request: new CreateEmployeeCommand(entity));

    /// <summary> Асинхронное изменение <see cref="Employee"/> в базе данных.</summary>
    /// <param name="entity">Объект сущности, данные которого будут изменены.</param>
    public async Task UpdateAsync(Employee entity) =>
        await _mediator.Send(request: new UpdateEmployeeCommand(entity));

    /// <summary> Асинхронное удаление <see cref="Employee"/> из базы данных.</summary>
    /// <remarks>Объекты сущностей, которые имеют ссылку на удаляемый объект, тоже будут удалены.</remarks>
    /// <param name="id">Идентификатор.</param>
    public async Task DeleteAsync(int id) =>
        await _mediator.Send(request: new DeleteEmployeeCommand(id));
}