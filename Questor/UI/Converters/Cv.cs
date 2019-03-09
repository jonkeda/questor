using System.Windows.Data;

namespace Questor.UI.Converters
{
    public static class Cv
    {
        public static readonly IValueConverter Boolean = new BooleanConverter();

        public static readonly IValueConverter Visibility = new VisibilityConverter();

        public static readonly IValueConverter Hidden = new HiddenConverter();

        public static readonly IValueConverter VirtualImage = new VirtualFileImageSourceConverter();
    }
}