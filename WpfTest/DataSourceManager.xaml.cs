using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPFControls.UIDataEntity;

namespace WpfTest
{
    /// <summary>
    /// DataSourceManager.xaml 的交互逻辑
    /// </summary>
    public partial class DataSourceManager : Window
    {
        public DataSourceManager()
        {
            InitializeComponent();
            this.objEditorDataSource.EditeObjects = new List<EditeObject>()
            {
                new EditeObject()
                {
                    ObjectName="测试对象1",
                    Description="测试描述1",
                    IsEditable=true
                }
            };
        }
    }
}
