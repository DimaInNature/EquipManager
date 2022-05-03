namespace EquipManager.Services.Data.Features.PPEs;

public sealed record class GetPPEListQuery : IRequest<List<PPE>?> { }