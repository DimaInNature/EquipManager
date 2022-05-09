namespace EquipManager.Domain.Models;

/// <summary> Договор выдачи С.И.З. </summary>
public class PPEContract : IDomainModel
{
    /// <summary> Идентификатор. </summary>
    public int Id { get; set; }

    /// <summary> Идентификатор сотрудника, на которого был оформлен договор. </summary>
    public int EmployeeId { get; set; }

    /// <summary> Сотрудник, на которого был оформлен договор. </summary>
    /// <remarks>Реализация Lazy Loading.</remarks>
    [ForeignKey("EmployeeId")]
    public virtual Employee? Employee { get; set; }

    /// <summary> Идентификатор тела договора.</summary>
    public int PPEContractBodyId { get; set; }

    /// <summary> Тело договора.</summary>
    /// <remarks>Реализация Lazy Loading.</remarks>
    [ForeignKey("PPEContractBodyId")]
    public virtual PPEContractBody? PPEContractBody { get; set; }

    /// <summary> Получить объект класса, реализующий паттерн Builder. </summary>
    /// <returns>Возвращает объект порождающего класса <see cref="PPEContractBuilder"/>.</returns>
    public static PPEContractBuilder GetBuilder() => new();
}