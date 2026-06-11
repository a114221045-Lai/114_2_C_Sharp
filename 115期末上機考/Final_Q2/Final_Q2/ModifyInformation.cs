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
    public partial class ModifyInformation : Form
    {
        // 宣告私有變數：用來儲存從主表單傳入的員工清單
        private List<Employee> empList;
        // 宣告私有變數：用來暫存目前正在被查詢、修改的員工物件
        private Employee currentEmployee;

        /// <summary>
        /// 建構子：接收主表單傳遞過來的員工清單
        /// </summary>
        /// <param name="list">主程式的員工清單</param>
        public ModifyInformation(List<Employee> list)
        {
            InitializeComponent();
            empList = list;       // 引用主表單的清單
            currentEmployee = null; // 初始化時尚未查詢任何員工，設為 null
        }

        /// <summary>
        /// 「查詢」按鈕點擊事件
        /// </summary>
        private void btnQuery_Click(object sender, EventArgs e)
        {
            // 1. 驗證輸入的員工編號格式（自動消除前後空白）
            if (!int.TryParse(txtEmployeeID.Text.Trim(), out int id))
            {
                MessageBox.Show("員工編號格式錯誤，請輸入數字。");
                return;
            }

            // 2. 從清單中搜尋符合該編號的第一個員工
            currentEmployee = empList.FirstOrDefault(emp => emp.IdNumber == id);

            // 3. 如果找不到該員工
            if (currentEmployee == null)
            {
                MessageBox.Show("找不到該員工，請重新輸入。");
                // 清空欄位，避免殘留上一次查詢的資料
                txtName.Text = "";
                txtDepartment.Text = "";
                txtPosition.Text = "";
                richTextBoxInfo.Text = "";
                return;
            }

            // 4. 找到員工，將資料帶入對應的 TextBox 控制項中供使用者修改
            txtName.Text = currentEmployee.Name;
            txtDepartment.Text = currentEmployee.Department;
            txtPosition.Text = currentEmployee.Position;

            // 5. 在 RichTextBox 顯示查詢成功的結果
            richTextBoxInfo.Text = $"查詢結果:\r\n員工編號: {currentEmployee.IdNumber}\r\n姓名: {currentEmployee.Name}\r\n部門: {currentEmployee.Department}\r\n職稱: {currentEmployee.Position}";
        }

        /// <summary>
        /// 「儲存修改」按鈕點擊事件
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            // 1. 安全檢查：確保使用者在點擊儲存前，有先進行查詢並找到員工
            if (currentEmployee == null)
            {
                MessageBox.Show("請先輸入員工編號並點擊查詢！");
                return;
            }

            // 2. 驗證修改後的姓名不可留空
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("姓名不可留空");
                return;
            }

            // 3. 驗證修改後的部門不可留空
            if (string.IsNullOrWhiteSpace(txtDepartment.Text))
            {
                MessageBox.Show("部門不可留空");
                return;
            }

            // 4. 驗證修改後的職稱不可留空
            if (string.IsNullOrWhiteSpace(txtPosition.Text))
            {
                MessageBox.Show("職稱不可留空");
                return;
            }

            // 5. 更新暫存員工物件的內容（透過物件參照，主清單的資料會同步被修改）
            currentEmployee.Name = txtName.Text.Trim();
            currentEmployee.Department = txtDepartment.Text.Trim();
            currentEmployee.Position = txtPosition.Text.Trim();

            // 6. 在 RichTextBox 更新顯示最新的資料
            richTextBoxInfo.Text = $"員工資料已更新:\r\n員工編號: {currentEmployee.IdNumber}\r\n姓名: {currentEmployee.Name}\r\n部門: {currentEmployee.Department}\r\n職稱: {currentEmployee.Position}";

            // 7. 彈出提示方塊讓使用者確認看到修改結果
            MessageBox.Show("員工資料修改成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // 8. 設定對話框結果為 OK，並關閉視窗回到主畫面
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// 「取消/關閉」按鈕點擊事件
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            // 設定對話框結果為 Cancel，並直接關閉視窗（不儲存任何變更）
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
