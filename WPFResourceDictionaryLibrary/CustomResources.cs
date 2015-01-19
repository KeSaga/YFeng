using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace WPFResourceDictionaryLibrary
{
    public class CustomResources
    {
        public static ComponentResourceKey ExpandListBoxItemDataTemplate
        {
            get { return new ComponentResourceKey(typeof(CustomResources), "ExpandListBoxItemDataTemplate"); }
        }

        /// <summary>
        /// 属性名不必与 ComponentResourceKey 的 resourceId 相同
        /// </summary>
        public static ComponentResourceKey BtnBackgound_SkyBlue
        {
            get { return new ComponentResourceKey(typeof(CustomResources), "BtnBackgound_SkyBlue"); }
        }

    }
}
