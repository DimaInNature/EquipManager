namespace EquipManager.Presentation.Configurations.MediatR.Profiles;

internal static class PPEContractBodyMediatRProfile
{
    public static void AddPPEContractBodyMediatRProfile(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(nameof(services));

        #region Commands

        // Create

        services.AddScoped<IRequest, CreateContractBodyCommand>();
        services.AddScoped<IRequestHandler<CreateContractBodyCommand, Unit>, CreateContractBodyCommandHandler>();

        // Update

        services.AddScoped<IRequest, UpdateContractBodyCommand>();
        services.AddScoped<IRequestHandler<UpdateContractBodyCommand, Unit>, UpdateContractBodyCommandHandler>();

        // Delete by Id

        services.AddScoped<IRequest, DeleteContractBodyCommand>();
        services.AddScoped<IRequestHandler<DeleteContractBodyCommand, Unit>, DeleteContractBodyCommandHandler>();

        #endregion
    }
}