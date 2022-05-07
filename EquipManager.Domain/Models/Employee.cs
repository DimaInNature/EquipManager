namespace EquipManager.Domain.Models;

/// <summary> Сотрудник. </summary>
public class Employee : IDomainModel
{
    /// <summary> Идентификатор. </summary>
    /// <remarks>Является также уникальным табельным номером.</remarks>
    public int Id { get; set; }

    /// <summary> Имя сотрудника. </summary>
    public string Name
    {
        get => _name ?? string.Empty;
        set => _name = value;
    }

    /// <summary> Фамилия сотрудника. </summary>
    public string Surname
    {
        get => _surname ?? string.Empty;
        set => _surname = value;
    }

    /// <summary> Отчество сотрудника. </summary>
    public string Patronymic
    {
        get => _patronymic ?? string.Empty;
        set => _patronymic = value;
    }

    /// <summary> Профессия сотрудника. </summary>
    public string Profession
    {
        get => _profession ?? string.Empty;
        set => _profession = value;
    }

    /// <summary> Структурное подразделение. </summary>
    public string StructuralDivision
    {
        get => _structuralDivision ?? string.Empty;
        set => _structuralDivision = value;
    }

    /// <summary> Рост сотрудника (в см). </summary>
    public int Height { get; set; }

    /// <summary> Пол сотрудника. </summary>
    public string Gender
    {
        get => _gender ?? string.Empty;
        set => _gender = value;
    }

    /// <summary> Дата приёма на работу. </summary>
    public DateTime DateOfEmployment { get; set; } = DateTime.UtcNow;

    /// <summary> Дата последней смены должности. </summary>
    public DateTime DateOfProfessionChange { get; set; } = DateTime.UtcNow;

    /// <summary> Номер таблицы с размерами экипировки сотрудника.</summary>
    public int EmployeeSizeChartId { get; set; }

    /// <summary> Таблица с размерами экипировки сотрудника.</summary>
    /// <remarks>Реализация Lazy Loading.</remarks>
    [ForeignKey("EmployeeSizeChartId")]
    public virtual EmployeeSizeChart? EmployeeSizeChart { get; set; }

    /// <summary> Получить объект класса, реализующий паттерн Builder. </summary>
    /// <returns>Возвращает объект порождающего класса <see cref="EmployeeBuilder"/>.</returns>
    public static EmployeeBuilder GetBuilder() => new();

    private string? _name;

    private string? _surname;

    private string? _patronymic;

    private string? _profession;

    private string? _structuralDivision;

    private string? _gender;
}