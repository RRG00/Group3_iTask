namespace iTasks
{
    partial class frmConsultarTarefasConcluidas
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
            this.btFechar = new System.Windows.Forms.Button();
            this.gvTarefasConcluidas = new System.Windows.Forms.DataGridView();
            this.dataGridTarefasConlcuidas = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gvTarefasConcluidas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTarefasConlcuidas)).BeginInit();
            this.SuspendLayout();
            // 
            // btFechar
            // 
            this.btFechar.Location = new System.Drawing.Point(1401, 638);
            this.btFechar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btFechar.Name = "btFechar";
            this.btFechar.Size = new System.Drawing.Size(156, 35);
            this.btFechar.TabIndex = 32;
            this.btFechar.Text = "Fechar";
            this.btFechar.UseVisualStyleBackColor = true;
            this.btFechar.Click += new System.EventHandler(this.btFechar_Click);
            // 
            // gvTarefasConcluidas
            // 
            this.gvTarefasConcluidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvTarefasConcluidas.Location = new System.Drawing.Point(18, 18);
            this.gvTarefasConcluidas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gvTarefasConcluidas.Name = "gvTarefasConcluidas";
            this.gvTarefasConcluidas.RowHeadersWidth = 62;
            this.gvTarefasConcluidas.Size = new System.Drawing.Size(1539, 608);
            this.gvTarefasConcluidas.TabIndex = 31;
            // 
            // dataGridTarefasConlcuidas
            // 
            this.dataGridTarefasConlcuidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridTarefasConlcuidas.Location = new System.Drawing.Point(18, 18);
            this.dataGridTarefasConlcuidas.Name = "dataGridTarefasConlcuidas";
            this.dataGridTarefasConlcuidas.RowHeadersWidth = 62;
            this.dataGridTarefasConlcuidas.RowTemplate.Height = 28;
            this.dataGridTarefasConlcuidas.Size = new System.Drawing.Size(1539, 608);
            this.dataGridTarefasConlcuidas.TabIndex = 33;
            // 
            // frmConsultarTarefasConcluidas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1578, 692);
            this.Controls.Add(this.dataGridTarefasConlcuidas);
            this.Controls.Add(this.btFechar);
            this.Controls.Add(this.gvTarefasConcluidas);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmConsultarTarefasConcluidas";
            this.Text = "iTask - Consultar tarefas concluidas";
            this.Load += new System.EventHandler(this.frmConsultarTarefasConcluidas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvTarefasConcluidas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTarefasConlcuidas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btFechar;
        private System.Windows.Forms.DataGridView gvTarefasConcluidas;
        private System.Windows.Forms.DataGridView dataGridTarefasConlcuidas;
    }
}