using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace WpfTest
{
    public class WPFTestDataObject : INotifyPropertyChanged
    {
        private string _objectName = string.Empty;
        /// <summary>
        /// 对象名称
        /// </summary>
        public string ObjectName
        {
            get { return this._objectName; }
            set
            {
                this._objectName = value;
                OnPropertyChanged(new PropertyChangedEventArgs("ObjectName"));
            }
        }

        private string _description = string.Empty;
        /// <summary>
        /// 描述
        /// </summary>
        public string Description
        {
            get { return this._description; }
            set
            {
                this._description = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Description"));
            }
        }

        #region 实现接口 INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null) PropertyChanged(this, e);
        }

        #endregion End 实现接口 INotifyPropertyChanged

    }
}
