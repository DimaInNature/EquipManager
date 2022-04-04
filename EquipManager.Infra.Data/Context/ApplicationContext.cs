namespace EquipManager.Infra.Data.Context;

public sealed class ApplicationContext : DbContext
{
    public DbSet<EmployeeEntity> Employees
        => Set<EmployeeEntity>();

    public DbSet<EmployeeSizeChartEntity> EmployeeSizeCharts
        => Set<EmployeeSizeChartEntity>();

    public DbSet<PersonalProtectiveEquipmentEntity> PersonalProtectiveEquipments
        => Set<PersonalProtectiveEquipmentEntity>();

    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options) => Database.EnsureCreated();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.AddEmployeeProfile();

        modelBuilder.AddEmployeeSizeChartProfile();

        modelBuilder.AddPersonalProtectiveEquipmentProfile();

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       => base.OnConfiguring(optionsBuilder);
}