namespace Review_Q3
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // Controls declaration
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label[] lblNumbers;
        private System.Windows.Forms.Button btnGenerateNumbers;
        private System.Windows.Forms.Button btnLoadDrawNumbers;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ListBox lstDrawNumbers;
        private System.Windows.Forms.Label lblDrawNumbersTitle;
        private System.Windows.Forms.TextBox txtResults;
        private System.Windows.Forms.Label lblResultsTitle;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            // Title
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblTitle.Text = "樂透號碼產生器";
            this.lblTitle.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(400, 20);
            this.lblTitle.Size = new System.Drawing.Size(400, 40);
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;

            // Number display area (5 labels)
            this.lblNumbers = new System.Windows.Forms.Label[5];
            for (int i = 0; i < 5; i++)
            {
                this.lblNumbers[i] = new System.Windows.Forms.Label();
                this.lblNumbers[i].Text = "";
                this.lblNumbers[i].Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold);
                this.lblNumbers[i].Size = new System.Drawing.Size(100, 100);
                this.lblNumbers[i].Location = new System.Drawing.Point(420 + i * 110, 80);
                this.lblNumbers[i].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                this.lblNumbers[i].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                this.lblNumbers[i].BackColor = System.Drawing.Color.LightYellow;
                this.Controls.Add(this.lblNumbers[i]);
            }

            // Buttons
            this.btnGenerateNumbers = new System.Windows.Forms.Button();
            this.btnGenerateNumbers.Text = "產生號碼";
            this.btnGenerateNumbers.Font = new System.Drawing.Font("微軟正黑體", 18F);
            this.btnGenerateNumbers.Size = new System.Drawing.Size(150, 60);
            this.btnGenerateNumbers.Location = new System.Drawing.Point(500, 210);
            this.btnGenerateNumbers.Click += new System.EventHandler(this.btnGenerateNumbers_Click);

            this.btnLoadDrawNumbers = new System.Windows.Forms.Button();
            this.btnLoadDrawNumbers.Text = "開獎號碼";
            this.btnLoadDrawNumbers.Font = new System.Drawing.Font("微軟正黑體", 18F);
            this.btnLoadDrawNumbers.Size = new System.Drawing.Size(150, 60);
            this.btnLoadDrawNumbers.Location = new System.Drawing.Point(700, 210);
            this.btnLoadDrawNumbers.Click += new System.EventHandler(this.btnLoadDrawNumbers_Click);

            this.btnExit = new System.Windows.Forms.Button();
            this.btnExit.Text = "離開";
            this.btnExit.Font = new System.Drawing.Font("微軟正黑體", 18F);
            this.btnExit.Size = new System.Drawing.Size(150, 60);
            this.btnExit.Location = new System.Drawing.Point(900, 210);
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);

            // Draw numbers ListBox title
            this.lblDrawNumbersTitle = new System.Windows.Forms.Label();
            this.lblDrawNumbersTitle.Text = "開獎號碼";
            this.lblDrawNumbersTitle.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.lblDrawNumbersTitle.Location = new System.Drawing.Point(420, 300);
            this.lblDrawNumbersTitle.Size = new System.Drawing.Size(150, 30);

            // Draw numbers ListBox
            this.lstDrawNumbers = new System.Windows.Forms.ListBox();
            this.lstDrawNumbers.Font = new System.Drawing.Font("微軟正黑體", 14F);
            this.lstDrawNumbers.Size = new System.Drawing.Size(340, 200);
            this.lstDrawNumbers.Location = new System.Drawing.Point(420, 340);

            // Results title
            this.lblResultsTitle = new System.Windows.Forms.Label();
            this.lblResultsTitle.Text = "中獎比對結果";
            this.lblResultsTitle.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.lblResultsTitle.Location = new System.Drawing.Point(800, 300);
            this.lblResultsTitle.Size = new System.Drawing.Size(150, 30);

            // Results TextBox
            this.txtResults = new System.Windows.Forms.TextBox();
            this.txtResults.Font = new System.Drawing.Font("微軟正黑體", 14F);
            this.txtResults.Size = new System.Drawing.Size(340, 200);
            this.txtResults.Location = new System.Drawing.Point(800, 340);
            this.txtResults.Multiline = true;
            this.txtResults.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResults.ReadOnly = true;
            this.txtResults.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

            // Form
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 580);
            this.Text = "樂透號碼產生器";
            this.Font = new System.Drawing.Font("微軟正黑體", 18F);

            // Add controls
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnGenerateNumbers);
            this.Controls.Add(this.btnLoadDrawNumbers);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblDrawNumbersTitle);
            this.Controls.Add(this.lstDrawNumbers);
            this.Controls.Add(this.lblResultsTitle);
            this.Controls.Add(this.txtResults);
        }

        #endregion

        private void btnGenerateNumbers_Click(object sender, System.EventArgs e)
        {
            // 此處將實作產生號碼的邏輯
        }

        private void btnLoadDrawNumbers_Click(object sender, System.EventArgs e)
        {
            // 此處將實作讀取開獎號碼的邏輯
        }

        private void btnExit_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}

