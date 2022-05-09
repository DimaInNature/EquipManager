namespace EquipManager.Services.Data.Features.PPEContracts;

public sealed record class GetPPEContractListQueryHandler
    : IRequestHandler<GetPPEContractListQuery, List<PPEContract>?>
{
    private readonly ApplicationContext _context;

    public GetPPEContractListQueryHandler(ApplicationContext context) => _context = context;

    public async Task<List<PPEContract>?> Handle(GetPPEContractListQuery request, CancellationToken token) =>
        await _context.PPEContract.ToListAsync(cancellationToken: token);
}