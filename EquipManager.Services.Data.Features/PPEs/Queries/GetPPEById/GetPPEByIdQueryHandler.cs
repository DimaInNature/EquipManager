namespace EquipManager.Services.Data.Features.PPEs;

public sealed record class GetPPEByIdQueryHandler
    : IRequestHandler<GetPPEByIdQuery, PPE?>
{
    private readonly ApplicationContext _context;

    public GetPPEByIdQueryHandler(ApplicationContext context) => _context = context;

    public async Task<PPE?> Handle(GetPPEByIdQuery request, CancellationToken token) =>
        await _context.PPEs.FindAsync(
            keyValues: new object[] { request.Id },
            cancellationToken: token);
}