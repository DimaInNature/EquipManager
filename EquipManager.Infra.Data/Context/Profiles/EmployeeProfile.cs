namespace EquipManager.Infra.Data.Context.Profiles;

internal static class EmployeeProfile
{
    public static void AddEmployeeProfile(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>()
            .HasIndex(entity => entity.Id)
            .IsUnique();

        modelBuilder.Entity<Employee>()
            .HasData(data: GetEmployees());
    }

    private static List<Employee> GetEmployees() => new();
}