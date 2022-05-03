namespace EquipManager.Services.Data.Features.PPEs;

public sealed record class DeletePPECommandHandler
    : IRequestHandler<DeletePPECommand>
{
    private readonly ApplicationContext _context;

    public DeletePPECommandHandler(ApplicationContext context) => _context = context;

    public async Task<Unit> Handle(DeletePPECommand request, CancellationToken token)
    {
        var entity = await _context.PPEs.FindAsync(
            keyValues: new object[] { request.Id },
            cancellationToken: token);

        if (entity is null) return Unit.Value;

        _context.PPEs.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken: token);

        return Unit.Value;
    }
}