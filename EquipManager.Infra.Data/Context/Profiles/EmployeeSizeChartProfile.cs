namespace EquipManager.Infra.Data.Context.Profiles;

internal static class EmployeeSizeChartProfile
{
    public static void AddEmployeeSizeChartProfile(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EmployeeSizeChart>()
            .HasIndex(entity => entity.Id)
            .IsUnique();

        modelBuilder.Entity<EmployeeSizeChart>()
            .HasData(data: GetEmployeeSizeCharts());
    }

    private static List<EmployeeSizeChart> GetEmployeeSizeCharts() => new();
}