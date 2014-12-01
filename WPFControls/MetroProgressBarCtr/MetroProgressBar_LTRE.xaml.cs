using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFControls.MetroProgressBarCtr
{
    /// <summary>
    /// MetroProgressBar_LTRE.xaml 的交互逻辑
    /// 实现圆形小球从左到右的滑动效果的滚动条
    /// </summary>
    public partial class MetroProgressBar_LTRE : UserControl
    {
        public MetroProgressBar_LTRE()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        static MetroProgressBar_LTRE()
        {
            //Set Ellipse Fill Color
            EllipseFillColor_1Property =
                DependencyProperty.Register("EllipseFillColor_1", typeof(Brush), typeof(MetroProgressBar_LTRE), new PropertyMetadata(Brushes.Black));
            EllipseFillColor_2Property =
                DependencyProperty.Register("EllipseFillColor_2", typeof(Brush), typeof(MetroProgressBar_LTRE), new PropertyMetadata(Brushes.Black));
            EllipseFillColor_3Property =
                DependencyProperty.Register("EllipseFillColor_3", typeof(Brush), typeof(MetroProgressBar_LTRE), new PropertyMetadata(Brushes.Black));
            EllipseFillColor_4Property =
                DependencyProperty.Register("EllipseFillColor_4", typeof(Brush), typeof(MetroProgressBar_LTRE), new PropertyMetadata(Brushes.Black));
            //Set Ellipse Size
            EllipseHeightProperty =
                DependencyProperty.Register("EllipseHeight", typeof(double),
                typeof(MetroProgressBar_LTRE),
                new PropertyMetadata(5D));
            EllipseWidthProperty =
                DependencyProperty.Register("EllipseWidth", typeof(double),
                typeof(MetroProgressBar_LTRE),
                new FrameworkPropertyMetadata(5D, new PropertyChangedCallback(OnEllipseWidthChanged)));
            //Set Ellipse Spacing
            EllipseSpacingProperty =
                DependencyProperty.Register("EllipseSpacing", typeof(double),
                typeof(MetroProgressBar_LTRE),
                new FrameworkPropertyMetadata(5D, new PropertyChangedCallback(OnEllipseSpacingChanged)));
            EllipseLeftMargin_1Property =
                DependencyProperty.Register("EllipseLeftMargin_1", typeof(Thickness),
                typeof(MetroProgressBar_LTRE), new PropertyMetadata(new Thickness(0, 0, 0, 0)));//30, 0, 0, 0)));
            EllipseLeftMargin_2Property =
                DependencyProperty.Register("EllipseLeftMargin_2", typeof(Thickness),
                typeof(MetroProgressBar_LTRE), new PropertyMetadata(new Thickness(0, 0, 0, 0)));//20, 0, 0, 0)));
            EllipseLeftMargin_3Property =
                DependencyProperty.Register("EllipseLeftMargin_3", typeof(Thickness),
                typeof(MetroProgressBar_LTRE), new PropertyMetadata(new Thickness(0, 0, 0, 0)));//10, 0, 0, 0)));
            EllipseLeftMargin_4Property =
                DependencyProperty.Register("EllipseLeftMargin_4", typeof(Thickness),
                typeof(MetroProgressBar_LTRE), new PropertyMetadata(new Thickness(0, 0, 0, 0)));
            //Set Converter Parameter
            MarginConvertRatio_StartProperty =
                DependencyProperty.Register("MarginConvertRatio_Start", typeof(double),
                typeof(MetroProgressBar_LTRE), new PropertyMetadata(0.0));//12));
            MarginConvertRatio_MiddleLeftProperty =
                DependencyProperty.Register("MarginConvertRatio_MiddleLeft", typeof(double),
                typeof(MetroProgressBar_LTRE), new PropertyMetadata(0.44));
            MarginConvertRatio_MiddleRightProperty =
                DependencyProperty.Register("MarginConvertRatio_MiddleRight", typeof(double),
                typeof(MetroProgressBar_LTRE), new PropertyMetadata(0.56));
            MarginConvertRatio_EndProperty =
                DependencyProperty.Register("MarginConvertRatio_End", typeof(double),
                typeof(MetroProgressBar_LTRE), new PropertyMetadata(1.0));
        }

        #region Fields

        /// <summary>
        /// 时间间隔，单位：秒
        /// </summary>
        private double _timeInterval = 0.5D;

        #endregion End Fields

        #region Attributes

        /// <summary>
        /// 时间间隔，单位：秒（默认为 0.5 秒）
        /// </summary>
        [Description("时间间隔，单位：秒（默认为 0.5 秒）")]
        [Browsable(true)]
        public double TimeInterval
        {
            get
            {
                return this._timeInterval;
            }
            set
            {
                //间隔不能小于0
                if (value >= 0)
                {
                    this._timeInterval = value;
                }
            }
        }

        #region Set Ellipse Margin Convert Ratio

        public static readonly DependencyProperty MarginConvertRatio_StartProperty;
        public static readonly DependencyProperty MarginConvertRatio_MiddleLeftProperty;
        public static readonly DependencyProperty MarginConvertRatio_MiddleRightProperty;
        public static readonly DependencyProperty MarginConvertRatio_EndProperty;

        /// <summary>
        /// 获取边距格式转换系数：起点位置
        /// </summary>
        public double MarginConvertRatio_Start
        {
            get { return (double)GetValue(MarginConvertRatio_StartProperty); }
            private set { SetValue(MarginConvertRatio_StartProperty, value); }
        }
        /// <summary>
        /// 获取边距格式转换系数：中左位置
        /// </summary>
        public double MarginConvertRatio_MiddleLeft
        {
            get { return (double)GetValue(MarginConvertRatio_MiddleLeftProperty); }
            private set { SetValue(MarginConvertRatio_MiddleLeftProperty, value); }
        }
        /// <summary>
        /// 获取边距格式转换系数：中右位置
        /// </summary>
        public double MarginConvertRatio_MiddleRight
        {
            get { return (double)GetValue(MarginConvertRatio_MiddleRightProperty); }
            private set { SetValue(MarginConvertRatio_MiddleRightProperty, value); }
        }
        /// <summary>
        /// 获取边距格式转换系数：终点位置
        /// </summary>
        public double MarginConvertRatio_End
        {
            get { return (double)GetValue(MarginConvertRatio_EndProperty); }
            private set { SetValue(MarginConvertRatio_EndProperty, value); }
        }

        #endregion End Set Ellipse Margin Convert Ratio

        #region Set Ellipse Fill Color

        public static readonly DependencyProperty EllipseFillColor_1Property;
        public static readonly DependencyProperty EllipseFillColor_2Property;
        public static readonly DependencyProperty EllipseFillColor_3Property;
        public static readonly DependencyProperty EllipseFillColor_4Property;

        /// <summary>
        /// 获取或设置 圆1 的填充色
        /// </summary>
        [Description("获取或设置 圆1 的填充色（默认为 黑色）")]
        [Browsable(true)]
        public Brush EllipseFillColor_1
        {
            get
            {
                return (Brush)GetValue(EllipseFillColor_1Property);
            }
            set
            {
                SetValue(EllipseFillColor_1Property, value);
            }
        }
        /// <summary>
        /// 获取或设置 圆2 的填充色
        /// </summary>
        [Description("获取或设置 圆2 的填充色（默认为 黑色）")]
        [Browsable(true)]
        public Brush EllipseFillColor_2
        {
            get
            {
                return (Brush)GetValue(EllipseFillColor_2Property);
            }
            set
            {
                SetValue(EllipseFillColor_2Property, value);
            }
        }
        /// <summary>
        /// 获取或设置 圆3 的填充色
        /// </summary>
        [Description("获取或设置 圆3 的填充色（默认为 黑色）")]
        [Browsable(true)]
        public Brush EllipseFillColor_3
        {
            get
            {
                return (Brush)GetValue(EllipseFillColor_3Property);
            }
            set
            {
                SetValue(EllipseFillColor_3Property, value);
            }
        }
        /// <summary>
        /// 获取或设置 圆4 的填充色
        /// </summary>
        [Description("获取或设置 圆4 的填充色（默认为 黑色）")]
        [Browsable(true)]
        public Brush EllipseFillColor_4
        {
            get
            {
                return (Brush)GetValue(EllipseFillColor_4Property);
            }
            set
            {
                SetValue(EllipseFillColor_4Property, value);
            }
        }

        #endregion End Set Ellipse Fill Color

        #region Set Ellipse Size

        public static readonly DependencyProperty EllipseHeightProperty;
        public static readonly DependencyProperty EllipseWidthProperty;

        /// <summary>
        /// 获取或设置 圆 的高度
        /// </summary>
        [Description("获取或设置 圆 的高度（默认为 5）")]
        [Browsable(true)]
        public double EllipseHeight
        {
            get { return (double)GetValue(EllipseHeightProperty); }
            set { SetValue(EllipseHeightProperty, value); }
        }

        /// <summary>
        /// 获取或设置 圆 的宽度
        /// </summary>
        [Description("获取或设置 圆 的宽度（默认为 5）")]
        [Browsable(true)]
        public double EllipseWidth
        {
            get { return (double)GetValue(EllipseWidthProperty); }
            set { SetValue(EllipseWidthProperty, value); }
        }

        #endregion End Ellipse Size

        #region Set Ellipse Spacing

        public static readonly DependencyProperty EllipseSpacingProperty;
        public static readonly DependencyProperty EllipseLeftMargin_1Property;
        public static readonly DependencyProperty EllipseLeftMargin_2Property;
        public static readonly DependencyProperty EllipseLeftMargin_3Property;
        public static readonly DependencyProperty EllipseLeftMargin_4Property;

        /// <summary>
        /// 获取或设置 圆 之间的间距
        /// </summary>
        [Description("获取或设置 圆 之间的间距（默认为 5）")]
        [Browsable(true)]
        public double EllipseSpacing
        {
            get { return (double)GetValue(EllipseSpacingProperty); }
            set { SetValue(EllipseSpacingProperty, value); }
        }

        /// <summary>
        /// 获取 圆1 的左边距
        /// </summary>
        public Thickness EllipseLeftMargin_1
        {
            get { return (Thickness)GetValue(EllipseLeftMargin_1Property); }
            private set { SetValue(EllipseLeftMargin_1Property, value); }
        }

        /// <summary>
        /// 获取 圆2 的左边距
        /// </summary>
        public Thickness EllipseLeftMargin_2
        {
            get { return (Thickness)GetValue(EllipseLeftMargin_2Property); }
            private set { SetValue(EllipseLeftMargin_2Property, value); }
        }

        /// <summary>
        /// 获取 圆3 的左边距
        /// </summary>
        public Thickness EllipseLeftMargin_3
        {
            get { return (Thickness)GetValue(EllipseLeftMargin_3Property); }
            private set { SetValue(EllipseLeftMargin_3Property, value); }
        }

        /// <summary>
        /// 获取 圆4 的左边距
        /// </summary>
        public Thickness EllipseLeftMargin_4
        {
            get { return (Thickness)GetValue(EllipseLeftMargin_4Property); }
            private set { SetValue(EllipseLeftMargin_4Property, value); }
        }

        #endregion End Set Ellipse Spacing

        #endregion End Attributes

        #region Args

        private static void OnEllipseWidthChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            MetroProgressBar_LTRE mProgressBar = (MetroProgressBar_LTRE)sender;

            //注意：当前还没有控件的 ActualWidth 值
            mProgressBar.MarginConvertRatio_Start = 0D;
            //(mProgressBar.EllipseWidth * 4 + mProgressBar.EllipseSpacing * 3) / mProgressBar.ActualWidth;
            mProgressBar.MarginConvertRatio_MiddleLeft =
                (mProgressBar.ActualWidth - mProgressBar.EllipseWidth * 4 - mProgressBar.EllipseSpacing * 3) / 2 / mProgressBar.ActualWidth;
            mProgressBar.MarginConvertRatio_MiddleRight =
                (mProgressBar.ActualWidth + mProgressBar.EllipseWidth * 4 + mProgressBar.EllipseSpacing * 3) / 2 / mProgressBar.ActualWidth;
            mProgressBar.MarginConvertRatio_End = 1D;
        }

        private static void OnEllipseSpacingChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            MetroProgressBar_LTRE mProgressBar = (MetroProgressBar_LTRE)sender;

            double ellipseLeftMargin_1 = 0D;// ((double)e.NewValue + mProgressBar.EllipseWidth) * 3;
            double ellipseLeftMargin_2 = 0D; //((double)e.NewValue + mProgressBar.EllipseWidth) * 2;
            double ellipseLeftMargin_3 = 0D;// (double)e.NewValue + mProgressBar.EllipseWidth;
            double ellipseLeftMargin_4 = 0D;

            mProgressBar.EllipseLeftMargin_1 = new Thickness(ellipseLeftMargin_1, 0, 0, 0);
            mProgressBar.EllipseLeftMargin_2 = new Thickness(ellipseLeftMargin_2, 0, 0, 0);
            mProgressBar.EllipseLeftMargin_3 = new Thickness(ellipseLeftMargin_3, 0, 0, 0);
            mProgressBar.EllipseLeftMargin_4 = new Thickness(ellipseLeftMargin_4, 0, 0, 0);

            //OnEllipseWidthChanged(sender, e);
        }

        #endregion End Args

        private void metroProgressBar_SizeChanged(object sender, SizeChangedEventArgs e)
        {
        }

    }
}
