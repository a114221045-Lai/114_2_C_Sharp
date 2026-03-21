using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Review_Q2
{
    public partial class Form1 : Form
    {
        // 費用常數定義
        private const decimal OIL_CHANGE_PRICE      = 780m;
        private const decimal LUBE_SERVICE_PRICE    = 540m;
        private const decimal RADIATOR_FLUSH_PRICE  = 900m;
        private const decimal TRANS_FLUSH_PRICE     = 2400m;
        private const decimal INSPECTION_PRICE      = 450m;
        private const decimal MUFFLER_PRICE         = 3000m;
        private const decimal TIRE_ROTATION_PRICE   = 600m;
        private const decimal LABOR_RATE_PER_HOUR   = 600m;
        private const decimal TAX_RATE              = 0.06m;

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 計算機油與潤滑服務費用
        /// </summary>
        private decimal OilLubeCharges()
        {
            decimal total = 0m;

            if (checkBoxOilChange.Checked)
                total += OIL_CHANGE_PRICE;

            if (checkBoxLubeService.Checked)
                total += LUBE_SERVICE_PRICE;

            return total;
        }

        /// <summary>
        /// 計算清洗服務費用
        /// </summary>
        private decimal FlushCharges()
        {
            decimal total = 0m;

            if (checkBoxRadiatorFlush.Checked)
                total += RADIATOR_FLUSH_PRICE;

            if (checkBoxTransFlush.Checked)
                total += TRANS_FLUSH_PRICE;

            return total;
        }

        /// <summary>
        /// 計算其他服務費用
        /// </summary>
        private decimal MiscCharges()
        {
            decimal total = 0m;

            if (checkBoxInspection.Checked)
                total += INSPECTION_PRICE;

            if (checkBoxMuffler.Checked)
                total += MUFFLER_PRICE;

            if (checkBoxTireRotation.Checked)
                total += TIRE_ROTATION_PRICE;

            return total;
        }

        /// <summary>
        /// 計算零件和工時費用
        /// </summary>
        private decimal OtherCharges(out decimal parts, out decimal labor)
        {
            parts = 0m;
            labor = 0m;

            // 解析零件費用
            if (decimal.TryParse(textBoxPartsPrice.Text, out decimal partsValue))
            {
                if (partsValue >= 0)
                    parts = partsValue;
            }

            // 解析工時費用
            if (decimal.TryParse(textBoxLaborHours.Text, out decimal hoursValue))
            {
                if (hoursValue >= 0)
                    labor = hoursValue * LABOR_RATE_PER_HOUR;
            }

            return parts + labor;
        }

        /// <summary>
        /// 計算稅金（僅對零件收取6%稅率）
        /// </summary>
        private decimal TaxCharges(decimal parts)
        {
            return parts * TAX_RATE;
        }

        /// <summary>
        /// 計算所有費用總和
        /// </summary>
        private decimal TotalCharges(decimal service, decimal parts, decimal tax)
        {
            return service + parts + tax;
        }

        /// <summary>
        /// 清除機油潤滑選項
        /// </summary>
        private void ClearOilLube()
        {
            checkBoxOilChange.Checked = false;
            checkBoxLubeService.Checked = false;
        }

        /// <summary>
        /// 清除清洗服務選項
        /// </summary>
        private void ClearFlushes()
        {
            checkBoxRadiatorFlush.Checked = false;
            checkBoxTransFlush.Checked = false;
        }

        /// <summary>
        /// 清除其他服務選項
        /// </summary>
        private void ClearMisc()
        {
            checkBoxInspection.Checked = false;
            checkBoxMuffler.Checked = false;
            checkBoxTireRotation.Checked = false;
        }

        /// <summary>
        /// 清除零件和工時輸入
        /// </summary>
        private void ClearOther()
        {
            textBoxPartsPrice.Text = "0";
            textBoxLaborHours.Text = "0";
        }

        /// <summary>
        /// 清除費用顯示
        /// </summary>
        private void ClearFees()
        {
            labelServiceFee.Text = "";
            labelPartsFee.Text = "";
            labelTaxFee.Text = "";
            labelTotalFee.Text = "";
        }

        /// <summary>
        /// 計算總額按鈕點擊事件
        /// </summary>
        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                // 計算各項費用
                decimal oilLube = OilLubeCharges();
                decimal flush = FlushCharges();
                decimal misc = MiscCharges();
                OtherCharges(out decimal parts, out decimal labor);

                // 計算服務與工資總額
                decimal serviceTotal = oilLube + flush + misc + labor;

                // 計算稅金和總費用
                decimal tax = TaxCharges(parts);
                decimal total = TotalCharges(serviceTotal, parts, tax);

                // 更新顯示
                labelServiceFee.Text = string.Format("NT${0:N0}", serviceTotal);
                labelPartsFee.Text = string.Format("NT${0:N0}", parts);
                labelTaxFee.Text = string.Format("NT${0:N0}", tax);
                labelTotalFee.Text = string.Format("NT${0:N0}", total);
            }
            catch (Exception ex)
            {
                MessageBox.Show("計算出錯：" + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 清除按鈕點擊事件
        /// </summary>
        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearOilLube();
            ClearFlushes();
            ClearMisc();
            ClearOther();
            ClearFees();
        }

        /// <summary>
        /// 離開按鈕點擊事件
        /// </summary>
        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 表單關閉事件 - 詢問是否儲存明細
        /// </summary>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 檢查是否有費用資訊
            if (labelTotalFee.Text != "NT$0")
            {
                DialogResult result = MessageBox.Show(
                    "是否要儲存維修明細？",
                    "儲存明細",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    SaveServiceDetailsToFile();
                }
            }
        }

        /// <summary>
        /// 儲存維修明細到檔案
        /// </summary>
        private void SaveServiceDetailsToFile()
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "文字檔案 (*.txt)|*.txt|所有檔案 (*.*)|*.*";
            dialog.FileName = "維修明細_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
            dialog.DefaultExt = "txt";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer = null;
                try
                {
                    writer = new StreamWriter(dialog.FileName, false, Encoding.UTF8);

                    // 寫入標題
                    writer.WriteLine("汽車維修服務費用明細");
                    writer.WriteLine("=" + new string('=', 50));
                    writer.WriteLine("日期時間：" + DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss"));
                    writer.WriteLine();

                    // 寫入服務項目
                    writer.WriteLine("【選擇的服務項目】");
                    writer.WriteLine("-" + new string('-', 50));

                    if (checkBoxOilChange.Checked || checkBoxLubeService.Checked)
                    {
                        writer.WriteLine("機油與潤滑：");
                        if (checkBoxOilChange.Checked)
                            writer.WriteLine("  • 更換機油：NT$780");
                        if (checkBoxLubeService.Checked)
                            writer.WriteLine("  • 潤滑保養：NT$540");
                    }

                    if (checkBoxRadiatorFlush.Checked || checkBoxTransFlush.Checked)
                    {
                        writer.WriteLine("清洗服務：");
                        if (checkBoxRadiatorFlush.Checked)
                            writer.WriteLine("  • 水箱清洗：NT$900");
                        if (checkBoxTransFlush.Checked)
                            writer.WriteLine("  • 變速箱清洗：NT$2,400");
                    }

                    if (checkBoxInspection.Checked || checkBoxMuffler.Checked || checkBoxTireRotation.Checked)
                    {
                        writer.WriteLine("其他服務：");
                        if (checkBoxInspection.Checked)
                            writer.WriteLine("  • 檢驗：NT$450");
                        if (checkBoxMuffler.Checked)
                            writer.WriteLine("  • 更換消音器：NT$3,000");
                        if (checkBoxTireRotation.Checked)
                            writer.WriteLine("  • 輪胎換位：NT$600");
                    }

                    writer.WriteLine();

                    // 寫入費用明細
                    writer.WriteLine("【費用明細】");
                    writer.WriteLine("-" + new string('-', 50));
                    writer.WriteLine("服務與工資：" + labelServiceFee.Text);
                    writer.WriteLine("零件費用：" + labelPartsFee.Text);
                    writer.WriteLine("稅金 (6%)：" + labelTaxFee.Text);
                    writer.WriteLine("-" + new string('-', 50));
                    writer.WriteLine("總費用：" + labelTotalFee.Text);
                    writer.WriteLine("=" + new string('=', 50));

                    writer.Close();
                    MessageBox.Show("明細已成功儲存！", "儲存成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("儲存失敗：" + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (writer != null)
                        writer.Close();
                }
            }
        }
    }
}
