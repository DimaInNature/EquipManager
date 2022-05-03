namespace EquipManager.Services.Data.Features.Employees;

public sealed record class UpdateEmployeeCommandHandler
    : IRequestHandler<UpdateEmployeeCommand>
{
    private readonly ApplicationContext _context;

    public UpdateEmployeeCommandHandler(ApplicationContext context) => _context = context;

    public async Task<Unit> Handle(UpdateEmployeeCommand request, CancellationToken token)
    {
        if (request.Employee is null) return Unit.Value;

        var entity = await _context.Employees.FindAsync(
            keyValues: new object[] { request.Employee.Id },
            cancellationToken: token);

        if (entity is null) return Unit.Value;

        entity.Id = request.Employee.Id;
        entity.Name = request.Employee.Name;
        entity.Surname = request.Employee.Surname;
        entity.Profession = request.Employee.Profession;
        entity.StructuralDivision = request.Employee.StructuralDivision;
        entity.Gender = request.Employee.Gender;
        entity.Height = request.Employee.Height;
        entity.EmployeeSizeChartId = request.Employee.EmployeeSizeChartId;

        await _context.SaveChangesAsync(cancellationToken: token);

        return Unit.Value;
    }
}