namespace EquipManager.Domain.Models;

/// <summary> Тело договора выдачи С.И.З. </summary>
public class PPEContractBody : IDomainModel
{
    /// <summary> Идентификатор. </summary>
    public int Id { get; set; }

    [ForeignKey("PPE1Id")]
    public virtual PPE? PPE1 { get; set; }

    public int? PPE1Id { get; set; }

    [ForeignKey("PPE2Id")]
    public virtual PPE? PPE2 { get; set; }

    public int? PPE2Id { get; set; }

    [ForeignKey("PPE3Id")]
    public virtual PPE? PPE3 { get; set; }

    public int? PPE3Id { get; set; }

    [ForeignKey("PPE4Id")]
    public virtual PPE? PPE4 { get; set; }

    public int? PPE4Id { get; set; }

    [ForeignKey("PPE5Id")]
    public virtual PPE? PPE5 { get; set; }

    public int? PPE5Id { get; set; }

    [ForeignKey("PPE6Id")]
    public virtual PPE? PPE6 { get; set; }

    public int? PPE6Id { get; set; }

    [ForeignKey("PPE7Id")]
    public virtual PPE? PPE7 { get; set; }

    public int? PPE7Id { get; set; }

    [ForeignKey("PPE8Id")]
    public virtual PPE? PPE8 { get; set; }

    public int? PPE8Id { get; set; }

    [ForeignKey("PPE9Id")]
    public virtual PPE? PPE9 { get; set; }

    public int? PPE9Id { get; set; }

    [ForeignKey("PPE10Id")]
    public virtual PPE? PPE10 { get; set; }

    public int? PPE10Id { get; set; }

    [ForeignKey("PPE11Id")]
    public virtual PPE? PPE11 { get; set; }

    public int? PPE11Id { get; set; }

    [ForeignKey("PPE12Id")]
    public virtual PPE? PPE12 { get; set; }

    public int? PPE12Id { get; set; }

    /// <summary> Получить объект класса, реализующий паттерн Builder. </summary>
    /// <returns>Возвращает объект порождающего класса <see cref="PPEContractBodyBuilder"/>.</returns>
    public static PPEContractBodyBuilder GetBuilder() => new();
}