namespace EquipManager.Services.Data.Features.PPEContracts;

public sealed class UpdatePPEContractCommandHandler
    : IRequestHandler<UpdatePPEContractCommand>
{
    private readonly ApplicationContext _context;

    public UpdatePPEContractCommandHandler(ApplicationContext context) => _context = context;

    public async Task<Unit> Handle(UpdatePPEContractCommand request, CancellationToken token)
    {
        if (request.PPEContract is null) return Unit.Value;

        var entity = await _context.PPEContract.FindAsync(
            keyValues: new object[] { request.PPEContract.Id },
            cancellationToken: token);

        if (entity is null) return Unit.Value;

        entity.Id = request.PPEContract.Id;
        entity.EmployeeId = request.PPEContract.EmployeeId;
        entity.PPEContractBodyId = request.PPEContract.PPEContractBodyId;

        await _context.SaveChangesAsync(cancellationToken: token);

        return Unit.Value;
    }
}