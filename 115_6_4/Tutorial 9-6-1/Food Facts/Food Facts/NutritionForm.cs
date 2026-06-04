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
    /// NutritionForm 類：營養信息展示窗口
    /// 功能：顯示選定食物的詳細營養信息，包括食物名稱、熱量、脂肪克數和碳水化合物克數
    /// </summary>
    public partial class NutritionForm : Form
    {
        private FoodItem FoodItem;
        /// <summary>
        /// NutritionForm 構造函數
        /// 接受 FoodItem 對象並初始化窗體組件
        /// </summary>
        /// <param name="foodItem">包含食物信息的 FoodItem 對象</param>
        public NutritionForm(FoodItem foodItem)
        {
            InitializeComponent();
            // 將傳入的 FoodItem 對象賦值給類的私有字段，以便在窗體中使用
            this.FoodItem = foodItem;
        }

        /// <summary>
        /// 關閉按鈕的點擊事件處理程序
        /// 用戶點擊此按鈕後關閉營養信息窗口
        /// </summary>
        private void closeButton_Click(object sender, EventArgs e)
        {
            // 關閉窗體
            this.Close();
        }


        private void NutritionForm_Load(object sender, EventArgs e)
        {
            // 在窗體加載時設置營養信息標籤的文本
            foodLabel.Text = FoodItem.Name;
            caloriesLabel.Text = FoodItem.Calories.ToString();
            fatLabel.Text =  FoodItem.Fat.ToString();
            carbLabel.Text =  FoodItem.Carbs.ToString();
        }
    }
}

