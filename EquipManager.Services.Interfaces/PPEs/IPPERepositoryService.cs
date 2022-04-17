namespace EquipManager.Services.Interfaces.PPEs;

public interface IPPERepositoryService
{
    Task<List<PPE>?> GetPPEListAsync();
    Task<PPE?> GetPPEAsync(int id);
    Task CreateAsync(PPE entity);
    Task UpdateAsync(PPE entity);
    Task DeleteAsync(int id);
}