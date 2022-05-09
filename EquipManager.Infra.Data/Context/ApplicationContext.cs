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

    /// <summary> Договор выдачи С.И.З.</summary>
    public DbSet<PPEContract> PPEContract => Set<PPEContract>();

    /// <summary> Тело договора выдачи С.И.З.</summary>
    public DbSet<PPEContractBody> PPEContractBody => Set<PPEContractBody>();

    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options) => Database.EnsureCreated();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.AddEmployeeProfile();

        modelBuilder.AddEmployeeSizeChartProfile();

        modelBuilder.AddPPEsProfile();

        modelBuilder.AddPPEContractProfile();

        modelBuilder.AddPPEContractBodyProfile();

        base.OnModelCreating(modelBuilder);
    }
}