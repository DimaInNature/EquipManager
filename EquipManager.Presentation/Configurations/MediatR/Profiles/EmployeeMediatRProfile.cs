namespace EquipManager.Presentation.Configurations.MediatR.Profiles;

internal static class EmployeeMediatRProfile
{
    public static void AddEmployeeMediatRProfile(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(nameof(services));

        #region Queries

        // Get Employee by Id

        services.AddScoped<IRequest<Employee?>, GetEmployeeByIdQuery>();
        services.AddScoped<IRequestHandler<GetEmployeeByIdQuery, Employee?>, GetEmployeeByIdQueryHandler>();

        // Get List<Employee>

        services.AddScoped<IRequest<List<Employee>?>, GetEmployeeListQuery>();
        services.AddScoped<IRequestHandler<GetEmployeeListQuery, List<Employee>?>, GetEmployeeListQueryHandler>();

        #endregion

        #region Commands

        // Create

        services.AddScoped<IRequest, CreateEmployeeCommand>();
        services.AddScoped<IRequestHandler<CreateEmployeeCommand, Unit>, CreateEmployeeCommandHandler>();

        // Update

        services.AddScoped<IRequest, UpdateEmployeeCommand>();
        services.AddScoped<IRequestHandler<UpdateEmployeeCommand, Unit>, UpdateEmployeeCommandHandler>();

        // Delete by Id

        services.AddScoped<IRequest, DeleteEmployeeCommand>();
        services.AddScoped<IRequestHandler<DeleteEmployeeCommand, Unit>, DeleteEmployeeCommandHandler>();

        #endregion
    }
}