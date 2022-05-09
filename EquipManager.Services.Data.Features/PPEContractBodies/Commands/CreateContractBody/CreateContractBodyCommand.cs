namespace EquipManager.Services.Data.Features.PPEContractBodies;

public class CreateContractBodyCommand : IRequest
{
    public PPEContractBody? ContractBody { get; init; }

    public CreateContractBodyCommand(PPEContractBody entity) => ContractBody = entity;

    public CreateContractBodyCommand() { }
}