﻿namespace EquipManager.Services.Features.EmployeeSizeCharts;

public sealed record class CreateEmployeeSizeChartCommand : IRequest
{
    public EmployeeSizeChart? SizeChart { get; init; }

    public CreateEmployeeSizeChartCommand(EmployeeSizeChart sizeChart) => SizeChart = sizeChart;

    public CreateEmployeeSizeChartCommand() { }
}