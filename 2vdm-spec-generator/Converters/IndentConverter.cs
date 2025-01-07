using System.Globalization;
using Microsoft.Maui.Controls;
using System.IO;

namespace _2vdm_spec_generator.Converters
{
    public class IndentConverter : IMultiValueConverter
    {
        public object? Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length == 2 && values[0] is string fullPath && values[1] is string rootPath)
            {
                // fullPathとrootPathが一致している場合はインデントを0とする
                if (string.Equals(fullPath, rootPath, StringComparison.OrdinalIgnoreCase))
                {
                    return new Thickness(0, 0, 0, 0);
                }

                // ルートパスからの相対パスを計算
                var relativePath = fullPath.Substring(rootPath.Length).TrimStart(Path.DirectorySeparatorChar);

                // 相対パスが空でない場合、深さを1増やす（ルート直下のアイテムにインデントを適用）
                int depth = relativePath.Length > 0 ? relativePath.Count(c => c == Path.DirectorySeparatorChar) + 1 : 0;

                return new Thickness(20 * depth, 0, 0, 0);
            }
            return new Thickness(0);
        }

        public object[] ConvertBack(object value, Type[] targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}