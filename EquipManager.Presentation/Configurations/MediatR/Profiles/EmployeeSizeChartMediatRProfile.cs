namespace EquipManager.Presentation.Configurations.MediatR.Profiles;

internal static class EmployeeSizeChartMediatRProfile
{
    public static void AddEmployeeSizeChartMediatRProfile(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(nameof(services));

        #region Commands

        // Create

        services.AddScoped<IRequest, CreateEmployeeSizeChartCommand>();
        services.AddScoped<IRequestHandler<CreateEmployeeSizeChartCommand, Unit>, CreateEmployeeSizeChartCommandHandler>();

        // Update

        services.AddScoped<IRequest, UpdateEmployeeSizeChartCommand>();
        services.AddScoped<IRequestHandler<UpdateEmployeeSizeChartCommand, Unit>, UpdateEmployeeSizeChartCommandHandler>();

        // Delete by Id

        services.AddScoped<IRequest, DeleteEmployeeSizeChartCommand>();
        services.AddScoped<IRequestHandler<DeleteEmployeeSizeChartCommand, Unit>, DeleteEmployeeSizeChartCommandHandler>();

        #endregion
    }
}