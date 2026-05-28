namespace Multiform_Practice
{
    partial class MessageForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.HaveAniceday = new System.Windows.Forms.Label();
            this.closebutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // HaveAniceday
            // 
            this.HaveAniceday.AutoSize = true;
            this.HaveAniceday.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.HaveAniceday.Location = new System.Drawing.Point(234, 52);
            this.HaveAniceday.Name = "HaveAniceday";
            this.HaveAniceday.Size = new System.Drawing.Size(303, 36);
            this.HaveAniceday.TabIndex = 0;
            this.HaveAniceday.Text = "祝你有愉快的一天";
            // 
            // closebutton
            // 
            this.closebutton.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.closebutton.Location = new System.Drawing.Point(324, 118);
            this.closebutton.Name = "closebutton";
            this.closebutton.Size = new System.Drawing.Size(121, 53);
            this.closebutton.TabIndex = 1;
            this.closebutton.Text = "關閉";
            this.closebutton.UseVisualStyleBackColor = true;
            this.closebutton.Click += new System.EventHandler(this.closebutton_Click);
            // 
            // MessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 210);
            this.Controls.Add(this.closebutton);
            this.Controls.Add(this.HaveAniceday);
            this.Name = "MessageForm";
            this.Text = "給你的訊息";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label HaveAniceday;
        private System.Windows.Forms.Button closebutton;
    }
}