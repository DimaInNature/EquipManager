namespace EquipManager.Domain.Builders;

/// <summary> Порождающий класс для <see cref="EmployeeSizeChart"/>.</summary>
/// <remarks>Реализует порождающий паттерн Builder.</remarks>
public class EmployeeSizeChartBuilder
{
    private readonly EmployeeSizeChart _sizeChart = new();

    /// <summary> Задать размер одежды.</summary>
    /// <remarks>Данный метод является частью конвейера порождающего класса.
    /// <para>Устанавливает <see cref="EmployeeSizeChart.Cloth"/>, 
    /// если входной параметр попадает в допустимый диапазон.</para>
    /// <para>В противном случае <see langword="null"/>.</para>
    /// </remarks>
    /// <param name="size">Размер одежды.</param>
    /// <value>Диапазон: min - 40, max - 58.</value>
    /// <returns>Возвращает вызывающий метод объект <see cref="EmployeeSizeChartBuilder"/>.</returns>
    public EmployeeSizeChartBuilder AddCloth(int? size)
    {
        if (size >= 40 && size <= 58)
            _sizeChart.Cloth = size;

        return this;
    }

    /// <summary> Задать размер противогаза.</summary>
    /// <remarks>Данный метод является частью конвейера порождающего класса.
    /// <para>Устанавливает <see cref="EmployeeSizeChart.GazMask"/>, 
    /// если входной параметр попадает в допустимый диапазон.</para>
    /// <para>В противном случае <see langword="null"/>.</para>
    /// </remarks>
    /// <param name="size">Размер противогаза.</param>
    /// <value>Диапазон: min - 0, max - 4.</value>
    /// <returns>Возвращает вызывающий метод объект <see cref="EmployeeSizeChartBuilder"/>.</returns>
    public EmployeeSizeChartBuilder AddGazMask(int? size)
    {
        if (size >= 0 && size <= 4)
            _sizeChart.GazMask = size;

        return this;
    }

    /// <summary> Задать размер маски - респиратора.</summary>
    /// <remarks>Данный метод является частью конвейера порождающего класса.
    /// <para>Устанавливает <see cref="EmployeeSizeChart.Respirator"/>, 
    /// если входной параметр попадает в допустимый диапазон.</para>
    /// <para>В противном случае <see langword="null"/>.</para>
    /// </remarks>
    /// <param name="size">Размер маски - респиратора.</param>
    /// <value>Диапазон: min - 1, max - 3.</value>
    /// <returns>Возвращает вызывающий метод объект <see cref="EmployeeSizeChartBuilder"/>.</returns>
    public EmployeeSizeChartBuilder AddRespirator(int? size)
    {
        if (size >= 1 && size <= 3)
            _sizeChart.Respirator = size;

        return this;
    }

    /// <summary> Задать размер обуви.</summary>
    /// <remarks>Данный метод является частью конвейера порождающего класса.
    /// <para>Устанавливает <see cref="EmployeeSizeChart.Shoes"/>, если входной параметр попадает в допустимый диапазон.</para>
    /// <para>В противном случае <see langword="null"/>.</para>
    /// </remarks>
    /// <param name="size">Размер обуви.</param>
    /// <value>Диапазон: min - 38, max - 50.</value>
    /// <returns>Возвращает вызывающий метод объект <see cref="EmployeeSizeChartBuilder"/>.</returns>
    public EmployeeSizeChartBuilder AddShoesSize(int? size)
    {
        if (size >= 38 && size <= 50)
            _sizeChart.Shoes = size;

        return this;
    }

    /// <summary> Задать размер рукавиц.</summary>
    /// <remarks>Данный метод является частью конвейера порождающего класса.
    /// <para>Устанавливает <see cref="EmployeeSizeChart.Sleeve"/>, если входной параметр попадает в допустимый диапазон.</para>
    /// <para>В противном случае <see langword="null"/>.</para>
    /// </remarks>
    /// <param name="size">Размер рукавиц.</param>
    /// <value>Диапазон: min - 6, max - 9.</value>
    /// <returns>Возвращает вызывающий метод объект <see cref="EmployeeSizeChartBuilder"/>.</returns>
    public EmployeeSizeChartBuilder AddSleeve(int? size)
    {
        if (size >= 6 && size <= 9)
            _sizeChart.Sleeve = size;

        return this;
    }

    /// <summary> Задать размер головного убора.</summary>
    /// <remarks>Данный метод является частью конвейера порождающего класса.
    /// <para>Устанавливает <see cref="EmployeeSizeChart.Headdress"/>, если входной параметр попадает в допустимый диапазон.</para>
    /// <para>В противном случае <see langword="null"/>.</para>
    /// </remarks>
    /// <param name="size">Размер головного убора.</param>
    /// <value>Диапазон: min - 54, max - 65.</value>
    /// <returns>Возвращает вызывающий метод объект <see cref="EmployeeSizeChartBuilder"/>.</returns>
    public EmployeeSizeChartBuilder AddHeaddress(int? headdressSize)
    {
        if (headdressSize >= 54 && headdressSize <= 65)
            _sizeChart.Headdress = headdressSize;

        return this;
    }

    /// <summary> Задать размер перчаток.</summary>
    /// <remarks>Данный метод является частью конвейера порождающего класса.
    /// <para>Устанавливает <see cref="EmployeeSizeChart.Glove"/>, если входной параметр попадает в допустимый диапазон.</para>
    /// <para>В противном случае <see langword="null"/>.</para>
    /// </remarks>
    /// <param name="size">Размер перчаток.</param>
    /// <value>Диапазон: min - 6, max - 12.</value>
    /// <returns>Возвращает вызывающий метод объект <see cref="EmployeeSizeChartBuilder"/>.</returns>
    public EmployeeSizeChartBuilder AddGlove(int? size)
    {
        if (size >= 6 && size <= 12)
            _sizeChart.Glove = size;

        return this;
    }

    /// <summary> Завершает создание объекта. </summary>
    /// <returns>Созданный объект <see cref="EmployeeSizeChart"/>.</returns>
    public EmployeeSizeChart Build() => _sizeChart;
}