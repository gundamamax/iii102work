namespace 期中專題
{
    partial class productselect
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
            this.TBNameSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LbResult = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TBNameSearch
            // 
            this.TBNameSearch.Font = new System.Drawing.Font("微軟正黑體", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TBNameSearch.Location = new System.Drawing.Point(46, 55);
            this.TBNameSearch.Name = "TBNameSearch";
            this.TBNameSearch.Size = new System.Drawing.Size(228, 57);
            this.TBNameSearch.TabIndex = 22;
            this.TBNameSearch.TextChanged += new System.EventHandler(this.TBNameSearch_TextChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(38, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 43);
            this.label1.TabIndex = 21;
            this.label1.Text = "搜尋";
            // 
            // LbResult
            // 
            this.LbResult.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.LbResult.FormattingEnabled = true;
            this.LbResult.ItemHeight = 30;
            this.LbResult.Location = new System.Drawing.Point(46, 118);
            this.LbResult.Name = "LbResult";
            this.LbResult.Size = new System.Drawing.Size(228, 424);
            this.LbResult.TabIndex = 20;
            this.LbResult.DoubleClick += new System.EventHandler(this.DCLICK);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Info;
            this.button1.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button1.Location = new System.Drawing.Point(46, 548);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(228, 65);
            this.button1.TabIndex = 23;
            this.button1.Text = "選擇";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // productselect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(332, 625);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TBNameSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LbResult);
            this.Name = "productselect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "商品選擇";
            this.Load += new System.EventHandler(this.productselect_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TBNameSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox LbResult;
        private System.Windows.Forms.Button button1;
    }
}