namespace EquipManager.Presentation.Configurations;

internal static class DatabaseConfiguration
{
    public static void AddDatabaseConfiguration(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(nameof(services));

        services.AddDbContext<ApplicationContext>(options =>
        {
            options.UseLazyLoadingProxies();
            options.UseSqlite(connectionString: "Data Source=EquipManagerDB");
        });
    }
}