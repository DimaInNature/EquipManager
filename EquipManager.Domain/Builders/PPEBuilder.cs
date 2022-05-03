namespace EquipManager.Domain.Builders;

/// <summary> Порождающий класс для <see cref="PPE"/>.</summary>
/// <remarks>Реализует порождающий паттерн Builder.</remarks>
public class PPEBuilder
{
    private readonly PPE _ppe = new();

    /// <summary> Установить название.</summary>
    /// <remarks>Данный метод является частью конвейера порождающего класса.
    /// <para>Устанавливает <see cref="PPE.Name"/></para>
    /// </remarks>
    /// <param name="name">Название</param>
    /// <returns>Возвращает вызывающий метод объект <see cref="PPEBuilder"/>.</returns>
    public PPEBuilder SetName(string name)
    {
        _ppe.Name = name;

        return this;
    }

    /// <summary> Установить единицу измерения.</summary>
    /// <remarks>Данный метод является частью конвейера порождающего класса.
    /// <para>Устанавливает <see cref="PPE.UnitOfMeasurement."/></para>
    /// </remarks>
    /// <param name="unitOfMeasurement">Единица измерения.</param>
    /// <returns>Возвращает вызывающий метод объект <see cref="PPEBuilder"/>.</returns>
    public PPEBuilder SetUnitOfMeasurement(string unitOfMeasurement)
    {
        _ppe.UnitOfMeasurement = unitOfMeasurement;

        return this;
    }

    /// <summary> Установить сертификат соответствия.</summary>
    /// <remarks>Данный метод является частью конвейера порождающего класса.
    /// <para>Устанавливает <see cref="PPE.CertificateOfConformity"/></para>
    /// </remarks>
    /// <param name="certificateOfConformity">Сертификат соответствия.</param>
    /// <returns>Возвращает вызывающий метод объект <see cref="PPEBuilder"/>.</returns>
    public PPEBuilder SetCertificateOfConformity(string certificateOfConformity)
    {
        _ppe.CertificateOfConformity = certificateOfConformity;

        return this;
    }

    /// <summary> Установить количество СИЗ в год.</summary>
    /// <remarks>Данный метод является частью конвейера порождающего класса.
    /// <para>Устанавливает <see cref="PPE.QuantityPerYear"/>, 
    /// если входной параметр попадает в допустимый диапазон.</para>
    /// <para>В противном случае устанавливается минимальное значение диапазона.</para>
    /// </remarks>
    /// <param name="quantity">Количество в год.</param>
    /// <value>Диапазон: min - 0.</value>
    /// <returns>Возвращает вызывающий метод объект <see cref="PPEBuilder"/>.</returns>
    public PPEBuilder SetQuantityPerYear(int? quantity)
    {
        _ppe.QuantityPerYear = quantity < 0 ? 0 : quantity ?? 0;

        return this;
    }

    /// <summary>Завершает создание объекта. </summary>
    /// <returns>Созданный объект <see cref="PPE"/>.</returns>
    public PPE Build() => _ppe;
}