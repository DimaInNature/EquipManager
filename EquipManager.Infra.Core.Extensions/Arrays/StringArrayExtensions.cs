namespace EquipManager.Infra.Core.Extensions.Arrays;

public static class StringArrayExtensions
{
    /// <summary> Указывает, что все элементы массива не равняются
    /// <see langword="null"/> или <see cref="string.Empty"/> и 
    /// что элементы не содержат только white-space символы.
    /// </summary>
    /// <returns><see langword="true"/> если <paramref name="strings"/> is
    /// <see langword="not null"/> or <see cref="string.Empty"/> или
    /// если какой-то из элемент содержит только white-space символы.</returns>
    public static bool IsNotNullOrWhiteSpace(this string[] strings) =>
         strings.All(stroke => string.IsNullOrWhiteSpace(stroke) is false);
}