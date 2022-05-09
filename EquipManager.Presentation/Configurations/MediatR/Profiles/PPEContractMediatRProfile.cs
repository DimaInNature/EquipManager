namespace EquipManager.Presentation.Configurations.MediatR.Profiles;

internal static class PPEContractMediatRProfile
{
    public static void AddPPEContractMediatRProfile(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(nameof(services));

        #region Queries

        // Get PPEContract by Id

        services.AddScoped<IRequest<PPEContract?>, GetPPEContractByIdQuery>();
        services.AddScoped<IRequestHandler<GetPPEContractByIdQuery, PPEContract?>, GetPPEContractByIdQueryHandler>();

        // Get List<PPEContract>

        services.AddScoped<IRequest<List<PPEContract>?>, GetPPEContractListQuery>();
        services.AddScoped<IRequestHandler<GetPPEContractListQuery, List<PPEContract>?>, GetPPEContractListQueryHandler>();

        #endregion

        #region Commands

        // Create

        services.AddScoped<IRequest, CreatePPEContractCommand>();
        services.AddScoped<IRequestHandler<CreatePPEContractCommand, Unit>, CreatePPEContractCommandHandler>();

        // Update

        services.AddScoped<IRequest, UpdatePPEContractCommand>();
        services.AddScoped<IRequestHandler<UpdatePPEContractCommand, Unit>, UpdatePPEContractCommandHandler>();

        // Delete by Id

        services.AddScoped<IRequest, DeletePPEContractCommand>();
        services.AddScoped<IRequestHandler<DeletePPEContractCommand, Unit>, DeletePPEContractCommandHandler>();

        #endregion
    }
}