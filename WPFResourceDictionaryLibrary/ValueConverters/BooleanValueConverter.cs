using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace WPFResourceDictionaryLibrary.ValueConverters
{
    /// <summary>
    /// 布尔值 与其他类型值的转换
    /// </summary>
    [ValueConversion(typeof(bool), typeof(Visibility))]
    public class BooleanValueConverter : IValueConverter
    {
        /// <summary>
        /// 将 Boolean 类型值转为指定类型值，如果失败则返回 FallbackValue 指定的结果
        /// </summary>
        /// <param name="value">bool 类型的绑定源生成的值</param>
        /// <param name="targetType">目标类型</param>
        /// <param name="parameter">指定类型值的参数，如果不能成功转换，则返回 FallbackValue 指定的结果</param>
        /// <param name="culture">要用在转换器中的区域性</param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value)
            {
                return parameter;
            }
            else
            {
                return DependencyProperty.UnsetValue;
            }
        }

        /// <summary>
        /// 将指定类型值还原为 Boolean 类型值
        /// </summary>
        /// <param name="value">指定的类型的值</param>
        /// <param name="targetType">Boolean 类型的目标类型</param>
        /// <param name="parameter">指定类型值的参数</param>
        /// <param name="culture">要用在转换器中的区域性</param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return object.Equals(value, parameter);
        }
    }
}
