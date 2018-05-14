using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;

namespace EditorDeGrafosV1._0
{
    public partial class Editor : Form
    {
        private List<Grafo> lisGrafo;
        public List<Arista> auxListaArista;
        public int dibuja = 0, dibujaClick = 0, mover = 0, elimina = 0, inc = 0, inc2 = 0, creaArista = 0, creaSpline = 0, conRela = 1;
        public int arraFlecha = 0, vGrado = 0, gmover = 0;
        public int fx, fy, grafo = 0, contGrafo = 0;
        string abc = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyz";
        public string auxName;
        private Vertice auxVert;
        private Arista newAristaSpline;
        private int dx;
        private int dy;
        private int dx1;
        private int dy1;
        public int aux1 = 0, aux2 = 0, dibujaCur = 0;
        public Point[] points;
        Grafo auxGrafo;
        Pen pen = new Pen(Color.Black, 2);
        Pen lapiz2 = new Pen(Color.Black, 3);
        private int grafoActual;
        private int agregaPeso = 0;

        public Editor()
        {
            InitializeComponent();
            lisGrafo = new List<Grafo>();
            auxVert = new Vertice();
            grafo = comboBox1.SelectedIndex;
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            elimina = 1;
            dibuja = 0;
            creaArista = 0;
        }

        private void mLRrelaciones_Click(object sender, EventArgs e)
        {
            for (int j = 0; j < lisGrafo[grafoActual].ListaVert.Count; j++)
            {
                MessageBox.Show("Vertice" + lisGrafo[grafoActual].ListaVert[j].Name);
                for (int k = 0; k < lisGrafo[grafoActual].ListaVert[j].listaVert.Count; k++)
                {
                    MessageBox.Show(lisGrafo[grafoActual].ListaVert[j].listaVert[k].Name);
                }

            }
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnDirigido.Visible = false;
            btnNoDirigido.Visible = false;
            OpenFileDialog open;



            DialogResult b = MessageBox.Show("¿Desea guardar?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (b == DialogResult.Yes)
            {
                guardarToolStripMenuItem_Click(sender, e);
                lisGrafo.Clear();
                open = new OpenFileDialog();
                if (open.ShowDialog() == DialogResult.OK)
                {
                    Stream st = File.Open(open.FileName, FileMode.Open);
                    BinaryFormatter bin = new BinaryFormatter();
                    lisGrafo = (List<Grafo>)bin.Deserialize(st);
                    st.Close();
                }
            }
            else
            {
                open = new OpenFileDialog();
                if (open.ShowDialog() == DialogResult.OK)
                {
                    Stream st = File.Open(open.FileName, FileMode.Open);
                    BinaryFormatter bin = new BinaryFormatter();
                    lisGrafo = (List<Grafo>)bin.Deserialize(st);
                    st.Close();
                }
            }

            contGrafo = 0;
            comboBox1.Items.Clear();
            for (int i = 0; i<lisGrafo.Count;i++)
            {
                comboBox1.Items.Add(contGrafo);
                comboBox1.Text = contGrafo.ToString();
                contGrafo++;
            }


            pictureBox1.Visible = true;
            toolStrip1.Visible = true;
            pictureBox1.Invalidate();
            this.Invalidate();
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //guarda en un archivo de texto

            SaveFileDialog saveDialog = new SaveFileDialog();

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                Stream st = File.Open(saveDialog.FileName, FileMode.Create);
                BinaryFormatter bin = new BinaryFormatter();
                bin.Serialize(st, lisGrafo);
                st.Close();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            dibuja = 1;
            elimina = 0;
            creaArista = 0;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            elimina = 1;
            dibuja = 0;
            creaArista = 0;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {

            try
            {
                if (lisGrafo[grafoActual].Tipo == 1)
                {

                    creaArista = 1;
                }
                else
                {
                    creaArista = 3;
                }
                dibuja = 0;
                elimina = 0;
            }
            catch
            {
                MessageBox.Show("Selecciona Grafo");
            }

        }

        private void letrasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dibuja = 2;
            elimina = 0;
            creaArista = 0;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            dibuja = 2;
            elimina = 0;
            creaArista = 0;
        }

        private void mACrear_Click(object sender, EventArgs e)
        {
            if (lisGrafo[grafoActual].Tipo == 1)
            {
                creaArista = 1;
            }
            else
            {
                creaArista = 3;
            }
            dibuja = 0;
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            mover = 1;
            creaArista = 0;
            dibuja = 0;
            elimina = 0;
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            elimina = 2;
            creaArista = 0;
        }

        private void btnTutorial_Click(object sender, EventArgs e)
        {
            reproductor.Visible = true;
            reproductor.Ctlcontrols.play();
            btnTutorial.Visible = false;
            btnNew.Visible = false;
            btnOpen.Visible = false;
            btnOmitir2.Visible = true;
        }

        private void btnOmitir_Click(object sender, EventArgs e)
        {

            btnTutorial.Visible = false;
            btnNew.Visible = false;
            btnOpen.Visible = false;
            btnDirigido.Visible = true;
            btnNoDirigido.Visible = true;
        }

        private void btnOmitir2_Click(object sender, EventArgs e)
        {
            reproductor.Ctlcontrols.stop();
            reproductor.Visible = false;
            btnOmitir2.Visible = false;
            btnOpen.Visible = true;
            btnNew.Visible = true;
            btnTutorial.Visible = true;
        }

        private void btnDirigido_Click(object sender, EventArgs e)
        {
            lisGrafo.Clear();
            toolStripButton3.Image = Bitmap.FromFile("dirigida.png");
            btnDirigido.Visible = false;
            btnNoDirigido.Visible = false;
            pictureBox1.Visible = true;
            toolStrip1.Visible = true;
            Grafo newGrafo = new Grafo();
            newGrafo.Tipo = 1;
            newGrafo.Name = "D";
            lisGrafo.Add(newGrafo);
            comboBox1.Items.Add(contGrafo);
            comboBox1.Text = contGrafo.ToString();
            contGrafo++;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            btnNew.Visible = false;
            btnOpen.Visible = false;
            btnTutorial.Visible = false;
            OpenFileDialog open;
            open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                Stream st = File.Open(open.FileName, FileMode.Open);
                BinaryFormatter bin = new BinaryFormatter();
                lisGrafo = (List<Grafo>)bin.Deserialize(st);
                st.Close();
            }

            contGrafo = 0;
            comboBox1.Items.Clear();
            for (int i = 0; i < lisGrafo.Count; i++)
            {
                comboBox1.Items.Add(contGrafo);
                comboBox1.Text = contGrafo.ToString();
                contGrafo++;
            }

            pictureBox1.Visible = true;
            toolStrip1.Visible = true;
            pictureBox1.Invalidate();
            this.Invalidate();
        }

        private void btnNoDirigido_Click(object sender, EventArgs e)
        {
            lisGrafo.Clear();
            toolStripButton3.Image = Bitmap.FromFile("nodirigida.png");
            creaArista = 3;
            btnDirigido.Visible = false;
            btnNoDirigido.Visible = false;
            pictureBox1.Visible = true;
            toolStrip1.Visible = true;
            Grafo newGrafo = new Grafo();
            newGrafo.Tipo = 2;
            newGrafo.Name = "ND";
            lisGrafo.Add(newGrafo);
            comboBox1.Items.Add(contGrafo);
            comboBox1.Text = contGrafo.ToString();
            contGrafo++;
        }

