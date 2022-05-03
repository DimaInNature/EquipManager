namespace EquipManager.Services.Data.Features.PPEs;

public sealed record class GetPPEListQueryHandler
    : IRequestHandler<GetPPEListQuery, List<PPE>?>
{
    private readonly ApplicationContext _context;

    public GetPPEListQueryHandler(ApplicationContext context) => _context = context;

    public async Task<List<PPE>?> Handle(GetPPEListQuery request, CancellationToken token) =>
        await _context.PPEs.ToListAsync(cancellationToken: token);
}