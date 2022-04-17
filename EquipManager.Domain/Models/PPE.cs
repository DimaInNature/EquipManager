namespace EquipManager.Domain.Models;

/// <summary> Personal Protective Enviroment </summary>

public class PPE : IDomainModel
{
    public int Id { get; set; }

    public string? Name { get; set; }
    public string? UnitOfMeasurement { get; set; }
    public string? CertificateOfConformity { get; set; }

    public int QuantityPerYear { get; set; }
}