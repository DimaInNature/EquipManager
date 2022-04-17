namespace EquipManager.Infra.Data.Context.Profiles;

internal static class PersonalProtectiveEquipmentProfile
{
    public static void AddPPEsProfile(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PPE>()
            .HasIndex(entity => entity.Id)
            .IsUnique();

        modelBuilder.Entity<PPE>()
            .HasData(data: GetPPEs());
    }

    private static List<PPE> GetPPEs() => new();
}