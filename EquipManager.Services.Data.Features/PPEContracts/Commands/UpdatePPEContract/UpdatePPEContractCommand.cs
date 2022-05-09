namespace EquipManager.Services.Data.Features.PPEContracts;

public sealed record class UpdatePPEContractCommand : IRequest
{
    public PPEContract? PPEContract { get; init; }

    public UpdatePPEContractCommand(PPEContract entity) => PPEContract = entity;

    public UpdatePPEContractCommand() { }
}