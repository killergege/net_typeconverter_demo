using System.ComponentModel;
using System.Globalization;

namespace WebApplication2.Converters;

public class DateOnlyTypeConverter : TypeConverter
{
    public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType)
    {
        return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
    }

    public override bool CanConvertTo(ITypeDescriptorContext? context, Type? destinationType)
    {
        return destinationType == typeof(string);
    }

    public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
    {
        return DateOnly.FromDateTime(DateTimeOffset.Parse((string)value).Date);
    }

    public override object? ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value,
        Type destinationType)
    {
        return ((DateOnly?)value)?.ToString("O");
    }
}