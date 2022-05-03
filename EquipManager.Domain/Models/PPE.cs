namespace EquipManager.Domain.Models;

/// <summary> Средство индивидуальной защиты (С.И.З.).</summary>
public class PPE : IDomainModel
{
    public int Id { get; set; }

    public string Name
    {
        get => _name ?? string.Empty;
        set => _name = value;
    }

    public string UnitOfMeasurement
    {
        get => _unitOfMeasurement ?? string.Empty;
        set => _unitOfMeasurement = value;
    }

    public string CertificateOfConformity
    {
        get => _certificateOfConformity ?? string.Empty;
        set => _certificateOfConformity = value;
    }

    public int QuantityPerYear { get; set; }

    /// <summary> Получить объект класса, реализующий паттерн Builder. </summary>
    /// <returns>Возвращает объект порождающего класса <see cref="PPEBuilder"/>.</returns>
    public static PPEBuilder GetBuilder() => new();

    private string? _name;
    private string? _unitOfMeasurement;
    private string? _certificateOfConformity;
}