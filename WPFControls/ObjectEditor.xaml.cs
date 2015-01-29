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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFControls.UIDataEntity;

namespace WPFControls
{
    /// <summary>
    /// ObjectEditor.xaml 的交互逻辑
    /// </summary>
    public partial class ObjectEditor : UserControl
    {
        public ObjectEditor()
        {
            InitializeComponent();

            this.DataContext = this;
        }

        static ObjectEditor()
        {
            TextBlockTitleProperty =
                DependencyProperty.Register("ObjectTitle", typeof(string), typeof(ObjectEditor), new PropertyMetadata(string.Empty));
            BoxBackgroundProperty =
                DependencyProperty.Register("BoxBackground", typeof(Brush), typeof(ObjectEditor), new PropertyMetadata(Brushes.White));
        }

        #region 属性

        private List<EditeObject> _editeObjects = new List<EditeObject>();
        /// <summary>
        /// 用于做为编辑器的数据源的对象集合
        /// </summary>
        public List<EditeObject> EditeObjects { get { return this._editeObjects; } set { this._editeObjects = value; } }

        /// <summary>
        /// 标题
        /// </summary>
        [Description("标题")]
        [Browsable(true)]
        public string ObjectTitle
        {
            get { return (string)GetValue(TextBlockTitleProperty); }
            set { SetValue(TextBlockTitleProperty, value); }
        }
        /// <summary>
        /// 标题 的依赖项属性
        /// </summary>
        public static readonly DependencyProperty TextBlockTitleProperty;

        /// <summary>
        /// 列表框的背景色
        /// </summary>
        [Description("列表框的背景色")]
        [Browsable(true)]
        public Brush BoxBackground
        {
            get { return (Brush)GetValue(BoxBackgroundProperty); }
            set { SetValue(BoxBackgroundProperty, value); }
        }
        /// <summary>
        /// 列表框的背景色 的依赖项属性
        /// </summary>
        public static readonly DependencyProperty BoxBackgroundProperty;

        //---------------以上是依赖项属性的定义----------------------

        /// <summary>
        /// 获取或设置列表框的选择行为
        /// </summary>
        [Description("获取或设置列表框的选择行为")]
        [Browsable(true)]
        public SelectionMode SelectionMode
        {
            get { return this.ltBoxObject.SelectionMode; }
            set { this.ltBoxObject.SelectionMode = value; }
        }

        #endregion End 属性

        #region Public Methods

        #endregion End Public Methods

        #region Private Methods

        private void DeleteSelectedItems()
        {
            try
            {
                var selectedItems = this.ltBoxObject.SelectedItems;
                foreach (object itm in selectedItems)
                {
                    this.ltBoxObject.Items.Remove(itm);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void LoadData()
        {
            this.ltBoxObject.ItemsSource = this._editeObjects;
        }

        #endregion End Private Methods

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            //TODO:后续需要实现 搜索 功能
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            this.grdEdit.Visibility = Visibility.Visible;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            this.DeleteSelectedItems();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            //TODO:后续实现 完成添加新项 的逻辑

            //成功添加新项后，隐藏添加界面
            this.grdEdit.Visibility = Visibility.Collapsed;
        }

        private void objEditor_Loaded(object sender, RoutedEventArgs e)
        {
            //必须在此处加载数据，原因：在控件构造函数初始化时还未能读取为控件属性设置的值
            this.LoadData();
        }

    }
}
