namespace EquipManager.Services.Data.Features.PPEContracts;

public sealed class DeletePPEContractCommandHandler
    : IRequestHandler<DeletePPEContractCommand>
{
    private readonly ApplicationContext _context;

    public DeletePPEContractCommandHandler(ApplicationContext context) => _context = context;

    public async Task<Unit> Handle(DeletePPEContractCommand request, CancellationToken token)
    {
        var entity = await _context.PPEContract.FindAsync(
            keyValues: new object[] { request.Id },
            cancellationToken: token);

        if (entity is null) return Unit.Value;

        _context.PPEContract.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken: token);

        return Unit.Value;
    }
}