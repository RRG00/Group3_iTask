﻿namespace iTasks
{
    partial class frmGereUtilizadores
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
            this.btGravarGestor = new System.Windows.Forms.Button();
            this.txtNomeGestor = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtIdGestor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstListaGestores = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btCleanGestor = new System.Windows.Forms.Button();
            this.btApagarGestor = new System.Windows.Forms.Button();
            this.btAttGestor = new System.Windows.Forms.Button();
            this.chkGereUtilizadores = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPasswordGestor = new System.Windows.Forms.TextBox();
            this.cbDepartamento = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUsernameGestor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btCleanProg = new System.Windows.Forms.Button();
            this.btApagarProg = new System.Windows.Forms.Button();
            this.btAttProg = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.cbGestorProg = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btGravarProg = new System.Windows.Forms.Button();
            this.txtPasswordProg = new System.Windows.Forms.TextBox();
            this.cbNivelProg = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtUsernameProg = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lstListaProgramadores = new System.Windows.Forms.ListBox();
            this.txtIdProg = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtNomeProg = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btGravarGestor
            // 
            this.btGravarGestor.Location = new System.Drawing.Point(441, 435);
            this.btGravarGestor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btGravarGestor.Name = "btGravarGestor";
            this.btGravarGestor.Size = new System.Drawing.Size(302, 35);
            this.btGravarGestor.TabIndex = 8;
            this.btGravarGestor.Text = "Gravar Dados";
            this.btGravarGestor.UseVisualStyleBackColor = true;
            this.btGravarGestor.Click += new System.EventHandler(this.btGravarGestor_Click);
            // 
            // txtNomeGestor
            // 
            this.txtNomeGestor.Location = new System.Drawing.Point(441, 123);
            this.txtNomeGestor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNomeGestor.Name = "txtNomeGestor";
            this.txtNomeGestor.Size = new System.Drawing.Size(300, 26);
            this.txtNomeGestor.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(436, 98);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 20);
            this.label4.TabIndex = 35;
            this.label4.Text = "Nome:";
            // 
            // txtIdGestor
            // 
            this.txtIdGestor.Enabled = false;
            this.txtIdGestor.Location = new System.Drawing.Point(441, 54);
            this.txtIdGestor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtIdGestor.Name = "txtIdGestor";
            this.txtIdGestor.ReadOnly = true;
            this.txtIdGestor.Size = new System.Drawing.Size(91, 26);
            this.txtIdGestor.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(436, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 20);
            this.label1.TabIndex = 33;
            this.label1.Text = "Id:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstListaGestores);
            this.groupBox1.Location = new System.Drawing.Point(9, 29);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(411, 700);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lista";
            // 
            // lstListaGestores
            // 
            this.lstListaGestores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstListaGestores.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstListaGestores.FormattingEnabled = true;
            this.lstListaGestores.ItemHeight = 25;
            this.lstListaGestores.Location = new System.Drawing.Point(4, 24);
            this.lstListaGestores.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lstListaGestores.Name = "lstListaGestores";
            this.lstListaGestores.Size = new System.Drawing.Size(403, 671);
            this.lstListaGestores.TabIndex = 1;
            this.lstListaGestores.SelectedIndexChanged += new System.EventHandler(this.lstListaGestores_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btCleanGestor);
            this.groupBox2.Controls.Add(this.btApagarGestor);
            this.groupBox2.Controls.Add(this.btAttGestor);
            this.groupBox2.Controls.Add(this.chkGereUtilizadores);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.btGravarGestor);
            this.groupBox2.Controls.Add(this.txtPasswordGestor);
            this.groupBox2.Controls.Add(this.cbDepartamento);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtUsernameGestor);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Controls.Add(this.txtIdGestor);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtNomeGestor);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(18, 18);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(766, 738);
            this.groupBox2.TabIndex = 38;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Gestores";
            // 
            // btCleanGestor
            // 
            this.btCleanGestor.Location = new System.Drawing.Point(598, 53);
            this.btCleanGestor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btCleanGestor.Name = "btCleanGestor";
            this.btCleanGestor.Size = new System.Drawing.Size(143, 36);
            this.btCleanGestor.TabIndex = 43;
            this.btCleanGestor.Text = "Limpar Campos";
            this.btCleanGestor.UseVisualStyleBackColor = true;
            this.btCleanGestor.Click += new System.EventHandler(this.btCleanGestor_Click);
            // 
            // btApagarGestor
            // 
            this.btApagarGestor.Location = new System.Drawing.Point(441, 525);
            this.btApagarGestor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btApagarGestor.Name = "btApagarGestor";
            this.btApagarGestor.Size = new System.Drawing.Size(302, 35);
            this.btApagarGestor.TabIndex = 10;
            this.btApagarGestor.Text = "Apagar Dados";
            this.btApagarGestor.UseVisualStyleBackColor = true;
            this.btApagarGestor.Click += new System.EventHandler(this.btApagarGestor_Click);
            // 
            // btAttGestor
            // 
            this.btAttGestor.Location = new System.Drawing.Point(439, 480);
            this.btAttGestor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btAttGestor.Name = "btAttGestor";
            this.btAttGestor.Size = new System.Drawing.Size(302, 35);
            this.btAttGestor.TabIndex = 9;
            this.btAttGestor.Text = "Atualizar Dados";
            this.btAttGestor.UseVisualStyleBackColor = true;
            this.btAttGestor.Click += new System.EventHandler(this.btAttGestor_Click);
            // 
            // chkGereUtilizadores
            // 
            this.chkGereUtilizadores.AutoSize = true;
            this.chkGereUtilizadores.Location = new System.Drawing.Point(441, 369);
            this.chkGereUtilizadores.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkGereUtilizadores.Name = "chkGereUtilizadores";
            this.chkGereUtilizadores.Size = new System.Drawing.Size(158, 24);
            this.chkGereUtilizadores.TabIndex = 7;
            this.chkGereUtilizadores.Text = "Gere Utilizadores";
            this.chkGereUtilizadores.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(436, 288);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 20);
            this.label5.TabIndex = 42;
            this.label5.Text = "Departamento:";
            // 
            // txtPasswordGestor
            // 
            this.txtPasswordGestor.Location = new System.Drawing.Point(441, 245);
            this.txtPasswordGestor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPasswordGestor.Name = "txtPasswordGestor";
            this.txtPasswordGestor.PasswordChar = '*';
            this.txtPasswordGestor.Size = new System.Drawing.Size(300, 26);
            this.txtPasswordGestor.TabIndex = 5;
            // 
            // cbDepartamento
            // 
            this.cbDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDepartamento.FormattingEnabled = true;
            this.cbDepartamento.Location = new System.Drawing.Point(441, 312);
            this.cbDepartamento.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbDepartamento.Name = "cbDepartamento";
            this.cbDepartamento.Size = new System.Drawing.Size(300, 28);
            this.cbDepartamento.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(436, 220);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 20);
            this.label3.TabIndex = 39;
            this.label3.Text = "Password:";
            // 
            // txtUsernameGestor
            // 
            this.txtUsernameGestor.Location = new System.Drawing.Point(441, 183);
            this.txtUsernameGestor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtUsernameGestor.Name = "txtUsernameGestor";
            this.txtUsernameGestor.Size = new System.Drawing.Size(300, 26);
            this.txtUsernameGestor.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(436, 158);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 20);
            this.label2.TabIndex = 37;
            this.label2.Text = "Username:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btCleanProg);
            this.groupBox3.Controls.Add(this.btApagarProg);
            this.groupBox3.Controls.Add(this.btAttProg);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.cbGestorProg);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.btGravarProg);
            this.groupBox3.Controls.Add(this.txtPasswordProg);
            this.groupBox3.Controls.Add(this.cbNivelProg);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.txtUsernameProg);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.txtIdProg);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txtNomeProg);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Location = new System.Drawing.Point(794, 18);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Size = new System.Drawing.Size(766, 738);
            this.groupBox3.TabIndex = 39;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Programadores";
            // 
            // btCleanProg
            // 
            this.btCleanProg.Location = new System.Drawing.Point(598, 54);
            this.btCleanProg.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btCleanProg.Name = "btCleanProg";
            this.btCleanProg.Size = new System.Drawing.Size(143, 36);
            this.btCleanProg.TabIndex = 44;
            this.btCleanProg.Text = "Limpar Campos";
            this.btCleanProg.UseVisualStyleBackColor = true;
            this.btCleanProg.Click += new System.EventHandler(this.btCleanProg_Click);
            // 
            // btApagarProg
            // 
            this.btApagarProg.Location = new System.Drawing.Point(441, 525);
            this.btApagarProg.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btApagarProg.Name = "btApagarProg";
            this.btApagarProg.Size = new System.Drawing.Size(302, 35);
            this.btApagarProg.TabIndex = 20;
            this.btApagarProg.Text = "Apagar Dados";
            this.btApagarProg.UseVisualStyleBackColor = true;
            this.btApagarProg.Click += new System.EventHandler(this.btApagarProg_Click);
            // 
            // btAttProg
            // 
            this.btAttProg.Location = new System.Drawing.Point(439, 480);
            this.btAttProg.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btAttProg.Name = "btAttProg";
            this.btAttProg.Size = new System.Drawing.Size(302, 35);
            this.btAttProg.TabIndex = 19;
            this.btAttProg.Text = "Atualizar Dados";
            this.btAttProg.UseVisualStyleBackColor = true;
            this.btAttProg.Click += new System.EventHandler(this.btAttProg_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(436, 354);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 20);
            this.label11.TabIndex = 44;
            this.label11.Text = "Gestor:";
            // 
            // cbGestorProg
            // 
            this.cbGestorProg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGestorProg.FormattingEnabled = true;
            this.cbGestorProg.Location = new System.Drawing.Point(441, 378);
            this.cbGestorProg.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbGestorProg.Name = "cbGestorProg";
            this.cbGestorProg.Size = new System.Drawing.Size(300, 28);
            this.cbGestorProg.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(436, 288);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(154, 20);
            this.label6.TabIndex = 42;
            this.label6.Text = "Nível de Experiência:";
            // 
            // btGravarProg
            // 
            this.btGravarProg.Location = new System.Drawing.Point(441, 435);
            this.btGravarProg.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btGravarProg.Name = "btGravarProg";
            this.btGravarProg.Size = new System.Drawing.Size(302, 35);
            this.btGravarProg.TabIndex = 18;
            this.btGravarProg.Text = "Gravar Dados";
            this.btGravarProg.UseVisualStyleBackColor = true;
            this.btGravarProg.Click += new System.EventHandler(this.btGravarProg_Click);
            // 
            // txtPasswordProg
            // 
            this.txtPasswordProg.Location = new System.Drawing.Point(441, 245);
            this.txtPasswordProg.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPasswordProg.Name = "txtPasswordProg";
            this.txtPasswordProg.PasswordChar = '*';
            this.txtPasswordProg.Size = new System.Drawing.Size(300, 26);
            this.txtPasswordProg.TabIndex = 15;
            // 
            // cbNivelProg
            // 
            this.cbNivelProg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNivelProg.FormattingEnabled = true;
            this.cbNivelProg.Location = new System.Drawing.Point(441, 312);
            this.cbNivelProg.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbNivelProg.Name = "cbNivelProg";
            this.cbNivelProg.Size = new System.Drawing.Size(300, 28);
            this.cbNivelProg.TabIndex = 16;
            this.cbNivelProg.Click += new System.EventHandler(this.s);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(436, 220);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 20);
            this.label7.TabIndex = 39;
            this.label7.Text = "Password:";
            // 
            // txtUsernameProg
            // 
            this.txtUsernameProg.Location = new System.Drawing.Point(441, 183);
            this.txtUsernameProg.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtUsernameProg.Name = "txtUsernameProg";
            this.txtUsernameProg.Size = new System.Drawing.Size(300, 26);
            this.txtUsernameProg.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(436, 158);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 20);
            this.label8.TabIndex = 37;
            this.label8.Text = "Username:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lstListaProgramadores);
            this.groupBox4.Location = new System.Drawing.Point(9, 29);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox4.Size = new System.Drawing.Size(411, 700);
            this.groupBox4.TabIndex = 32;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Lista";
            // 
            // lstListaProgramadores
            // 
            this.lstListaProgramadores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstListaProgramadores.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstListaProgramadores.FormattingEnabled = true;
            this.lstListaProgramadores.ItemHeight = 25;
            this.lstListaProgramadores.Location = new System.Drawing.Point(4, 24);
            this.lstListaProgramadores.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lstListaProgramadores.Name = "lstListaProgramadores";
            this.lstListaProgramadores.Size = new System.Drawing.Size(403, 671);
            this.lstListaProgramadores.TabIndex = 11;
            this.lstListaProgramadores.SelectedIndexChanged += new System.EventHandler(this.lstListaProgramadores_SelectedIndexChanged);
            // 
            // txtIdProg
            // 
            this.txtIdProg.Enabled = false;
            this.txtIdProg.Location = new System.Drawing.Point(441, 54);
            this.txtIdProg.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtIdProg.Name = "txtIdProg";
            this.txtIdProg.ReadOnly = true;
            this.txtIdProg.Size = new System.Drawing.Size(91, 26);
            this.txtIdProg.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(436, 29);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 20);
            this.label9.TabIndex = 33;
            this.label9.Text = "Id:";
            // 
            // txtNomeProg
            // 
            this.txtNomeProg.Location = new System.Drawing.Point(441, 123);
            this.txtNomeProg.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNomeProg.Name = "txtNomeProg";
            this.txtNomeProg.Size = new System.Drawing.Size(300, 26);
            this.txtNomeProg.TabIndex = 13;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(436, 98);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 20);
            this.label10.TabIndex = 35;
            this.label10.Text = "Nome:";
            // 
            // frmGereUtilizadores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1576, 775);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmGereUtilizadores";
            this.Text = "iTask - Formulário Utilizadores";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btGravarGestor;
        private System.Windows.Forms.TextBox txtNomeGestor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtIdGestor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lstListaGestores;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtPasswordGestor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUsernameGestor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkGereUtilizadores;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbDepartamento;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btGravarProg;
        private System.Windows.Forms.TextBox txtPasswordProg;
        private System.Windows.Forms.ComboBox cbNivelProg;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtUsernameProg;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListBox lstListaProgramadores;
        private System.Windows.Forms.TextBox txtIdProg;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtNomeProg;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbGestorProg;
        private System.Windows.Forms.Button btApagarGestor;
        private System.Windows.Forms.Button btAttGestor;
        private System.Windows.Forms.Button btApagarProg;
        private System.Windows.Forms.Button btAttProg;
        private System.Windows.Forms.Button btCleanGestor;
        private System.Windows.Forms.Button btCleanProg;
    }
}