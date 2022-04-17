namespace EquipManager.Services.Interfaces.PPEs;

public interface IPPEFacadeService
{
    Task<List<PPE>?> GetPPEListAsync();
    Task<PPE?> GetPPEAsync(int id);
    Task CreateAsync(PPE entity);
    Task UpdateAsync(PPE entity);
    Task DeleteAsync(int id);
}