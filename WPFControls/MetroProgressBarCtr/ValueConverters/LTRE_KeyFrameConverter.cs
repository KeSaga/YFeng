using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Media.Animation;

namespace WPFControls.MetroProgressBarCtr.ValueConverters
{
    /// <summary>
    /// MetroProgressBar_LTRE 的边距转换类
    /// </summary>
    [ValueConversion(typeof(double), typeof(KeyTime))]
    public class LTRE_KeyFrameConverter : IValueConverter
    {
        /// <summary>
        /// 根据时间间隔和系数计算延迟时间
        /// </summary>
        /// <param name="value">时间间隔</param>
        /// <param name="targetType"></param>
        /// <param name="parameter">系数，必须大于 0</param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            KeyTime kTime = KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(0));
            double timeInterval = (double)value;
            double ratio = 0D;
            Double.TryParse(parameter.ToString(), out ratio);

            if (ratio < 0)
                throw new Exception("系数必须为大于 0");

            kTime = KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(timeInterval * ratio * 1000));

            return kTime;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new Exception("The method or operation is not implemented.");
        }

    }
}
