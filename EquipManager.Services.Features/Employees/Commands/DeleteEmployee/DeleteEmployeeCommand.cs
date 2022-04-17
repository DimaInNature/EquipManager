namespace EquipManager.Services.Features.Employees;

public sealed record class DeleteEmployeeCommand : IRequest
{
    public int Id { get; init; }

    public DeleteEmployeeCommand(int id) => Id = id;

    public DeleteEmployeeCommand() { }
}