namespace EquipManager.Infra.Data.Context.Profiles;

internal static class EmployeeSizeChartProfile
{
    public static void AddEmployeeSizeChartProfile(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EmployeeSizeChartEntity>()
            .HasIndex(entity => entity.Id)
            .IsUnique();

        modelBuilder.Entity<EmployeeSizeChartEntity>()
            .HasData(data: GetEmployeeSizeCharts());
    }

    private static List<EmployeeSizeChartEntity> GetEmployeeSizeCharts() => new();
}