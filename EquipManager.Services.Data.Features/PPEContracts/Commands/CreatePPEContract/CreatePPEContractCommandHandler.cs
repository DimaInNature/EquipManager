namespace EquipManager.Services.Data.Features.PPEContracts;

public sealed class CreatePPEContractCommandHandler
    : IRequestHandler<CreatePPEContractCommand>
{
    private readonly ApplicationContext _context;

    public CreatePPEContractCommandHandler(ApplicationContext context) => _context = context;

    public async Task<Unit> Handle(CreatePPEContractCommand request, CancellationToken token)
    {
        if (request.PPEContract is null) return Unit.Value;

        await _context.PPEContract.AddAsync(
            entity: request.PPEContract,
            cancellationToken: token);

        await _context.SaveChangesAsync(cancellationToken: token);

        return Unit.Value;
    }
}