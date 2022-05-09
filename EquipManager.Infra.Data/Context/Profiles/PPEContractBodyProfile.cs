namespace EquipManager.Infra.Data.Context.Profiles;

internal static class PPEContractBodyProfile
{
    public static void AddPPEContractBodyProfile(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PPEContractBody>()
            .HasIndex(entity => entity.Id)
            .IsUnique();

        modelBuilder.Entity<PPEContractBody>()
            .HasData(data: GetPPEContractBodies());
    }

    private static List<PPEContractBody> GetPPEContractBodies() => new();
}