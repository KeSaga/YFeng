using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
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

namespace WPFControls.ProgressBar
{
    /// <summary>
    /// 实现进度条的控件
    /// </summary>
    public partial class ProgressBar : UserControl
    {
        public ProgressBar()
        {
            InitializeComponent();

            InitializationProgressBar();
        }

        /// <summary>
        /// Register Dependency Property
        /// </summary>
        static ProgressBar()
        {
            //Register Ellipse Fill Color
            EllipseFillColorProperty =
                DependencyProperty.Register("EllipseFillColor",
                typeof(Brush),
                typeof(ProgressBar),
                new PropertyMetadata(Brushes.Black));
            //Register Ellipse Size
            EllipseHeightProperty =
                DependencyProperty.Register("EllipseHeight",
                typeof(double),
                typeof(ProgressBar),
                new PropertyMetadata(3D));
            EllipseWidthProperty =
                DependencyProperty.Register("EllipseWidth",
                typeof(double),
                typeof(ProgressBar),
                new PropertyMetadata(3D));
        }

        #region Fields

        /// <summary>
        /// 圆球某一位置的X坐标的系数——起点
        /// </summary>
        private const double XRatio_Start = 0d;
        /// <summary>
        /// 圆球某一位置的X坐标的系数——中左
        /// </summary>
        private const double XRatio_MiddleLeft = 0.4;
        /// <summary>
        /// 圆球某一位置的X坐标的系数——中右
        /// </summary>
        private const double XRatio_MiddleRight = 0.6;
        /// <summary>
        /// 圆球某一位置的X坐标的系数——终点
        /// </summary>
        private const double XRatio_End = 1d;

        /// <summary>
        /// 实现动画的故事板
        /// </summary>
        private Storyboard _storyboard = new Storyboard();

        /// <summary>
        /// 圆的集合
        /// </summary>
        private List<Ellipse> _ellipses = new List<Ellipse>();

        #endregion End Fields

        #region Attributes

        private double _timeInvterval = 0.5;
        /// <summary>
        /// 时间间隔，单位：秒（默认为 0.5 秒）
        /// </summary>
        [Description("时间间隔，单位：秒（默认为 0.5 秒）")]
        [Browsable(true)]
        public double TimeInvterval
        {
            get { return this._timeInvterval; }
            set
            {
                //小于零无意义
                if (value >= 0) this._timeInvterval = value;
            }
        }

        public static readonly DependencyProperty EllipseHeightProperty;
        /// <summary>
        /// 获取或设置 圆 的高度
        /// </summary>
        [Description("获取或设置 圆 的高度（默认为 3）")]
        [Browsable(true)]
        public double EllipseHeight
        {
            get { return (double)GetValue(EllipseHeightProperty); }
            set { SetValue(EllipseHeightProperty, value); }
        }

        public static readonly DependencyProperty EllipseWidthProperty;
        /// <summary>
        /// 获取或设置 圆 的宽度
        /// </summary>
        [Description("获取或设置 圆 的宽度（默认为 3）")]
        [Browsable(true)]
        public double EllipseWidth
        {
            get { return (double)GetValue(EllipseWidthProperty); }
            set { SetValue(EllipseWidthProperty, value); }
        }

        public static readonly DependencyProperty EllipseFillColorProperty;
        /// <summary>
        /// 获取或设置 圆 的填充色
        /// </summary>
        [Description("获取或设置 圆 的填充色（默认为 黑色）")]
        [Browsable(true)]
        public Brush EllipseFillColor
        {
            get { return (Brush)GetValue(EllipseFillColorProperty); }
            set { SetValue(EllipseFillColorProperty, value); }
        }

        #endregion End Attributes

        #region Methods

        #region Private Methods

        private void InitializationProgressBar()
        {
            this.DataContext = this;
            LoadEllipses();
        }

        /// <summary>
        /// 窗体加载完成后初始化故事板：Storyboard
        /// </summary>
        private void InitializeStoryboard()
        {
            this._storyboard.RepeatBehavior = RepeatBehavior.Forever;
            this._storyboard.Name = "ellipseStoryLeftToRight";

            double dWeight = 0d;
            foreach (Ellipse e in this._ellipses)
            {
                dWeight += 0.4;
                ThicknessAnimationUsingKeyFrames thicknessAUKF = CreateThicknessAnimationUsingKeyFrames(dWeight);

                Storyboard.SetTarget(thicknessAUKF, e);
                Storyboard.SetTargetName(thicknessAUKF, e.Name);
                Storyboard.SetTargetProperty(thicknessAUKF, new PropertyPath(Ellipse.MarginProperty));
                this._storyboard.Children.Add(thicknessAUKF);
            }
        }

