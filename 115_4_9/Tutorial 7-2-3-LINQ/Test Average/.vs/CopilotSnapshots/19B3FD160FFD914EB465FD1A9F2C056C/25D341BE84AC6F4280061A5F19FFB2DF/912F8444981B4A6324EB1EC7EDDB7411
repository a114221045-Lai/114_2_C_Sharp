using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Test_Average
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // 計算平均分數的方法
        // 接受一個整數陣列作為參數，並返回陣列中所有分數的平均值
        // 使用LINQ查詢語法計算平均值
        private double Average(int[] sArray)
        {
            double result = (from score in sArray
                            select score).Average();
            return result;
        }

        // 計算最高分數的方法
        // 接受一個整數陣列作為參數，並返回陣列中的最高分數
        // 使用LINQ查詢語法找出最高分數
        private int Highest(int[] sArray)
        {
            int result = (from score in sArray
                         select score).Max();
            return result;
        }

        // 計算最低分數的方法
        // 接受一個整數陣列作為參數，並返回陣列中的最低分數
        // 使用LINQ查詢語法找出最低分數
        private int Lowest(int[] sArray)
        {
            int result = (from score in sArray
                         select score).Min();
            return result;
        }

        private void getScoresButton_Click(object sender, EventArgs e)
        {
            // 當用戶點擊「取得分數」按鈕時觸發的事件處理程序
            // 打開文件對話框，讓用戶選擇包含分數的文本文件
            // 讀取文件中的分數，將它們添加到列表框中，並計算平均值、最高值和最低值
            
            try
            {
                // 創建文件開啟對話框
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Title = "選擇包含分數的文本文件";
                openFileDialog.Filter = "文本文件 (*.txt)|*.txt|所有文件 (*.*)|*.*";
                openFileDialog.InitialDirectory = Application.StartupPath;
                
                // 如果用戶選擇了文件
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // 清空列表框
                    testScoresListBox.Items.Clear();
                    
                    // 使用LINQ查詢語法讀取文件中的所有分數
                    var scoreLines = (from line in File.ReadAllLines(openFileDialog.FileName)
                                     where !string.IsNullOrWhiteSpace(line)
                                     select int.Parse(line));
                    
                    // 將分數添加到列表框中
                    foreach (var score in scoreLines)
                    {
                        testScoresListBox.Items.Add(score);
                    }
                    
                    // 將分數轉換為整數陣列以供計算使用
                    int[] scoresArray = scoreLines.ToArray();
                    
                    // 計算並顯示平均分數
                    if (scoresArray.Length > 0)
                    {
                        averageScoreLabel.Text = Average(scoresArray).ToString("F2");
                        highScoreLabel.Text = Highest(scoresArray).ToString();
                        lowScoreLabel.Text = Lowest(scoresArray).ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("錯誤: " + ex.Message);
            }
        }

        // 當用戶點擊「離開」按鈕時觸發的事件處理程序
        // 關閉表單並結束應用程式
        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉表單。
            this.Close();
        }
    }
}
