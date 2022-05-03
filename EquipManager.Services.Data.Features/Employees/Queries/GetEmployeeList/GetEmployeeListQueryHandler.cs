namespace EquipManager.Services.Data.Features.Employees;

public sealed record class GetEmployeeListQueryHandler
    : IRequestHandler<GetEmployeeListQuery, List<Employee>?>
{
    private readonly ApplicationContext _context;

    public GetEmployeeListQueryHandler(ApplicationContext context) => _context = context;

    public async Task<List<Employee>?> Handle(GetEmployeeListQuery request, CancellationToken token) =>
        await _context.Employees.ToListAsync(cancellationToken: token);
}