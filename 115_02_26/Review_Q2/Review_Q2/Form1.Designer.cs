namespace Review_Q2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // Controls
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private GroupBox groupBox5;
        private CheckBox chkEngineOil_NT1780;
        private CheckBox chkCoolant_NT540;
        private CheckBox chkTransmissionFluid_NT450;
        private CheckBox chkBrakeFluid_NT3000;
        private CheckBox chkPowerSteeringFluid_NT600;
        private CheckBox chkWaterWash_NT3900;
        private CheckBox chkEngineWash_NT2400;
        private Label lblParts;
        private Label lblLabor;
        private Label lblWarranty;
        private Label lblLaborCost;
        private TextBox txtLaborCostSmall;
        private TextBox txtLaborCostLarge;
        private Button btnCalculate;
        private Button btnClear;
        private Button btnClose;
        private Label lblPartsInput;
        private Label lblLaborInput;
        private Label lblWarrantyInput;
        private Label lblLaborCostSmall;
        private Label lblLaborCostLarge;
        private Label lblPartsAndLabor;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            chkEngineOil_NT1780 = new CheckBox();
            chkCoolant_NT540 = new CheckBox();
            groupBox2 = new GroupBox();
            chkWaterWash_NT3900 = new CheckBox();
            chkEngineWash_NT2400 = new CheckBox();
            groupBox3 = new GroupBox();
            chkTransmissionFluid_NT450 = new CheckBox();
            chkBrakeFluid_NT3000 = new CheckBox();
            chkPowerSteeringFluid_NT600 = new CheckBox();
            groupBox4 = new GroupBox();
            textBox1 = new TextBox();
            lblLaborCostLarge = new Label();
            txtLaborCostLarge = new TextBox();
            lblLaborCostSmall = new Label();
            lblPartsAndLabor = new Label();
            groupBox5 = new GroupBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            lblWarrantyInput = new Label();
            lblLaborInput = new Label();
            lblPartsInput = new Label();
            txtLaborCostSmall = new TextBox();
            btnCalculate = new Button();
            btnClear = new Button();
            btnClose = new Button();
            label4 = new Label();
            label5 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox5.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(chkEngineOil_NT1780);
            groupBox1.Controls.Add(chkCoolant_NT540);
            groupBox1.Location = new Point(28, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(252, 89);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "機油和潤滑";
            // 
            // chkEngineOil_NT1780
            // 
            chkEngineOil_NT1780.AutoSize = true;
            chkEngineOil_NT1780.Location = new Point(15, 25);
            chkEngineOil_NT1780.Name = "chkEngineOil_NT1780";
            chkEngineOil_NT1780.Size = new Size(190, 27);
            chkEngineOil_NT1780.TabIndex = 0;
            chkEngineOil_NT1780.Text = "更換機油 (NT$780)";
            chkEngineOil_NT1780.UseVisualStyleBackColor = true;
            // 
            // chkCoolant_NT540
            // 
            chkCoolant_NT540.AutoSize = true;
            chkCoolant_NT540.Location = new Point(15, 50);
            chkCoolant_NT540.Name = "chkCoolant_NT540";
            chkCoolant_NT540.Size = new Size(190, 27);
            chkCoolant_NT540.TabIndex = 1;
            chkCoolant_NT540.Text = "潤滑保養 (NT$540)";
            chkCoolant_NT540.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(chkWaterWash_NT3900);
            groupBox2.Controls.Add(chkEngineWash_NT2400);
            groupBox2.Location = new Point(303, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(271, 89);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "清洗服務";
            // 
            // chkWaterWash_NT3900
            // 
            chkWaterWash_NT3900.AutoSize = true;
            chkWaterWash_NT3900.Location = new Point(15, 25);
            chkWaterWash_NT3900.Name = "chkWaterWash_NT3900";
            chkWaterWash_NT3900.Size = new Size(190, 27);
            chkWaterWash_NT3900.TabIndex = 0;
            chkWaterWash_NT3900.Text = "水箱清洗 (NT$900)";
            chkWaterWash_NT3900.UseVisualStyleBackColor = true;
            // 
            // chkEngineWash_NT2400
            // 
            chkEngineWash_NT2400.AutoSize = true;
            chkEngineWash_NT2400.Location = new Point(15, 50);
            chkEngineWash_NT2400.Name = "chkEngineWash_NT2400";
            chkEngineWash_NT2400.Size = new Size(222, 27);
            chkEngineWash_NT2400.TabIndex = 1;
            chkEngineWash_NT2400.Text = "變速箱清洗 (NT$2,400)";
            chkEngineWash_NT2400.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(chkTransmissionFluid_NT450);
            groupBox3.Controls.Add(chkBrakeFluid_NT3000);
            groupBox3.Controls.Add(chkPowerSteeringFluid_NT600);
            groupBox3.Location = new Point(28, 120);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(252, 118);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "其他服務";
            // 
            // chkTransmissionFluid_NT450
            // 
            chkTransmissionFluid_NT450.AutoSize = true;
            chkTransmissionFluid_NT450.Location = new Point(15, 25);
            chkTransmissionFluid_NT450.Name = "chkTransmissionFluid_NT450";
            chkTransmissionFluid_NT450.Size = new Size(154, 27);
            chkTransmissionFluid_NT450.TabIndex = 0;
            chkTransmissionFluid_NT450.Text = "檢驗 (NT$450)";
            chkTransmissionFluid_NT450.UseVisualStyleBackColor = true;
            // 
            // chkBrakeFluid_NT3000
            // 
            chkBrakeFluid_NT3000.AutoSize = true;
            chkBrakeFluid_NT3000.Location = new Point(15, 50);
            chkBrakeFluid_NT3000.Name = "chkBrakeFluid_NT3000";
            chkBrakeFluid_NT3000.Size = new Size(222, 27);
            chkBrakeFluid_NT3000.TabIndex = 1;
            chkBrakeFluid_NT3000.Text = "更換消音器 (NT$3,000)";
            chkBrakeFluid_NT3000.UseVisualStyleBackColor = true;
            // 
            // chkPowerSteeringFluid_NT600
            // 
            chkPowerSteeringFluid_NT600.AutoSize = true;
            chkPowerSteeringFluid_NT600.Location = new Point(15, 75);
            chkPowerSteeringFluid_NT600.Name = "chkPowerSteeringFluid_NT600";
            chkPowerSteeringFluid_NT600.Size = new Size(190, 27);
            chkPowerSteeringFluid_NT600.TabIndex = 2;
            chkPowerSteeringFluid_NT600.Text = "輪轉換位 (NT$600)";
            chkPowerSteeringFluid_NT600.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(textBox1);
            groupBox4.Controls.Add(lblLaborCostLarge);
            groupBox4.Controls.Add(txtLaborCostLarge);
            groupBox4.Controls.Add(lblLaborCostSmall);
            groupBox4.Controls.Add(lblPartsAndLabor);
            groupBox4.Location = new Point(303, 120);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(271, 118);
            groupBox4.TabIndex = 3;
            groupBox4.TabStop = false;
            groupBox4.Text = "零件和工時";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(154, 32);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(66, 30);
            textBox1.TabIndex = 5;
            // 
            // lblLaborCostLarge
            // 
            lblLaborCostLarge.AutoSize = true;
            lblLaborCostLarge.Location = new Point(15, 30);
            lblLaborCostLarge.Name = "lblLaborCostLarge";
            lblLaborCostLarge.Size = new Size(0, 23);
            lblLaborCostLarge.TabIndex = 4;
            lblLaborCostLarge.Visible = false;
            // 
            // txtLaborCostLarge
            // 
            txtLaborCostLarge.Location = new Point(154, 70);
            txtLaborCostLarge.Name = "txtLaborCostLarge";
            txtLaborCostLarge.Size = new Size(66, 30);
            txtLaborCostLarge.TabIndex = 3;
            // 
            // lblLaborCostSmall
            // 
            lblLaborCostSmall.AutoSize = true;
            lblLaborCostSmall.Location = new Point(15, 73);
            lblLaborCostSmall.Name = "lblLaborCostSmall";
            lblLaborCostSmall.Size = new Size(117, 23);
            lblLaborCostSmall.TabIndex = 2;
            lblLaborCostSmall.Text = "工時數 (小時)";
            // 
            // lblPartsAndLabor
            // 
            lblPartsAndLabor.AutoSize = true;
            lblPartsAndLabor.Location = new Point(21, 35);
            lblPartsAndLabor.Name = "lblPartsAndLabor";
            lblPartsAndLabor.Size = new Size(93, 23);
            lblPartsAndLabor.TabIndex = 0;
            lblPartsAndLabor.Text = "零件(NT$)";
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(label4);
            groupBox5.Controls.Add(label5);
            groupBox5.Controls.Add(label3);
            groupBox5.Controls.Add(label2);
            groupBox5.Controls.Add(label1);
            groupBox5.Controls.Add(lblWarrantyInput);
            groupBox5.Controls.Add(lblLaborInput);
            groupBox5.Controls.Add(lblPartsInput);
            groupBox5.Location = new Point(28, 244);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(546, 211);
            groupBox5.TabIndex = 4;
            groupBox5.TabStop = false;
            groupBox5.Text = "費用摘要";
            // 
            // label3
            // 
            label3.BorderStyle = BorderStyle.Fixed3D;
            label3.Location = new Point(143, 109);
            label3.Name = "label3";
            label3.Size = new Size(169, 32);
            label3.TabIndex = 7;
            label3.Text = "label3";
            label3.TextAlign = ContentAlignment.BottomCenter;
            // 
            // label2
            // 
            label2.BorderStyle = BorderStyle.Fixed3D;
            label2.Location = new Point(143, 67);
            label2.Name = "label2";
            label2.Size = new Size(169, 32);
            label2.TabIndex = 6;
            label2.Text = "label2";
            label2.TextAlign = ContentAlignment.BottomCenter;
            // 
            // label1
            // 
            label1.BorderStyle = BorderStyle.Fixed3D;
            label1.Location = new Point(143, 26);
            label1.Name = "label1";
            label1.Size = new Size(169, 32);
            label1.TabIndex = 5;
            label1.Text = "label1";
            label1.TextAlign = ContentAlignment.BottomCenter;
            // 
            // lblWarrantyInput
            // 
            lblWarrantyInput.AutoSize = true;
            lblWarrantyInput.Location = new Point(16, 116);
            lblWarrantyInput.Name = "lblWarrantyInput";
            lblWarrantyInput.Size = new Size(99, 23);
            lblWarrantyInput.TabIndex = 4;
            lblWarrantyInput.Text = "稅金 (零件)";
            // 
            // lblLaborInput
            // 
            lblLaborInput.AutoSize = true;
            lblLaborInput.Location = new Point(68, 74);
            lblLaborInput.Name = "lblLaborInput";
            lblLaborInput.Size = new Size(46, 23);
            lblLaborInput.TabIndex = 2;
            lblLaborInput.Text = "零件";
            // 
            // lblPartsInput
            // 
            lblPartsInput.AutoSize = true;
            lblPartsInput.Location = new Point(14, 33);
            lblPartsInput.Name = "lblPartsInput";
            lblPartsInput.Size = new Size(100, 23);
            lblPartsInput.TabIndex = 0;
            lblPartsInput.Text = "服務與工資";
            // 
            // txtLaborCostSmall
            // 
            txtLaborCostSmall.Location = new Point(100, 22);
            txtLaborCostSmall.Name = "txtLaborCostSmall";
            txtLaborCostSmall.Size = new Size(120, 30);
            txtLaborCostSmall.TabIndex = 1;
            // 
            // btnCalculate
            // 
            btnCalculate.Location = new Point(60, 482);
            btnCalculate.Name = "btnCalculate";
            btnCalculate.Size = new Size(120, 40);
            btnCalculate.TabIndex = 5;
            btnCalculate.Text = "計算總額";
            btnCalculate.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(235, 482);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(120, 40);
            btnClear.TabIndex = 6;
            btnClear.Text = "清除";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(410, 482);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(120, 40);
            btnClose.TabIndex = 7;
            btnClose.Text = "離開";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.BorderStyle = BorderStyle.Fixed3D;
            label4.Location = new Point(143, 150);
            label4.Name = "label4";
            label4.Size = new Size(169, 32);
            label4.TabIndex = 9;
            label4.Text = "label4";
            label4.TextAlign = ContentAlignment.BottomCenter;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(50, 157);
            label5.Name = "label5";
            label5.Size = new Size(64, 23);
            label5.TabIndex = 8;
            label5.Text = "總費用";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(601, 566);
            Controls.Add(groupBox1);
            Controls.Add(groupBox2);
            Controls.Add(groupBox3);
            Controls.Add(groupBox4);
            Controls.Add(groupBox5);
            Controls.Add(btnCalculate);
            Controls.Add(btnClear);
            Controls.Add(btnClose);
            Name = "Form1";
            Text = "汽車維修服務";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox textBox1;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label4;
        private Label label5;
    }
}
