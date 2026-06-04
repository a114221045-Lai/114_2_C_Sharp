using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multiform_Practice
{
    /// <summary>
    /// 第二個表單類別 - 這是多表單應用程式中的次要視窗
    /// 當使用者點擊主表單的"顯示表單"按鈕時會被建立並顯示
    /// </summary>
    public partial class SecondForm : Form
    {
        /// <summary>
        /// 使用者名稱變數 - 用於儲存使用者的相關資訊
        /// </summary>
        private string uname;

        /// <summary>
        /// 第二個表單的建構函式 - 初始化表單的所有元件
        /// </summary>
        /// <param name="name">傳入的使用者名稱參考</param>
        public SecondForm(ref string name)
        {
            InitializeComponent();
            // 儲存傳入的使用者名稱
            uname = name;
            // 設定表單的 Text 屬性顯示使用者名稱
            this.Text = "使用者: " + uname;
        }

        /// <summary>
        /// 表單載入事件處理程式
        /// 用途：在表單載入時，將使用者名稱顯示在標籤上
        /// </summary>
        private void SecondForm_Load(object sender, EventArgs e)
        {
            // 在表單載入時，將使用者名稱顯示在標籤上
            nameLabel.Text = "您好, " + uname;
        }
    }
}
