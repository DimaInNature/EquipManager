namespace EquipManager.Services.Data.Features.PPEContractBodies;

public sealed class UpdateContractBodyCommandHandler
    : IRequestHandler<UpdateContractBodyCommand>
{
    private readonly ApplicationContext _context;

    public UpdateContractBodyCommandHandler(ApplicationContext context) => _context = context;

    public async Task<Unit> Handle(UpdateContractBodyCommand request, CancellationToken token)
    {
        if (request.ContractBody is null) return Unit.Value;

        var entity = await _context.PPEContractBody.FindAsync(
            keyValues: new object[] { request.ContractBody.Id },
            cancellationToken: token);

        if (entity is null) return Unit.Value;

        entity.Id = request.ContractBody.Id;
        entity.PPE1Id = request.ContractBody.PPE1Id;
        entity.PPE2Id = request.ContractBody.PPE2Id;
        entity.PPE3Id = request.ContractBody.PPE3Id;
        entity.PPE4Id = request.ContractBody.PPE4Id;
        entity.PPE5Id = request.ContractBody.PPE5Id;
        entity.PPE6Id = request.ContractBody.PPE6Id;
        entity.PPE7Id = request.ContractBody.PPE7Id;
        entity.PPE8Id = request.ContractBody.PPE8Id;
        entity.PPE9Id = request.ContractBody.PPE9Id;
        entity.PPE10Id = request.ContractBody.PPE10Id;
        entity.PPE11Id = request.ContractBody.PPE11Id;
        entity.PPE12Id = request.ContractBody.PPE12Id;

        await _context.SaveChangesAsync(cancellationToken: token);

        return Unit.Value;
    }
}