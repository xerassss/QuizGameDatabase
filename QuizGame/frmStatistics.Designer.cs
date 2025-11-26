namespace QuizGame
{
    partial class frmStatistics
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
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.quizDataGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.quizDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(558, 215);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(31, 416);
            this.vScrollBar1.TabIndex = 1;
            // 
            // quizDataGrid
            // 
            this.quizDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.quizDataGrid.Location = new System.Drawing.Point(12, 215);
            this.quizDataGrid.Name = "quizDataGrid";
            this.quizDataGrid.RowHeadersWidth = 51;
            this.quizDataGrid.RowTemplate.Height = 24;
            this.quizDataGrid.Size = new System.Drawing.Size(543, 416);
            this.quizDataGrid.TabIndex = 2;
            this.quizDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // frmStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 659);
            this.Controls.Add(this.quizDataGrid);
            this.Controls.Add(this.vScrollBar1);
            this.Name = "frmStatistics";
            this.Text = "frmStatistics";
            ((System.ComponentModel.ISupportInitialize)(this.quizDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.DataGridView quizDataGrid;
    }
}