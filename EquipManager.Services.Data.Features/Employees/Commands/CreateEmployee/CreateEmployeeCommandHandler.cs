namespace EquipManager.Services.Data.Features.Employees;

public sealed record class CreateEmployeeCommandHandler
    : IRequestHandler<CreateEmployeeCommand>
{
    private readonly ApplicationContext _context;

    public CreateEmployeeCommandHandler(ApplicationContext context) => _context = context;

    public async Task<Unit> Handle(CreateEmployeeCommand request, CancellationToken token)
    {
        if (request.Employee is null) return Unit.Value;

        await _context.Employees.AddAsync(
            entity: request.Employee,
            cancellationToken: token);

        await _context.SaveChangesAsync(cancellationToken: token);

        return Unit.Value;
    }
}