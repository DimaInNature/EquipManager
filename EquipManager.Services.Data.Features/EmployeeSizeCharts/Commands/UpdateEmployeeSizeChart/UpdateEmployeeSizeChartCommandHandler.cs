namespace EquipManager.Services.Data.Features.EmployeeSizeCharts;

public sealed record class UpdateEmployeeSizeChartCommandHandler
    : IRequestHandler<UpdateEmployeeSizeChartCommand>
{
    private readonly ApplicationContext _context;

    public UpdateEmployeeSizeChartCommandHandler(ApplicationContext context) => _context = context;

    public async Task<Unit> Handle(UpdateEmployeeSizeChartCommand request, CancellationToken token)
    {
        if (request.SizeChart is null) return Unit.Value;

        var entity = await _context.EmployeeSizeCharts.FindAsync(
            keyValues: new object[] { request.SizeChart.Id },
            cancellationToken: token);

        if (entity is null) return Unit.Value;

        entity.Id = request.SizeChart.Id;
        entity.Cloth = request.SizeChart.Cloth;
        entity.Headdress = request.SizeChart.Headdress;
        entity.GazMask = request.SizeChart.GazMask;
        entity.Respirator = request.SizeChart.Respirator;
        entity.Sleeve = request.SizeChart.Sleeve;
        entity.Glove = request.SizeChart.Glove;
        entity.Shoes = request.SizeChart.Shoes;

        await _context.SaveChangesAsync(cancellationToken: token);

        return Unit.Value;
    }
}