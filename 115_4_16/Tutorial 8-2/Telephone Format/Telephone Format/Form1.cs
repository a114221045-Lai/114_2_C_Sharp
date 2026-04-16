using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Telephone_Format
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

    
        private bool IsValidNumber(string str)//
        {
            if (str == null)// 如果 str 為 null，則返回 false
            {
                return false;
            }
            else if (str.Length != 10)// 如果 str 的長度不等於 10，則返回 false
            {

                return false;
            }
            else
            {// 否則，檢查 str 中的每個字元是否都是數字，如果有任何一個字元不是數字，則返回 false；如果所有字元都是數字，則返回 true
                foreach (char c in str) {
                    if (!char.IsDigit(c)) {
                        return false;
                    }
                }
                return true;
            }
        }


        // The TelephoneFormat method accepts a string argument
        // by reference and formats it as a telephone number.
        private void TelephoneFormat(ref string str)
        {
            //使用 Substring 方法從 str 中提取前兩個字元，並將結果存入 partl 變數
            //第一部分：前2個數字(區域碼
            //string partl = str.Substring(0, 2); 
            //第二部分:中間4個數字
            //string part2 = str.Substring(2, 4);
            //第三部分:最後4個數字
            //string part3 = str.Substring(6, 4);

            //將三個部分組合成電話號碼格式，並將結果存入 str 變數
            //str = $"({partl}) {part2}-{part3}";

            str =str.Insert(0,"(") // 在 str 的開頭插入 "(" 字元 ex.(02223682225
                .Insert(3, ") ") // 在 str 的第 3 個位置插入 ") " 字串 ex.(02)223682225
                .Insert(9, "-"); // 在 str 的第 9 個位置插入 "-" 字元 ex.(02)22368-2225
        }

        private void formatButton_Click(object sender, EventArgs e)
        {
            string number = numberTextBox.Text;// 將 TextBox 中的文字存入 number 變數

            if (IsValidNumber(number))// 如果 number 是有效的電話號碼
            {
                TelephoneFormat(ref number);// 將 number 格式化為電話號碼
                numberTextBox.Text = number;// 將格式化後的 number 顯示在 TextBox 中
            }
            else
            {
                MessageBox.Show("無效的電話號碼。請輸入10位數字。"); // 顯示錯誤訊息
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
