namespace EquipManager.Services.Data.Features.PPEContracts;

public sealed class CreatePPEContractCommand : IRequest
{
    public PPEContract? PPEContract { get; init; }

    public CreatePPEContractCommand(PPEContract entity) => PPEContract = entity;

    public CreatePPEContractCommand() { }
}