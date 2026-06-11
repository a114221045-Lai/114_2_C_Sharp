using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO; // 引入 IO 命名空間，用於路徑處理
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Q2
{
    public partial class EmployeeInformationManagementSystem : Form
    {
        // 宣告全域變數：儲存整間公司的員工資料清單
        private List<Employee> globalEmpList;

        // 宣告檔案路徑：直接指定檔名，後續會搭配程式執行目錄做結合，避免路徑出錯
        private string fileName = "employees.txt";
        private string filePath;

        /// <summary>
        /// 主表單建構子
        /// </summary>
        public EmployeeInformationManagementSystem()
        {
            InitializeComponent();

            // 安全的路徑設定：自動取得目前程式執行檔 (.exe) 所在的資料夾路徑，並與檔名結合
            // 這樣做可以確保不論在開發環境還是編譯後，都能正確讀寫 bin/Debug 底下的檔案
            filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
        }

        /// <summary>
        /// 主表單載入事件（視窗第一次開啟時執行）
        /// </summary>
        private void EmployeeInformationManagementSystem_Load(object sender, EventArgs e)
        {
            try
            {
                // 步驟 1：呼叫檔案資料庫類別，從文字檔中載入歷史員工資料
                globalEmpList = FileRepository.LoadData(filePath);
            }
            catch (Exception ex)
            {
                // 防呆：如果檔案讀取失敗（例如第一次執行還沒有檔案），建立一個空的清單，避免程式崩潰
                MessageBox.Show($"載入檔案時發生錯誤：{ex.Message}\n將建立新的員工清單。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                globalEmpList = new List<Employee>();
            }

            // 步驟 2：將載入的資料更新到畫面的 ListBox 上
            RefreshListBox();
        }

        /// <summary>
        /// 自訂方法：重新整理並填入 ListBox 的資料
        /// </summary>
        private void RefreshListBox()
        {
            // 先清空 ListBox 舊有的項目
            employeeListBox.Items.Clear();

            // 逐筆將全域清單中的員工加入 ListBox 
            foreach (Employee emp in globalEmpList)
            {
                // 注意：這會呼叫 Employee 類別的 ToString() 方法。
                // 如果畫面顯示類別名稱，請確保你的 Employee 類別內有寫 override public string ToString()
                employeeListBox.Items.Add(emp);

                // 備用方案：如果不想改 Employee 類別，也可以改成下面這行來指定顯示格式：
                // employeeListBox.Items.Add($"[{emp.IdNumber}] {emp.Name} - {emp.Department}({emp.Position})");
            }
        }

        /// <summary>
        /// 「新增員工」按鈕點擊事件
        /// </summary>
        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            // 建立新增視窗，並把全域員工清單傳進去（共用同一個記憶體區塊）
            Addemployee addForm = new Addemployee(globalEmpList);

            // 以對話框模式打開。如果使用者在該視窗成功新增並按下了「確定」
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                // 重新整理主畫面的清單
                RefreshListBox();
            }
        }

        /// <summary>
        /// 「刪除員工」按鈕點擊事件
        /// </summary>
        private void btnDeleteEmployee_Click(object sender, EventArgs e)
        {
            // 建立刪除視窗，並把全域員工清單傳進去
            Delete deleteForm = new Delete(globalEmpList);

            // 如果刪除成功並關閉視窗
            if (deleteForm.ShowDialog() == DialogResult.OK)
            {
                // 重新整理主畫面的清單
                RefreshListBox();
            }
        }

        /// <summary>
        /// 「修改員工資料」按鈕點擊事件
        /// </summary>
        private void btnModifyEmployee_Click(object sender, EventArgs e)
        {
            // 建立修改視窗，並把全域員工清單傳進去
            ModifyInformation modifyForm = new ModifyInformation(globalEmpList);

            // 如果修改成功並儲存
            if (modifyForm.ShowDialog() == DialogResult.OK)
            {
                // 重新整理主畫面的清單
                RefreshListBox();
            }
        }

        /// <summary>
        /// 「查詢員工」按鈕點擊事件
        /// </summary>
        private void btnQueryEmployee_Click(object sender, EventArgs e)
        {
            // 建立查詢視窗，並把全域員工清單傳進去
            Query queryForm = new Query(globalEmpList);

            // 僅開啟查詢視窗（查詢不涉及清單項目的刪增，故不需要 DialogResult 驗證與 Refresh）
            queryForm.ShowDialog();
        }

        /// <summary>
        /// 「結束系統」按鈕點擊事件
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            // 關閉目前的主視窗，這會觸發 FormClosing 事件
            this.Close();
        }

        /// <summary>
        /// 視窗正在關閉的事件（無論是按 X 還是點擊結束系統按鈕都會觸發）
        /// </summary>
        private void EmployeeInformationManagementSystem_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                // 步驟 4：在程式完全關閉前，將記憶體中最新的 globalEmpList 寫回文字檔保存
                FileRepository.SaveData(filePath, globalEmpList);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"存檔時發生錯誤：{ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
