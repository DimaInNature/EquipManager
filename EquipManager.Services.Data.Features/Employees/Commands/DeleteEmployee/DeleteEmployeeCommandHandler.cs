namespace EquipManager.Services.Data.Features.Employees;

public sealed record class DeleteEmployeeCommandHandler
    : IRequestHandler<DeleteEmployeeCommand>
{
    private readonly ApplicationContext _context;

    public DeleteEmployeeCommandHandler(ApplicationContext context) => _context = context;

    public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken token)
    {
        var entity = await _context.Employees.FindAsync(
            keyValues: new object[] { request.Id },
            cancellationToken: token);

        if (entity is null) return Unit.Value;

        _context.Employees.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken: token);

        return Unit.Value;
    }
}