namespace EquipManager.Services.Data.PPEContracts;

/// <summary> Реализация паттерна Facade над логикой
/// управления данными <see cref="PPEContract"/>.</summary>
public sealed class PPEContractFacadeService
    : IPPEContractFacadeService
{
    private readonly IPPEContractRepositoryService _contractRepository;

    private readonly IPPEContractBodyRepositoryService _bodyRepository;

    public PPEContractFacadeService(IPPEContractRepositoryService contractRepository,
        IPPEContractBodyRepositoryService bodyRepository) =>
        (_contractRepository, _bodyRepository) = (contractRepository, bodyRepository);

    /// <summary> Асинхронно получить список всех 
    /// <see cref="PPEContract"/> из базы данных.</summary>
    /// <returns>Коллекцию всех <see cref="PPEContract"/>.</returns>
    public async Task<List<PPEContract>> GetPPEContractListAsync() =>
       await _contractRepository.GetPPEContractListAsync() ?? new();

    /// <summary> Асинхронно получить <see cref="PPEContract"/>
    /// по его <paramref name="id"/> из базы данных.</summary>
    /// <param name="id">Идентификатор.</param>
    /// <returns><see langword="null"/> если искомого объекта не существует.</returns>
    public async Task<PPEContract?> GetPPEContractAsync(int id) =>
        await _contractRepository.GetPPEContractAsync(id);

    /// <summary> Асинхронное создание <see cref="PPEContract"/> и
    /// принадлежащей ему <see cref="PPEContractBody"/> в базе данных.</summary>
    /// <param name="contractModel">Объект - кортеж, объединяющий в
    /// себе <see cref="PPEContract"/> и его <see cref="PPEContractBody"/>.</param>
    public async Task CreateAsync((PPEContract contract, PPEContractBody body) contractModel)
    {
        PPEContract contract = contractModel.contract;

        PPEContractBody body = contractModel.body;

        if (contract is null || body is null) return;

        await _bodyRepository.CreateAsync(body);

        contract.PPEContractBodyId = body.Id;

        await _contractRepository.CreateAsync(contract);
    }

    /// <summary> Асинхронное изменение <see cref="PPEContract"/> и
    /// принадлежащей ему <see cref="PPEContractBody"/> в базе данных.</summary>
    /// <param name="contractModel">Объект - кортеж, объединяющий в
    /// себе <see cref="PPEContract"/> и его <see cref="PPEContractBody"/>.</param>
    public async Task UpdateAsync((PPEContract contract, PPEContractBody body) contractModel)
    {
        if (contractModel.contract is null || contractModel.body is null) return;

        await _contractRepository.UpdateAsync(entity: contractModel.contract);

        await _bodyRepository.UpdateAsync(entity: contractModel.body);
    }

    /// <summary> Асинхронное удаление <see cref="PPEContract"/> и
    /// принадлежащей ему <see cref="PPEContractBody"/> из базы данных.</summary>
    /// <param name="id">Идентификатор.</param>
    public async Task DeleteAsync(int id)
    {
        if (id < 0) return;

        await _contractRepository.DeleteAsync(id);
    }
}