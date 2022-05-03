namespace EquipManager.Services.Data.Features.Employees;

public sealed record class UpdateEmployeeCommand : IRequest
{
    public Employee? Employee { get; init; }

    public UpdateEmployeeCommand(Employee entity) => Employee = entity;

    public UpdateEmployeeCommand() { }
}