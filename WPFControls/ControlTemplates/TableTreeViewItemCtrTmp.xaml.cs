using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace WPFControls.ControlTemplates
{
    public partial class TableTreeViewItemCtrTmp : ResourceDictionary
    {

        public TableTreeViewItemCtrTmp()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            ContextMenu cntMenu = this["SubItemListCntMenu"] as ContextMenu;
            if (btn == null || cntMenu == null) return;
            //定义菜单显示的位置（相对于目标的位置）
            cntMenu.PlacementTarget = btn;
            cntMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
            cntMenu.IsOpen = true;
        }

    }
}
