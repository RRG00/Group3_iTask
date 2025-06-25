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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btFechar = new System.Windows.Forms.Button();
            this.gvTarefasConcluidas = new System.Windows.Forms.DataGridView();
            this.dataGridTarefasConlcuidas = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gvTarefasConcluidas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTarefasConlcuidas)).BeginInit();
            this.SuspendLayout();
            // 
            // btFechar
            // 
            this.btFechar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btFechar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btFechar.FlatAppearance.BorderSize = 0;
            this.btFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btFechar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btFechar.ForeColor = System.Drawing.Color.White;
            this.btFechar.Location = new System.Drawing.Point(934, 415);
            this.btFechar.Name = "btFechar";
            this.btFechar.Size = new System.Drawing.Size(104, 35);
            this.btFechar.TabIndex = 32;
            this.btFechar.Text = "❌ Fechar";
            this.btFechar.UseVisualStyleBackColor = false;
            this.btFechar.Click += new System.EventHandler(this.btFechar_Click);
            // 
            // gvTarefasConcluidas
            // 
            this.gvTarefasConcluidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvTarefasConcluidas.Location = new System.Drawing.Point(12, 12);
            this.gvTarefasConcluidas.Name = "gvTarefasConcluidas";
            this.gvTarefasConcluidas.RowHeadersWidth = 62;
            this.gvTarefasConcluidas.Size = new System.Drawing.Size(1026, 395);
            this.gvTarefasConcluidas.TabIndex = 31;
            this.gvTarefasConcluidas.Visible = false;
            // 
            // dataGridTarefasConlcuidas
            // 
            this.dataGridTarefasConlcuidas.AllowUserToAddRows = false;
            this.dataGridTarefasConlcuidas.AllowUserToDeleteRows = false;
            this.dataGridTarefasConlcuidas.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.dataGridTarefasConlcuidas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridTarefasConlcuidas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridTarefasConlcuidas.BackgroundColor = System.Drawing.Color.White;
            this.dataGridTarefasConlcuidas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridTarefasConlcuidas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridTarefasConlcuidas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridTarefasConlcuidas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridTarefasConlcuidas.ColumnHeadersHeight = 40;
            this.dataGridTarefasConlcuidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(10, 5, 5, 5);
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridTarefasConlcuidas.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridTarefasConlcuidas.EnableHeadersVisualStyles = false;
            this.dataGridTarefasConlcuidas.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridTarefasConlcuidas.Location = new System.Drawing.Point(12, 12);
            this.dataGridTarefasConlcuidas.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridTarefasConlcuidas.MultiSelect = false;
            this.dataGridTarefasConlcuidas.Name = "dataGridTarefasConlcuidas";
            this.dataGridTarefasConlcuidas.ReadOnly = true;
            this.dataGridTarefasConlcuidas.RowHeadersVisible = false;
            this.dataGridTarefasConlcuidas.RowHeadersWidth = 62;
            this.dataGridTarefasConlcuidas.RowTemplate.Height = 35;
            this.dataGridTarefasConlcuidas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridTarefasConlcuidas.Size = new System.Drawing.Size(1026, 395);
            this.dataGridTarefasConlcuidas.TabIndex = 33;
            // 
            // frmConsultarTarefasConcluidas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(1052, 465);
            this.Controls.Add(this.dataGridTarefasConlcuidas);
            this.Controls.Add(this.btFechar);
            this.Controls.Add(this.gvTarefasConcluidas);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmConsultarTarefasConcluidas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "iTask - ✅ Consultar Tarefas Concluídas";
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