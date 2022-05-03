namespace EquipManager.Services.Data.Features.EmployeeSizeCharts;

public sealed record class CreateEmployeeSizeChartCommandHandler
    : IRequestHandler<CreateEmployeeSizeChartCommand>
{
    private readonly ApplicationContext _context;

    public CreateEmployeeSizeChartCommandHandler(ApplicationContext context) => _context = context;

    public async Task<Unit> Handle(CreateEmployeeSizeChartCommand request, CancellationToken token)
    {
        if (request.SizeChart is null) return Unit.Value;

        await _context.EmployeeSizeCharts.AddAsync(
            entity: request.SizeChart,
            cancellationToken: token);

        await _context.SaveChangesAsync(cancellationToken: token);

        return Unit.Value;
    }
}