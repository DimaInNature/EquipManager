namespace EquipManager.Presentation.Configurations.MediatR;

internal static class MediatRConfiguration
{
    public static void AddMediatRConfiguration(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(nameof(services));

        services.AddMediatR(assemblies: Assembly.GetExecutingAssembly());

        // Add features: ...

        services.AddEmployeeMediatRProfile();

        services.AddEmployeeSizeChartMediatRProfile();

        services.AddPPEMediatRProfile();

        services.AddPPEContractMediatRProfile();

        services.AddPPEContractBodyMediatRProfile();
    }
}