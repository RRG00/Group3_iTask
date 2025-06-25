namespace iTasks
{
    partial class frmKanban
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
            this.lstTodo = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lstDoing = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lstDone = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ficheiroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportarParaCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.utilizadoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonNewUsers = new System.Windows.Forms.ToolStripMenuItem();
            this.gerirTiposDeTarefasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listagensToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonTaskDone = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonTaskDoing = new System.Windows.Forms.ToolStripMenuItem();
            this.btSetDoing = new System.Windows.Forms.Button();
            this.btSetDone = new System.Windows.Forms.Button();
            this.btSetTodo = new System.Windows.Forms.Button();
            this.buttonNewTask = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btPrevisao = new System.Windows.Forms.Button();
            this.deleteTask = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstTodo
            // 
            this.lstTodo.BackColor = System.Drawing.Color.White;
            this.lstTodo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstTodo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstTodo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstTodo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lstTodo.FormattingEnabled = true;
            this.lstTodo.ItemHeight = 17;
            this.lstTodo.Location = new System.Drawing.Point(3, 25);
            this.lstTodo.Name = "lstTodo";
            this.lstTodo.Size = new System.Drawing.Size(296, 405);
            this.lstTodo.TabIndex = 0;
            this.lstTodo.SelectedIndexChanged += new System.EventHandler(this.lstTodo_SelectedIndexChanged);
            this.lstTodo.DoubleClick += new System.EventHandler(this.lstTodo_DoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.lstTodo);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.groupBox1.Location = new System.Drawing.Point(12, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(302, 433);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "📋 ToDo";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.lstDoing);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.groupBox2.Location = new System.Drawing.Point(320, 63);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(302, 433);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "⚡ Doing";
            // 
            // lstDoing
            // 
            this.lstDoing.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(242)))), ((int)(((byte)(233)))));
            this.lstDoing.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstDoing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstDoing.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstDoing.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lstDoing.FormattingEnabled = true;
            this.lstDoing.ItemHeight = 17;
            this.lstDoing.Location = new System.Drawing.Point(3, 25);
            this.lstDoing.Name = "lstDoing";
            this.lstDoing.Size = new System.Drawing.Size(296, 405);
            this.lstDoing.TabIndex = 0;
            this.lstDoing.DoubleClick += new System.EventHandler(this.lstDoing_DoubleClick);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.lstDone);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.groupBox3.Location = new System.Drawing.Point(628, 63);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(302, 433);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "✅ Done";
            // 
            // lstDone
            // 
            this.lstDone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(248)))), ((int)(((byte)(245)))));
            this.lstDone.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstDone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstDone.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstDone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lstDone.FormattingEnabled = true;
            this.lstDone.ItemHeight = 17;
            this.lstDone.Location = new System.Drawing.Point(3, 25);
            this.lstDone.Name = "lstDone";
            this.lstDone.Size = new System.Drawing.Size(296, 405);
            this.lstDone.TabIndex = 0;
            this.lstDone.DoubleClick += new System.EventHandler(this.lstDone_DoubleClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ficheiroToolStripMenuItem,
            this.utilizadoresToolStripMenuItem,
            this.listagensToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(943, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ficheiroToolStripMenuItem
            // 
            this.ficheiroToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sairToolStripMenuItem,
            this.exportarParaCSVToolStripMenuItem});
            this.ficheiroToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.ficheiroToolStripMenuItem.Name = "ficheiroToolStripMenuItem";
            this.ficheiroToolStripMenuItem.Size = new System.Drawing.Size(79, 22);
            this.ficheiroToolStripMenuItem.Text = "📁 Ficheiro";
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this.sairToolStripMenuItem.Text = "🚪 Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // exportarParaCSVToolStripMenuItem
            // 
            this.exportarParaCSVToolStripMenuItem.Name = "exportarParaCSVToolStripMenuItem";
            this.exportarParaCSVToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this.exportarParaCSVToolStripMenuItem.Text = "📊 Exportar Tarefas Concluídas para CSV";
            this.exportarParaCSVToolStripMenuItem.Click += new System.EventHandler(this.exportarParaCSVToolStripMenuItem_Click);
            // 
            // utilizadoresToolStripMenuItem
            // 
            this.utilizadoresToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonNewUsers,
            this.gerirTiposDeTarefasToolStripMenuItem});
            this.utilizadoresToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.utilizadoresToolStripMenuItem.Name = "utilizadoresToolStripMenuItem";
            this.utilizadoresToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.utilizadoresToolStripMenuItem.Text = "⚙️ Gestão da Aplicação";
            // 
            // buttonNewUsers
            // 
            this.buttonNewUsers.Name = "buttonNewUsers";
            this.buttonNewUsers.Size = new System.Drawing.Size(211, 22);
            this.buttonNewUsers.Text = "👥 Gerir Utilizadores";
            this.buttonNewUsers.Click += new System.EventHandler(this.buttonNewUsers_Click);
            // 
            // gerirTiposDeTarefasToolStripMenuItem
            // 
            this.gerirTiposDeTarefasToolStripMenuItem.Name = "gerirTiposDeTarefasToolStripMenuItem";
            this.gerirTiposDeTarefasToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.gerirTiposDeTarefasToolStripMenuItem.Text = "🏷️ Gerir Tipos de Tarefas";
            this.gerirTiposDeTarefasToolStripMenuItem.Click += new System.EventHandler(this.gerirTiposDeTarefasToolStripMenuItem_Click);
            // 
            // listagensToolStripMenuItem
            // 
            this.listagensToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonTaskDone,
            this.buttonTaskDoing});
            this.listagensToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.listagensToolStripMenuItem.Name = "listagensToolStripMenuItem";
            this.listagensToolStripMenuItem.Size = new System.Drawing.Size(86, 22);
            this.listagensToolStripMenuItem.Text = "📋 Listagens";
            // 
            // buttonTaskDone
            // 
            this.buttonTaskDone.Name = "buttonTaskDone";
            this.buttonTaskDone.Size = new System.Drawing.Size(191, 22);
            this.buttonTaskDone.Text = "✅ Tarefas Concluídas";
            this.buttonTaskDone.Click += new System.EventHandler(this.tarefasTerminadasToolStripMenuItem_Click);
            // 
            // buttonTaskDoing
            // 
            this.buttonTaskDoing.Name = "buttonTaskDoing";
            this.buttonTaskDoing.Size = new System.Drawing.Size(191, 22);
            this.buttonTaskDoing.Text = "⚡ Tarefas em Curso";
            this.buttonTaskDoing.Click += new System.EventHandler(this.tarefasEmCursoToolStripMenuItem_Click);
            // 
            // btSetDoing
            // 
            this.btSetDoing.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.btSetDoing.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btSetDoing.FlatAppearance.BorderSize = 0;
            this.btSetDoing.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSetDoing.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSetDoing.ForeColor = System.Drawing.Color.White;
            this.btSetDoing.Location = new System.Drawing.Point(165, 502);
            this.btSetDoing.Name = "btSetDoing";
            this.btSetDoing.Size = new System.Drawing.Size(146, 35);
            this.btSetDoing.TabIndex = 5;
            this.btSetDoing.Text = "⚡ Executar Tarefa ➤";
            this.btSetDoing.UseVisualStyleBackColor = false;
            this.btSetDoing.Click += new System.EventHandler(this.btSetDoing_Click);
            // 
            // btSetDone
            // 
            this.btSetDone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btSetDone.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btSetDone.FlatAppearance.BorderSize = 0;
            this.btSetDone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSetDone.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSetDone.ForeColor = System.Drawing.Color.White;
            this.btSetDone.Location = new System.Drawing.Point(475, 502);
            this.btSetDone.Name = "btSetDone";
            this.btSetDone.Size = new System.Drawing.Size(144, 35);
            this.btSetDone.TabIndex = 6;
            this.btSetDone.Text = "✅ Terminar Tarefa ➤";
            this.btSetDone.UseVisualStyleBackColor = false;
            this.btSetDone.Click += new System.EventHandler(this.btSetDone_Click);
            // 
            // btSetTodo
            // 
            this.btSetTodo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btSetTodo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btSetTodo.FlatAppearance.BorderSize = 0;
            this.btSetTodo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSetTodo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSetTodo.ForeColor = System.Drawing.Color.White;
            this.btSetTodo.Location = new System.Drawing.Point(323, 502);
            this.btSetTodo.Name = "btSetTodo";
            this.btSetTodo.Size = new System.Drawing.Size(144, 35);
            this.btSetTodo.TabIndex = 7;
            this.btSetTodo.Text = "⬅️ Reiniciar Tarefa";
            this.btSetTodo.UseVisualStyleBackColor = false;
            this.btSetTodo.Click += new System.EventHandler(this.btSetTodo_Click);
            // 
            // buttonNewTask
            // 
            this.buttonNewTask.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.buttonNewTask.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonNewTask.FlatAppearance.BorderSize = 0;
            this.buttonNewTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNewTask.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNewTask.ForeColor = System.Drawing.Color.White;
            this.buttonNewTask.Location = new System.Drawing.Point(15, 502);
            this.buttonNewTask.Name = "buttonNewTask";
            this.buttonNewTask.Size = new System.Drawing.Size(104, 35);
            this.buttonNewTask.TabIndex = 8;
            this.buttonNewTask.Text = "➕ Nova Tarefa";
            this.buttonNewTask.UseVisualStyleBackColor = false;
            this.buttonNewTask.Click += new System.EventHandler(this.buttonNewTask_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.label1.Location = new System.Drawing.Point(710, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "👋 Bem vindo: <Utilizador>";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btPrevisao
            // 
            this.btPrevisao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.btPrevisao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btPrevisao.FlatAppearance.BorderSize = 0;
            this.btPrevisao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btPrevisao.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPrevisao.ForeColor = System.Drawing.Color.White;
            this.btPrevisao.Location = new System.Drawing.Point(12, 29);
            this.btPrevisao.Name = "btPrevisao";
            this.btPrevisao.Size = new System.Drawing.Size(167, 28);
            this.btPrevisao.TabIndex = 10;
            this.btPrevisao.Text = "📊 Ver Previsão";
            this.btPrevisao.UseVisualStyleBackColor = false;
            this.btPrevisao.Click += new System.EventHandler(this.btPrevisao_Click);
            // 
            // deleteTask
            // 
            this.deleteTask.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.deleteTask.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deleteTask.FlatAppearance.BorderSize = 0;
            this.deleteTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteTask.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteTask.ForeColor = System.Drawing.Color.White;
            this.deleteTask.Location = new System.Drawing.Point(15, 543);
            this.deleteTask.Name = "deleteTask";
            this.deleteTask.Size = new System.Drawing.Size(104, 35);
            this.deleteTask.TabIndex = 12;
            this.deleteTask.Text = "🗑️ Apagar";
            this.deleteTask.UseVisualStyleBackColor = false;
            this.deleteTask.Click += new System.EventHandler(this.deleteTask_Click);
            // 
            // frmKanban
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(943, 593);
            this.Controls.Add(this.deleteTask);
            this.Controls.Add(this.btPrevisao);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonNewTask);
            this.Controls.Add(this.btSetTodo);
            this.Controls.Add(this.btSetDone);
            this.Controls.Add(this.btSetDoing);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmKanban";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "iTask - Kanban Board";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmKanban_FormClosed);
            this.Load += new System.EventHandler(this.frmKanban_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstTodo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lstDoing;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox lstDone;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ficheiroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem utilizadoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buttonNewUsers;
        private System.Windows.Forms.ToolStripMenuItem gerirTiposDeTarefasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportarParaCSVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listagensToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buttonTaskDone;
        private System.Windows.Forms.ToolStripMenuItem buttonTaskDoing;
        private System.Windows.Forms.Button btSetDoing;
        private System.Windows.Forms.Button btSetDone;
        private System.Windows.Forms.Button btSetTodo;
        private System.Windows.Forms.Button buttonNewTask;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btPrevisao;
        private System.Windows.Forms.Button deleteTask;
    }
}