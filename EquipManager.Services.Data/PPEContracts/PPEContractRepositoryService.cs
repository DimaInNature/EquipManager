namespace EquipManager.Services.Data.PPEContracts;

/// <summary> Реализация паттерна Repository сущности базы данных
/// <see cref="PPEContract"/>.</summary>
public sealed class PPEContractRepositoryService
    : IPPEContractRepositoryService
{
    private readonly IMediator _mediator;

    public PPEContractRepositoryService(IMediator mediator) => _mediator = mediator;

    /// <summary> Асинхронно получить список всех сотрудников из базы данных.</summary>
    /// <returns>Коллекция со всеми объектами <see cref="PPEContract"/>.</returns>
    public async Task<List<PPEContract>?> GetPPEContractListAsync() =>
        await _mediator.Send(request: new GetPPEContractListQuery());

    /// <summary> Асинхронно получить <see cref="PPEContract"/> по
    /// его <paramref name="id"/> из базы данных.</summary>
    /// <param name="id">Идентификатор.</param>
    /// <returns><see langword="null"/> если искомого объекта не существует.</returns>
    public async Task<PPEContract?> GetPPEContractAsync(int id) =>
       await _mediator.Send(request: new GetPPEContractByIdQuery());

    /// <summary> Асинхронное создание <see cref="PPEContract"/> в базе данных.</summary>
    /// <param name="entity">Объект сущности, данные которого будут занесены в базу данных.</param>
    public async Task CreateAsync(PPEContract entity) =>
        await _mediator.Send(request: new CreatePPEContractCommand(entity));

    /// <summary> Асинхронное изменение <see cref="PPEContract"/> в базе данных.</summary>
    /// <param name="entity">Объект сущности, данные которого будут изменены.</param>
    public async Task UpdateAsync(PPEContract entity) =>
        await _mediator.Send(request: new UpdatePPEContractCommand(entity));

    /// <summary> Асинхронное удаление <see cref="PPEContract"/> из базы данных.</summary>
    /// <remarks>Объекты сущностей, которые имеют ссылку на удаляемый объект, тоже будут удалены.</remarks>
    /// <param name="id">Идентификатор.</param>
    public async Task DeleteAsync(int id) =>
        await _mediator.Send(request: new DeletePPEContractCommand(id));
}