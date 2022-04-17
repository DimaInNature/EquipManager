namespace EquipManager.Infra.Data.Context;

public sealed class ApplicationContext : DbContext
{
    public DbSet<Employee> Employees => Set<Employee>();

    public DbSet<EmployeeSizeChart> EmployeeSizeCharts => Set<EmployeeSizeChart>();

    public DbSet<PPE> PPEs => Set<PPE>();

    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options) => Database.EnsureCreated();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.AddEmployeeProfile();

        modelBuilder.AddEmployeeSizeChartProfile();

        modelBuilder.AddPPEsProfile();

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       => base.OnConfiguring(optionsBuilder);
}