        private void Editor_Load(object sender, EventArgs e)
        {
            reproductor.Ctlcontrols.stop();
        }

        private void mayorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            vGrado = 1;
            dibuja = 0;
            elimina = 0;
            creaArista = 0;
        }

        private void menorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            vGrado = 2;
            dibuja = 0;
            elimina = 0;
            creaArista = 0;
        }

        private void mGNNDirigido_Click(object sender, EventArgs e)
        {
            creaArista = 3;
            btnDirigido.Visible = false;
            toolStripButton3.Image = Bitmap.FromFile("nodirigida.png");
            btnNoDirigido.Visible = false;
            pictureBox1.Visible = true;
            toolStrip1.Visible = true;
            Grafo newGrafo = new Grafo();
            newGrafo.Tipo = 2;
            newGrafo.Name = "ND";
            lisGrafo.Add(newGrafo);
            comboBox1.Items.Add(contGrafo);
            comboBox1.Text = contGrafo.ToString();
            contGrafo++;
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            gmover = 2;
            creaArista = 0;
            elimina = 0;
            dibuja = 0;
            mover = 0;
            auxGrafo = lisGrafo[grafoActual];
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            if (lisGrafo[grafoActual].Tipo == 1)
            {
                creaSpline = 1;
            }
            dibuja = 0;
            elimina = 0;
            creaArista = 0;
        }

        private void nuevoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            toolStrip1.Visible = false;
            btnDirigido.Visible = true;
            btnNoDirigido.Visible = true;
            contGrafo = 0;
            inc = 0;
            inc2 = 0;

        }

        private void mGNDirigido_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            toolStripButton3.Image = Bitmap.FromFile("dirigida.png");
            toolStrip1.Visible = true;
            Grafo newGrafo = new Grafo();
            newGrafo.Tipo = 1;
            newGrafo.Name = "D";
            lisGrafo.Add(newGrafo);
            comboBox1.Items.Add(contGrafo);
            comboBox1.Text = contGrafo.ToString();
            contGrafo++;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            grafoActual = comboBox1.SelectedIndex;
        }

        private void matrizDeAdyacenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            auxListaArista = lisGrafo[grafoActual].ListaArista;
            Matriz m = new Matriz(auxListaArista, lisGrafo[grafoActual].ListaVert, 1);
            m.Show();

        }

        private void listaDeAdyacenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            auxListaArista = lisGrafo[grafoActual].ListaArista;
            Matriz m = new Matriz(auxListaArista, lisGrafo[grafoActual].ListaVert, 2);
            m.Show();
        }

        private void matrizDeIncidenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            auxListaArista = lisGrafo[grafoActual].ListaArista;
            Matriz m = new Matriz(auxListaArista, lisGrafo[grafoActual].ListaVert, 3);
            m.Show();
        }

        private void medioKuratowskyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            medioKuratowsky();
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            dibujaCur = 1;
            pictureBox1.Invalidate();
        }

        private void tsIsomorfo_Click(object sender, EventArgs e)
        {
            isomorfismo();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (dibujaCur == 1)
            {
                dibujaCurva(e, 10, 50, 50, 40, 100, 40, 150, 50);
            }
            if (arraFlecha == 1)
            {
                Pen lapiz2 = new Pen(Color.Black, 5);
                lapiz2.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
                e.Graphics.DrawLine(lapiz2, auxVert.X, auxVert.Y, fx, fy);
            }
            if (arraFlecha == 2)
            {
                Pen lapiz2 = new Pen(Color.Black, 5);
                e.Graphics.DrawLine(lapiz2, auxVert.X, auxVert.Y, fx, fy);
            }
            if (arraFlecha == 3)
            {
                Pen lapiz2 = new Pen(Color.Black, 5);
                lapiz2.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
                e.Graphics.DrawLine(lapiz2, auxVert.X, auxVert.Y, fx, fy);
            }
            if (creaSpline == 3)
            {
                Point[] points = {
                    new Point(newAristaSpline.VI.X, newAristaSpline.VI.Y),
                    new Point(((newAristaSpline.VI.X + newAristaSpline.VF.X) / 2), ((newAristaSpline.VI.Y + newAristaSpline.VF.Y) / 2) + 35),
                    new Point(newAristaSpline.VF.X, newAristaSpline.VF.Y)};

                Pen pen = new Pen(Color.Black, 5);
                e.Graphics.DrawCurve(pen, points);
            }

            for (int i = 0; i < lisGrafo.Count; i++)
            {
                foreach (Vertice elemento in lisGrafo[i].ListaVert)
                {
                    // Dibuja Vertices


                    SolidBrush lapiz  = escogeColor(elemento.ColorVert);
                    Font Font = new Font("arial", 20);
                    int x = elemento.X;
                    int y = elemento.Y;
                    string name = elemento.Name;
                    e.Graphics.FillEllipse(lapiz, x + dx1 - 25, y + dy1 - 25, 50, 50);
                    e.Graphics.DrawString(name, Font, Brushes.Black, x + dx1 - 15, y + dy1 - 15);
                }
            }
            for (int i = 0; i < lisGrafo.Count; i++)
            {
                try
                {
                    foreach (Arista elemento in lisGrafo[i].ListaArista)
                    {
                        try
                        {
                            elemento.AgregaDatos();
                        }
                        catch
                        {
                            lisGrafo[i].ListaArista.Remove(elemento);
                        }
                        int xi = elemento.Xi;
                        int yi = elemento.Yi;
                        int xf = elemento.Xf;
                        int yf = elemento.Yf;

                        if (lisGrafo[i].Tipo == 1)   // si el grafo es dirigido
                        {
                            // si la arista es una linea dibuja lo siguiente                          

                            if (elemento.Tipo == 0)
                            {
                                comoDibuja(elemento, e, xf, xi, yf, yi, 1);
                            }

                            // si la arista es una spline dibuja esto
                            if (elemento.Tipo == 1)
                            {
                                if (elemento.NDArista == 2)
                                {
                                    elemento.NIncr = 45;
                                    comoDibuja(elemento, e, xf, xi, yf, yi, 1);
                                }
                                if (elemento.NDArista == 3)
                                {
                                    elemento.NIncr = -45;
                                    comoDibuja(elemento, e, xf, xi, yf, yi, -1);
                                }
                                if (elemento.NDArista == 4)
                                {
                                    elemento.NIncr = -85;
                                    comoDibuja(elemento, e, xf, xi, yf, yi, 1);
                                }
                                if (elemento.NDArista == 5)
                                {
                                    elemento.NIncr = 85;
                                    comoDibuja(elemento, e, xf, xi, yf, yi, -1);
                                }
                                if (elemento.NDArista == 6)
                                {
                                    elemento.NIncr = -105;
                                    comoDibuja(elemento, e, xf, xi, yf, yi, 1);
                                }
                                if (elemento.NDArista == 7)
                                {
                                    elemento.NIncr = 105;
                                    comoDibuja(elemento, e, xf, xi, yf, yi, -1);
                                }
                            }

                            //si es una oreja dibuja esto
                            if (elemento.Tipo == 2)
                            {
                                comoDibuja(elemento, e, xf, xi, yf, yi, 1);
                            }
                        }

                        // si es grafo no dirigido
                        else
                        {
                            // si la arista es una linea dibuja lo siguiente                          

                            if (elemento.Tipo == 0)
                            {
                                comoDibuja(elemento, e, xf, xi, yf, yi, 1);
                            }

                            // si la arista es una spline dibuja esto
                            if (elemento.Tipo == 1)
                            {
                                if (elemento.NDArista == 2)
                                {
                                    elemento.NIncr = 35;
                                    comoDibuja(elemento, e, xf, xi, yf, yi, 1);
                                }
                                if (elemento.NDArista == 3)
                                {
                                    elemento.NIncr = -35;
                                    comoDibuja(elemento, e, xf, xi, yf, yi, -1);
                                }
                                if (elemento.NDArista == 4)
                                {
                                    elemento.NIncr = -75;
                                    comoDibuja(elemento, e, xf, xi, yf, yi, 1);
                                }
                                if (elemento.NDArista == 5)
                                {
                                    elemento.NIncr = 95;
                                    comoDibuja(elemento, e, xf, xi, yf, yi, -1);
                                }
                            }

                            //si es una oreja dibuja esto
                            if (elemento.Tipo == 2)
                            {
                                comoDibuja(elemento, e, xf, xi, yf, yi, 1);
                            }
                        }
                    }
                }
                catch
                {
                }
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {

                if (dibuja == 1)
                {
                    dibujaClick = 1;
                }
                if (dibuja == 2)
                {
                    dibujaClick = 2;
                }
                for (int j = 0; j < lisGrafo[grafoActual].ListaVert.Count; j++)
                {
                    //if para verificar que elemento es el que estoy dando click
                    if (e.X > lisGrafo[grafoActual].ListaVert[j].X - 25 && e.Y > lisGrafo[grafoActual].ListaVert[j].Y - 25 && e.X < lisGrafo[grafoActual].ListaVert[j].X + 25 && e.Y < lisGrafo[grafoActual].ListaVert[j].Y + 25)
                    {
                        if (creaArista == 1)
                        {
                            arraFlecha = 1;
                            auxVert = lisGrafo[grafoActual].ListaVert[j];
                            mover = 0;
                        }
                        else
                        {
                            mover = 2;
                            dibuja = 0;
                        }
                        if (creaArista == 3)
                        {
                            arraFlecha = 2;
                            auxVert = lisGrafo[grafoActual].ListaVert[j];
                            mover = 0;
                        }
                        if (creaSpline == 1)
                        {
                            arraFlecha = 3;
                            auxVert = lisGrafo[grafoActual].ListaVert[j];
                            mover = 0;
                        }
                        else
                        {
                            mover = 2;
                            dibuja = 0;
                        }

                        if (vGrado == 1)
                        {
                            Point ep = new Point();
                            ep.X = e.X;
                            ep.Y = e.Y;
                            diGrado(ep);
                            vGrado = 0;
                        }
                        if (vGrado == 2)
                        {
                            Point ep = new Point();
                            ep.X = e.X;
                            ep.Y = e.Y;
                            diGrado(ep);
                            vGrado = 0;
                        }
                    }
                }

                if (creaSpline == 2)
                {
                    Arista newArista = new Arista();
                    for (int j = 0; j < lisGrafo[grafoActual].ListaVert.Count; j++)
                    {
                        if (auxVert == lisGrafo[grafoActual].ListaVert[j])
                        {
                            newArista.VI = auxVert;
                        }
                    }
                    for (int j = 0; j < lisGrafo[grafoActual].ListaVert.Count; j++)
                    {
                        if (e.X > lisGrafo[grafoActual].ListaVert[j].X - 25 && e.Y > lisGrafo[grafoActual].ListaVert[j].Y - 25 && e.X < lisGrafo[grafoActual].ListaVert[j].X + 25 && e.Y < lisGrafo[grafoActual].ListaVert[j].Y + 25)
                        {
                            newArista.VF = lisGrafo[grafoActual].ListaVert[j];
                        }
                    }
                    newAristaSpline = newArista;
                    creaSpline = 3;
                    pictureBox1.Invalidate();
                    creaArista = 1;

                }

                if (creaArista == 2)
                {
                    Arista newArista = new Arista();

                    for (int j = 0; j < lisGrafo[grafoActual].ListaVert.Count; j++)
                    {
                        if (auxVert == lisGrafo[grafoActual].ListaVert[j])
                        {
                            newArista.VI = auxVert;
                        }
                    }


                    for (int j = 0; j < lisGrafo[grafoActual].ListaVert.Count; j++)
                    {
                        if (e.X > lisGrafo[grafoActual].ListaVert[j].X - 25 && e.Y > lisGrafo[grafoActual].ListaVert[j].Y - 25 && e.X < lisGrafo[grafoActual].ListaVert[j].X + 25 && e.Y < lisGrafo[grafoActual].ListaVert[j].Y + 25)
                        {
                            newArista.VF = lisGrafo[grafoActual].ListaVert[j];
                        }
                    }

                    int cont = 1;
                    for (int j = 0; j < lisGrafo[grafoActual].ListaArista.Count; j++)
                    {
                        if (newArista.VI.Name == lisGrafo[grafoActual].ListaArista[j].VI.Name && newArista.VF.Name == lisGrafo[grafoActual].ListaArista[j].VF.Name || newArista.VI.Name == lisGrafo[grafoActual].ListaArista[j].VF.Name && newArista.VF.Name == lisGrafo[grafoActual].ListaArista[j].VI.Name)
                        {
                            cont++;
                            if (cont == 2)
                            {
                                lisGrafo[grafoActual].ListaArista[j].Tipo = 1;
                                lisGrafo[grafoActual].ListaArista[j].NDArista = 2;
                                newArista.Tipo = 1;
                                newArista.NDArista = 3;
                            }
                            if (cont == 3)
                            {
                                newArista.Tipo = 0;
                                newArista.NDArista = 1;
                            }
                            if (cont == 4)
                            {
                                newArista.Tipo = 1;
                                newArista.NDArista = 4;
                            }
                            if (cont == 5)
                            {
                                newArista.Tipo = 1;
                                newArista.NDArista = 5;
                            }
                            if (cont == 6)
                            {
                                newArista.Tipo = 1;
                                newArista.NDArista = 6;
                            }
                            if (cont == 7)
                            {
                                newArista.Tipo = 1;
                                newArista.NDArista = 7;
                            }
                        }
                        else
                        {
                            newArista.Tipo = 0;
                            newArista.NDArista = 1;
                        }

                    }

                    if (newArista.VI.Name == newArista.VF.Name)
                    {
                        newArista.Tipo = 2;
                        newArista.NDArista = 1;
                    }

                    lisGrafo[grafoActual].ListaArista.Add(newArista);
                    creaArista = 1;

                }

                if (creaArista == 4)
                {
                    Arista newArista = new Arista();

                    for (int j = 0; j < lisGrafo[grafoActual].ListaVert.Count; j++)
                    {
                        if (auxVert == lisGrafo[grafoActual].ListaVert[j])
                        {
                            newArista.VI = auxVert;
                        }
                    }

                    for (int j = 0; j < lisGrafo[grafoActual].ListaVert.Count; j++)
                    {
                        if (e.X > lisGrafo[grafoActual].ListaVert[j].X - 25 && e.Y > lisGrafo[grafoActual].ListaVert[j].Y - 25 && e.X < lisGrafo[grafoActual].ListaVert[j].X + 25 && e.Y < lisGrafo[grafoActual].ListaVert[j].Y + 25)
                        {
                            newArista.VF = lisGrafo[grafoActual].ListaVert[j];
                        }
                    }
                    int cont = 1;
                    for (int j = 0; j < lisGrafo[grafoActual].ListaArista.Count; j++)
                    {
                        if (newArista.VI.Name == lisGrafo[grafoActual].ListaArista[j].VI.Name && newArista.VF.Name == lisGrafo[grafoActual].ListaArista[j].VF.Name || newArista.VI.Name == lisGrafo[grafoActual].ListaArista[j].VF.Name && newArista.VF.Name == lisGrafo[grafoActual].ListaArista[j].VI.Name)
                        {
                            cont++;
                            if (cont == 2)
                            {
                                lisGrafo[grafoActual].ListaArista[j].Tipo = 1;
                                lisGrafo[grafoActual].ListaArista[j].NDArista = 2;
                                newArista.Tipo = 1;
                                newArista.NDArista = 3;
                            }
                            if (cont == 3)
                            {
                                newArista.Tipo = 0;
                                newArista.NDArista = 1;
                            }
                            if (cont == 4)
                            {
                                newArista.Tipo = 1;
                                newArista.NDArista = 4;
                            }
                            if (cont == 5)
                            {
                                newArista.Tipo = 1;
                                newArista.NDArista = 5;
                            }
                            if (cont == 6)
                            {
                                newArista.Tipo = 1;
                                newArista.NDArista = 6;
                            }
                            if (cont == 7)
                            {
                                newArista.Tipo = 1;
                                newArista.NDArista = 7;
                            }
                        }
                        else if (newArista.VI.Name != lisGrafo[grafoActual].ListaArista[j].VI.Name && newArista.VF.Name != lisGrafo[grafoActual].ListaArista[j].VF.Name)
                        {
                            newArista.Tipo = 0;
                            newArista.NDArista = 1;
                        }
                    }

                    if (newArista.VI.Name == newArista.VF.Name)
                    {
                        newArista.Tipo = 2;
                        newArista.NDArista = 1;
                    }

                    lisGrafo[grafoActual].ListaArista.Add(newArista);
                    creaArista = 3;

                }


                if (agregaPeso == 1)
                {
                    int res = encuentraArista(e);
                    agregaPeso = 0;
                }

                if (elimina == 0)// condiciones para saber si esta eliminando o dibujando al hacer click en el pictureBox
                {
                    if (dibuja == 1)
                    {
                        Vertice vertice = new Vertice();
                        vertice.X = e.X;
                        vertice.Y = e.Y;
                        vertice.Name = Convert.ToString(inc2); //Guardamos el nombre que se dio en el vertice
                        lisGrafo[grafoActual].ListaVert.Add(vertice);
                        pictureBox1.Invalidate();
                        inc2++;
                    }
                    else if (dibuja == 2)
                    {
                        Vertice vertice = new Vertice();

                        vertice.X = e.X;
                        vertice.Y = e.Y;
                        vertice.Name = abc[inc].ToString();
                        lisGrafo[grafoActual].ListaVert.Add(vertice);
                        pictureBox1.Invalidate();
                        inc++;
                    }
                }
                else if (elimina == 1)
                {
                    for (int j = 0; j < lisGrafo[grafoActual].ListaVert.Count; j++)
                    {
                        if (e.X > lisGrafo[grafoActual].ListaVert[j].X - 25 && e.Y > lisGrafo[grafoActual].ListaVert[j].Y - 25 && e.X < lisGrafo[grafoActual].ListaVert[j].X + 25 && e.Y < lisGrafo[grafoActual].ListaVert[j].Y + 25)
                        {
                            Vertice auxV = new Vertice();
                            auxV = lisGrafo[grafoActual].ListaVert[j];
                            for (int a = 0; a < lisGrafo.Count; a++)
                            {
                                int cont = lisGrafo[a].ListaArista.Count;
                                for (int b = 0; b < cont; b++)
                                {
                                    try
                                    {
                                        if (auxV == lisGrafo[a].ListaArista[b].VI)
                                        {
                                            lisGrafo[a].ListaArista.Remove(lisGrafo[a].ListaArista[b]);
                                            b--;
                                        }
                                        else if (auxV == lisGrafo[a].ListaArista[b].VF)
                                        {
                                            lisGrafo[a].ListaArista.Remove(lisGrafo[a].ListaArista[b]);
                                            b--;
                                        }
                                    }
                                    catch
                                    {

                                    }
                                }
                            }
                            auxName = lisGrafo[grafoActual].ListaVert[j].Name;
                            lisGrafo[grafoActual].ListaVert.Remove(lisGrafo[grafoActual].ListaVert[j]);//remueve de la lista el elemento encontrado
                        }
                        if (lisGrafo[grafoActual].ListaVert.Count == 0)
                        {
                            inc = 0;
                        }
                    }
                }
                else if (elimina == 2)
                {
                    int res = eliminaA(e);

                }

                pictureBox1.Invalidate();
            }
            catch
            {
                MessageBox.Show("Selecciona accion");
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (gmover == 2)
            {
                gmover = 3;
                dx = e.X;
                dy = e.Y;
            }
            for (int j = 0; j < lisGrafo[grafoActual].ListaVert.Count; j++)
            {
                if (e.X > lisGrafo[grafoActual].ListaVert[j].X - 25 && e.Y > lisGrafo[grafoActual].ListaVert[j].Y - 25 && e.X < lisGrafo[grafoActual].ListaVert[j].X + 25 && e.Y < lisGrafo[grafoActual].ListaVert[j].Y + 25)
                {
                    if (creaArista == 1)
                    {
                        arraFlecha = 1;
                        auxVert = lisGrafo[grafoActual].ListaVert[j];
                        mover = 0;
                    }
                    else
                    {
                        mover = 2;
                        dibuja = 0;
                    }
                    if (creaArista == 3)
                    {
                        arraFlecha = 2;
                        auxVert = lisGrafo[grafoActual].ListaVert[j];
                        mover = 0;
                    }
                    if (creaArista == 0)
                    {
                        mover = 2;
                    }
                }
            }
            //arraFlecha = 0;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (gmover == 3)
            {
                dx1 = e.X - dx;
                dy1 = e.Y - dy;
                pictureBox1.Invalidate();
            }
            if (arraFlecha == 1)
            {
                fx = e.X;
                fy = e.Y;
                pictureBox1.Invalidate();
                creaArista = 2;
            }
            if (arraFlecha == 2)
            {
                fx = e.X;
                fy = e.Y;
                pictureBox1.Invalidate();
                creaArista = 4;
            }
            if (arraFlecha == 3)
            {
                fx = e.X;
                fy = e.Y;
                pictureBox1.Invalidate();
                creaSpline = 2;
            }
            if (mover == 2)
            {
                int Bv = 0;
                Vertice auxVertm = new Vertice();
                for (int j = 0; j < lisGrafo[grafoActual].ListaVert.Count; j++)
                {
                    if (e.X > lisGrafo[grafoActual].ListaVert[j].X - 25 && e.Y > lisGrafo[grafoActual].ListaVert[j].Y - 25 && e.X < lisGrafo[grafoActual].ListaVert[j].X + 25 && e.Y < lisGrafo[grafoActual].ListaVert[j].Y + 25)
                    {
                        auxVertm = lisGrafo[grafoActual].ListaVert[j];
                        Bv = 1;
                    }
                }
                if (Bv == 1)
                {
                    auxVertm.X = e.X;
                    auxVertm.Y = e.Y;
                }
                pictureBox1.Invalidate();
            }
        }

        private void agregaGradosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            agregaGrado();
        }

        private void numeroCromaticoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int cuantosColores;
            numeroCromatico();
            cuantosColores = numeroCromatico();
            MessageBox.Show("son: " + cuantosColores + " los que se encontraron");
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (gmover == 3)
            {
                for (int j = 0; j < lisGrafo[grafoActual].ListaVert.Count; j++)
                {
                    lisGrafo[grafoActual].ListaVert[j].X += dx1;
                    lisGrafo[grafoActual].ListaVert[j].Y += dy1;
                }
                pictureBox1.Invalidate();
            }

            if (dibujaClick == 1)
            {
                dibuja = 1;
                dibujaClick = 0;
            }
            if (dibujaClick == 2)
            {
                dibuja = 2;
                dibujaClick = 0;
            }
            dx1 = 0;
            dy1 = 0;

            mover = 0;
            gmover = 0;
            arraFlecha = 0;
        }

        private void corolariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            porCorolarios();
        }

        private void recorridoEnAmplitudToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rAmplitud();
        }

        private void recorrerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Vertice elemento in lisGrafo[grafoActual].ListaVert)
            {
                string nombre;
                nombre = elemento.Name;
                MessageBox.Show(nombre);
            }
        }

        private void btnCerrarC_Click(object sender, EventArgs e)
        {
            btnCerrarC.Visible = false;
            richTextBox1.Visible = false;
            richTextBox1.Clear();
        }

        private void algoritmoDeKruskalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kruskal();
        }

        private void numerosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dibuja = 1;
            elimina = 0;
            creaArista = 0;
        }

        private void toolStripButton8_Click_1(object sender, EventArgs e)
        {
            agregaPeso = 1;
        }

        public void diGrado(Point e)
        {
            int cont = 0;
            if (vGrado == 1)
            {
                for (int i = 0; i < lisGrafo.Count; i++)
                {
                    for (int j = 0; j < lisGrafo[i].ListaVert.Count; j++)
                    {
                        if (e.X > lisGrafo[i].ListaVert[j].X - 25 && e.Y > lisGrafo[i].ListaVert[j].Y - 25 && e.X < lisGrafo[i].ListaVert[j].X + 25 && e.Y < lisGrafo[i].ListaVert[j].Y + 25)
                        {
                            for (int a = 0; a < lisGrafo.Count; a++)
                            {
                                for (int b = 0; b < lisGrafo[a].ListaArista.Count; b++)
                                {
                                    if (lisGrafo[a].ListaArista[b].VI == lisGrafo[i].ListaVert[j])
                                    {
                                        cont++;
                                    }
                                }
                            }
                        }
                    }
                }
                MessageBox.Show("El grado mayor es: " + cont);
            }
            if (vGrado == 2)
            {
                for (int i = 0; i < lisGrafo.Count; i++)
                {
                    for (int j = 0; j < lisGrafo[i].ListaVert.Count; j++)
                    {

                        if (e.X > lisGrafo[i].ListaVert[j].X - 25 && e.Y > lisGrafo[i].ListaVert[j].Y - 25 && e.X < lisGrafo[i].ListaVert[j].X + 25 && e.Y < lisGrafo[i].ListaVert[j].Y + 25)
                        {
                            for (int a = 0; a < lisGrafo.Count; a++)
                            {
                                for (int b = 0; b < lisGrafo[a].ListaArista.Count; b++)
                                {
                                    if (lisGrafo[a].ListaArista[b].VF == lisGrafo[i].ListaVert[j])
                                    {
                                        cont++;
                                    }
                                }
                            }
                        }
                    }
                }
                MessageBox.Show("El grado menor es: " + cont);
            }
        }

        //elimina aristas
        private int eliminaA(MouseEventArgs e)
        {
            double x = 0, y = 0, m = 0;
            foreach (Arista a in lisGrafo[grafoActual].ListaArista)
            {
                if (a.Tipo == 0)
                {

                    m = (Convert.ToDouble(a.Yf) - Convert.ToDouble(a.Yi)) / (Convert.ToDouble(a.Xf) - Convert.ToDouble(a.Xi));
                   
                    if (a.Xi < a.Xf)
                    {
                        if (a.Xi - a.Xf > 3)
                        {
                            for (x = a.Xi; x < a.Xf; x++)
                            {
                                y = (m * (x - a.Xi)) + a.Yi;
                                
                                if (e.X >= x - 7 && e.Y >= y - 7 && e.X <= x + 7 && e.Y <= y + 7)
                                {
                                    if (a.Tipo == 0)
                                    {
                                        lisGrafo[grafoActual].ListaArista.Remove(a);
                                        pictureBox1.Invalidate();
                                        return 0;
                                    }
                                }
                            }
                        }
                        else
                        {
                            for (x = a.Xi; x < a.Xf; x += 0.01)
                            {
                                y = (m * (x - a.Xi)) + a.Yi;
                                if (e.X >= x - 7 && e.Y >= y - 7 && e.X <= x + 7 && e.Y <= y + 7)
                                {
                                    if (a.Tipo == 0)
                                    {
                                        lisGrafo[grafoActual].ListaArista.Remove(a);
                                        pictureBox1.Invalidate();
                                        return 0;
                                    }
                                }
                            }
                        }
                    }
                    if (a.Xi > a.Xf)
                    {
                        if (a.Xf - a.Xf > 3)
                        {
                            for (x = a.Xi; x > a.Xf; x++)
                            {
                                y = (m * (x - a.Xi)) + a.Yi;
                                if (e.X >= x - 7 && e.Y >= y - 7 && e.X <= x + 7 && e.Y <= y + 7)
                                {
                                    if (a.Tipo == 0)
                                    {
                                        lisGrafo[grafoActual].ListaArista.Remove(a);
                                        pictureBox1.Invalidate();
                                        return 0;
                                    }
                                }
                            }
                        }
                        else
                        {
                            for (x = a.Xi; x > a.Xf; x -= 0.01)
                            {
                                y = (m * (x - a.Xi)) + a.Yi;
                                if (e.X >= x - 7 && e.Y >= y - 7 && e.X <= x + 7 && e.Y <= y + 7)
                                {
                                    if (a.Tipo == 0)
                                    {
                                        lisGrafo[grafoActual].ListaArista.Remove(a);
                                        pictureBox1.Invalidate();
                                        return 0;
                                    }
                                }
                            }
                        }
                    }
                    if (a.Xi == a.Xf)
                    {
                        x = a.Xi;
                        for (y = a.Xi; y < a.Yf; y++)
                        {
                            if (e.X >= x - 7 && e.Y >= y - 7 && e.X <= x + 7 && e.Y <= y + 7)
                            {
                                if (a.Tipo == 0)
                                {
                                    lisGrafo[grafoActual].ListaArista.Remove(a);
                                    pictureBox1.Invalidate();
                                    return 0;
                                }
                            }
                        }
                    }
                    if (a.Yi == a.Yf)
                    {
                        y = a.Yi;
                        for (x = a.Xi; x < a.Xf; x++)
                        {
                            if (e.X >= x - 7 && e.Y >= y - 7 && e.X <= x + 7 && e.Y <= y + 7)
                            {
                                if (a.Tipo == 0)
                                {
                                    lisGrafo[grafoActual].ListaArista.Remove(a);
                                    pictureBox1.Invalidate();
                                    return 0;
                                }
                            }
                        }
                    }
                }
                if (a.Tipo == 1)
                {
                    int res = 0;
                    res = eliminaCurva(e, a.Xi, a.Yi, ((a.Xi + a.Xf) / 2), ((a.Yi + a.Yf) / 2) + a.NIncr, ((a.Xi + a.Xf) / 2), ((a.Yi + a.Yf) / 2) + a.NIncr, a.Xf, a.Yf);
                    if (res == 1)
                    {
                        lisGrafo[grafoActual].ListaArista.Remove(a);
                        pictureBox1.Invalidate();
                        return 0;
                    }
                }
                if (a.Tipo == 2)
                {
                    int res = 0;
                    res = eliminaCurva(e, a.Xi + dx1, a.Yi + dy1, a.Xi - 10 + dx1, a.Yi - 25 + dy1, a.Xf - 25 + dx1, a.Yf - 10 + dy1, a.Xf + dx1, a.Yf + dy1);
                    if (res == 1)
                    {
                        lisGrafo[grafoActual].ListaArista.Remove(a);
                        pictureBox1.Invalidate();
                        return 0;
                    }
                }
            }
            return 1;
        }

        private void comoDibuja(Arista elemento, PaintEventArgs e, int xf, int xi, int yf, int yi, int sig)
        {
            if (elemento.Tipo != 2)
            {
                if (xf > xi && yf < yi)
                {
                    if (elemento.Tipo == 1)
                    {
                        datosSpline(elemento, 1, -1, -1, 1, sig * 35, e);
                    }
                    if (elemento.Tipo == 0)
                    {
                        datosLinea(elemento, e, 1, -1, -1, 1);
                    }
                }
                if (xf < xi && yf < yi)
                {
                    if (elemento.Tipo == 1)
                    {
                        datosSpline(elemento, -1, -1, 1, 1, sig * 35, e);
                    }
                    if (elemento.Tipo == 0)
                    {
                        datosLinea(elemento, e, -1, -1, 1, 1);
                    }
                }
                if (xf < xi && yf > yi)
                {
                    if (elemento.Tipo == 1)
                    {
                        datosSpline(elemento, -1, 1, 1, -1, sig * 35, e);
                    }
                    if (elemento.Tipo == 0)
                    {
                        datosLinea(elemento, e, -1, 1, 1, -1);
                    }
                }
                if (xf > xi && yf > yi)
                {
                    if (elemento.Tipo == 1)
                    {
                        datosSpline(elemento, 1, 1, -1, -1, sig * 35, e);
                    }
                    if (elemento.Tipo == 0)
                    {
                        datosLinea(elemento, e, 1, 1, -1, -1);
                    }
                }
            }
            if (elemento.Tipo == 2)
            {
                elemento.Yi -= 25;
                elemento.Xf -= 25;
                if (lisGrafo[grafoActual].Tipo == 1)
                {
                    Pen pen = new Pen(Color.Black, 5);
                    pen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
                    e.Graphics.DrawBezier(pen, elemento.Xi + dx1, elemento.Yi + dy1, elemento.Xi - 10 + dx1, elemento.Yi - 25 + dy1, elemento.Xf - 25 + dx1, elemento.Yf - 10 + dy1, elemento.Xf + dx1, elemento.Yf + dy1);
                }
                if (lisGrafo[grafoActual].Tipo == 2)
                {
                    e.Graphics.DrawBezier(pen, elemento.Xi + dx1, elemento.Yi + dy1, elemento.Xi - 10 + dx1, elemento.Yi - 25 + dy1, elemento.Xf - 25 + dx1, elemento.Yf - 10 + dy1, elemento.Xf + dx1, elemento.Yf + dy1);
                }
            }
        }

        private void datosSpline(Arista elemento, int s1, int s2, int s3, int s4, int inc, PaintEventArgs e)
        {
            elemento.Xi = elemento.Xi + (s1 * 18);
            elemento.Yi = elemento.Yi + (s2 * 18);
            elemento.Xf = elemento.Xf + (s3 * 18);
            elemento.Yf = elemento.Yf + (s4 * 18);
            if (lisGrafo[grafoActual].Tipo == 1)
            {
                Pen pen = new Pen(Color.Black, 3);
                pen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
                e.Graphics.DrawBezier(pen, elemento.Xi + dx1, elemento.Yi + dy1, ((elemento.Xi + dx1 + elemento.Xf + dx1) / 2), ((elemento.Yi + dy1 + elemento.Yf + dy1) / 2) + elemento.NIncr, ((elemento.Xi + dx1 + elemento.Xf + dx1) / 2), ((elemento.Yi + dy1 + elemento.Yf + dy1) / 2) + elemento.NIncr, elemento.Xf + dx1, elemento.Yf + dy1);

            }
            if (lisGrafo[grafoActual].Tipo == 2)
            {
                dibujaCurva(e, elemento.Xi + dx1, elemento.Yi + dy1, ((elemento.Xi + dx1 + elemento.Xf + dx1) / 2), ((elemento.Yi + dy1 + elemento.Yf + dy1) / 2) + elemento.NIncr, ((elemento.Xi + dx1 + elemento.Xf + dx1) / 2), ((elemento.Yi + dy1 + elemento.Yf + dy1) / 2) + elemento.NIncr, elemento.Xf + dx1, elemento.Yf + dy1);
            }
        }

        private void datosLinea(Arista elemento, PaintEventArgs e, int s1, int s2, int s3, int s4)
        {
            elemento.Xi = elemento.Xi + (s1 * 18);
            elemento.Yi = elemento.Yi + (s2 * 18);
            elemento.Xf = elemento.Xf + (s3 * 18);
            elemento.Yf = elemento.Yf + (s4 * 18);
            if (lisGrafo[grafoActual].Tipo == 1)
            {
                Pen lapiz2 = new Pen(Color.Black, 6);
                lapiz2.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
                e.Graphics.DrawLine(lapiz2, elemento.Xi + dx1, elemento.Yi + dy1, elemento.Xf + dx1, elemento.Yf + dy1);
            }

            if (lisGrafo[grafoActual].Tipo == 2)
            {
                e.Graphics.DrawLine(lapiz2, elemento.Xi + dx1, elemento.Yi + dy1, elemento.Xf + dx1, elemento.Yf + dy1);
            }
        }

        private void dibujaCurva(PaintEventArgs e, double p0x, double p0y, double p1x, double p1y, double p2x, double p2y, double p3x, double p3y)
        {
            double px, py;
            for (double t = 0; t < 1; t += 0.001)
            {
                px = (p0x * ((1 - t) * (1 - t) * (1 - t))) + (((3 * p1x) * t) * ((1 - t) * (1 - t))) + (((3 * p2x) * (t * t)) * (1 - t)) + (p3x * (t * t * t));
                py = (p0y * ((1 - t) * (1 - t) * (1 - t))) + (((3 * p1y) * t) * ((1 - t) * (1 - t))) + (((3 * p2y) * (t * t)) * (1 - t)) + (p3y * (t * t * t));
                Brush aBrush = (Brush)Brushes.Black;
                e.Graphics.FillRectangle(aBrush, Convert.ToSingle(px), Convert.ToSingle(py), 1, 1);
            }


        }

        private int eliminaCurva(MouseEventArgs e, double p0x, double p0y, double p1x, double p1y, double p2x, double p2y, double p3x, double p3y)
        {
            double px, py;
            for (double t = 0; t < 1; t += 0.001)
            {
                double var = 1 - t;
                px = (p0x * (var * var * var)) + (((3 * p1x) * t) * (var * var)) + (((3 * p2x) * (t * t)) * var) + (p3x * (t * t * t));
                py = (p0y * (var * var * var)) + (((3 * p1y) * t) * (var * var)) + (((3 * p2y) * (t * t)) * var) + (p3y * (t * t * t));
                if (e.X >= px - 3 && e.Y >= py - 3 && e.X <= px + 3 && e.Y <= py + 3)
                {
                    return 1;
                }
            }
            return 0;

        }

        public void medioKuratowsky()
        {
            if (lisGrafo[grafoActual].Tipo == 2)
            {
                int band = 0;
                int contPropiedad = 0;

                // K33
                for (int i = 0; i < lisGrafo[grafoActual].ListaVert.Count; i++)
                {
                    int contGrado = 0;
                    for (int j = 0; j < lisGrafo[grafoActual].ListaArista.Count; j++)
                    {
                        if (lisGrafo[grafoActual].ListaVert[i].Name == lisGrafo[grafoActual].ListaArista[j].VF.Name || lisGrafo[grafoActual].ListaVert[i].Name == lisGrafo[grafoActual].ListaArista[j].VI.Name)
                        {
                            contGrado++;
                        }
                
                    }
                    if (contGrado >= 3)
                    {
                        contPropiedad++;
                        if (contPropiedad == 6)
                        {
                            MessageBox.Show("contiene un grafo k33");
                            band = 1;
                        }
                    }
                }

                //k5
                contPropiedad = 0;

                for (int i = 0; i < lisGrafo[grafoActual].ListaVert.Count; i++)
                {
                    int contGrado = 0;
                    for (int j = 0; j < lisGrafo[grafoActual].ListaArista.Count; j++)
                    {
                        if (lisGrafo[grafoActual].ListaVert[i].Name == lisGrafo[grafoActual].ListaArista[j].VF.Name || lisGrafo[grafoActual].ListaVert[i].Name == lisGrafo[grafoActual].ListaArista[j].VI.Name)
                        {
                            contGrado++;
                        }

                    }
                    if (contGrado >= 4)
                    {
                        contPropiedad++;
                        if (contPropiedad == 5)
                        {
                            MessageBox.Show("contiene un grafo k5");
                            band = 1;
                        }
                    }
                }
                if (band == 0)
                {
                    MessageBox.Show("no contiene grafos k5 ni k33");
                }
            }
            else
                MessageBox.Show("Tiene que ser grafo no dirigido");
        }

        public void agregaGrado()
        {
            lisGrafo[grafoActual].AgregarGrados();
            foreach (Vertice v in lisGrafo[grafoActual].ListaVert)
            {
                MessageBox.Show("Vertice: " + v.Name + " de grado de salida de: " + v.GradoS);
                MessageBox.Show("Vertice: " + v.Name + " de grado de entrada de: " + v.GradoE);
            }
        }

        public void isomorfismo()
        {
            Grafo g1, g2;
            g1 = lisGrafo[0];
            g2 = lisGrafo[1];

            Boolean isomorfismo = false;
            if (g1.Tipo == g2.Tipo)
            {
                if (g1.ListaVert.Count == g2.ListaVert.Count)
                {
                    if (g1.ListaArista.Count == g2.ListaArista.Count)
                    {
                        g1.AgregarGrados();
                        g2.AgregarGrados();
                        g1.AgregaAdyacencias();
                        g2.AgregaAdyacencias();
                        foreach (Vertice v1 in g1.ListaVert)
                        {
                            foreach (Vertice v2 in g2.ListaVert)
                            {
                                if (v1.GradoS == v2.GradoS && v1.GradoE == v2.GradoE)
                                {
                                    List<int> lisg1 = new List<int>();
                                    List<int> lisg2 = new List<int>();
                                    foreach (Vertice v in v1.listaVert)
                                    {
                                        lisg1.Add(v.GradoS);
                                    }
                                    foreach (Vertice v in v2.listaVert)
                                    {
                                        lisg2.Add(v.GradoS);
                                    }
                                    lisg1.Sort();
                                    lisg2.Sort();
                                    if (lisg1.SequenceEqual(lisg2))
                                    {
                                        isomorfismo = true;
                                    }
                                    else
                                    {
                                        isomorfismo = false;
                                    }

                                }
                            }
                        }
                        if (isomorfismo == true)
                        {
                            MessageBox.Show("Es isomorfo");
                        }
                        else
                        {
                            MessageBox.Show("no son isomorfos");
                        }
                    }
                    else
                        MessageBox.Show("no son isomorfos");
                }
                else
                    MessageBox.Show("no son isomorfos");
            }
            else
                MessageBox.Show("no son isomorfos");
        }

        public SolidBrush escogeColor(int color)
        {
            SolidBrush lapiz;

            switch (color)
            {
                case 1:
                    lapiz = new SolidBrush(Color.Red);
                    break;
                case 2:
                    lapiz = new SolidBrush(Color.Green);
                    break;
                case 3:
                    lapiz = new SolidBrush(Color.Blue);
                    break;
                case 4:
                    lapiz = new SolidBrush(Color.Aqua);
                    break;
                case 5:
                    lapiz = new SolidBrush(Color.Purple);
                    break;
                default:
                    lapiz = new SolidBrush(Color.Silver);
                    break;
            }

            return lapiz;
        }

        public int numeroCromatico()
        {
            lisGrafo[grafoActual].ListaVert[0].ColorVert = 1;

            try
            {
                foreach (Vertice aux in lisGrafo[grafoActual].ListaVert)
                {
                    aux.listaVert.Clear();
                }



                lisGrafo[grafoActual].AgregaAdyacenciasNo();

                int contColor = 1;
                int cuantosColores = 0;
                for (int i = 1; i < lisGrafo[grafoActual].ListaVert.Count(); i++)
                {
                    lisGrafo[grafoActual].ListaVert[i].ColorVert = 1;
                    //IEnumerable<Vertice> lisVertOrde = lisGrafo[grafoActual].ListaVert[i].listaVert.OrderBy(Name => Name);
                    for (int j = 0; j < lisGrafo[grafoActual].ListaVert[i].listaVert.Count(); j++)
                    {
                        //MessageBox.Show("Vertice: " + lisGrafo[grafoActual].ListaVert[i].Name.ToString() + " " +  lisGrafo[grafoActual].ListaVert[i].listaVert[j].Name.ToString());
                        if (lisGrafo[grafoActual].ListaVert[i].ColorVert == lisGrafo[grafoActual].ListaVert[i].listaVert[j].ColorVert)
                        {
                            contColor++;
                            lisGrafo[grafoActual].ListaVert[i].ColorVert = contColor;
                        }
                    }
                    if (cuantosColores < contColor)
                    {
                        cuantosColores = contColor;
                    }
                    contColor = 1;
                }
                pictureBox1.Invalidate();

                return cuantosColores;
            }
            catch
            {
                return 0;
            }
        }

        public void porCorolarios()
        {
            int nAristas = lisGrafo[grafoActual].ListaArista.Count();
            int nVertices = lisGrafo[grafoActual].ListaVert.Count();
            //MessageBox.Show("El numero de vertices son: " + nVertices + " y el numero de aristas son: " + nAristas);

            int formula = (3 * nVertices) - 6;
            int formula2 = (2 * nVertices) - 4;
            if (nAristas <= formula)
            {
                MessageBox.Show("Por corolario 1 es plano ");
            }
            else
            {
                MessageBox.Show("Por corolario 1 no es plano :(");
            }
            if(lisGrafo[grafoActual].ListaVert.Count() >= 3)
            {
                if (nAristas <= formula2)
                {
                    MessageBox.Show("Por corolario 2 es plano ");
                }
                else
                {
                    MessageBox.Show("Por corolario 2 no es plano :(");
                }
            }
        }

        public void rAmplitud()
        {
            foreach (Vertice v in lisGrafo[grafoActual].ListaVert)
            {
                v.Visitado = 0;
            }

            foreach (Vertice aux in lisGrafo[grafoActual].ListaVert)
            {
                aux.listaVert.Clear();
            }
      
            lisGrafo[grafoActual].AgregaAdyacenciasNo();

            List<Vertice> cola = new List<Vertice>();
            List<Vertice> visitados = new List<Vertice>();

            Vertice auxV = lisGrafo[grafoActual].ListaVert[0];
            auxV.Visitado = 1;
            cola.Add(auxV);
            visitados.Add(auxV);

            while (cola.Count() != 0)
            {

                foreach (Vertice v in auxV.listaVert)
                {
                    if (v.Visitado == 0)
                    {
                        v.Visitado = 1;
                        cola.Add(v);
                        visitados.Add(v);
                    }
                }
                cola.Remove(auxV);

                if (cola.Count() != 0)
                {
                    auxV = cola[0];
                }

            }

            richTextBox1.Visible = true;
            btnCerrarC.Visible = true;
            foreach (Vertice v in visitados)
            {
                richTextBox1.Text += v.Name + " ";
            }

            


        }

        public int encuentraArista(MouseEventArgs e)
        {
            double x = 0, y = 0, m = 0;
            foreach (Arista a in lisGrafo[grafoActual].ListaArista)
            {
                if (a.Tipo == 0)
                {

                    m = (Convert.ToDouble(a.Yf) - Convert.ToDouble(a.Yi)) / (Convert.ToDouble(a.Xf) - Convert.ToDouble(a.Xi));

                    if (a.Xi < a.Xf)
                    {
                        if (a.Xi - a.Xf > 3)
                        {
                            for (x = a.Xi; x < a.Xf; x++)
                            {
                                y = (m * (x - a.Xi)) + a.Yi;

                                if (e.X >= x - 7 && e.Y >= y - 7 && e.X <= x + 7 && e.Y <= y + 7)
                                {
                                    if (a.Tipo == 0)
                                    {
                                        //MessageBox.Show("hola");
                                        Peso peso = new Peso();
                                        //peso.Show();
                                        peso.ShowDialog();
                                        if (peso.DialogResult == DialogResult.OK)
                                        {
                                            a.Peso = peso.peso;
                                        }
                                        MessageBox.Show(a.Peso.ToString());
                                        pictureBox1.Invalidate();
                                        return 0;
                                    }
                                }
                            }
                        }
                        else
                        {
                            for (x = a.Xi; x < a.Xf; x += 0.01)
                            {
                                y = (m * (x - a.Xi)) + a.Yi;
                                if (e.X >= x - 7 && e.Y >= y - 7 && e.X <= x + 7 && e.Y <= y + 7)
                                {
                                    if (a.Tipo == 0)
                                    {
                                       // MessageBox.Show("hola");
                                        Peso peso = new Peso();
                                        //peso.Show();
                                        peso.ShowDialog();
                                        if (peso.DialogResult == DialogResult.OK)
                                        {
                                            a.Peso = peso.peso;
                                        }
                                        MessageBox.Show(a.Peso.ToString());
                                        pictureBox1.Invalidate();
                                        return 0;
                                    }
                                }
                            }
                        }
                    }
                    if (a.Xi > a.Xf)
                    {
                        if (a.Xf - a.Xf > 3)
                        {
                            for (x = a.Xi; x > a.Xf; x++)
                            {
                                y = (m * (x - a.Xi)) + a.Yi;
                                if (e.X >= x - 7 && e.Y >= y - 7 && e.X <= x + 7 && e.Y <= y + 7)
                                {
                                   // MessageBox.Show("hola");
                                    Peso peso = new Peso();
                                   // peso.Show();
                                    peso.ShowDialog();
                                    if (peso.DialogResult == DialogResult.OK)
                                    {
                                        a.Peso = peso.peso;
                                    }
                                    MessageBox.Show(a.Peso.ToString());
                                    pictureBox1.Invalidate();
                                    return 0;
                                }
                            }
                        }
                        else
                        {
                            for (x = a.Xi; x > a.Xf; x -= 0.01)
                            {
                                y = (m * (x - a.Xi)) + a.Yi;
                                if (e.X >= x - 7 && e.Y >= y - 7 && e.X <= x + 7 && e.Y <= y + 7)
                                {
                                    if (a.Tipo == 0)
                                    {
                                       // MessageBox.Show("hola");
                                        Peso peso = new Peso();
                                       // peso.Show();
                                        peso.ShowDialog();
                                        if (peso.DialogResult == DialogResult.OK)
                                        {
                                            a.Peso = peso.peso;
                                        }
                                        MessageBox.Show(a.Peso.ToString());
                                        pictureBox1.Invalidate();
                                        return 0;
                                    }
                                }
                            }
                        }
                    }
                    if (a.Xi == a.Xf)
                    {
                        x = a.Xi;
                        for (y = a.Xi; y < a.Yf; y++)
                        {
                            if (e.X >= x - 7 && e.Y >= y - 7 && e.X <= x + 7 && e.Y <= y + 7)
                            {
                                if (a.Tipo == 0)
                                {
                                    //MessageBox.Show("hola");
                                    Peso peso = new Peso();
                                    //peso.Show();
                                    peso.ShowDialog();
                                    if (peso.DialogResult == DialogResult.OK)
                                    {
                                        a.Peso = peso.peso;
                                    }
                                    MessageBox.Show(a.Peso.ToString());
                                    pictureBox1.Invalidate();
                                    return 0;
                                }
                            }
                        }
                    }
                    if (a.Yi == a.Yf)
                    {
                        y = a.Yi;
                        for (x = a.Xi; x < a.Xf; x++)
                        {
                            if (e.X >= x - 7 && e.Y >= y - 7 && e.X <= x + 7 && e.Y <= y + 7)
                            {
                                if (a.Tipo == 0)
                                {
                                    //MessageBox.Show("hola");
                                    Peso peso = new Peso();
                                   // peso.Show();
                                    peso.ShowDialog();
                                    if (peso.DialogResult == DialogResult.OK)
                                    {
                                        a.Peso = peso.peso;
                                    }
                                    MessageBox.Show(a.Peso.ToString());
                                    pictureBox1.Invalidate();
                                    return 0;
                                }
                            }
                        }
                    }
                }
            }
            return 1;
        }

        public void kruskal()
        {

        }
    }
}
