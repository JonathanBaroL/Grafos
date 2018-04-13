namespace EditorDeGrafosV1._0
{
    partial class Editor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Editor));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mArchivo = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mGrafo = new System.Windows.Forms.ToolStripMenuItem();
            this.mGNuevo = new System.Windows.Forms.ToolStripMenuItem();
            this.mGNDirigido = new System.Windows.Forms.ToolStripMenuItem();
            this.mGNNDirigido = new System.Windows.Forms.ToolStripMenuItem();
            this.mVertice = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.numerosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.letrasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarNombreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.propiedadesDelGrafoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gradoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mayorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mArista = new System.Windows.Forms.ToolStripMenuItem();
            this.mACrear = new System.Windows.Forms.ToolStripMenuItem();
            this.mLista = new System.Windows.Forms.ToolStripMenuItem();
            this.recorrerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mLRrelaciones = new System.Windows.Forms.ToolStripMenuItem();
            this.mAyuda = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.reproductor = new AxWMPLib.AxWindowsMediaPlayer();
            this.btnTutorial = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnOmitir2 = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnDirigido = new System.Windows.Forms.Button();
            this.btnNoDirigido = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.lbGrafo = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reproductor)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mArchivo,
            this.mGrafo,
            this.mVertice,
            this.propiedadesDelGrafoToolStripMenuItem,
            this.mArista,
            this.mLista,
            this.mAyuda});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1348, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mArchivo
            // 
            this.mArchivo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem1,
            this.abrirToolStripMenuItem,
            this.guardarToolStripMenuItem});
            this.mArchivo.ForeColor = System.Drawing.SystemColors.Window;
            this.mArchivo.Name = "mArchivo";
            this.mArchivo.Size = new System.Drawing.Size(71, 24);
            this.mArchivo.Text = "Archivo";
            // 
            // nuevoToolStripMenuItem1
            // 
            this.nuevoToolStripMenuItem1.Name = "nuevoToolStripMenuItem1";
            this.nuevoToolStripMenuItem1.Size = new System.Drawing.Size(137, 26);
            this.nuevoToolStripMenuItem1.Text = "Nuevo";
            this.nuevoToolStripMenuItem1.Click += new System.EventHandler(this.nuevoToolStripMenuItem1_Click);
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(137, 26);
            this.abrirToolStripMenuItem.Text = "Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(137, 26);
            this.guardarToolStripMenuItem.Text = "Guardar";
            this.guardarToolStripMenuItem.Click += new System.EventHandler(this.guardarToolStripMenuItem_Click);
            // 
            // mGrafo
            // 
            this.mGrafo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mGNuevo});
            this.mGrafo.ForeColor = System.Drawing.SystemColors.Window;
            this.mGrafo.Name = "mGrafo";
            this.mGrafo.Size = new System.Drawing.Size(58, 24);
            this.mGrafo.Text = "Grafo";
            // 
            // mGNuevo
            // 
            this.mGNuevo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mGNDirigido,
            this.mGNNDirigido});
            this.mGNuevo.Name = "mGNuevo";
            this.mGNuevo.Size = new System.Drawing.Size(181, 26);
            this.mGNuevo.Text = "Nuevo";
            // 
            // mGNDirigido
            // 
            this.mGNDirigido.Name = "mGNDirigido";
            this.mGNDirigido.Size = new System.Drawing.Size(181, 26);
            this.mGNDirigido.Text = "Dirigido";
            this.mGNDirigido.Click += new System.EventHandler(this.mGNDirigido_Click);
            // 
            // mGNNDirigido
            // 
            this.mGNNDirigido.Name = "mGNNDirigido";
            this.mGNNDirigido.Size = new System.Drawing.Size(181, 26);
            this.mGNNDirigido.Text = "No dirigido";
            this.mGNNDirigido.Click += new System.EventHandler(this.mGNNDirigido_Click);
            // 
            // mVertice
            // 
            this.mVertice.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem,
            this.eliminarToolStripMenuItem});
            this.mVertice.ForeColor = System.Drawing.SystemColors.Window;
            this.mVertice.Name = "mVertice";
            this.mVertice.Size = new System.Drawing.Size(66, 24);
            this.mVertice.Text = "Vertice";
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.numerosToolStripMenuItem,
            this.letrasToolStripMenuItem,
            this.agregarNombreToolStripMenuItem});
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(138, 26);
            this.nuevoToolStripMenuItem.Text = "Nuevo";
            // 
            // numerosToolStripMenuItem
            // 
            this.numerosToolStripMenuItem.Name = "numerosToolStripMenuItem";
            this.numerosToolStripMenuItem.Size = new System.Drawing.Size(197, 26);
            this.numerosToolStripMenuItem.Text = "Numeros";
            this.numerosToolStripMenuItem.Click += new System.EventHandler(this.numerosToolStripMenuItem_Click);
            // 
            // letrasToolStripMenuItem
            // 
            this.letrasToolStripMenuItem.Name = "letrasToolStripMenuItem";
            this.letrasToolStripMenuItem.Size = new System.Drawing.Size(197, 26);
            this.letrasToolStripMenuItem.Text = "Letras";
            this.letrasToolStripMenuItem.Click += new System.EventHandler(this.letrasToolStripMenuItem_Click);
            // 
            // agregarNombreToolStripMenuItem
            // 
            this.agregarNombreToolStripMenuItem.Name = "agregarNombreToolStripMenuItem";
            this.agregarNombreToolStripMenuItem.Size = new System.Drawing.Size(197, 26);
            this.agregarNombreToolStripMenuItem.Text = "Agregar Nombre";
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(138, 26);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // propiedadesDelGrafoToolStripMenuItem
            // 
            this.propiedadesDelGrafoToolStripMenuItem.BackColor = System.Drawing.SystemColors.MenuText;
            this.propiedadesDelGrafoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gradoToolStripMenuItem});
            this.propiedadesDelGrafoToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Window;
            this.propiedadesDelGrafoToolStripMenuItem.Name = "propiedadesDelGrafoToolStripMenuItem";
            this.propiedadesDelGrafoToolStripMenuItem.Size = new System.Drawing.Size(170, 24);
            this.propiedadesDelGrafoToolStripMenuItem.Text = "Propiedades del Grafo";
            // 
            // gradoToolStripMenuItem
            // 
            this.gradoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mayorToolStripMenuItem,
            this.menorToolStripMenuItem});
            this.gradoToolStripMenuItem.Name = "gradoToolStripMenuItem";
            this.gradoToolStripMenuItem.Size = new System.Drawing.Size(125, 26);
            this.gradoToolStripMenuItem.Text = "Grado";
            // 
            // mayorToolStripMenuItem
            // 
            this.mayorToolStripMenuItem.Name = "mayorToolStripMenuItem";
            this.mayorToolStripMenuItem.Size = new System.Drawing.Size(127, 26);
            this.mayorToolStripMenuItem.Text = "Mayor";
            this.mayorToolStripMenuItem.Click += new System.EventHandler(this.mayorToolStripMenuItem_Click);
            // 
            // menorToolStripMenuItem
            // 
            this.menorToolStripMenuItem.Name = "menorToolStripMenuItem";
            this.menorToolStripMenuItem.Size = new System.Drawing.Size(127, 26);
            this.menorToolStripMenuItem.Text = "Menor";
            this.menorToolStripMenuItem.Click += new System.EventHandler(this.menorToolStripMenuItem_Click);
            // 
            // mArista
            // 
            this.mArista.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mACrear});
            this.mArista.ForeColor = System.Drawing.SystemColors.Window;
            this.mArista.Name = "mArista";
            this.mArista.Size = new System.Drawing.Size(59, 24);
            this.mArista.Text = "Arista";
            // 
            // mACrear
            // 
            this.mACrear.Name = "mACrear";
            this.mACrear.Size = new System.Drawing.Size(119, 26);
            this.mACrear.Text = "Crear";
            this.mACrear.Click += new System.EventHandler(this.mACrear_Click);
            // 
            // mLista
            // 
            this.mLista.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.recorrerToolStripMenuItem,
            this.mLRrelaciones});
            this.mLista.ForeColor = System.Drawing.SystemColors.Window;
            this.mLista.Name = "mLista";
            this.mLista.Size = new System.Drawing.Size(51, 24);
            this.mLista.Text = "Lista";
            // 
            // recorrerToolStripMenuItem
            // 
            this.recorrerToolStripMenuItem.Name = "recorrerToolStripMenuItem";
            this.recorrerToolStripMenuItem.Size = new System.Drawing.Size(215, 26);
            this.recorrerToolStripMenuItem.Text = "Recorrer";
            this.recorrerToolStripMenuItem.Click += new System.EventHandler(this.recorrerToolStripMenuItem_Click);
            // 
            // mLRrelaciones
            // 
            this.mLRrelaciones.Name = "mLRrelaciones";
            this.mLRrelaciones.Size = new System.Drawing.Size(215, 26);
            this.mLRrelaciones.Text = "Recorrer Relaciones";
            this.mLRrelaciones.Click += new System.EventHandler(this.mLRrelaciones_Click);
            // 
            // mAyuda
            // 
            this.mAyuda.ForeColor = System.Drawing.SystemColors.Window;
            this.mAyuda.Name = "mAyuda";
            this.mAyuda.Size = new System.Drawing.Size(63, 24);
            this.mAyuda.Text = "Ayuda";
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.Black;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton7,
            this.toolStripButton1,
            this.toolStripButton5,
            this.toolStripButton4,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripButton6});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 28);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(41, 683);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.Visible = false;
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton7.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton7.Image")));
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(29, 29);
            this.toolStripButton7.Text = "Mover Grafo";
            this.toolStripButton7.Click += new System.EventHandler(this.toolStripButton7_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(29, 29);
            this.toolStripButton1.Text = "Agregar Vertice";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(29, 29);
            this.toolStripButton5.Text = "Mover Vertice";
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(29, 29);
            this.toolStripButton4.Text = "Agrega Vertice Número";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(29, 29);
            this.toolStripButton2.Text = "Eliminar Vertice";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.AutoSize = false;
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(31, 23);
            this.toolStripButton3.Text = "Agregar Arista";
            this.toolStripButton3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.AutoSize = false;
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(29, 25);
            this.toolStripButton6.Text = "Elimina Arista";
            this.toolStripButton6.Click += new System.EventHandler(this.toolStripButton6_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBox1.Location = new System.Drawing.Point(37, 26);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1311, 685);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // reproductor
            // 
            this.reproductor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reproductor.Enabled = true;
            this.reproductor.Location = new System.Drawing.Point(0, 28);
            this.reproductor.Name = "reproductor";
            this.reproductor.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("reproductor.OcxState")));
            this.reproductor.Size = new System.Drawing.Size(1348, 683);
            this.reproductor.TabIndex = 4;
            this.reproductor.Visible = false;
            // 
            // btnTutorial
            // 
            this.btnTutorial.BackColor = System.Drawing.Color.Navy;
            this.btnTutorial.Font = new System.Drawing.Font("Snap ITC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTutorial.ForeColor = System.Drawing.SystemColors.Window;
            this.btnTutorial.Location = new System.Drawing.Point(552, 366);
            this.btnTutorial.Name = "btnTutorial";
            this.btnTutorial.Size = new System.Drawing.Size(174, 89);
            this.btnTutorial.TabIndex = 5;
            this.btnTutorial.Text = "Iniciar Tutorial?";
            this.btnTutorial.UseVisualStyleBackColor = false;
            this.btnTutorial.Click += new System.EventHandler(this.btnTutorial_Click);
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnNew.Font = new System.Drawing.Font("Snap ITC", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Location = new System.Drawing.Point(552, 138);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(174, 89);
            this.btnNew.TabIndex = 6;
            this.btnNew.Text = "Nuevo Proyecto";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnOmitir_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnOmitir2
            // 
            this.btnOmitir2.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnOmitir2.Font = new System.Drawing.Font("Snap ITC", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOmitir2.Location = new System.Drawing.Point(1147, 674);
            this.btnOmitir2.Name = "btnOmitir2";
            this.btnOmitir2.Size = new System.Drawing.Size(174, 37);
            this.btnOmitir2.TabIndex = 7;
            this.btnOmitir2.Text = "Omitir";
            this.btnOmitir2.UseVisualStyleBackColor = false;
            this.btnOmitir2.Visible = false;
            this.btnOmitir2.Click += new System.EventHandler(this.btnOmitir2_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnOpen.Font = new System.Drawing.Font("Snap ITC", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpen.Location = new System.Drawing.Point(552, 251);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(174, 89);
            this.btnOpen.TabIndex = 8;
            this.btnOpen.Text = "Abrir Proyecto";
            this.btnOpen.UseVisualStyleBackColor = false;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnDirigido
            // 
            this.btnDirigido.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnDirigido.Font = new System.Drawing.Font("Snap ITC", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDirigido.Location = new System.Drawing.Point(316, 277);
            this.btnDirigido.Name = "btnDirigido";
            this.btnDirigido.Size = new System.Drawing.Size(195, 37);
            this.btnDirigido.TabIndex = 9;
            this.btnDirigido.Text = "Dirigido";
            this.btnDirigido.UseVisualStyleBackColor = false;
            this.btnDirigido.Visible = false;
            this.btnDirigido.Click += new System.EventHandler(this.btnDirigido_Click);
            // 
            // btnNoDirigido
            // 
            this.btnNoDirigido.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnNoDirigido.Font = new System.Drawing.Font("Snap ITC", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNoDirigido.Location = new System.Drawing.Point(761, 277);
            this.btnNoDirigido.Name = "btnNoDirigido";
            this.btnNoDirigido.Size = new System.Drawing.Size(195, 37);
            this.btnNoDirigido.TabIndex = 10;
            this.btnNoDirigido.Text = "No dirigido";
            this.btnNoDirigido.UseVisualStyleBackColor = false;
            this.btnNoDirigido.Visible = false;
            this.btnNoDirigido.Click += new System.EventHandler(this.btnNoDirigido_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(1215, 0);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 11;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // lbGrafo
            // 
            this.lbGrafo.AutoSize = true;
            this.lbGrafo.Location = new System.Drawing.Point(1165, 3);
            this.lbGrafo.Name = "lbGrafo";
            this.lbGrafo.Size = new System.Drawing.Size(44, 17);
            this.lbGrafo.TabIndex = 12;
            this.lbGrafo.Text = "Grafo";
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuText;
            this.ClientSize = new System.Drawing.Size(1348, 711);
            this.Controls.Add(this.lbGrafo);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnNoDirigido);
            this.Controls.Add(this.btnDirigido);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.btnOmitir2);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnTutorial);
            this.Controls.Add(this.reproductor);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.Window;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Editor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editor de grafos by Baro";
            this.Load += new System.EventHandler(this.Editor_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reproductor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mArchivo;
        private System.Windows.Forms.ToolStripMenuItem mGrafo;
        private System.Windows.Forms.ToolStripMenuItem mGNuevo;
        private System.Windows.Forms.ToolStripMenuItem mGNDirigido;
        private System.Windows.Forms.ToolStripMenuItem mGNNDirigido;
        private System.Windows.Forms.ToolStripMenuItem mVertice;
        private System.Windows.Forms.ToolStripMenuItem mArista;
        private System.Windows.Forms.ToolStripMenuItem mLista;
        private System.Windows.Forms.ToolStripMenuItem mAyuda;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recorrerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem numerosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem letrasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarNombreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mACrear;
        private System.Windows.Forms.ToolStripMenuItem mLRrelaciones;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private AxWMPLib.AxWindowsMediaPlayer reproductor;
        private System.Windows.Forms.Button btnTutorial;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnOmitir2;
        private System.Windows.Forms.ToolStripMenuItem propiedadesDelGrafoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gradoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mayorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menorToolStripMenuItem;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnDirigido;
        private System.Windows.Forms.Button btnNoDirigido;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label lbGrafo;
    }
}

