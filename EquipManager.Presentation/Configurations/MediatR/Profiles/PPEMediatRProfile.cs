namespace EquipManager.Presentation.Configurations.MediatR.Profiles;

internal static class PPEMediatRProfile
{
    public static void AddPPEMediatRProfile(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(nameof(services));

        #region Queries

        // Get PPE by Id

        services.AddScoped<IRequest<PPE?>, GetPPEByIdQuery>();
        services.AddScoped<IRequestHandler<GetPPEByIdQuery, PPE?>, GetPPEByIdQueryHandler>();

        // Get List<PPE>

        services.AddScoped<IRequest<List<PPE>?>, GetPPEListQuery>();
        services.AddScoped<IRequestHandler<GetPPEListQuery, List<PPE>?>, GetPPEListQueryHandler>();

        #endregion

        #region Commands

        // Create

        services.AddScoped<IRequest, CreatePPECommand>();
        services.AddScoped<IRequestHandler<CreatePPECommand, Unit>, CreatePPECommandHandler>();

        // Update

        services.AddScoped<IRequest, UpdatePPECommand>();
        services.AddScoped<IRequestHandler<UpdatePPECommand, Unit>, UpdatePPECommandHandler>();

        // Delete by Id

        services.AddScoped<IRequest, DeletePPECommand>();
        services.AddScoped<IRequestHandler<DeletePPECommand, Unit>, DeletePPECommandHandler>();

        #endregion
    }
}