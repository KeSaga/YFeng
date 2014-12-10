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

        public static ComponentResourceKey BtnBackgound_SkyBlue
        {
            get { return new ComponentResourceKey(typeof(CustomResources), "BtnBackgound_SkyBlue"); }
        }

    }
}
