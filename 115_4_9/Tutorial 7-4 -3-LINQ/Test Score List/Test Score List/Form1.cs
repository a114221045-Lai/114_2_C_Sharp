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

namespace Test_Score_List
{
    /// <summary>
    /// Form1 - 測試分數清單管理應用程式
    /// 功能：讀取分數文件、顯示分數、計算統計資訊、搜尋分數
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// 儲存學號與分數對應關係的字典
        /// </summary>
        private Dictionary<string, int> studentScores = new Dictionary<string, int>();
        /// <summary>
        /// 建構函式 - 初始化表單
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 從檔案讀取分數數值（格式：學號 分數）
        /// </summary>
        /// <param name="scoresList">存儲分數的清單</param>
        private void ReadScores(List<int> scoresList)
        {
            // 指定分數檔案路徑
            string filePath = "TestScores.txt"; // 假設分數存儲在 TestScores.txt 文件中，格式為「學號 分數」
            try
            {
                // 清空字典以存儲新的學號與分數對應
                studentScores.Clear();
                
                // 使用 StreamReader 逐行讀取檔案內容
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    // 當未到達檔案結尾時，持續讀取
                    while (!reader.EndOfStream)
                    {
                        // 讀取一行資料
                        line = reader.ReadLine();
                        
                        // 檢查該行是否為空
                        if (string.IsNullOrWhiteSpace(line))
                        {
                            continue;
                        }
                        
                        // 以空格分割學號和分數
                        string[] parts = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        
                        // 檢查分割結果是否包含學號和分數兩部分
                        if (parts.Length >= 2)
                        {
                            // 取得學號（第一部分）
                            string studentId = parts[0];
                            // 嘗試解析分數（第二部分）
                            if (int.TryParse(parts[1], out int score))
                            {
                                // 將分數加入清單用於計算統計資訊
                                scoresList.Add(score);
                                // 將學號和分數的對應關係儲存至字典
                                studentScores[studentId] = score;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // 若讀取檔案發生錯誤，顯示錯誤訊息
                MessageBox.Show("讀取檔案時發生錯誤: " + ex.Message);
            }
        }

        /// <summary>
        /// 將分數顯示到 ListBox 控件（含序號、學號和分數）
        /// </summary>
        /// <param name="scores">包含分數的清單（此參數用於計算統計資訊，主要顯示邏輯使用 studentScores 字典）</param>
        private void DisplayScores(List<int> scores)
        {
            // 清除 ListBox 中現有的項目
            testScoresListBox.Items.Clear();
            // 初始化序號索引
            int index = 1;
            // 遍歷 studentScores 字典中的所有學號和分數對應
            foreach (var entry in studentScores)
            {
                // 取得學號
                string studentId = entry.Key;
                // 取得分數
                int score = entry.Value;
                // 格式化顯示為「序號 學號 分數」
                testScoresListBox.Items.Add(index + " " + studentId + " " + score);
                index++;
            }
        }

        /// <summary>
        /// 計算平均分數
        /// </summary>
        /// <param name="scoresList">分數清單</param>
        /// <returns>平均分數</returns>
        private double CalculateAverage(List<int> scoresList)
        {
            // 檢查清單是否為空
            if (scoresList.Count == 0)
            {
                return 0;
            }
            // 使用 LINQ 查詢語法計算平均分數
            double average = (from score in scoresList
                            select score).Average();
            return average;
        }

        /// <summary>
        /// 計算高於平均分數的筆數
        /// </summary>
        /// <param name="scoresList">分數清單</param>
        /// <param name="averageScore">平均分數</param>
        /// <returns>高於平均分數的筆數</returns>
        private int CountAboveAverage(List<int> scoresList, double averageScore)
        {
            // 使用 LINQ 查詢語法計算高於平均分數的筆數
            int count = (from score in scoresList
                        where score > averageScore
                        select score).Count();
            return count;
        }

        /// <summary>
        /// 計算低於平均分數的筆數
        /// </summary>
        /// <param name="scoresList">分數清單</param>
        /// <param name="averageScore">平均分數</param>
        /// <returns>低於平均分數的筆數</returns>
        private int CountBelowAverage(List<int> scoresList, double averageScore)
        {
            // 使用 LINQ 查詢語法計算低於平均分數的筆數
            int count = (from score in scoresList
                        where score < averageScore
                        select score).Count();
            return count;
        }

        /// <summary>
        /// 「取得分數」按鈕的點擊事件處理程式
        /// 讀取分數檔案、顯示分數並計算統計資訊
        /// </summary>
        private void getScoresButton_Click(object sender, EventArgs e)
        {
            // 宣告變數存儲平均分數
            double averageScore;
            // 宣告變數存儲高於平均分數的筆數
            int numAboveAverage;
            // 宣告變數存儲低於平均分數的筆數
            int numBelowAverage;

            // 建立分數清單
            List<int> scoresList = new List<int>();

            // 從檔案讀取分數
            ReadScores(scoresList);

            // 若清單為空，提示使用者並返回
            if (scoresList.Count == 0)
            {
                MessageBox.Show("分數清單為空，請檢查檔案內容");
                return;
            }

            // 將分數顯示到 ListBox
            DisplayScores(scoresList);

            // 計算平均分數
            averageScore = CalculateAverage(scoresList);
            // 計算高於平均分數的筆數
            numAboveAverage = CountAboveAverage(scoresList, averageScore);
            // 計算低於平均分數的筆數
            numBelowAverage = CountBelowAverage(scoresList, averageScore);

            // 在介面上顯示平均分數
            averageLabel.Text = averageScore.ToString("F2");
            // 在介面上顯示高於平均分數的筆數
            aboveAverageLabel.Text = numAboveAverage.ToString();
            // 在介面上顯示低於平均分數的筆數
            belowAverageLabel.Text = numBelowAverage.ToString();
        }

        /// <summary>
        /// 「結束」按鈕的點擊事件處理程式
        /// 關閉應用程式
        /// </summary>
        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉表單視窗
            this.Close();
        }

        /// <summary>
        /// 「搜尋」按鈕的點擊事件處理程式
        /// 在 ListBox 中搜尋輸入的分數並顯示結果
        /// </summary>
        private void searchButton_Click(object sender, EventArgs e)
        {
            // 檢查搜尋框是否為空
            if (string.IsNullOrWhiteSpace(searchTextBox.Text))
            {
                searchResultLabel.Text = "請輸入分數";
                return;
            }

            // 嘗試將輸入的文字轉換為整數
            if (!int.TryParse(searchTextBox.Text, out int searchScore))
            {
                searchResultLabel.Text = "請輸入有效的數字";
                return;
            }

            // 使用 LINQ 查詢語法建立序號與學號的配對清單
            var indexedScores = (from entry in studentScores.Select((kvp, index) => new { kvp.Key, kvp.Value, Index = index + 1 })
                                select entry).ToList();
            
            // 使用 LINQ 查詢語法搜尋所有相符的分數
            var results = (from item in indexedScores
                          where item.Value == searchScore
                          select $"位置：第 {item.Index} 筆，學號：{item.Key}").ToList();

            // 檢查是否找到分數
            if (results.Count > 0)
            {
                // 用換行符將所有結果連接，並顯示在 Label 中
                searchResultLabel.Text = string.Join(Environment.NewLine, results);
            }
            else
            {
                // 若未找到，顯示「分數不存在」
                searchResultLabel.Text = "分數不存在";
            }
        }
    }
}
