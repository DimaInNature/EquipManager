namespace EquipManager.Presentation.Converters;

/// <summary> Конвертертирует входные данные таким образом,
/// что допускаются к записи только целые числа.</summary>
internal sealed class OnlyDigitConverter : IValueConverter
{
    public object Convert(object value, Type targetType,
        object parameter, CultureInfo culture) => value;

    public object? ConvertBack(object value, Type targetType,
        object parameter, CultureInfo culture) =>
        int.TryParse((string)value, out int result) ? result : null;
}