namespace EquipManager.Services.Features.EmployeeSizeCharts;

public sealed record class UpdateEmployeeSizeChartCommand : IRequest
{
    public EmployeeSizeChart? SizeChart { get; init; }

    public UpdateEmployeeSizeChartCommand(EmployeeSizeChart entity) => SizeChart = entity;

    public UpdateEmployeeSizeChartCommand() { }
}