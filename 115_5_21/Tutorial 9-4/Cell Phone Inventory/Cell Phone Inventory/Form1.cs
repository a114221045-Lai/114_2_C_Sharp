using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cell_Phone_Inventory
{
    public partial class Form1 : Form
    {
        // 儲存手機物件的列表
        List<CellPhone> phoneList = new List<CellPhone>();

        // 表單建構子
        public Form1()
        {
            InitializeComponent();
        }

        // GetPhoneData 方法接受一個 CellPhone 物件作為參數
        // 將使用者輸入的資料指派給物件的屬性
        private void GetPhoneData(CellPhone phone)
        {
            // 臨時變數，用於儲存價格
            decimal price;

            // 取得手機品牌
            phone.Brand = brandTextBox.Text;

            // 取得手機型號
            phone.Model = modelTextBox.Text;

            // 取得手機價格
            if (decimal.TryParse(priceTextBox.Text, out price))
            {
                phone.Price = price;
            }
            else
            {
                // 顯示錯誤訊息
                MessageBox.Show("無效的價格");
            }
        }

        private void addPhoneButton_Click(object sender, EventArgs e)
        {
            // 創建一個新的 CellPhone 物件
            CellPhone newPhone = new CellPhone();
            // 從使用者輸入中獲取手機資料
            GetPhoneData(newPhone);
            // 將新的手機物件添加到列表中
            phoneList.Add(newPhone);
            // 更新 ListBox 顯示手機資訊
            phoneListBox.Items.Add($"{newPhone.Brand} {newPhone.Model}");
            // 清空輸入欄位
            brandTextBox.Clear();
            modelTextBox.Clear();
            priceTextBox.Clear();

            //將焦點設置回品牌輸入框，方便使用者繼續輸入下一個手機資訊
            brandTextBox.Focus();
        }

        private void phoneListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 確保有選取項目
            int selectedIndex = phoneListBox.SelectedIndex;
            // 顯示選取的手機資訊
            MessageBox.Show($"手機資訊：{phoneList[selectedIndex].Brand} {phoneList[selectedIndex].Model} -  NT${phoneList[selectedIndex].Price}");
        }    

        private void exitButton_Click(object sender, EventArgs e)
        {
            // Close the form.
            this.Close();
        }
    }
}
