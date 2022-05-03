namespace EquipManager.Services.Data.EmployeeSizeCharts;

/// <summary> Реализация паттерна Repository над логикой
/// управления данными сущности базы данных <see cref="EmployeeSizeChart"/>.</summary>
public sealed class EmployeeSizeChartsRepositoryService
    : IEmployeeSizeChartsRepositoryService
{
    private readonly IMediator _mediator;

    public EmployeeSizeChartsRepositoryService(IMediator mediator) => _mediator = mediator;

    /// <summary> Асинхронное создание <see cref="EmployeeSizeChart"/> в базе данных.</summary>
    /// <param name="entity">Объект сущности, данные которого будут занесены в базу данных.</param>
    public async Task CreateAsync(EmployeeSizeChart entity) =>
        await _mediator.Send(request: new CreateEmployeeSizeChartCommand(entity));

    /// <summary> Асинхронное изменение <see cref="EmployeeSizeChart"/> в базе данных.</summary>
    /// <param name="entity">Объект сущности, данные которого будут изменены.</param>
    public async Task UpdateAsync(EmployeeSizeChart entity) =>
        await _mediator.Send(request: new UpdateEmployeeSizeChartCommand(entity));

    /// <summary> Асинхронное удаление <see cref="EmployeeSizeChart"/> из базы данных.</summary>
    /// <remarks>Объекты сущностей, которые имеют ссылку на удаляемый объект, тоже будут удалены.</remarks>
    /// <param name="id">Идентификатор.</param>
    public async Task DeleteAsync(int id) =>
        await _mediator.Send(request: new DeleteEmployeeSizeChartCommand(id));
}