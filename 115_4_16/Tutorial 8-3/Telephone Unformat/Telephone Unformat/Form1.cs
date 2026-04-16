using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Telephone_Unformat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // IsValidFormat 方法用來驗證電話號碼格式
        // 檢查字串是否符合 (XX) XXXX-XXXX 的格式
        // 如果格式正確則傳回 true，否則傳回 false
        private bool IsValidFormat(string str)
        {
            // 檢查字串長度是否為 14 個字元
            if (str.Length != 14)
            {
                return false;
            }

            // 檢查字串的特定位置是否為括號和連字號
            if (str[0] != '(' || str[3] != ')' || str[4] != ' ' || str[9] != '-')
            {
                return false;
            }
            return true;
        }

        // Unformat 方法用來去除電話號碼的格式
        // 接收一個以參考方式傳入的字串，移除括號和連字號
        // 將 (XX) XXXX-XXXX 轉換成 XXXXXXXXXX
        private void Unformat(ref string str)
        {
            // 建立新的字串來儲存去格式化後的號碼
            // 只保留數字部份
            string unformattedNumber = "";

            // 逐一檢查字串中的每個字元
            for (int i = 0; i < str.Length; i++)
            {
                // 如果字元是數字，就加入到新字串中
                if (char.IsDigit(str[i]))
                {
                    unformattedNumber += str[i];
                }
            }

            // 將原始字串以傳參考方式更新為去格式化後的結果
            str = unformattedNumber;
        }

        // 去格式化按鈕的點擊事件處理程序
        private void unformatButton_Click(object sender, EventArgs e)
        {
            // 從文字方塊中取得使用者輸入的電話號碼
            string phoneNumber = numberTextBox.Text;

            // 檢查電話號碼格式是否正確
            if (IsValidFormat(phoneNumber))
            {
                // 如果格式正確，呼叫 Unformat 方法去除格式
                Unformat(ref phoneNumber);

                // 將去格式化後的號碼更新到文字方塊中
                numberTextBox.Text = phoneNumber;

                // 顯示成功訊息
                MessageBox.Show("電話號碼已成功去格式化！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // 如果格式不正確，顯示錯誤訊息
                MessageBox.Show("電話號碼格式不正確。\n請使用 (XX) XXXX-XXXX 的格式。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // Close the form.
            this.Close();
        }
    }
}
