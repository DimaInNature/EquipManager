namespace EquipManager.Domain.Builders;

/// <summary> Порождающий класс для <see cref="PPEContract"/>.</summary>
/// <remarks>Реализует порождающий паттерн Builder.</remarks>
public class PPEContractBuilder
{
    private readonly PPEContract _ppeContract = new();

    /// <summary> Добавить тело договора. </summary>
    /// <remarks>Данный метод является частью конвейера порождающего класса.</remarks>
    /// <returns>Возвращает вызывающий метод объект <see cref="PPEContractBuilder"/>.</returns>
    /// <value>Параметр <paramref name="id"/> является внешним ключом <see cref="PPEContractBody"/>.</value>
    public PPEContractBuilder AddContractBody(int id)
    {
        _ppeContract.PPEContractBodyId = id;

        return this;
    }

    /// <summary> Добавить сотрудника, на которого оформляется договор. </summary>
    /// <remarks>Данный метод является частью конвейера порождающего класса.</remarks>
    /// <returns>Возвращает вызывающий метод объект <see cref="PPEContractBuilder"/>.</returns>
    /// <value>Параметр <paramref name="id"/> является внешним ключом <see cref="Employee"/>.</value>
    public PPEContractBuilder AddEmployee(int id)
    {
        _ppeContract.EmployeeId = id;

        return this;
    }

    /// <summary>Завершает создание объекта. </summary>
    /// <returns>Созданный объект <see cref="PPEContract"/>.</returns>
    public PPEContract Build() => _ppeContract;
}