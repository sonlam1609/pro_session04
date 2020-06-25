namespace Session4
{
    partial class frmViewBatch
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.BathNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TranSaction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SourceWareHouse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Destination = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BathNumber,
            this.Amount,
            this.TranSaction,
            this.SourceWareHouse,
            this.Destination});
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(588, 336);
            this.dataGridView1.TabIndex = 0;
            // 
            // BathNumber
            // 
            this.BathNumber.DataPropertyName = "BathNumber";
            this.BathNumber.HeaderText = "BathNumber";
            this.BathNumber.Name = "BathNumber";
            // 
            // Amount
            // 
            this.Amount.DataPropertyName = "Amount";
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.Width = 70;
            // 
            // TranSaction
            // 
            this.TranSaction.DataPropertyName = "TranSactionName";
            this.TranSaction.HeaderText = "TranSaction";
            this.TranSaction.Name = "TranSaction";
            this.TranSaction.Width = 150;
            // 
            // SourceWareHouse
            // 
            this.SourceWareHouse.DataPropertyName = "Source";
            this.SourceWareHouse.HeaderText = "SourceWareHouse";
            this.SourceWareHouse.Name = "SourceWareHouse";
            this.SourceWareHouse.Width = 130;
            // 
            // Destination
            // 
            this.Destination.DataPropertyName = "Destination";
            this.Destination.HeaderText = "Destination";
            this.Destination.Name = "Destination";
            this.Destination.Width = 130;
            // 
            // frmViewBatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 357);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frmViewBatch";
            this.Text = "frmViewBatch";
            this.Load += new System.EventHandler(this.frmViewBatch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn BathNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn TranSaction;
        private System.Windows.Forms.DataGridViewTextBoxColumn SourceWareHouse;
        private System.Windows.Forms.DataGridViewTextBoxColumn Destination;
    }
}