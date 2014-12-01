using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace WPFControls.MetroProgressBarCtr.ValueConverters
{
    /// <summary>
    /// MetroProgressBar_LTRE 的边距转换类
    /// </summary>
    [ValueConversion(typeof(double[]), typeof(Thickness))]
    public class LTRE_MarginConverter : IMultiValueConverter
    {
        /// <summary>
        /// 根据控件宽度和指定系数计算球的左边距
        /// </summary>
        /// <param name="values">{控件宽度，系数，必须大于 0 且小于 1}</param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            Thickness theMargin = new Thickness(0, 0, 0, 0);
            if (values.Length == 2 && values[0] is double && values[1] is double)
            {
                double ctrWidth = 0D;
                double ratio = 0D;
                Double.TryParse(values[0].ToString(), out ctrWidth);
                Double.TryParse(values[1].ToString(), out ratio);

                if (ratio < 0 || ratio > 1)
                    throw new Exception("系数必须为大于 0 且小于 1 的任何小数");

                theMargin.Left = ctrWidth * ratio;
            }
            else if (values.Length == 1 && values[0] is Thickness)
            {
                theMargin = (Thickness)values[0];
            }

            return theMargin;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new object[] { value };
        }

    }
}
