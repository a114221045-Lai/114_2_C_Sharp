using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Q2
{
    public partial class Query : Form
    {
        // 宣告私有變數：用來儲存從主表單傳遞過來的員工清單引用
        private List<Employee> empList;

        /// <summary>
        /// 建構子：初始化表單並接收員工清單
        /// </summary>
        /// <param name="list">主程式的員工清單</param>
        public Query(List<Employee> list)
        {
            InitializeComponent();
            empList = list; // 綁定傳入的清單
        }

        /// <summary>
        /// 「查詢」按鈕點擊事件
        /// </summary>
        private void btnQuery_Click(object sender, EventArgs e)
        {
            // 1. 驗證輸入的員工編號格式是否為整數（加入 Trim() 自動過濾前後空白）
            if (!int.TryParse(txtEmployeeID.Text.Trim(), out int id))
            {
                MessageBox.Show("員工編號格式錯誤，請輸入數字。");
                richTextBoxInfo.Text = ""; // 格式錯誤時，清空下方的資訊欄
                return;
            }

            // 2. 使用 LINQ 搜尋清單中符合該編號的第一個員工
            Employee target = empList.FirstOrDefault(emp => emp.IdNumber == id);

            // 3. 如果找不到該編號的員工 (target 為 null)
            if (target == null)
            {
                MessageBox.Show("找不到該員工，請確認編號是否正確。");
                richTextBoxInfo.Text = ""; // 找不到員工時，清空下方的資訊欄
                return;
            }

            // 4. 成功找到員工，將詳細資訊格式化後顯示在 RichTextBox 上
            richTextBoxInfo.Text = $"員工編號：{target.IdNumber}\r\n姓名：{target.Name}\r\n部門：{target.Department}\r\n職稱：{target.Position}";
        }

        /// <summary>
        /// 「關閉」按鈕點擊事件
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            // 關閉目前的查詢視窗
            this.Close();
        }
    }
}
