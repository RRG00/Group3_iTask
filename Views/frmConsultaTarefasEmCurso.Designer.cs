﻿namespace iTasks
{
    partial class frmConsultaTarefasEmCurso
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
            this.gvTarefasEmCurso = new System.Windows.Forms.DataGridView();
            this.btFechar = new System.Windows.Forms.Button();
            this.dataGridTarefasEmcurso = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gvTarefasEmCurso)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTarefasEmcurso)).BeginInit();
            this.SuspendLayout();
            // 
            // gvTarefasEmCurso
            // 
            this.gvTarefasEmCurso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvTarefasEmCurso.Location = new System.Drawing.Point(18, 18);
            this.gvTarefasEmCurso.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gvTarefasEmCurso.Name = "gvTarefasEmCurso";
            this.gvTarefasEmCurso.RowHeadersWidth = 62;
            this.gvTarefasEmCurso.Size = new System.Drawing.Size(1539, 608);
            this.gvTarefasEmCurso.TabIndex = 0;
            // 
            // btFechar
            // 
            this.btFechar.Location = new System.Drawing.Point(1401, 638);
            this.btFechar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btFechar.Name = "btFechar";
            this.btFechar.Size = new System.Drawing.Size(156, 35);
            this.btFechar.TabIndex = 30;
            this.btFechar.Text = "Fechar";
            this.btFechar.UseVisualStyleBackColor = true;
            this.btFechar.Click += new System.EventHandler(this.btFechar_Click);
            // 
            // dataGridTarefasEmcurso
            // 
            this.dataGridTarefasEmcurso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridTarefasEmcurso.Location = new System.Drawing.Point(18, 18);
            this.dataGridTarefasEmcurso.Name = "dataGridTarefasEmcurso";
            this.dataGridTarefasEmcurso.RowHeadersWidth = 62;
            this.dataGridTarefasEmcurso.RowTemplate.Height = 28;
            this.dataGridTarefasEmcurso.Size = new System.Drawing.Size(1539, 608);
            this.dataGridTarefasEmcurso.TabIndex = 31;
            // 
            // frmConsultaTarefasEmCurso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1575, 692);
            this.Controls.Add(this.dataGridTarefasEmcurso);
            this.Controls.Add(this.btFechar);
            this.Controls.Add(this.gvTarefasEmCurso);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmConsultaTarefasEmCurso";
            this.Text = "iTask - Consultar tarefas em curso";
            this.Load += new System.EventHandler(this.frmConsultaTarefasEmCurso_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvTarefasEmCurso)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTarefasEmcurso)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gvTarefasEmCurso;
        private System.Windows.Forms.Button btFechar;
        private System.Windows.Forms.DataGridView dataGridTarefasEmcurso;
    }
}