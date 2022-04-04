namespace EquipManager.Infra.Data.Context.Profiles;

internal static class EmployeeProfile
{
    public static void AddEmployeeProfile(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EmployeeEntity>()
            .HasIndex(entity => entity.Id)
            .IsUnique();

        modelBuilder.Entity<EmployeeEntity>()
            .HasData(data: GetEmployees());
    }

    private static List<EmployeeEntity> GetEmployees() => new();
}