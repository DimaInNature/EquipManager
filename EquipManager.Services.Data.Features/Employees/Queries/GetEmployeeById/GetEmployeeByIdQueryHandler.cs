namespace EquipManager.Services.Data.Features.Employees;

public sealed record class GetEmployeeByIdQueryHandler
    : IRequestHandler<GetEmployeeByIdQuery, Employee?>
{
    private readonly ApplicationContext _context;

    public GetEmployeeByIdQueryHandler(ApplicationContext context) => _context = context;

    public async Task<Employee?> Handle(GetEmployeeByIdQuery request, CancellationToken token) =>
        await _context.Employees.FindAsync(
            keyValues: new object[] { request.Id },
            cancellationToken: token);
}