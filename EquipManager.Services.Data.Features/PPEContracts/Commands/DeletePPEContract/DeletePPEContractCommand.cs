namespace EquipManager.Services.Data.Features.PPEContracts;

public sealed class DeletePPEContractCommand : IRequest
{
    public int Id { get; init; }

    public DeletePPEContractCommand(int id) => Id = id;

    public DeletePPEContractCommand() { }
}