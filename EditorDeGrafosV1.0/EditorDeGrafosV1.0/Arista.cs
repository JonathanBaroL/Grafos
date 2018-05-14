using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace EditorDeGrafosV1._0
{
    [Serializable()]
     public class Arista
    {
        private int xi;
        private int yi;
        private int xf;
        private int yf;
        private Vertice vI;    //Vertice origen
        private Vertice vF;    //Vertice destino
        private int tipo;     // Si es 0 es una linea, si es 1 es un spline, si es 2 es una oreja.
        private int ndArista; // identifica que numero de arista es.
        private int ninc;     // de acuerdo a el numero de arista que es.
        private int peso;     // peso de la arista

        public void Dibujar(Graphics lienzo)
        {
            Pen lapiz2 = new Pen(Color.Black, 5);
            lapiz2.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            lienzo.DrawLine(lapiz2, xi, yi, xf, yf);
        }

        public void AgregaDatos()
        {
            xi = VI.X;
            yi = VI.Y;
            xf = VF.X;
            yf = VF.Y;
        }


        public int Xi
        {
            get
            {
                return xi;
            }
            set
            {
                xi = value;
            }

        }

        public int Yi
        {
            get
            {
                return yi;
            }
            set
            {
                yi = value;

            }

        }

        public int Xf
        {
            get
            {
                return xf;
            }
            set
            {
                xf = value;
            }

        }

        public int Yf
        {
            get
            {
                return yf;
            }
            set
            {
                yf = value;

            }

        }

        public Vertice VI
        {
            get
            {
                return vI;
            }
            set
            {
                vI = value;

            }
        }

        public Vertice VF
        {
            get
            {
                return vF;
            }
            set
            {
                vF = value;

            }
        }

        public int Tipo
        {
            get
            {
                return tipo;
            }
            set
            {
                tipo = value;

            }

        }

        public int NDArista
        {
            get
            {
                return ndArista;
            }
            set
            {
                ndArista = value;

            }
        }

        public int NIncr
        {
            get
            {
                return ninc;
            }
            set
            {
                ninc = value;

            }

        }

        public int Peso
        {
            get
            {
                return peso;
            }
            set
            {
                peso = value;

            }

        }
    }
}
