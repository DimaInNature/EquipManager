namespace EquipManager.Services.Data.Features.PPEs;

public sealed record class UpdatePPECommandHandler
    : IRequestHandler<UpdatePPECommand>
{
    private readonly ApplicationContext _context;

    public UpdatePPECommandHandler(ApplicationContext context) => _context = context;

    public async Task<Unit> Handle(UpdatePPECommand request, CancellationToken token)
    {
        if (request.PPE is null) return Unit.Value;

        var entity = await _context.PPEs.FindAsync(
            keyValues: new object[] { request.PPE.Id },
            cancellationToken: token);

        if (entity is null) return Unit.Value;

        entity.Id = request.PPE.Id;
        entity.Name = request.PPE.Name;
        entity.UnitOfMeasurement = request.PPE.UnitOfMeasurement;
        entity.CertificateOfConformity = request.PPE.CertificateOfConformity;
        entity.QuantityPerYear = request.PPE.QuantityPerYear;

        await _context.SaveChangesAsync(cancellationToken: token);

        return Unit.Value;
    }
}