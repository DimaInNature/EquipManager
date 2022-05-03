namespace EquipManager.Services.Data.PPEs;

/// <summary> Реализация паттерна Repository над логикой
/// управления данными сущности базы данных <see cref="PPE"/>.</summary>
public sealed class PPERepositoryService : IPPERepositoryService
{
    private readonly IMediator _mediator;

    public PPERepositoryService(IMediator mediator) => _mediator = mediator;

    /// <summary> Асинхронно получить список всех <see cref="PPE"/> из базы данных.</summary>
    /// <returns>Коллекция со всеми объектами <see cref="PPE"/>.</returns>
    public async Task<List<PPE>?> GetPPEListAsync() =>
        await _mediator.Send(request: new GetPPEListQuery());

    /// <summary> Асинхронно получить <see cref="PPE"/> по
    /// его <paramref name="id"/> из базы данных.</summary>
    /// <param name="id">Идентификатор.</param>
    /// <returns><see langword="null"/> если искомого объекта не существует.</returns>
    public async Task<PPE?> GetPPEAsync(int id) =>
        await _mediator.Send(request: new GetPPEByIdQuery(id));

    /// <summary> Асинхронное создание <see cref="PPE"/> в базе данных.</summary>
    /// <param name="entity">Объект сущности, данные которого будут занесены в базу данных.</param>
    public async Task CreateAsync(PPE entity) =>
        await _mediator.Send(request: new CreatePPECommand(entity));

    /// <summary> Асинхронное изменение <see cref="PPE"/> в базе данных.</summary>
    /// <param name="entity">Объект сущности, данные которого будут изменены.</param>
    public async Task UpdateAsync(PPE entity) =>
        await _mediator.Send(request: new UpdatePPECommand(entity));

    /// <summary> Асинхронное удаление <see cref="PPE"/> из базы данных.</summary>
    /// <remarks>Объекты сущностей, которые имеют ссылку на удаляемый объект, тоже будут удалены.</remarks>
    /// <param name="id">Идентификатор.</param>
    public async Task DeleteAsync(int id) =>
        await _mediator.Send(request: new DeletePPECommand(id));
}