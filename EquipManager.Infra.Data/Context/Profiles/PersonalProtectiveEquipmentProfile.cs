namespace EquipManager.Infra.Data.Context.Profiles;

internal static class PersonalProtectiveEquipmentProfile
{
    public static void AddPersonalProtectiveEquipmentProfile(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PersonalProtectiveEquipmentEntity>()
            .HasIndex(entity => entity.Id)
            .IsUnique();

        modelBuilder.Entity<PersonalProtectiveEquipmentEntity>()
            .HasData(data: GetPersonalProtectiveEquipments());
    }

    private static List<PersonalProtectiveEquipmentEntity> GetPersonalProtectiveEquipments() => new();
}