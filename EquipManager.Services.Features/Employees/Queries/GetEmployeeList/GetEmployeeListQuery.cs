namespace EquipManager.Services.Features.Employees;

public sealed record class GetEmployeeListQuery : IRequest<List<Employee>?> { }