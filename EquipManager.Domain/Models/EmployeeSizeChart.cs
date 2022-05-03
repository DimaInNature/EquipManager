namespace EquipManager.Domain.Models;

/// <summary> Таблица с размерами экипировки сотрудника. </summary>
public class EmployeeSizeChart : IDomainModel
{
    /// <summary> Идентификатор. </summary>
    public int Id { get; set; }

    /// <summary> Размер одежды. </summary>
    public int? Cloth { get; set; }

    /// <summary> Размер головного убора. </summary>
    public int? Headdress { get; set; }

    /// <summary> Размер противогаза. </summary>
    public int? GazMask { get; set; }

    /// <summary> Размер маски - респиратора. </summary>
    public int? Respirator { get; set; }

    /// <summary> Размер рукавиц. </summary>
    public int? Sleeve { get; set; }

    /// <summary> Размер перчаток. </summary>
    public int? Glove { get; set; }

    /// <summary> Размер обуви. </summary>
    public int? Shoes { get; set; }

    /// <summary> Получить объект класса, реализующий паттерн Builder. </summary>
    /// <returns>Возвращает объект порождающего класса <see cref="EmployeeSizeChartBuilder"/>.</returns>
    public static EmployeeSizeChartBuilder GetBuilder() => new();
}