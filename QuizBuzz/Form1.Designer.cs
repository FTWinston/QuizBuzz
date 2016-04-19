namespace QuizBuzz
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.gridBuzzers = new System.Windows.Forms.DataGridView();
            this.ddlBuzzDelay = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lnkAllowBuzzing = new System.Windows.Forms.LinkLabel();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSound = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridBuzzers)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(349, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Browse to this address on phones\' web browser:";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.Location = new System.Drawing.Point(367, 9);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(43, 20);
            this.lblAddress.TabIndex = 0;
            this.lblAddress.Text = "blah";
            // 
            // gridBuzzers
            // 
            this.gridBuzzers.AllowUserToAddRows = false;
            this.gridBuzzers.AllowUserToDeleteRows = false;
            this.gridBuzzers.AllowUserToResizeRows = false;
            this.gridBuzzers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridBuzzers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridBuzzers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridBuzzers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colSound});
            this.gridBuzzers.Location = new System.Drawing.Point(16, 86);
            this.gridBuzzers.Name = "gridBuzzers";
            this.gridBuzzers.RowHeadersVisible = false;
            this.gridBuzzers.RowTemplate.Height = 28;
            this.gridBuzzers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridBuzzers.Size = new System.Drawing.Size(726, 316);
            this.gridBuzzers.TabIndex = 1;
            // 
            // ddlBuzzDelay
            // 
            this.ddlBuzzDelay.DisplayMember = "Item1";
            this.ddlBuzzDelay.FormattingEnabled = true;
            this.ddlBuzzDelay.Location = new System.Drawing.Point(187, 40);
            this.ddlBuzzDelay.Name = "ddlBuzzDelay";
            this.ddlBuzzDelay.Size = new System.Drawing.Size(174, 28);
            this.ddlBuzzDelay.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Delay between buzzes";
            // 
            // lnkAllowBuzzing
            // 
            this.lnkAllowBuzzing.AutoSize = true;
            this.lnkAllowBuzzing.Location = new System.Drawing.Point(367, 43);
            this.lnkAllowBuzzing.Name = "lnkAllowBuzzing";
            this.lnkAllowBuzzing.Size = new System.Drawing.Size(382, 20);
            this.lnkAllowBuzzing.TabIndex = 3;
            this.lnkAllowBuzzing.TabStop = true;
            this.lnkAllowBuzzing.Text = "Buzzers are currently disabled. Click to allow buzzing.";
            this.lnkAllowBuzzing.Visible = false;
            this.lnkAllowBuzzing.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAllowBuzzing_LinkClicked);
            // 
            // colName
            // 
            this.colName.DataPropertyName = "Name";
            this.colName.HeaderText = "Buzzer Name";
            this.colName.Name = "colName";
            this.colName.Width = 150;
            // 
            // colSound
            // 
            this.colSound.DataPropertyName = "SoundName";
            this.colSound.HeaderText = "Buzzer Sound";
            this.colSound.Name = "colSound";
            this.colSound.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colSound.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colSound.Width = 300;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 414);
            this.Controls.Add(this.lnkAllowBuzzing);
            this.Controls.Add(this.ddlBuzzDelay);
            this.Controls.Add(this.gridBuzzers);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "QuizBuzz";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridBuzzers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.DataGridView gridBuzzers;
        private System.Windows.Forms.ComboBox ddlBuzzDelay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel lnkAllowBuzzing;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewComboBoxColumn colSound;
    }
}

