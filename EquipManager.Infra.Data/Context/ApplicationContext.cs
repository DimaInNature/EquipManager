namespace EquipManager.Infra.Data.Context;

/// <summary> Контекст данных.</summary>
public sealed class ApplicationContext : DbContext
{
    /// <summary> Сотрудники.</summary>
    public DbSet<Employee> Employees => Set<Employee>();

    /// <summary> Таблица с размерами сотрудника.</summary>
    public DbSet<EmployeeSizeChart> EmployeeSizeCharts => Set<EmployeeSizeChart>();

    /// <summary> Средство индивидуальной защиты (С.И.З.).</summary>
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
}