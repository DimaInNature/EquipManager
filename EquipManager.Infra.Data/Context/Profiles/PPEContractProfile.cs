namespace EquipManager.Infra.Data.Context.Profiles;

internal static class PPEContractProfile
{
    public static void AddPPEContractProfile(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PPEContract>()
            .HasIndex(entity => entity.Id)
            .IsUnique();

        modelBuilder.Entity<PPEContract>()
            .HasData(data: GetPPEContracts());
    }

    private static List<PPEContract> GetPPEContracts() => new();
}