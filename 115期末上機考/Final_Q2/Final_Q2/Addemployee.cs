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
    public partial class Addemployee : Form
    {
        // 宣告用來儲存員工資料的私有清單（由主表單傳入）
        private List<Employee> empList;

        /// <summary>
        /// 建構子：接收從主表單傳遞過來的員工清單引用
        /// </summary>
        /// <param name="list">主程式的員工清單</param>
        public Addemployee(List<Employee> list)
        {
            InitializeComponent();
            empList = list; // 將傳入的清單指定給全域變數
        }

        /// <summary>
        /// 「新增員工」按鈕點擊事件
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // 1. 驗證員工編號格式是否為整數
            if (!int.TryParse(txtEmployeeID.Text.Trim(), out int id))
            {
                MessageBox.Show("員工編號格式錯誤，請輸入數字。");
                return;
            }

            // 2. 檢查員工編號是否已經重複
            if (empList.Any(emp => emp.IdNumber == id))
            {
                MessageBox.Show("該員工編號已存在，請使用其他編號。");
                return;
            }

            // 3. 驗證姓名不可留空
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("姓名不可留空");
                return;
            }

            // 4. 驗證部門不可留空
            if (string.IsNullOrWhiteSpace(txtDepartment.Text))
            {
                MessageBox.Show("部門不可留空");
                return;
            }

            // 5. 驗證職稱不可留空
            if (string.IsNullOrWhiteSpace(txtPosition.Text))
            {
                MessageBox.Show("職稱不可留空");
                return;
            }

            // 6. 格式驗證皆通過，建立新的員工物件（自動修剪前後空白）
            string name = txtName.Text.Trim();
            string dept = txtDepartment.Text.Trim();
            string pos = txtPosition.Text.Trim();

            Employee newEmp = new Employee(id, name, dept, pos);

            // 7. 將新員工加入至清單中（因為是引用傳遞，主表單的清單也會同步更新）
            empList.Add(newEmp);

            // 8. 將新增的資訊呈現在畫面的 RichTextBox 上
            richTextBoxInfo.Text = $"新員工已新增:\r\n員工編號: {id}\r\n姓名: {name}\r\n部門: {dept}\r\n職稱: {pos}";

            // 9. 彈出提示視窗告知使用者，按下確認後才關閉視窗
            MessageBox.Show("員工資料新增成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // 10. 設定對話框結果為 OK，並關閉目前的新增視窗
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// 「取消/關閉」按鈕點擊事件
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            // 設定對話框結果為 Cancel，並關閉視窗
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
