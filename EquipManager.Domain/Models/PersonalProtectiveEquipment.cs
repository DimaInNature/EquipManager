namespace EquipManager.Domain.Models;

public class PersonalProtectiveEquipment : IDomainModel
{
    public int Id { get; set; }

    public string? Name { get; set; }
    public string? UnitOfMeasurement { get; set; }
    public string? CertificateOfConformity { get; set; }

    public int QuantityPerYear { get; set; }
}