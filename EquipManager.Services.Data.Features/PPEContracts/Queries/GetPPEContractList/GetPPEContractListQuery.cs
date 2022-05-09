namespace EquipManager.Services.Data.Features.PPEContracts;

public sealed record class GetPPEContractListQuery : IRequest<List<PPEContract>?> { }