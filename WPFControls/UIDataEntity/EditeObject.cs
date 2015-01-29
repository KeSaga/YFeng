using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace WPFControls.UIDataEntity
{
    /// <summary>
    /// 用于 对象编辑器（ObjectEditor） 的可编辑的对象
    /// </summary>
    public class EditeObject : INotifyPropertyChanged
    {

        private string _objectName = string.Empty;
        public string ObjectName
        {
            get { return this._objectName; }
            set
            {
                this._objectName = value;
                this.OnPropertyChanged("ObjectName");
            }
        }

        private string _description = string.Empty;
        public string Description
        {
            get { return this._description; }
            set
            {
                this._description = value;
                this.OnPropertyChanged("Description");
            }
        }

        private bool _isEditable = false;
        public bool IsEditable
        {
            get { return this._isEditable; }
            set
            {
                this._isEditable = value;
                this.OnPropertyChanged("IsEditable");
            }
        }

        #region 接口 INotifyPropertyChanged 的实现

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion End 接口 INotifyPropertyChanged 的实现

    }
}
