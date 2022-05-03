namespace EquipManager.Services.Data.Features.EmployeeSizeCharts;

public sealed record class DeleteEmployeeSizeChartCommandHandler
    : IRequestHandler<DeleteEmployeeSizeChartCommand>
{
    private readonly ApplicationContext _context;

    public DeleteEmployeeSizeChartCommandHandler(ApplicationContext context) => _context = context;

    public async Task<Unit> Handle(DeleteEmployeeSizeChartCommand request, CancellationToken token)
    {
        var entity = await _context.EmployeeSizeCharts.FindAsync(
            keyValues: new object[] { request.Id },
            cancellationToken: token);

        if (entity is null) return Unit.Value;

        _context.EmployeeSizeCharts.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken: token);

        return Unit.Value;
    }
}