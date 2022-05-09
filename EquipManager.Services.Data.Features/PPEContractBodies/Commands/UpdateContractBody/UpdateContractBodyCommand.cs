namespace EquipManager.Services.Data.Features.PPEContractBodies;

public sealed class UpdateContractBodyCommand : IRequest
{
    public PPEContractBody? ContractBody { get; init; }

    public UpdateContractBodyCommand(PPEContractBody entity) => ContractBody = entity;

    public UpdateContractBodyCommand() { }
}