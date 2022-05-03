namespace EquipManager.Services.Data.Features.Employees;

public sealed record class GetEmployeeByIdQuery
    : IRequest<Employee?>
{
    public int Id { get; init; }

    public GetEmployeeByIdQuery(int id) => Id = id;

    public GetEmployeeByIdQuery() { }
}