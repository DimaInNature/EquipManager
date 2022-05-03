namespace EquipManager.Services.Data.PPEs;

/// <summary> Реализация паттерна Facade над логикой
/// управления данными <see cref="PPE"/>.</summary>
public sealed class PPEFacadeService : IPPEFacadeService
{
    private readonly IPPERepositoryService _repository;

    public PPEFacadeService(IPPERepositoryService repository) =>
        _repository = repository;

    /// <summary> Асинхронно получить список всех <see cref="PPE"/> из базы данных.</summary>
    /// <returns>Коллекция со всеми объектами <see cref="PPE"/>.</returns>
    public async Task<List<PPE>> GetPPEListAsync() =>
        await _repository.GetPPEListAsync() ?? new();

    /// <summary> Асинхронно получить <see cref="PPE"/> по
    /// его <paramref name="id"/> из базы данных.</summary>
    /// <param name="id">Идентификатор.</param>
    /// <returns><see langword="null"/> если искомого объекта не существует.</returns>
    public async Task<PPE?> GetPPEAsync(int id) =>
        await _repository.GetPPEAsync(id);

    /// <summary> Асинхронное создание <see cref="PPE"/> в базе данных.</summary>
    /// <param name="entity">Объект сущности, данные которого будут занесены в базу данных.</param>
    public async Task CreateAsync(PPE entity)
    {
        if (entity is null) return;

        await _repository.CreateAsync(entity);
    }

    /// <summary> Асинхронное изменение <see cref="PPE"/> в базе данных.</summary>
    /// <param name="entity">Объект сущности, данные которого будут изменены.</param>
    public async Task UpdateAsync(PPE entity)
    {
        if (entity is null) return;

        await _repository.UpdateAsync(entity);
    }

    /// <summary> Асинхронное удаление <see cref="PPE"/> из базы данных.</summary>
    /// <remarks>Объекты сущностей, которые имеют ссылку на удаляемый объект, тоже будут удалены.</remarks>
    /// <param name="id">Идентификатор.</param>
    public async Task DeleteAsync(int id)
    {
        if (id < 0) return;

        await _repository.DeleteAsync(id);
    }
}