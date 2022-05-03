namespace EquipManager.Services.Data.Features.PPEs;

public sealed record class DeletePPECommand : IRequest
{
    public int Id { get; init; }

    public DeletePPECommand(int id) => Id = id;

    public DeletePPECommand() { }
}