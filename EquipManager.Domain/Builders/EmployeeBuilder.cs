namespace EquipManager.Domain.Builders;

/// <summary> Порождающий класс для <see cref="Employee"/>.</summary>
/// <remarks>Реализует порождающий паттерн Builder.</remarks>
public class EmployeeBuilder
{
    private readonly Employee _employee = new();

    /// <summary> Установить имя, фамилию и отчество. </summary>
    /// <remarks>Данный метод является частью конвейера порождающего класса.
    /// <para>Устанавливает <see cref="Employee.Name"/>,
    /// <see cref="Employee.Surname"/> и <see cref="Employee.Patronymic"/>.</para>
    /// </remarks>
    /// <param name="name">Имя сотрудника.</param>
    /// <param name="surname">Фамилия сотрудника.</param>
    /// <param name="patronymic">Отчество сотрудника.</param>
    /// <returns>Возвращает вызывающий метод объект <see cref="EmployeeBuilder"/>.</returns>
    public EmployeeBuilder SetFullName(string name, string surname, string patronymic)
    {
        _employee.Name = name;
        _employee.Surname = surname;
        _employee.Patronymic = patronymic;

        return this;
    }

    /// <summary> Задать профессию. </summary>
    /// <remarks>Данный метод является частью конвейера порождающего класса.
    /// <para>Устанавливает <see cref="Employee.Profession"/></para></remarks>
    /// <param name="profession">Имя сотрудника.</param>
    /// <returns>Возвращает вызывающий метод объект <see cref="EmployeeBuilder"/>.</returns>
    public EmployeeBuilder SetProfession(string profession)
    {
        _employee.Profession = profession;

        return this;
    }

    /// <summary> Задать структурное подразделение.</summary>
    /// <remarks>Данный метод является частью конвейера порождающего класса.
    /// <para>Устанавливает <see cref="Employee.StructuralDivision"/></para></remarks>
    /// <param name="structuralDivision">Структурное подразделение.</param>
    /// <returns>Возвращает вызывающий метод объект <see cref="EmployeeBuilder"/>.</returns>
    public EmployeeBuilder SetStructuralDivision(string structuralDivision)
    {
        _employee.StructuralDivision = structuralDivision;

        return this;
    }

    /// <summary> Установить рост.</summary>
    /// <remarks>Данный метод является частью конвейера порождающего класса.
    /// <para>Устанавливает <see cref="Employee.Height"/>, 
    /// если входной параметр попадает в допустимый диапазон.</para>
    /// <para>В противном случае устанавливается минимальное значение диапазона.</para>
    /// </remarks>
    /// <param name="height">Рост сотрудника.</param>
    /// <value>Диапазон: min - 150, max - 220. Значения выражены в сантиметрах.</value>
    /// <returns>Возвращает вызывающий метод объект <see cref="EmployeeBuilder"/>.</returns>
    public EmployeeBuilder SetHeight(int? height)
    {
        _employee.Height = height < 150 || height > 220 ? 150 : height ?? 150;

        return this;
    }

    /// <summary> Задать пол. </summary>
    /// <remarks>Данный метод является частью конвейера порождающего класса.</remarks>
    /// <param name="gender">Рост сотрудника.</param>
    /// <returns>Возвращает вызывающий метод объект <see cref="EmployeeBuilder"/>.</returns>
    public EmployeeBuilder SetGender(string gender)
    {
        _employee.Gender = gender;

        return this;
    }

    /// <summary> Задать дату приёма на работу.</summary>
    /// <remarks>Данный метод является частью конвейера порождающего класса.
    /// <para>Устанавливает <see cref="Employee.DateOfEmployment"/></para></remarks>
    /// <param name="date">Дата приёма на работу.</param>
    /// <returns>Возвращает вызывающий метод объект <see cref="EmployeeBuilder"/>.</returns>
    public EmployeeBuilder SetDateOfEmployment(DateTime? date)
    {
        _employee.DateOfEmployment = date ?? DateTime.UtcNow;

        return this;
    }

    /// <summary> Задать дату последней смены должности.</summary>
    /// <remarks>Данный метод является частью конвейера порождающего класса.
    /// <para>Устанавливает <see cref="Employee.DateOfProfessionChange"/></para></remarks>
    /// <param name="date">Дата последней смены должности.</param>
    /// <returns>Возвращает вызывающий метод объект <see cref="EmployeeBuilder"/>.</returns>
    public EmployeeBuilder SetDateOfProfessionChange(DateTime? date)
    {
        _employee.DateOfProfessionChange = date ?? DateTime.UtcNow;

        return this;
    }

    /// <summary> Добавить таблицу с размерами экипировки. </summary>
    /// <remarks>Данный метод является частью конвейера порождающего класса.</remarks>
    /// <param name="gender">Рост сотрудника.</param>
    /// <returns>Возвращает вызывающий метод объект <see cref="EmployeeBuilder"/>.</returns>
    /// <value>Параметр <paramref name="id"/> является внешним ключом <see cref="EmployeeSizeChart"/></value>
    public EmployeeBuilder AddSizeChart(int id)
    {
        _employee.EmployeeSizeChartId = id;

        return this;
    }

    /// <summary> Завершает создание объекта. </summary>
    /// <returns>Созданный объект <see cref="Employee"/>.</returns>
    public Employee Build() => _employee;
}