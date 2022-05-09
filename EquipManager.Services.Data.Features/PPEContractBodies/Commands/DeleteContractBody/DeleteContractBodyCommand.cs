namespace EquipManager.Services.Data.Features.PPEContractBodies;

public sealed class DeleteContractBodyCommand : IRequest
{
    public int Id { get; init; }

    public DeleteContractBodyCommand(int id) => Id = id;

    public DeleteContractBodyCommand() { }
}