using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Review_Q3
{
    public partial class Form1 : Form
    {
        private int[] generatedNumbers = new int[5];
        private int[] lotteryNumbers = new int[5];
        private int[] matchedNumbers = new int[5];
        private int matchCount = 0;
        private bool lotteryLoaded = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void BtnLoadLottery_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    LoadLotteryNumbers(openFileDialog1.FileName);
                    lotteryLoaded = true;
                    DisplayLotteryNumbers();
                    btnGenerateNumbers.Enabled = true;
                    labelResult.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("讀取檔案出錯: " + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    lotteryLoaded = false;
                    btnGenerateNumbers.Enabled = false;
                }
            }
        }

        private void BtnGenerateNumbers_Click(object sender, EventArgs e)
        {
            if (!lotteryLoaded)
            {
                MessageBox.Show("請先讀取開獎號碼檔案", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            GenerateRandomNumbers();
            DisplayGeneratedNumbers();
            CompareLotteryNumbers();
            DisplayComparisonResults();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadLotteryNumbers(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                int index = 0;

                while ((line = reader.ReadLine()) != null && index < 5)
                {
                    line = line.Trim();

                    if (string.IsNullOrEmpty(line))
                        continue;

                    if (!int.TryParse(line, out int number))
                    {
                        throw new FormatException($"第 {index + 1} 行無法轉換為整數: {line}");
                    }

                    if (number < 1 || number > 49)
                    {
                        throw new ArgumentException($"號碼必須在1-49範圍內，但收到: {number}");
                    }

                    lotteryNumbers[index] = number;
                    index++;
                }

                if (index < 5)
                {
                    throw new InvalidOperationException($"檔案中號碼數量不足，需要5個，但只有 {index} 個");
                }
            }
        }

        private void DisplayLotteryNumbers()
        {
            listBoxLottery.Items.Clear();
            listBoxLottery.Items.Add("本期開獎號碼 :");

            for (int i = 0; i < 5; i++)
            {
                listBoxLottery.Items.Add($"第{i + 1}個號碼: {lotteryNumbers[i]}");
            }
        }

        private void GenerateRandomNumbers()
        {
            Random random = new Random();
            bool[] used = new bool[50];

            for (int i = 0; i < 5; i++)
            {
                int number;
                do
                {
                    number = random.Next(1, 50);
                } while (used[number - 1]);

                used[number - 1] = true;
                generatedNumbers[i] = number;
            }
        }

        private void DisplayGeneratedNumbers()
        {
            Label[] numberLabels = { label1, label2, label3, label4, label5 };
            for (int i = 0; i < 5; i++)
            {
                numberLabels[i].Text = generatedNumbers[i].ToString();
            }
        }

        private void CompareLotteryNumbers()
        {
            matchCount = 0;
            for (int i = 0; i < 5; i++)
            {
                matchedNumbers[i] = 0;
            }

            int matchIndex = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (generatedNumbers[i] == lotteryNumbers[j])
                    {
                        matchCount++;
                        matchedNumbers[matchIndex] = generatedNumbers[i];
                        matchIndex++;
                        break;
                    }
                }
            }
        }

        private void DisplayComparisonResults()
        {
            string resultText = "比對結果 :\n中" + matchCount + "個號碼\n";

            if (matchCount > 0)
            {
                resultText += "中獎號碼: ";
                for (int i = 0; i < matchCount; i++)
                {
                    if (i > 0) resultText += ", ";
                    resultText += matchedNumbers[i].ToString();
                }
            }
            else
            {
                resultText += "😢 沒中獎";
            }

            labelResult.Text = resultText;
        }
    }
}
