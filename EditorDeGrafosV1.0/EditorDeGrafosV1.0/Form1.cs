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
        List<Grafo> lisGrafo;
        public int dibuja = 0, dibujaClick = 0, mover = 0, elimina = 0, inc = 0, creaArista = 0, creaSpline = 0, conRela = 1;
        public int arraFlecha = 0, vGrado = 0, gmover = 0;
        public int fx, fy, grafo = 0, contGrafo = 0;
        string abc = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ";
        public string auxName;
        private Vertice auxVert, auxVert2;
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
            //for (int i = 0; i < lisGrafo.Count; i++)
           // {
                for (int j = 0; j < lisGrafo[grafoActual].ListaVert.Count; j++)
                {
                    MessageBox.Show("Vertice"+ lisGrafo[grafoActual].ListaVert[j].Name);
                    for (int k = 0; k < lisGrafo[grafoActual].ListaVert[j].listaRelacion.Count; k++)
                    {
                        MessageBox.Show(lisGrafo[grafoActual].ListaVert[j].listaRelacion[k].Rela);
                    }

                }
           // }
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
            //openFileDialog1.ShowDialog();
            //reproductor.URL = openFileDialog1.FileName;
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

        private void btnDirigido_Click(object sender, EventArgs e)
        {
            //lisGrafo.Clear();
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
            //MessageBox.Show(comboBox1.ValueMember);
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
            pictureBox1.Visible = true;
            toolStrip1.Visible = true;
            pictureBox1.Invalidate();
            this.Invalidate();
        }

        private void btnNoDirigido_Click(object sender, EventArgs e)
        {
            //lisGrafo.Clear();
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
            contGrafo++;
        }

        private void mGNNDirigido_Click(object sender, EventArgs e)
        {
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

        }

        private void mGNDirigido_Click(object sender, EventArgs e)
        {
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            grafoActual = comboBox1.SelectedIndex;
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            dibujaCur= 1;
            pictureBox1.Invalidate();
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
                    Pen lapiz = new Pen(Color.Black);
                    Font Font = new Font("arial", 20);
                    int x = elemento.X;
                    int y = elemento.Y;
                    string name = elemento.Name;
                    e.Graphics.DrawEllipse(lapiz, x + dx1 - 25, y + dy1 - 25, 50, 50);
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

                //for (int i = 0; i < lisGrafo.Count; i++)
                //{
                    for (int j = 0; j < lisGrafo[grafoActual].ListaVert.Count; j++)
                    {
                        //if para verificar que elemento es el que estoy dando click para eliminar
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
                                mover = 1;
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
                                mover = 1;
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
                   // }
                }

                if (creaSpline == 2)
                {
                    Arista newArista = new Arista();

                    //for (int i = 0; i < lisGrafo.Count; i++)
                    //{
                        for (int j = 0; j < lisGrafo[grafoActual].ListaVert.Count; j++)
                        {
                            if (auxVert == lisGrafo[grafoActual].ListaVert[j])
                            {
                                newArista.VI = auxVert;
                            }
                        }
                    //}


                   // for (int i = 0; i < lisGrafo.Count; i++)
                    //{
                        for (int j = 0; j < lisGrafo[grafoActual].ListaVert.Count; j++)
                        {
                            //if para verificar que elemento es el que estoy dando click para eliminar
                            if (e.X > lisGrafo[grafoActual].ListaVert[j].X - 25 && e.Y > lisGrafo[grafoActual].ListaVert[j].Y - 25 && e.X < lisGrafo[grafoActual].ListaVert[j].X + 25 && e.Y < lisGrafo[grafoActual].ListaVert[j].Y + 25)
                            {
                                newArista.VF = lisGrafo[grafoActual].ListaVert[j];
                            }
                        }
                    //}
                    newAristaSpline = newArista;
                    creaSpline = 3;
                    pictureBox1.Invalidate();
                    creaArista = 1;

                }

                if (creaArista == 2)
                {
                    Arista newArista = new Arista();

                    //for (int i = 0; i < lisGrafo.Count; i++)
                    //{
                        for (int j = 0; j < lisGrafo[grafoActual].ListaVert.Count; j++)
                        {
                            if (auxVert == lisGrafo[grafoActual].ListaVert[j])
                            {
                                newArista.VI = auxVert;
                            }
                       // }
                    }


                    //for (int i = 0; i < lisGrafo.Count; i++)
                    //{
                        for (int j = 0; j < lisGrafo[grafoActual].ListaVert.Count; j++)
                        {
                            //if para verificar que elemento es el que estoy dando click para eliminar
                            if (e.X > lisGrafo[grafoActual].ListaVert[j].X - 25 && e.Y > lisGrafo[grafoActual].ListaVert[j].Y - 25 && e.X < lisGrafo[grafoActual].ListaVert[j].X + 25 && e.Y < lisGrafo[grafoActual].ListaVert[j].Y + 25)
                            {
                                newArista.VF = lisGrafo[grafoActual].ListaVert[j];
                            }
                        }
                   //}

                    //ciclo para buscar si la nueva arista ya existe si existe hace splines
                    //for (int i = 0; i < lisGrafo.Count; i++)
                    //{
                        int cont = 1;
                        for (int j = 0; j < lisGrafo[grafoActual].ListaArista.Count; j++)
                        {
                            if (newArista.VI.Name == lisGrafo[grafoActual].ListaArista[j].VI.Name && newArista.VF.Name == lisGrafo[grafoActual].ListaArista[j].VF.Name || newArista.VI.Name == lisGrafo[grafoActual].ListaArista[j].VF.Name && newArista.VF.Name == lisGrafo[grafoActual].ListaArista[j].VI.Name)
                            {
                                cont++;
                                // MessageBox.Show("arista " + cont);
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
                    //}

                    if (newArista.VI.Name == newArista.VF.Name)
                    {
                        // MessageBox.Show("Oreja");
                        newArista.Tipo = 2;
                        newArista.NDArista = 1;
                    }

                    lisGrafo[grafoActual].ListaArista.Add(newArista);
                    creaArista = 1;

                }

                if (creaArista == 4)
                {
                    Arista newArista = new Arista();
                    //for (int i = 0; i < lisGrafo.Count; i++)
                    //{
                        for (int j = 0; j < lisGrafo[grafoActual].ListaVert.Count; j++)
                        {
                            if (auxVert == lisGrafo[grafoActual].ListaVert[j])
                            {
                                newArista.VI = auxVert;
                            }
                        }
                    //}


                    //for (int i = 0; i < lisGrafo.Count; i++)
                    //{
                        for (int j = 0; j < lisGrafo[grafoActual].ListaVert.Count; j++)
                        {
                            //if para verificar que elemento es el que estoy dando click para eliminar
                            if (e.X > lisGrafo[grafoActual].ListaVert[j].X - 25 && e.Y > lisGrafo[grafoActual].ListaVert[j].Y - 25 && e.X < lisGrafo[grafoActual].ListaVert[j].X + 25 && e.Y < lisGrafo[grafoActual].ListaVert[j].Y + 25)
                            {
                                newArista.VF = lisGrafo[grafoActual].ListaVert[j];
                            }
                        }
                    //}

                    //ciclo para buscar si la nueva arista ya existe si existe hace splines
                   // for (int i = 0; i < lisGrafo.Count; i++)
                    //{
                        int cont = 1;
                        for (int j = 0; j < lisGrafo[grafoActual].ListaArista.Count; j++)
                        {
                            if (newArista.VI.Name == lisGrafo[grafoActual].ListaArista[j].VI.Name && newArista.VF.Name == lisGrafo[grafoActual].ListaArista[j].VF.Name || newArista.VI.Name == lisGrafo[grafoActual].ListaArista[j].VF.Name && newArista.VF.Name == lisGrafo[grafoActual].ListaArista[j].VI.Name)
                            {
                                cont++;
                                if  (cont == 2)
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

                        //}
                    }

                    if (newArista.VI.Name == newArista.VF.Name)
                    {
                       // MessageBox.Show("Oreja");
                        newArista.Tipo = 2;
                        newArista.NDArista = 1;
                    }

                    lisGrafo[grafoActual].ListaArista.Add(newArista);
                    creaArista = 3;

                }

                if (elimina == 0)// condiciones para saber si esta eliminando o dibujando al hacer click en el pictureBox
                {
                    if (dibuja == 1)
                    {
                        Vertice vertice = new Vertice();
                        vertice.X = e.X;
                        vertice.Y = e.Y;
                        vertice.Name = Convert.ToString(inc); //Guardamos el nombre que se dio en el vertice
                        //vertice.Dibujar(lienzo); //manda llamar el metodo de dibujar
                        lisGrafo[grafoActual].ListaVert.Add(vertice);
                        pictureBox1.Invalidate();
                        inc++;
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

                    //for (int i = 0; i < lisGrafo.Count; i++)
                    //{
                        for (int j = 0; j < lisGrafo[grafoActual].ListaVert.Count; j++)
                        {
                            //if para verificar que elemento es el que estoy dando click para eliminar
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
                    //}
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
            //for (int i = 0; i < lisGrafo.Count; i++)
            //{
                for (int j = 0; j < lisGrafo[grafoActual].ListaVert.Count; j++)
                {
                    //if para verificar que elemento es el que estoy dando click para eliminar
                    if (e.X > lisGrafo[grafoActual].ListaVert[j].X - 25 && e.Y > lisGrafo[grafoActual].ListaVert[j].Y - 25 && e.X < lisGrafo[grafoActual].ListaVert[j].X + 25 && e.Y < lisGrafo[grafoActual].ListaVert[j].Y + 25)
                    {
                        if (creaArista == 0)
                        {
                            mover = 1;
                        }
                    }
                }
            //}
            arraFlecha = 0;
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
            if (mover == 1)
            {
                //for (int i = 0; i < lisGrafo.Count; i++)
                //{
                    for (int j = 0; j < lisGrafo[grafoActual].ListaVert.Count; j++)
                    {
                        //if para verificar que elemento es el que estoy dando click para eliminar
                        if (e.X > lisGrafo[grafoActual].ListaVert[j].X - 25 && e.Y > lisGrafo[grafoActual].ListaVert[j].Y - 25 && e.X < lisGrafo[grafoActual].ListaVert[j].X + 25 && e.Y < lisGrafo[grafoActual].ListaVert[j].Y + 25)
                        {
                            lisGrafo[grafoActual].ListaVert[j].X = e.X;
                            lisGrafo[grafoActual].ListaVert[j].Y = e.Y;
                        }
                    }
                //}
                pictureBox1.Invalidate();
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (gmover == 3)
            {

                //dx1 = e.X - dx;
                //dy1 = e.Y - dy;
                //for (int i = 0; i < lisGrafo.Count; i++)
                //{
                    for (int j = 0; j < lisGrafo[grafoActual].ListaVert.Count; j++)
                    {
                        lisGrafo[grafoActual].ListaVert[j].X += dx1;
                        lisGrafo[grafoActual].ListaVert[j].Y += dy1;
                    }
                //}
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
        }

        private void recorrerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //for (int i = 0; i < lisGrafo.Count; i++)
            //{
                foreach (Vertice elemento in lisGrafo[grafoActual].ListaVert)
                {
                    string nombre;
                    nombre = elemento.Name;
                    MessageBox.Show(nombre);
                    // toma el valor de cada elemento de la lista
                }
           // }
        }

        private void numerosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dibuja = 1;
            elimina = 0;
            creaArista = 0;
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
                        //if para verificar que elemento es el que estoy dando click para eliminar
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
                    /*
                    y = Convert.ToDouble(a.VF.Y) - Convert.ToDouble(a.VI.Y);
                    x = Convert.ToDouble(a.VF.X) - Convert.ToDouble(a.VI.X);
                   if (y == 0)
                    {
                        MessageBox.Show("Valor de y0 = " + y);
                        MessageBox.Show("Valor de x0 = " + x);
                    }
                    else
                    {
                        MessageBox.Show("Valor de y = " + y);
                        MessageBox.Show("Valor de x = " + x);
                    }*/
                    m = (Convert.ToDouble(a.Yf) - Convert.ToDouble(a.Yi)) / (Convert.ToDouble(a.Xf) - Convert.ToDouble(a.Xi));
                    // MessageBox.Show(Convert.ToString(m));
                    // MessageBox.Show("xi " + a.VI.X + " yi = " + a.VI.Y + " xf " + a.VF.X + " yf = " + a.VF.Y);
                    if (a.Xi < a.Xf)
                    {
                        if (a.Xi - a.Xf > 3)
                        {
                            for (x = a.Xi; x < a.Xf; x++)
                            {
                                y = (m * (x - a.Xi)) + a.Yi;
                                //MessageBox.Show("e.X = " + e.X + " e.y = " + e.Y + " valor de x y y " + x + " " + y);
                                if (e.X >= x - 7 && e.Y >= y - 7 && e.X <= x + 7 && e.Y <= y + 7)
                                {
                                    //MessageBox.Show("Entro");
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
                                //MessageBox.Show("e.X = " + e.X + " e.y = " + e.Y + " valor de x y y " + x + " " + y);
                                if (e.X >= x - 7 && e.Y >= y - 7 && e.X <= x + 7 && e.Y <= y + 7)
                                {
                                    //MessageBox.Show("Entro");
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
                                //MessageBox.Show("e.X = " + e.X + " e.y = " + e.Y + " valor de x y y " + x + " " + y);
                                if (e.X >= x - 7 && e.Y >= y - 7 && e.X <= x + 7 && e.Y <= y + 7)
                                {
                                    //MessageBox.Show("Entro");
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
                                //MessageBox.Show("e.X = " + e.X + " e.y = " + e.Y + " valor de x y y " + x + " " + y);
                                if (e.X >= x - 7 && e.Y >= y - 7 && e.X <= x + 7 && e.Y <= y + 7)
                                {
                                    //MessageBox.Show("Entro");
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
                        // MessageBox.Show("Entro");
                        x = a.Xi;
                        for (y = a.Xi; y < a.Yf; y++)
                        {
                            //MessageBox.Show("e.X = " + e.X + " e.y = " + e.Y + " valor de x y y " + x + " " + y);
                            if (e.X >= x - 7 && e.Y >= y - 7 && e.X <= x + 7 && e.Y <= y + 7)
                            {
                                //MessageBox.Show("Entro");
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
                        //MessageBox.Show("Entro");
                        y = a.Yi;
                        for (x = a.Xi; x < a.Xf; x++)
                        {
                            //MessageBox.Show("e.X = " + e.X + " e.y = " + e.Y + " valor de x y y " + x + " " + y);
                            if (e.X >= x - 7 && e.Y >= y - 7 && e.X <= x + 7 && e.Y <= y + 7)
                            {
                                //MessageBox.Show("Entro");
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
                    //MessageBox.Show("Entro");
                    int res = 0;
                    res = eliminaCurva(e, a.Xi, a.Yi, ((a.Xi + a.Xf) / 2), ((a.Yi+ a.Yf) / 2) + a.NIncr, ((a.Xi+ a.Xf) / 2), ((a.Yi+ a.Yf) / 2) + a.NIncr, a.Xf , a.Yf);
                    if (res == 1)
                    {
                        lisGrafo[grafoActual].ListaArista.Remove(a);
                        pictureBox1.Invalidate();
                        return 0;
                    }
                }
                if (a.Tipo == 2)
                {
                    //MessageBox.Show("Entro");
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
            //MessageBox.Show("entro");
            for(double t = 0; t < 1; t+=0.001)
            {
                px = (p0x * ((1 - t) * (1 - t) * (1 - t))) + (((3 * p1x) * t) * ((1 - t) * (1 - t))) + (((3 * p2x) * (t * t)) * (1 - t)) + (p3x * (t * t * t));
                py = (p0y * ((1 - t) * (1 - t) * (1 - t))) + (((3 * p1y) * t) * ((1 - t) * (1 - t))) + (((3 * p2y) * (t * t)) * (1 - t)) + (p3y * (t * t * t));
                Brush aBrush = (Brush)Brushes.Black;
                e.Graphics.FillRectangle(aBrush, Convert.ToSingle(px), Convert.ToSingle(py), 1, 1);
                //MessageBox.Show("El valor en x es: " + px + " El valor de y es: " + py);
            }


        }
        private int eliminaCurva(MouseEventArgs e, double p0x, double p0y, double p1x, double p1y, double p2x, double p2y, double p3x, double p3y)
        {
            double px, py;
            //MessageBox.Show("entro");
            for (double t = 0; t < 1; t += 0.001)
            {
                double var = 1 - t;
                px = (p0x * (var * var * var)) + (((3 * p1x) * t) * (var * var)) + (((3 * p2x) * (t * t)) * var) + (p3x * (t * t * t));
                py = (p0y * (var * var * var)) + (((3 * p1y) * t) * (var * var)) + (((3 * p2y) * (t * t)) * var) + (p3y * (t * t * t));
                //MessageBox.Show("El valor en x es: " + px + " El valor de y es: " + py + "                              El valor de e.x = " + e.X + " El valor de e.y = " + e.Y);
                if (e.X >= px - 3 && e.Y >= py - 3 && e.X <= px + 3 && e.Y <= py + 3)
                {
                   // MessageBox.Show("Entro");
                    return 1;
                }
            }
            return 0;

        }
    }
}
