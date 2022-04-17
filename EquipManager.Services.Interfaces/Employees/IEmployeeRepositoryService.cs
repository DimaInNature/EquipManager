namespace EquipManager.Services.Interfaces;

public interface IEmployeeRepositoryService
{
    Task<List<Employee>?> GetEmployeeListAsync();
    Task<Employee?> GetEmployeeAsync(int id);
    Task CreateAsync(Employee entity);
    Task UpdateAsync(Employee entity);
    Task DeleteAsync(int id);
}