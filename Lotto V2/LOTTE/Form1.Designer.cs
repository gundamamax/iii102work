namespace LOTTE
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ADBTN = new System.Windows.Forms.Button();
            this.LOTFACE = new System.Windows.Forms.Panel();
            this.LBLRESULT = new System.Windows.Forms.Label();
            this.LBLSTATE = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LBLLotNum = new System.Windows.Forms.Label();
            this.LOTTRY = new System.Windows.Forms.Button();
            this.PASS = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LOTFACE.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ADBTN
            // 
            this.ADBTN.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ADBTN.Font = new System.Drawing.Font("微軟正黑體", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ADBTN.Location = new System.Drawing.Point(1, 1);
            this.ADBTN.Name = "ADBTN";
            this.ADBTN.Size = new System.Drawing.Size(105, 61);
            this.ADBTN.TabIndex = 2;
            this.ADBTN.Text = "+";
            this.ADBTN.UseVisualStyleBackColor = false;
            this.ADBTN.Click += new System.EventHandler(this.button1_Click);
            // 
            // LOTFACE
            // 
            this.LOTFACE.Controls.Add(this.LBLRESULT);
            this.LOTFACE.Controls.Add(this.LBLSTATE);
            this.LOTFACE.Controls.Add(this.label3);
            this.LOTFACE.Controls.Add(this.LBLLotNum);
            this.LOTFACE.Controls.Add(this.LOTTRY);
            this.LOTFACE.Controls.Add(this.PASS);
            this.LOTFACE.Location = new System.Drawing.Point(13, 69);
            this.LOTFACE.Name = "LOTFACE";
            this.LOTFACE.Size = new System.Drawing.Size(458, 504);
            this.LOTFACE.TabIndex = 28;
            // 
            // LBLRESULT
            // 
            this.LBLRESULT.BackColor = System.Drawing.SystemColors.Menu;
            this.LBLRESULT.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.LBLRESULT.Location = new System.Drawing.Point(3, 275);
            this.LBLRESULT.Name = "LBLRESULT";
            this.LBLRESULT.Size = new System.Drawing.Size(452, 216);
            this.LBLRESULT.TabIndex = 29;
            // 
            // LBLSTATE
            // 
            this.LBLSTATE.BackColor = System.Drawing.SystemColors.Menu;
            this.LBLSTATE.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.LBLSTATE.Location = new System.Drawing.Point(3, 68);
            this.LBLSTATE.Name = "LBLSTATE";
            this.LBLSTATE.Size = new System.Drawing.Size(452, 112);
            this.LBLSTATE.TabIndex = 28;
            this.LBLSTATE.Text = "選號組數:\r\n有效組數:\r\n無效組數:";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.Menu;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(3, 242);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(452, 33);
            this.label3.TabIndex = 27;
            this.label3.Text = "結果:";
            // 
            // LBLLotNum
            // 
            this.LBLLotNum.BackColor = System.Drawing.SystemColors.Menu;
            this.LBLLotNum.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.LBLLotNum.Location = new System.Drawing.Point(3, 190);
            this.LBLLotNum.Name = "LBLLotNum";
            this.LBLLotNum.Size = new System.Drawing.Size(452, 43);
            this.LBLLotNum.TabIndex = 26;
            this.LBLLotNum.Text = "獎號:";
            // 
            // LOTTRY
            // 
            this.LOTTRY.BackColor = System.Drawing.SystemColors.Info;
            this.LOTTRY.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.LOTTRY.Location = new System.Drawing.Point(186, 4);
            this.LOTTRY.Name = "LOTTRY";
            this.LOTTRY.Size = new System.Drawing.Size(176, 61);
            this.LOTTRY.TabIndex = 1;
            this.LOTTRY.Text = "開獎";
            this.LOTTRY.UseVisualStyleBackColor = false;
            this.LOTTRY.Click += new System.EventHandler(this.LOTTRY_Click);
            // 
            // PASS
            // 
            this.PASS.BackColor = System.Drawing.SystemColors.Info;
            this.PASS.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.PASS.Location = new System.Drawing.Point(4, 4);
            this.PASS.Name = "PASS";
            this.PASS.Size = new System.Drawing.Size(176, 61);
            this.PASS.TabIndex = 0;
            this.PASS.Text = "送出";
            this.PASS.UseVisualStyleBackColor = false;
            this.PASS.Click += new System.EventHandler(this.PASS_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Bisque;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(141, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 47);
            this.label1.TabIndex = 29;
            this.label1.Text = "雙贏彩!";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button1.Font = new System.Drawing.Font("微軟正黑體", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button1.Location = new System.Drawing.Point(299, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(169, 47);
            this.button1.TabIndex = 30;
            this.button1.Text = "操作方法";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(0, 0);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 31;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(509, 678);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LOTFACE);
            this.Controls.Add(this.ADBTN);
            this.Name = "Form1";
            this.Text = "Form1";
            this.LOTFACE.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button ADBTN;
        private System.Windows.Forms.Panel LOTFACE;
        private System.Windows.Forms.Button PASS;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LBLLotNum;
        private System.Windows.Forms.Button LOTTRY;
        private System.Windows.Forms.Label LBLSTATE;
        private System.Windows.Forms.Label LBLRESULT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

