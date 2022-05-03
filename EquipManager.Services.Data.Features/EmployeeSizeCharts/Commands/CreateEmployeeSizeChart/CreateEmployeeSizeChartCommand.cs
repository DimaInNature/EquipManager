namespace EquipManager.Services.Data.Features.EmployeeSizeCharts;

public sealed record class CreateEmployeeSizeChartCommand : IRequest
{
    public EmployeeSizeChart? SizeChart { get; init; }

    public CreateEmployeeSizeChartCommand(EmployeeSizeChart entity) => SizeChart = entity;

    public CreateEmployeeSizeChartCommand() { }
}