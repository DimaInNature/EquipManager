namespace EquipManager.Services.Data.Features.PPEContractBodies;

public sealed class DeleteContractBodyCommandHandler
    : IRequestHandler<DeleteContractBodyCommand>
{
    private readonly ApplicationContext _context;

    public DeleteContractBodyCommandHandler(ApplicationContext context) => _context = context;

    public async Task<Unit> Handle(DeleteContractBodyCommand request, CancellationToken token)
    {
        var entity = await _context.PPEContractBody.FindAsync(
            keyValues: new object[] { request.Id },
            cancellationToken: token);

        if (entity is null) return Unit.Value;

        _context.PPEContractBody.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken: token);

        return Unit.Value;
    }
}