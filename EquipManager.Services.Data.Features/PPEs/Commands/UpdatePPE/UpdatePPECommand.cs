namespace EquipManager.Services.Data.Features.PPEs;

public sealed record class UpdatePPECommand : IRequest
{
    public PPE? PPE { get; init; }

    public UpdatePPECommand(PPE entity) => PPE = entity;

    public UpdatePPECommand() { }
}