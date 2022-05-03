namespace EquipManager.Services.Data.Features.PPEs;

public sealed record class CreatePPECommand : IRequest
{
    public PPE? PPE { get; init; }

    public CreatePPECommand(PPE entity) => PPE = entity;

    public CreatePPECommand() { }
}