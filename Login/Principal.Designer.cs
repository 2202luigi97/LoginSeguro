namespace Login
{
    partial class Principal
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pnMenu = new System.Windows.Forms.Panel();
            this.btnlogout = new System.Windows.Forms.Button();
            this.btnAdmin = new System.Windows.Forms.Button();
            this.btnReporte = new System.Windows.Forms.Button();
            this.btnInventario = new System.Windows.Forms.Button();
            this.btnVentas = new System.Windows.Forms.Button();
            this.tbpageInventario = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbpageBienvenido = new System.Windows.Forms.TabPage();
            this.lbrol = new System.Windows.Forms.Label();
            this.lbnombre = new System.Windows.Forms.Label();
            this.tbpageVentas = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.tbpageReporte = new System.Windows.Forms.TabPage();
            this.tbpageAdmin = new System.Windows.Forms.TabPage();
            this.pbMostrarConstraseña = new System.Windows.Forms.PictureBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbRoles = new System.Windows.Forms.ComboBox();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.dgvUsuario = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.pnMenu.SuspendLayout();
            this.tbpageInventario.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tbpageBienvenido.SuspendLayout();
            this.tbpageVentas.SuspendLayout();
            this.tbpageAdmin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMostrarConstraseña)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuario)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pictureBox5);
            this.panel1.Controls.Add(this.pictureBox6);
            this.panel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(991, 30);
            this.panel1.TabIndex = 21;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox5.Image = global::Login.Properties.Resources.FluentSubtract12Filled;
            this.pictureBox5.Location = new System.Drawing.Point(940, 5);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(20, 20);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 1;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // pictureBox6
            // 
            this.pictureBox6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox6.Image = global::Login.Properties.Resources.MingcuteCloseFill;
            this.pictureBox6.Location = new System.Drawing.Point(964, 5);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(20, 20);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 0;
            this.pictureBox6.TabStop = false;
            this.pictureBox6.Click += new System.EventHandler(this.pictureBox6_Click);
            // 
            // pnMenu
            // 
            this.pnMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.pnMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnMenu.Controls.Add(this.btnlogout);
            this.pnMenu.Controls.Add(this.btnAdmin);
            this.pnMenu.Controls.Add(this.btnReporte);
            this.pnMenu.Controls.Add(this.btnInventario);
            this.pnMenu.Controls.Add(this.btnVentas);
            this.pnMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnMenu.Location = new System.Drawing.Point(0, 30);
            this.pnMenu.Name = "pnMenu";
            this.pnMenu.Size = new System.Drawing.Size(141, 413);
            this.pnMenu.TabIndex = 22;
            // 
            // btnlogout
            // 
            this.btnlogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnlogout.FlatAppearance.BorderSize = 0;
            this.btnlogout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(80)))), ((int)(((byte)(99)))));
            this.btnlogout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(80)))), ((int)(((byte)(99)))));
            this.btnlogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnlogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnlogout.ForeColor = System.Drawing.Color.White;
            this.btnlogout.Image = global::Login.Properties.Resources.MdiAccountLock;
            this.btnlogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnlogout.Location = new System.Drawing.Point(0, 140);
            this.btnlogout.Name = "btnlogout";
            this.btnlogout.Size = new System.Drawing.Size(140, 35);
            this.btnlogout.TabIndex = 5;
            this.btnlogout.Text = "          Cerrar Sesión";
            this.btnlogout.UseVisualStyleBackColor = true;
            this.btnlogout.Click += new System.EventHandler(this.btnlogout_Click);
            // 
            // btnAdmin
            // 
            this.btnAdmin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdmin.FlatAppearance.BorderSize = 0;
            this.btnAdmin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(80)))), ((int)(((byte)(99)))));
            this.btnAdmin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(80)))), ((int)(((byte)(99)))));
            this.btnAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdmin.ForeColor = System.Drawing.Color.White;
            this.btnAdmin.Image = global::Login.Properties.Resources.MdiSecurity;
            this.btnAdmin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdmin.Location = new System.Drawing.Point(0, 105);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(140, 35);
            this.btnAdmin.TabIndex = 4;
            this.btnAdmin.Text = "            Administración";
            this.btnAdmin.UseVisualStyleBackColor = true;
            this.btnAdmin.Click += new System.EventHandler(this.btnAdmin_Click);
            // 
            // btnReporte
            // 
            this.btnReporte.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReporte.FlatAppearance.BorderSize = 0;
            this.btnReporte.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(80)))), ((int)(((byte)(99)))));
            this.btnReporte.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(80)))), ((int)(((byte)(99)))));
            this.btnReporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReporte.ForeColor = System.Drawing.Color.White;
            this.btnReporte.Image = global::Login.Properties.Resources.MdiFileChart;
            this.btnReporte.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReporte.Location = new System.Drawing.Point(0, 70);
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Size = new System.Drawing.Size(140, 35);
            this.btnReporte.TabIndex = 3;
            this.btnReporte.Text = "  Reportes";
            this.btnReporte.UseVisualStyleBackColor = true;
            // 
            // btnInventario
            // 
            this.btnInventario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInventario.FlatAppearance.BorderSize = 0;
            this.btnInventario.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(80)))), ((int)(((byte)(99)))));
            this.btnInventario.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(80)))), ((int)(((byte)(99)))));
            this.btnInventario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInventario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInventario.ForeColor = System.Drawing.Color.White;
            this.btnInventario.Image = global::Login.Properties.Resources.MdiWarehouse;
            this.btnInventario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInventario.Location = new System.Drawing.Point(0, 35);
            this.btnInventario.Name = "btnInventario";
            this.btnInventario.Size = new System.Drawing.Size(140, 35);
            this.btnInventario.TabIndex = 2;
            this.btnInventario.Text = "    Inventario";
            this.btnInventario.UseVisualStyleBackColor = true;
            this.btnInventario.Click += new System.EventHandler(this.btnInventario_Click);
            // 
            // btnVentas
            // 
            this.btnVentas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVentas.FlatAppearance.BorderSize = 0;
            this.btnVentas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(80)))), ((int)(((byte)(99)))));
            this.btnVentas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(80)))), ((int)(((byte)(99)))));
            this.btnVentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVentas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVentas.ForeColor = System.Drawing.Color.White;
            this.btnVentas.Image = global::Login.Properties.Resources.MdiCart__2_;
            this.btnVentas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVentas.Location = new System.Drawing.Point(0, 0);
            this.btnVentas.Name = "btnVentas";
            this.btnVentas.Size = new System.Drawing.Size(140, 35);
            this.btnVentas.TabIndex = 1;
            this.btnVentas.Text = "            Ventas";
            this.btnVentas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVentas.UseVisualStyleBackColor = true;
            this.btnVentas.Click += new System.EventHandler(this.btnVentas_Click);
            // 
            // tbpageInventario
            // 
            this.tbpageInventario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(80)))), ((int)(((byte)(99)))));
            this.tbpageInventario.Controls.Add(this.label1);
            this.tbpageInventario.Location = new System.Drawing.Point(4, 5);
            this.tbpageInventario.Name = "tbpageInventario";
            this.tbpageInventario.Padding = new System.Windows.Forms.Padding(3);
            this.tbpageInventario.Size = new System.Drawing.Size(842, 404);
            this.tbpageInventario.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.label1.Location = new System.Drawing.Point(176, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Formulario Inventario";
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tbpageBienvenido);
            this.tabControl1.Controls.Add(this.tbpageVentas);
            this.tabControl1.Controls.Add(this.tbpageInventario);
            this.tabControl1.Controls.Add(this.tbpageReporte);
            this.tabControl1.Controls.Add(this.tbpageAdmin);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(0, 1);
            this.tabControl1.Location = new System.Drawing.Point(141, 30);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(1, 1);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(850, 413);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 23;
            // 
            // tbpageBienvenido
            // 
            this.tbpageBienvenido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(80)))), ((int)(((byte)(99)))));
            this.tbpageBienvenido.Controls.Add(this.lbrol);
            this.tbpageBienvenido.Controls.Add(this.lbnombre);
            this.tbpageBienvenido.Location = new System.Drawing.Point(4, 5);
            this.tbpageBienvenido.Name = "tbpageBienvenido";
            this.tbpageBienvenido.Size = new System.Drawing.Size(842, 404);
            this.tbpageBienvenido.TabIndex = 2;
            this.tbpageBienvenido.Text = "tabPage1";
            // 
            // lbrol
            // 
            this.lbrol.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbrol.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.lbrol.Location = new System.Drawing.Point(11, 203);
            this.lbrol.Name = "lbrol";
            this.lbrol.Size = new System.Drawing.Size(817, 25);
            this.lbrol.TabIndex = 2;
            this.lbrol.Text = "Rol";
            this.lbrol.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbnombre
            // 
            this.lbnombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbnombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.lbnombre.Location = new System.Drawing.Point(11, 161);
            this.lbnombre.Name = "lbnombre";
            this.lbnombre.Size = new System.Drawing.Size(817, 25);
            this.lbnombre.TabIndex = 1;
            this.lbnombre.Text = "Bienvenido ";
            this.lbnombre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbpageVentas
            // 
            this.tbpageVentas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(80)))), ((int)(((byte)(99)))));
            this.tbpageVentas.Controls.Add(this.label2);
            this.tbpageVentas.Location = new System.Drawing.Point(4, 5);
            this.tbpageVentas.Name = "tbpageVentas";
            this.tbpageVentas.Padding = new System.Windows.Forms.Padding(3);
            this.tbpageVentas.Size = new System.Drawing.Size(842, 404);
            this.tbpageVentas.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.label2.Location = new System.Drawing.Point(176, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(187, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Formulario Ventas";
            // 
            // tbpageReporte
            // 
            this.tbpageReporte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(80)))), ((int)(((byte)(99)))));
            this.tbpageReporte.Location = new System.Drawing.Point(4, 5);
            this.tbpageReporte.Name = "tbpageReporte";
            this.tbpageReporte.Size = new System.Drawing.Size(842, 404);
            this.tbpageReporte.TabIndex = 3;
            // 
            // tbpageAdmin
            // 
            this.tbpageAdmin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(80)))), ((int)(((byte)(99)))));
            this.tbpageAdmin.Controls.Add(this.pbMostrarConstraseña);
            this.tbpageAdmin.Controls.Add(this.txtPassword);
            this.tbpageAdmin.Controls.Add(this.label8);
            this.tbpageAdmin.Controls.Add(this.label6);
            this.tbpageAdmin.Controls.Add(this.txtUsuario);
            this.tbpageAdmin.Controls.Add(this.label5);
            this.tbpageAdmin.Controls.Add(this.txtCorreo);
            this.tbpageAdmin.Controls.Add(this.label4);
            this.tbpageAdmin.Controls.Add(this.txtNombre);
            this.tbpageAdmin.Controls.Add(this.label3);
            this.tbpageAdmin.Controls.Add(this.cmbRoles);
            this.tbpageAdmin.Controls.Add(this.txtBuscar);
            this.tbpageAdmin.Controls.Add(this.dgvUsuario);
            this.tbpageAdmin.Location = new System.Drawing.Point(4, 5);
            this.tbpageAdmin.Name = "tbpageAdmin";
            this.tbpageAdmin.Size = new System.Drawing.Size(842, 404);
            this.tbpageAdmin.TabIndex = 4;
            this.tbpageAdmin.Text = "tabPage1";
            // 
            // pbMostrarConstraseña
            // 
            this.pbMostrarConstraseña.BackColor = System.Drawing.Color.White;
            this.pbMostrarConstraseña.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbMostrarConstraseña.Image = global::Login.Properties.Resources.PhEyeThin;
            this.pbMostrarConstraseña.Location = new System.Drawing.Point(343, 65);
            this.pbMostrarConstraseña.Name = "pbMostrarConstraseña";
            this.pbMostrarConstraseña.Size = new System.Drawing.Size(20, 20);
            this.pbMostrarConstraseña.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbMostrarConstraseña.TabIndex = 24;
            this.pbMostrarConstraseña.TabStop = false;
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(165, 65);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(200, 22);
            this.txtPassword.TabIndex = 22;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(80, 68);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 17);
            this.label8.TabIndex = 23;
            this.label8.Text = "Password";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(660, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 16);
            this.label6.TabIndex = 9;
            this.label6.Text = "Usuario";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.Location = new System.Drawing.Point(720, 21);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(90, 22);
            this.txtUsuario.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(379, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "Correo";
            // 
            // txtCorreo
            // 
            this.txtCorreo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCorreo.Location = new System.Drawing.Point(433, 21);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(215, 22);
            this.txtCorreo.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(32, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Nombre Completo";
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(155, 21);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(207, 22);
            this.txtNombre.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(382, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Rol:";
            // 
            // cmbRoles
            // 
            this.cmbRoles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRoles.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRoles.FormattingEnabled = true;
            this.cmbRoles.Location = new System.Drawing.Point(419, 65);
            this.cmbRoles.Name = "cmbRoles";
            this.cmbRoles.Size = new System.Drawing.Size(121, 24);
            this.cmbRoles.TabIndex = 2;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.Location = new System.Drawing.Point(15, 159);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(162, 22);
            this.txtBuscar.TabIndex = 1;
            // 
            // dgvUsuario
            // 
            this.dgvUsuario.AllowUserToAddRows = false;
            this.dgvUsuario.AllowUserToDeleteRows = false;
            this.dgvUsuario.AllowUserToResizeColumns = false;
            this.dgvUsuario.AllowUserToResizeRows = false;
            this.dgvUsuario.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(80)))), ((int)(((byte)(99)))));
            this.dgvUsuario.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUsuario.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvUsuario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuario.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUsuario.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgvUsuario.Location = new System.Drawing.Point(11, 187);
            this.dgvUsuario.MultiSelect = false;
            this.dgvUsuario.Name = "dgvUsuario";
            this.dgvUsuario.ReadOnly = true;
            this.dgvUsuario.RowHeadersVisible = false;
            this.dgvUsuario.Size = new System.Drawing.Size(819, 209);
            this.dgvUsuario.TabIndex = 0;
            this.dgvUsuario.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsuario_CellClick);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(80)))), ((int)(((byte)(99)))));
            this.ClientSize = new System.Drawing.Size(991, 443);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.pnMenu);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Principal";
            this.Load += new System.EventHandler(this.Principal_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.pnMenu.ResumeLayout(false);
            this.tbpageInventario.ResumeLayout(false);
            this.tbpageInventario.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tbpageBienvenido.ResumeLayout(false);
            this.tbpageVentas.ResumeLayout(false);
            this.tbpageVentas.PerformLayout();
            this.tbpageAdmin.ResumeLayout(false);
            this.tbpageAdmin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMostrarConstraseña)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuario)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnVentas;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Panel pnMenu;
        private System.Windows.Forms.Button btnAdmin;
        private System.Windows.Forms.Button btnReporte;
        private System.Windows.Forms.Button btnInventario;
        private System.Windows.Forms.Button btnlogout;
        private System.Windows.Forms.TabPage tbpageInventario;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbpageVentas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tbpageBienvenido;
        private System.Windows.Forms.Label lbnombre;
        private System.Windows.Forms.Label lbrol;
        private System.Windows.Forms.TabPage tbpageReporte;
        private System.Windows.Forms.TabPage tbpageAdmin;
        private System.Windows.Forms.DataGridView dgvUsuario;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.ComboBox cmbRoles;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.PictureBox pbMostrarConstraseña;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label8;
    }
}