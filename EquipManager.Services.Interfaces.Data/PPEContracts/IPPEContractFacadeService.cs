namespace EquipManager.Services.Interfaces.Data.PPEContracts;

/// <summary> Контракт реализации паттерна Facade над логикой
/// управления данными <see cref="PPEContract"/> и <see cref="PPEContractBody"/>.</summary>
public interface IPPEContractFacadeService
{
    /// <summary> Асинхронно получить список всех 
    /// <see cref="PPEContract"/> из базы данных.</summary>
    /// <returns>Коллекцию всех <see cref="PPEContract"/>.</returns>
    Task<List<PPEContract>> GetPPEContractListAsync();

    /// <summary> Асинхронно получить <see cref="PPEContract"/>
    /// по его <paramref name="id"/> из базы данных.</summary>
    /// <param name="id">Идентификатор.</param>
    /// <returns><see langword="null"/> если искомого объекта не существует.</returns>
    Task<PPEContract?> GetPPEContractAsync(int id);

    /// <summary> Асинхронное создание <see cref="PPEContract"/> и
    /// принадлежащей ему <see cref="PPEContractBody"/> в базе данных.</summary>
    /// <param name="contractModel">Объект - кортеж, объединяющий в
    /// себе <see cref="PPEContract"/> и его <see cref="PPEContractBody"/>.</param>
    Task CreateAsync((PPEContract contract, PPEContractBody body) contractModel);

    /// <summary> Асинхронное изменение <see cref="PPEContract"/> и
    /// принадлежащей ему <see cref="PPEContractBody"/> в базе данных.</summary>
    /// <param name="contractModel">Объект - кортеж, объединяющий в
    /// себе <see cref="PPEContract"/> и его <see cref="PPEContractBody"/>.</param>
    Task UpdateAsync((PPEContract contract, PPEContractBody body) contractModel);

    /// <summary> Асинхронное удаление <see cref="PPEContract"/> и
    /// принадлежащей ему <see cref="PPEContractBody"/> из базы данных.</summary>
    /// <param name="id">Идентификатор.</param>
    Task DeleteAsync(int id);
}