        /// <summary>
        /// 生成一个 ThicknessAnimationUsingKeyFrames 对象
        /// </summary>
        /// <param name="dWeight">当前位置时间间隔系数的权重加值</param>
        /// <returns>返回一个新的 ThicknessAnimationUsingKeyFrames 对象</returns>
        private ThicknessAnimationUsingKeyFrames CreateThicknessAnimationUsingKeyFrames(double dWeight)
        {
            ThicknessAnimationUsingKeyFrames thicknessAUKF = new ThicknessAnimationUsingKeyFrames();

            thicknessAUKF.BeginTime = TimeSpan.Zero;
            string[] ellipseXNames = Enum.GetNames(typeof(ProgressBarEnum));
            foreach (string xName in ellipseXNames)
            {
                KeyValuePair<Thickness, double> thicknessDic =
                      this.GetEllipseLeftMargin((ProgressBarEnum)Enum.Parse(typeof(ProgressBarEnum), xName)).FirstOrDefault();
                Thickness ellipseLeftMargin = thicknessDic.Key;
                KeyTime kTime = this.GetKeyTime(thicknessDic.Value + dWeight);

                thicknessAUKF.KeyFrames.Add(CreateSplineThicknessKeyFrame(kTime, ellipseLeftMargin));
            }

            return thicknessAUKF;
        }

        /// <summary>
        /// 生成一个 SplineThicknessKeyFrame 对象
        /// </summary>
        /// <param name="kTime">应到达关键帧的目标 System.Windows.Media.Animation.ThicknessKeyFrame.Value 的时间</param>
        /// <param name="ellipseLeftMarginVal">关键帧的目标值</param>
        /// <returns>返回一个新的 SplineThicknessKeyFrame 对象</returns>
        private SplineThicknessKeyFrame CreateSplineThicknessKeyFrame(KeyTime kTime, Thickness ellipseLeftMarginVal)
        {
            SplineThicknessKeyFrame sThicknessKeyFrame = new SplineThicknessKeyFrame();

            sThicknessKeyFrame.KeyTime = kTime;
            sThicknessKeyFrame.Value = ellipseLeftMarginVal;

            return sThicknessKeyFrame;
        }

        /// <summary>
        /// 窗体初始化时加载 圆
        /// </summary>
        private void LoadEllipses()
        {
            this._ellipses.Clear();
            this.progressBarGrid.Children.Clear();

            Binding ellipseWidthBinding = new Binding();
            Binding ellipseHeightBinding = new Binding();
            Binding ellipseFill = new Binding();

            //Binding Width
            ellipseWidthBinding.Path = new PropertyPath("EllipseWidth");
            ellipseWidthBinding.Mode = BindingMode.TwoWay;
            //Binding Height
            ellipseHeightBinding.Path = new PropertyPath("EllipseHeight");
            ellipseHeightBinding.Mode = BindingMode.TwoWay;
            //Binding Fill
            ellipseFill.Path = new PropertyPath("EllipseFillColor");
            ellipseFill.Mode = BindingMode.TwoWay;

            for (int i = 0; i < 5; i++)
            {
                Ellipse e = new Ellipse();

                e.Name = "e" + i.ToString();
                e.Margin = this.GetEllipseLeftMargin(ProgressBarEnum.Start).First().Key;
                e.HorizontalAlignment = HorizontalAlignment.Left;
                e.SetBinding(Ellipse.WidthProperty, ellipseWidthBinding);
                e.SetBinding(Ellipse.HeightProperty, ellipseHeightBinding);
                e.SetBinding(Ellipse.FillProperty, ellipseFill);

                this._ellipses.Add(e);
                this.progressBarGrid.Children.Add(e);
            }
        }

        /// <summary>
        /// 获取圆的 Thickness 类型的左边距值
        /// </summary>
        /// <param name="xName">圆的某一位置的X坐标名称</param>
        /// <returns>返回一个 Dictionary&lt;Thickness, double&gt; 类型的左边距值与当前位置时间间隔系数的字典对象</returns>
        private Dictionary<Thickness, double> GetEllipseLeftMargin(ProgressBarEnum xName)
        {
            double x = 0d;
            double ratio = 0d;
            switch (xName)
            {
                case ProgressBarEnum.Start:
                    x = this.ActualWidth * ProgressBar.XRatio_Start;
                    ratio = 0d;
                    break;
                case ProgressBarEnum.MiddleLeft:
                    x = this.ActualWidth * ProgressBar.XRatio_MiddleLeft;
                    ratio = 1d;
                    break;
                case ProgressBarEnum.MiddleRight:
                    x = this.ActualWidth * ProgressBar.XRatio_MiddleRight;
                    ratio = 3d;
                    break;
                case ProgressBarEnum.End:
                    x = this.ActualWidth * ProgressBar.XRatio_End;
                    ratio = 4d;
                    break;
                default:
                    x = this.ActualWidth * ProgressBar.XRatio_Start;
                    ratio = 0d;
                    break;
            }
            Dictionary<Thickness, double> thicknessDic = new Dictionary<Thickness, double>();
            Thickness xTkn = new Thickness(x, 0, 0, 0);
            thicknessDic.Add(xTkn, ratio);
            return thicknessDic;
        }

        /// <summary>
        /// 获取应到达关键帧的目标 System.Windows.Media.Animation.ThicknessKeyFrame.Value 的时间
        /// </summary>
        /// <param name="timeInvtervalRatio">时间间隔系数</param>
        /// <returns></returns>
        private KeyTime GetKeyTime(double timeInvtervalRatio)
        {
            if (timeInvtervalRatio < 0)
                throw new Exception("系数必须为大于 0");

            return KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(this._timeInvterval * timeInvtervalRatio * 1000));
        }

        #endregion End Private Methods

        #endregion End Methods

        #region Envents

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //初始化故事板
            this.InitializeStoryboard();
            //启动故事板
            this._storyboard.Begin();
        }

        #endregion End Envents

    }
}
