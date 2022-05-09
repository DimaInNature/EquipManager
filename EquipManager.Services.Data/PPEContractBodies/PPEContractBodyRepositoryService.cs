namespace EquipManager.Services.Data.PPEContractBodies;

/// <summary> Реализация паттерна Repository над логикой
/// управления данными сущности базы данных <see cref="PPEContractBody"/>.</summary>
public sealed class PPEContractBodyRepositoryService
    : IPPEContractBodyRepositoryService
{
    private readonly IMediator _mediator;

    public PPEContractBodyRepositoryService(IMediator mediator) => _mediator = mediator;

    /// <summary> Асинхронное создание <see cref="PPEContractBody"/> в базе данных.</summary>
    /// <param name="entity">Объект сущности, данные которого будут занесены в базу данных.</param>
    public async Task CreateAsync(PPEContractBody entity) =>
        await _mediator.Send(request: new CreateContractBodyCommand(entity));

    /// <summary> Асинхронное изменение <see cref="PPEContractBody"/> в базе данных.</summary>
    /// <param name="entity">Объект сущности, данные которого будут изменены.</param>
    public async Task UpdateAsync(PPEContractBody entity) =>
        await _mediator.Send(request: new UpdateContractBodyCommand(entity));

    /// <summary> Асинхронное удаление <see cref="PPEContractBody"/> из базы данных.</summary>
    /// <remarks>Объекты сущностей, которые имеют ссылку на удаляемый объект, тоже будут удалены.</remarks>
    /// <param name="id">Идентификатор.</param>
    public async Task DeleteAsync(int id) =>
        await _mediator.Send(request: new DeleteContractBodyCommand(id));
}