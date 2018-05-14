using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace EditorDeGrafosV1._0
{
    [Serializable()]
    public class Vertice
    {
        private int x;
        private int y;
        private String name;
        private int color;       // 1-Rojo 2-Verde 3-Azul 4-Cyan 5-Purple
        private int gradoS, gradoE;
        private List<Vertice> lisVert;
        private List<int> lisVertInt;
        private int visitado = 0;

        public Vertice()
        {
            lisVert = new List<Vertice>();
            lisVertInt = new List<int>();
        }

        public void Dibujar(Graphics lienzo)
        {
            Pen lapiz = new Pen(Color.Black);
            Font Font = new Font("arial", 20);
            lienzo.DrawEllipse(lapiz, x - 25, y - 25, 50, 50);
            lienzo.DrawString(name, Font, Brushes.Black, x - 15, y - 15);   
        }

 

        public int X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }

        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;

            }
        }

        public int ColorVert
        {
            get
            {
                return color;
            }
            set
            {
                color = value;

            }
        }

        public String Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;

            }
        }

        public int GradoS
        {
            get
            {
                return gradoS;
            }
            set
            {
                gradoS = value;

            }
        }

        public int GradoE
        {
            get
            {
                return gradoE;
            }
            set
            {
                gradoE = value;

            }
        }

        public int Visitado
        {
            get
            {
                return visitado;
            }
            set
            {
                visitado = value;

            }
        }

        public List<Vertice> listaVert
        {
            get
            {
                return lisVert;
            }
            set
            {
               lisVert= value;

            }
        }

        public List<int> VertInt
        {
            get
            {
                return lisVertInt;
            }
            set
            {
                lisVertInt = value;

            }
        }

    }
}
