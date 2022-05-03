namespace EquipManager.Services.Data.Features.Employees;

public sealed record class CreateEmployeeCommand : IRequest
{
    public Employee? Employee { get; init; }

    public CreateEmployeeCommand(Employee entity) => Employee = entity;

    public CreateEmployeeCommand() { }
}