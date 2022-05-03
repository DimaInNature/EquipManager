namespace EquipManager.Services.Data.Features.PPEs;

public sealed record class CreatePPECommandHandler
    : IRequestHandler<CreatePPECommand>
{
    private readonly ApplicationContext _context;

    public CreatePPECommandHandler(ApplicationContext context) => _context = context;

    public async Task<Unit> Handle(CreatePPECommand request, CancellationToken token)
    {
        if (request.PPE is null) return Unit.Value;

        await _context.PPEs.AddAsync(
            entity: request.PPE,
            cancellationToken: token);

        await _context.SaveChangesAsync(cancellationToken: token);

        return Unit.Value;
    }
}