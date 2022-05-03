namespace EquipManager.Infra.Core.Extensions.Arrays;

public static class NullableIntegerArrayExtensions
{
    /// <summary> Указывает, что все элементы массива являются положительными числами.</summary>
    /// <returns><see langword="true"/> если все элементы <paramref name="numbers"/> являются положительными.</returns>
    public static bool IsPositive(this int?[] numbers) =>
        numbers.All(number => number > -1);
}