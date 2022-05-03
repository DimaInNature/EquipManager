namespace EquipManager.Services.Data.Features.EmployeeSizeCharts;

public sealed record class DeleteEmployeeSizeChartCommand : IRequest
{
    public int Id { get; init; }

    public DeleteEmployeeSizeChartCommand(int id) => Id = id;

    public DeleteEmployeeSizeChartCommand() { }
}