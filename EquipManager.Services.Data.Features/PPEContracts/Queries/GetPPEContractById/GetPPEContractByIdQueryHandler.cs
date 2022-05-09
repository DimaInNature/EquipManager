namespace EquipManager.Services.Data.Features.PPEContracts;

public sealed record class GetPPEContractByIdQueryHandler
    : IRequestHandler<GetPPEContractByIdQuery, PPEContract?>
{
    private readonly ApplicationContext _context;

    public GetPPEContractByIdQueryHandler(ApplicationContext context) => _context = context;

    public async Task<PPEContract?> Handle(GetPPEContractByIdQuery request, CancellationToken token) =>
        await _context.PPEContract.FindAsync(
            keyValues: new object[] { request.Id },
            cancellationToken: token);
}