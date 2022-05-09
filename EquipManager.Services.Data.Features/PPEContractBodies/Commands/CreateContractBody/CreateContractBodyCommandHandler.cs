namespace EquipManager.Services.Data.Features.PPEContractBodies;

public class CreateContractBodyCommandHandler
     : IRequestHandler<CreateContractBodyCommand>
{
    private readonly ApplicationContext _context;

    public CreateContractBodyCommandHandler(ApplicationContext context) => _context = context;

    public async Task<Unit> Handle(CreateContractBodyCommand request, CancellationToken token)
    {
        if (request.ContractBody is null) return Unit.Value;

        await _context.PPEContractBody.AddAsync(
            entity: request.ContractBody,
            cancellationToken: token);

        await _context.SaveChangesAsync(cancellationToken: token);

        return Unit.Value;
    }
}