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
    public partial class Delete : Form
    {
        // 宣告私有變數：用來儲存從主表單傳遞過來的員工清單引用
        private List<Employee> empList;

        /// <summary>
        /// 建構子：接收主表單的員工清單
        /// </summary>
        /// <param name="list">主程式的員工清單</param>
        public Delete(List<Employee> list)
        {
            InitializeComponent();
            empList = list; // 綁定傳入的清單
        }

        /// <summary>
        /// 「刪除」按鈕點擊事件
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // 1. 驗證輸入的員工編號格式是否為整數（加入 Trim() 自動過濾前後空白）
            if (!int.TryParse(txtEmployeeID.Text.Trim(), out int id))
            {
                MessageBox.Show("員工編號格式錯誤，請輸入數字。");
                return;
            }

            // 2. 使用 LINQ 搜尋清單中符合該編號的第一個員工
            Employee target = empList.FirstOrDefault(emp => emp.IdNumber == id);

            // 3. 如果找不到該員工
            if (target == null)
            {
                MessageBox.Show("找不到該員工，無法進行刪除。");
                return;
            }

            // 4. 【安全優化】刪除前再次向使用者確認，避免誤刪
            DialogResult confirmResult = MessageBox.Show(
                $"確定要刪除該員工嗎？\n\n工號：{target.IdNumber}\n姓名：{target.Name}",
                "確認刪除",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            // 如果使用者點擊「否(No)」，則中斷刪除程序
            if (confirmResult != DialogResult.Yes)
            {
                return;
            }

            // 5. 執行刪除：從清單中移除該員工物件
            empList.Remove(target);

            // 6. 將已刪除的員工資訊呈現在 RichTextBox 上
            richTextBoxInfo.Text = $"員工已刪除:\r\n員工編號: {target.IdNumber}\r\n姓名: {target.Name}\r\n部門: {target.Department}\r\n職稱: {target.Position}";

            // 7. 彈出提示視窗告知使用者刪除成功
            MessageBox.Show("員工資料已順利刪除！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // 8. 設定對話框結果為 OK（通知主視窗需要重新整理 ListBox），並關閉目前視窗
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// 「取消/關閉」按鈕點擊事件
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            // 設定對話框結果為 Cancel，不進行任何刪除並關閉視窗
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
