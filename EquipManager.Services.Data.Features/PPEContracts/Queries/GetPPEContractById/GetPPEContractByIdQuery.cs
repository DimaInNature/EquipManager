namespace EquipManager.Services.Data.Features.PPEContracts;

public sealed record class GetPPEContractByIdQuery
    : IRequest<PPEContract?>
{
    public int Id { get; init; }

    public GetPPEContractByIdQuery(int id) => Id = id;

    public GetPPEContractByIdQuery() { }
}