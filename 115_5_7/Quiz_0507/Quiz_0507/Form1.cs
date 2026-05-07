using System;
using System.Windows.Forms;

namespace Quiz_0507
{
    public partial class Form1 : Form
    {
        // 狀態變數
        private Random rand = new Random();
        private int n1, n2, n3;           // 三個轉輪圖片索引（0~9）
        private int prize = 0;             // 本次旋轉獎金
        private int balance = 0;           // 目前餘額
        private int totalDeposited = 0;    // 累計存入金額
        private int totalSpins = 0;        // 累計旋轉次數
        private int winCount = 0;          // 累計中獎次數

        public Form1()
        {
            InitializeComponent();

            // 綁定事件以確保介面互動可用
            this.Load += Form1_Load;
            button_deposit.Click += Button_deposit_Click;
            button1.Click += Button1_Click;
            button2.Click += Button2_Click;
            comboBox_bet.SelectedIndexChanged += ComboBox_bet_SelectedIndexChanged;

            // 初始時旋轉按鈕應為停用（balance = 0）
            button1.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 初始化下注選項
            comboBox_bet.Items.Clear();
            comboBox_bet.Items.Add("$1");      // ✅ 選項 1
            comboBox_bet.Items.Add("$5");      // ✅ 選項 2
            comboBox_bet.Items.Add("$10");     // ✅ 選項 3
            comboBox_bet.Items.Add("$50");     // ✅ 選項 4
            comboBox_bet.SelectedIndex = 0;    // ✅ 預設選取 $1
            
            getImage();
            UpdateUI();
        }

        private void Button_deposit_Click(object sender, EventArgs e)
        {
            // ✅ 驗證規則：必須為正整數
            if (string.IsNullOrWhiteSpace(textBox_deposit.Text) ||       // 檢查空白
                !int.TryParse(textBox_deposit.Text, out int amount) ||   // 檢查非數字
                amount <= 0)                                             // 檢查非正整數
            {
                MessageBox.Show("請輸入有效的存入金額（必須為正整數）");
                return;
            }

            // ✅ 驗證通過後執行
            balance += amount;              // 將金額加入 balance（目前餘額）
            totalDeposited += amount;       // 將金額加入 totalDeposited（累計存入）
            textBox_deposit.Clear();        // 清空輸入方塊
            UpdateUI();                     // 更新介面
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int bet = GetBetAmount();

            // 檢查餘額是否足夠
            if (balance < bet)
            {
                MessageBox.Show("餘額不足，無法下注");
                return;
            }

            // 扣款
            balance -= bet;

            // 決定結果
            getImage();

            // 判斷勝負
            checkWinner(bet);

            // 更新統計
            UpdateStats();
            UpdateUI();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            // 計算盈虧
            int netGain = balance - totalDeposited;
            string result = netGain >= 0 ? $"盈利：${netGain:F2}" : $"虧損：${-netGain:F2}";

            MessageBox.Show(
                $"累計存入：${totalDeposited:F2}\r\n" +
                $"目前餘額：${balance:F2}\r\n" +
                $"{result}\r\n\r\n" +
                $"旋轉次數：{totalSpins} 次　中獎次數：{winCount} 次",
                "結算摘要"
            );

            Application.Exit();
        }

        private void ComboBox_bet_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateUI();  // ✅ 呼叫 UpdateUI() 重新判斷按鈕狀態
        }

        private int GetBetAmount()
        {
            if (comboBox_bet.SelectedIndex < 0)
                return 1;

            string text = comboBox_bet.SelectedItem.ToString();  // 取得 "$1" 格式
            return int.Parse(text.TrimStart('$'));               // 去掉 '$' 後轉為整數
        }

        private void getImage()
        {
            // 亂數決定三個圖片索引
            n1 = rand.Next(10);
            n2 = rand.Next(10);
            n3 = rand.Next(10);

            // 更新圖片
            pictureBox1.Image = imageList1.Images[n1];
            pictureBox2.Image = imageList1.Images[n2];
            pictureBox3.Image = imageList1.Images[n3];
        }

        private void checkWinner(int bet)
        {
            prize = 0;

            // 判斷獲獎等級並計算獎金
            if (n1 == n2 && n2 == n3)
            {
                // 頭獎：三個相同
                prize = bet * 10;
            }
            else if (n1 == n2 || n2 == n3 || n1 == n3)
            {
                // 普獎：任意兩個相同
                prize = bet * 2;
            }

            // 若有獎金則計入中獎次數
            if (prize > 0)
            {
                winCount++;
            }

            // 加回獎金
            balance += prize;
            totalSpins++;
        }

        private void UpdateUI()
        {
            // 更新餘額和獎金標籤（使用 "c" 貨幣格式）
            label_balance.Text = $"餘額：{balance.ToString("c")}";
            label_lastWin.Text = $"本次獲得：{prize.ToString("c")}";

            // 判斷旋轉按鈕是否可用
            if (comboBox_bet.SelectedIndex >= 0)
            {
                int bet = GetBetAmount();          // ✅ 取得目前下注金額
                button1.Enabled = (balance >= bet); // ✅ balance >= 下注金額時啟用
            }
            else
            {
                button1.Enabled = false;           // ✅ 無選項時停用
            }
        }

        private void UpdateStats()
        {
            // 更新統計標籤
            label_totalSpins.Text = $"旋轉：{totalSpins} 次";
            label_winCount.Text = $"中獎：{winCount} 次";

            // 計算勝率
            double winRate = totalSpins > 0 ? (double)winCount / totalSpins * 100 : 0;
            label_winRate.Text = $"勝率：{winRate:F1}%";
        }
    }
}