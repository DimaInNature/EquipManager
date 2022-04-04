namespace EquipManager.Domain.Models;

public class Employee : IDomainModel
{
    public int Id { get; set; }

    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Profession { get; set; }
    public string? StructuralDivision { get; set; }

    public int TabelNumber { get; set; }
    public int Height { get; set; }
    public EmployeeGender Gender { get; set; }

    public int SizeChartId { get; set; }
    public virtual EmployeeSizeChart? SizeChart { get; set; }
}