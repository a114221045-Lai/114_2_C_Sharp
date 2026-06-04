using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Food_Facts
{
    /// <summary>
    /// MainForm 類：主應用窗口
    /// 功能：允許用戶選擇食物並查看其營養信息
    /// </summary>
    public partial class MainForm : Form
    {
        public FoodItem selected;
        /// <summary>
        /// MainForm 構造函數
        /// 初始化窗體組件
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 顯示食物信息按鈕的點擊事件處理程序
        /// 根據用戶選擇的食物類型顯示相應的營養信息
        /// </summary>
        private void displayButton_Click(object sender, EventArgs e)
        {
            // 定義食物項目對象，初始值為 null
            FoodItem selectedFood = null;

            // 根據選中的單選按鈕確定用戶選擇的食物
            if (bananaRadioButton.Checked)
            {
                // 建立香蕉食物項目，包含其營養信息
                selectedFood = new FoodItem("1根香蕉", "100", "0.4", "27");
            }
            else if (popcornRadioButton.Checked)
            {
                // 建立爆米花食物項目，包含其營養信息
                selectedFood = new FoodItem("1杯空氣爆米花", "31", "0.4", "6");
            }
            else if (muffinRadioButton.Checked)
            {
                // 建立藍莓瑪芬食物項目，包含其營養信息
                selectedFood = new FoodItem("1個大型藍莓瑪芬", "385", "9", "67");
            }

            // 如果選擇了食物，則顯示其營養信息
            if (selectedFood != null)
            {
                // 創建 NutritionForm 類的實例，傳遞食物對象
                NutritionForm nutritionForm = new NutritionForm(selectedFood);

                // 以對話框形式顯示 NutritionForm
                nutritionForm.ShowDialog();
            }
        }

        /// <summary>
        /// 退出按鈕的點擊事件處理程序
        /// 關閉主應用窗口
        /// </summary>
        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉窗體
            this.Close();
        }
    }
}
