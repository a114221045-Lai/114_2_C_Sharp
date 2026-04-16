using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Password_Validation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // NumberUpperCase 方法接受一個字串參數
        // 並返回該字串中大寫字母的個數
        private int NumberUpperCase(string str)
        {
            int count = 0; // 初始化計數器
            foreach (var c in str)
            {
                if (char.IsUpper(c)) // 如果字元是大寫字母，則增加計數器
                {
                    count++;
                }
            }
            return count;// 返回大寫字母的總數
        }

        // NumberLowerCase 方法接受一個字串參數
        // 並返回該字串中小寫字母的個數
        private int NumberLowerCase(string str)
        {
            int count = 0;
            foreach (var c in str)
            {
                if (char.IsLower(c)) // 如果字元是小寫字母，則增加計數器
                {
                    count++;
                }
            }
            return count;
        }

        // NumberDigits 方法接受一個字串參數
        // 並返回該字串中數字的個數
        private int NumberDigits(string str)
        {
            int count = 0;
            foreach (var c in str) {
                if (char.IsDigit(c)) // 如果字元是數字，則增加計數器
                {
                    count++;
                }
            }
            return count;
        }

        // 檢查密碼按鈕的點擊事件處理程序
        // 此方法驗證使用者輸入的密碼是否符合所有要求
        private void checkPasswordButton_Click(object sender, EventArgs e)
        {
            const int MIN_LENGTH = 8; // 密碼的最小長度要求
            string password = passwordTextBox.Text; // 從文本框獲取使用者輸入的密碼
            if (password.Length < MIN_LENGTH)
            {
                MessageBox.Show("密碼長度必須至少為 8 個字元。");
                return;
            }
            else if (NumberUpperCase(password) < 1)
            {
                MessageBox.Show("密碼必須至少包含一個大寫字母。");
                return;
            }
            else if (NumberLowerCase(password) < 1)
            {
                MessageBox.Show("密碼必須至少包含一個小寫字母。");
                return;
            }
            else if (NumberDigits(password) < 1)
            {
                MessageBox.Show("密碼必須至少包含一個數字。");
                return;
            }
            else
            {
                MessageBox.Show("密碼有效！");
            }
        }

        // 離開按鈕的點擊事件處理程序
        // 此方法關閉應用程式視窗
        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉表單視窗
            this.Close();
        }
    }
}
