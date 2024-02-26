namespace 期中專題
{
    partial class Form3
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
            this.button1 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.PRODUCTSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LbResult = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TBID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TBPRICE = new System.Windows.Forms.TextBox();
            this.TBCOST = new System.Windows.Forms.TextBox();
            this.TBNAME = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BTN3 = new System.Windows.Forms.Button();
            this.BTN2 = new System.Windows.Forms.Button();
            this.BTN1 = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button1.Location = new System.Drawing.Point(13, 120);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(167, 65);
            this.button1.TabIndex = 29;
            this.button1.Text = "重新整理";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("微軟正黑體", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label9.Location = new System.Drawing.Point(186, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(101, 43);
            this.label9.TabIndex = 28;
            this.label9.Text = "結果";
            // 
            // PRODUCTSearch
            // 
            this.PRODUCTSearch.Font = new System.Drawing.Font("微軟正黑體", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.PRODUCTSearch.Location = new System.Drawing.Point(13, 55);
            this.PRODUCTSearch.Name = "PRODUCTSearch";
            this.PRODUCTSearch.Size = new System.Drawing.Size(167, 57);
            this.PRODUCTSearch.TabIndex = 25;
            this.PRODUCTSearch.TextChanged += new System.EventHandler(this.PRODUCTSearch_TextChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 43);
            this.label1.TabIndex = 24;
            this.label1.Text = "商品搜尋";
            // 
            // LbResult
            // 
            this.LbResult.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.LbResult.FormattingEnabled = true;
            this.LbResult.ItemHeight = 24;
            this.LbResult.Location = new System.Drawing.Point(186, 55);
            this.LbResult.Name = "LbResult";
            this.LbResult.Size = new System.Drawing.Size(141, 676);
            this.LbResult.TabIndex = 23;
            this.LbResult.SelectedIndexChanged += new System.EventHandler(this.LbResult_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Turquoise;
            this.groupBox2.Controls.Add(this.TBID);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.TBPRICE);
            this.groupBox2.Controls.Add(this.TBCOST);
            this.groupBox2.Controls.Add(this.TBNAME);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Font = new System.Drawing.Font("微軟正黑體", 26.25F);
            this.groupBox2.Location = new System.Drawing.Point(333, 57);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(536, 674);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "資料欄位";
            // 
            // TBID
            // 
            this.TBID.Font = new System.Drawing.Font("微軟正黑體", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TBID.Location = new System.Drawing.Point(172, 50);
            this.TBID.Name = "TBID";
            this.TBID.ReadOnly = true;
            this.TBID.Size = new System.Drawing.Size(346, 57);
            this.TBID.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 44);
            this.label2.TabIndex = 21;
            this.label2.Text = "商品編號";
            // 
            // TBPRICE
            // 
            this.TBPRICE.Font = new System.Drawing.Font("微軟正黑體", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TBPRICE.Location = new System.Drawing.Point(172, 407);
            this.TBPRICE.Name = "TBPRICE";
            this.TBPRICE.Size = new System.Drawing.Size(346, 57);
            this.TBPRICE.TabIndex = 20;
            this.TBPRICE.TextChanged += new System.EventHandler(this.TBPRICE_TextChanged);
            // 
            // TBCOST
            // 
            this.TBCOST.Font = new System.Drawing.Font("微軟正黑體", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TBCOST.Location = new System.Drawing.Point(172, 288);
            this.TBCOST.MaxLength = 100;
            this.TBCOST.Name = "TBCOST";
            this.TBCOST.Size = new System.Drawing.Size(346, 57);
            this.TBCOST.TabIndex = 19;
            this.TBCOST.TextChanged += new System.EventHandler(this.TBCOST_TextChanged);
            // 
            // TBNAME
            // 
            this.TBNAME.Font = new System.Drawing.Font("微軟正黑體", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TBNAME.Location = new System.Drawing.Point(172, 169);
            this.TBNAME.Name = "TBNAME";
            this.TBNAME.Size = new System.Drawing.Size(346, 57);
            this.TBNAME.TabIndex = 18;
            this.TBNAME.TextChanged += new System.EventHandler(this.TBNAME_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 412);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 44);
            this.label6.TabIndex = 3;
            this.label6.Text = "售價";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 293);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 44);
            this.label5.TabIndex = 2;
            this.label5.Text = "成本";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 174);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 44);
            this.label4.TabIndex = 1;
            this.label4.Text = "品名";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.MediumAquamarine;
            this.groupBox1.Controls.Add(this.BTN3);
            this.groupBox1.Controls.Add(this.BTN2);
            this.groupBox1.Controls.Add(this.BTN1);
            this.groupBox1.Font = new System.Drawing.Font("微軟正黑體", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox1.Location = new System.Drawing.Point(875, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(180, 674);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "功能表";
            // 
            // BTN3
            // 
            this.BTN3.Location = new System.Drawing.Point(6, 462);
            this.BTN3.Name = "BTN3";
            this.BTN3.Size = new System.Drawing.Size(168, 201);
            this.BTN3.TabIndex = 10;
            this.BTN3.Text = "刪除商品";
            this.BTN3.UseVisualStyleBackColor = true;
            this.BTN3.Click += new System.EventHandler(this.BTN3_Click);
            // 
            // BTN2
            // 
            this.BTN2.Location = new System.Drawing.Point(6, 255);
            this.BTN2.Name = "BTN2";
            this.BTN2.Size = new System.Drawing.Size(168, 201);
            this.BTN2.TabIndex = 9;
            this.BTN2.Text = "儲存商品資料";
            this.BTN2.UseVisualStyleBackColor = true;
            this.BTN2.Click += new System.EventHandler(this.BTN2_Click);
            // 
            // BTN1
            // 
            this.BTN1.Location = new System.Drawing.Point(6, 48);
            this.BTN1.Name = "BTN1";
            this.BTN1.Size = new System.Drawing.Size(168, 201);
            this.BTN1.TabIndex = 8;
            this.BTN1.Text = "新商品";
            this.BTN1.UseVisualStyleBackColor = true;
            this.BTN1.Click += new System.EventHandler(this.BTN1_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(1067, 753);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.PRODUCTSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LbResult);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "商品管理系統";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox PRODUCTSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox LbResult;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox TBPRICE;
        private System.Windows.Forms.TextBox TBCOST;
        private System.Windows.Forms.TextBox TBNAME;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BTN3;
        private System.Windows.Forms.Button BTN2;
        private System.Windows.Forms.Button BTN1;
        private System.Windows.Forms.TextBox TBID;
        private System.Windows.Forms.Label label2;
    }
}