namespace EquipManager.Services.Data.Features.PPEs;

public sealed record class GetPPEByIdQuery : IRequest<PPE?>
{
    public int Id { get; init; }

    public GetPPEByIdQuery(int id) => Id = id;

    public GetPPEByIdQuery() { }
}