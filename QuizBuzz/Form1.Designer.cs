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
            this.gridBuzzers.Location = new System.Drawing.Point(16, 54);
            this.gridBuzzers.Name = "gridBuzzers";
            this.gridBuzzers.RowHeadersVisible = false;
            this.gridBuzzers.RowTemplate.Height = 28;
            this.gridBuzzers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridBuzzers.Size = new System.Drawing.Size(726, 348);
            this.gridBuzzers.TabIndex = 1;
            // 
            // colName
            // 
            this.colName.DataPropertyName = "Name";
            this.colName.HeaderText = "Buzzer Name";
            this.colName.Name = "colName";
            // 
            // colSound
            // 
            this.colSound.DataPropertyName = "SoundName";
            this.colSound.HeaderText = "Buzzer Sound";
            this.colSound.Name = "colSound";
            this.colSound.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colSound.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 414);
            this.Controls.Add(this.gridBuzzers);
            this.Controls.Add(this.lblAddress);
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
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewComboBoxColumn colSound;
    }
}

