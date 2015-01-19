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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfTest
{
    /// <summary>
    /// ExpandLisstBoxItemTestUserCtr.xaml 的交互逻辑
    /// </summary>
    public partial class ExpandLisstBoxItemTestUserCtr : UserControl
    {
        public ExpandLisstBoxItemTestUserCtr()
        {
            InitializeComponent();

            ResourceDictionary resourceDic = new ResourceDictionary();
            resourceDic.Source = new Uri(
                "WPFControls;component/DataTemplates/ExpandListBoxItemDtTmp.xaml", UriKind.Relative);
            Style style = (Style)resourceDic["MultipleSelectedCheckBox"];
            if (style != null)
            {
                Setter st = style.Setters.FirstOrDefault() as Setter;
                if (st != null) st.Value = Visibility.Visible;
            }
            this.ltBoxDataSource.ItemTemplate = (DataTemplate)resourceDic["ExpandListBoxItemDataTemplate"];
            ResourceDictionary resourceDic1 = new ResourceDictionary();
            resourceDic1.Source = new Uri(
                "WPFControls;component/DataTemplates/ExpandListBoxItemDtTmp.xaml", UriKind.Relative);
            Style style1 = (Style)resourceDic1["MultipleSelectedCheckBox"];
            if (style1 != null)
            {
                Setter st = style1.Setters.FirstOrDefault() as Setter;
                if (st != null) st.Value = Visibility.Collapsed;
            }
            this.ltBoxValues.ItemTemplate = (DataTemplate)resourceDic1["ExpandListBoxItemDataTemplate"];

            WPFTestDataObject dtObj = new WPFTestDataObject();
            dtObj.ObjectName = "WPFTestDataObject";
            dtObj.Description = "测试用数据对象";
            List<WPFTestDataObject> HL = new List<WPFTestDataObject>();
            for (int i = 0; i < 2; i++)
                HL.Add(dtObj);
            this.ltBoxDataSource.ItemsSource = HL;
            this.ltBoxValues.ItemsSource = HL;
        }

        private void btnDataSourcesEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSearchDataSource_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAddDataSource_Click(object sender, RoutedEventArgs e)
        {
            grdDataSourcesEdit.Visibility = Visibility.Visible;
        }

        private void btnDataSourcesOK_Click(object sender, RoutedEventArgs e)
        {
            grdDataSourcesEdit.Visibility = Visibility.Collapsed;
        }

        private void btnValuesOK_Click(object sender, RoutedEventArgs e)
        {
            grdValuesEdit.Visibility = Visibility.Collapsed;
        }

        private void btnAddValue_Click(object sender, RoutedEventArgs e)
        {
            grdValuesEdit.Visibility = Visibility.Visible;
        }

        private void btnDeleteValues_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEditValues_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDeleteDataSources_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSearchValue_Click(object sender, RoutedEventArgs e)
        {

        }

    }

}
