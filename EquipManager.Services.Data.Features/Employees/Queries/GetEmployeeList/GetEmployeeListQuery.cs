namespace EquipManager.Services.Data.Features.Employees;

public sealed record class GetEmployeeListQuery : IRequest<List<Employee>?> { }