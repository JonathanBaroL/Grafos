using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditorDeGrafosV1._0
{
    public partial class Matriz : Form
    {
        List<Arista> a1;
        List<Vertice> v1;
        public Matriz(List<Arista> lArista, List<Vertice> lVertice, int opcion)
        {
            MaximizeBox = false;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            InitializeComponent();
            a1 = lArista;
            v1 = lVertice;
            if (opcion == 1)
            {
                generaMatriz();
            }
            if (opcion == 2)
            {
                generaLista();
            }
            if (opcion == 3)
            {
                generaMatrizIncidencia();
            }

        }

        public void generaMatriz()
        {
            string s = "";
            s = "    ";
            for (int j = 0; j < v1.Count; j++)
            {
                s = s + v1[j].Name + "  ";
            }
            Adyacencia.Items.Add(s);
            s = "";
            for (int j = 0; j < v1.Count; j++)
            {
                s = v1[j].Name + "  ";
                for (int k = 0; k < v1.Count; k++)
                {
                    int band = 0;
                    for (int i = 0; i < a1.Count; i++)
                    {

                        if (a1[i].VI.Name == v1[j].Name && a1[i].VF.Name == v1[k].Name)
                        {
                            s = s + "1  ";
                            band = 1;
                        }
                    }
                    if (band == 0)
                    {
                        s = s + "0  ";
                    }
                    else
                    {
                        band = 0;
                    }
                }
                Adyacencia.Items.Add(s);
                s = "";
            }
        }

        public void generaLista()
        {
            string s = "";
            for (int j = 0; j < v1.Count; j++)
            {
                s = v1[j].Name + "      ";
                for (int k = 0; k < v1.Count; k++)
                {
                    for (int i = 0; i < a1.Count; i++)
                    {

                        if (a1[i].VI.Name == v1[j].Name && a1[i].VF.Name == v1[k].Name)
                        {
                            s = s + a1[i].VF.Name + " ";
                        }
                    }
                }
                Adyacencia.Items.Add(s);
                s = "";
            }
        }

        public void generaMatrizIncidencia()
        {
            string s = "";
            s = "    ";
            for (int i = 0; i < a1.Count; i++)
            {
                int e = i + 1;
                s = s + "e" + e + "  ";
            }
            Adyacencia.Items.Add(s);
            s = "";
            for (int j = 0; j < v1.Count; j++)
            {
                s = v1[j].Name + "  ";
                for (int k = 0; k < v1.Count; k++)
                {
                    for (int i = 0; i < a1.Count; i++)
                    {

                        if (a1[i].VI.Name == v1[j].Name && a1[i].VF.Name == v1[k].Name)
                        {
                            s = s + "1  ";
                        }
                        else
                        {
                            s = s + "0  ";
                        }
                    }
                }
                Adyacencia.Items.Add(s);
                s = "";
            }
        }
    }
}
