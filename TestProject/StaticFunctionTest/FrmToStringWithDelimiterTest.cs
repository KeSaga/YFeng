using ClassLibrary.Static;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestProject.StaticFunctionTest
{
    public partial class FrmToStringWithDelimiterFromStringArrayTest : Form
    {
        public FrmToStringWithDelimiterFromStringArrayTest()
        {
            InitializeComponent();
        }

        private StringBuilder _strB = new StringBuilder();
        private Stopwatch _sw = new Stopwatch();

        private void btnStart_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            this._strB = new StringBuilder();
            string strResult = string.Empty;
            List<string> strList = new List<string>();
            int listLength = (int)numUpDown.Value;

            this._sw.Restart();
            for (int i = 1; i < listLength; i++)
            {
                strList.Add(i.ToString());
            }
            this._sw.Stop();
            this._strB.AppendLine(string.Format("生成数据共耗时： {0} 毫秒", this._sw.ElapsedMilliseconds.ToString()));

            this._sw.Restart();
            strResult = StaticFunction.ToStringWithDelimiterFromStringArray(strList);
            this._sw.Stop();
            this._strB.AppendLine(
                string.Format("ToStringWithDelimiterFromStringArray()函数共耗时： {0} 毫秒", this._sw.ElapsedMilliseconds.ToString())
                );

            this._sw.Restart();
            string VerticalLineDelimiter = ClassLibrary.Constant.DelimiterConst.VerticalLine.ToString();
            string strR = StaticFunction.JoinStringArrayToStringWithDelimiter(VerticalLineDelimiter, strList);
            this._sw.Stop();
            this._strB.AppendLine(
                string.Format("string.Join()函数共耗时： {0} 毫秒", this._sw.ElapsedMilliseconds.ToString())
                );

            this._sw.Restart();
            List<string> newStrList = StaticFunction.ToStringArrayFromStringWithDelimiter(strResult);
            this._sw.Stop();
            this._strB.AppendLine(
                string.Format("ToStringArrayFromStringWithDelimiter()函数共耗时： {0} 毫秒", this._sw.ElapsedMilliseconds.ToString())
                );

            this._sw.Restart();
            List<string> otherStringList = strList.Skip(1).ToList();
            this._sw.Stop();
            this._strB.AppendLine(
                string.Format("List<string>.Skip() 函数共耗时： {0} 毫秒", this._sw.ElapsedMilliseconds.ToString())
                );

            this._sw.Restart();
            List<string> otherStringList1 = strList.GetRange(1, strList.Count - 1);
            this._sw.Stop();
            this._strB.AppendLine(
                string.Format("List<string>.GetRange() 函数共耗时： {0} 毫秒", this._sw.ElapsedMilliseconds.ToString())
                );

            //当 strList 很大（如达到千万级以上）时在现实会占用很大内存
            //this._strB.AppendLine(string.Format("转换结果：{0}", strResult));

            this.richTxtBoxTestResult.Text = this._strB.ToString();

            this.Cursor = Cursors.Default;
        }
    }
}
