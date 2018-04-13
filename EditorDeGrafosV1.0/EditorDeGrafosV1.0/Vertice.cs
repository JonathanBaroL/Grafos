using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace EditorDeGrafosV1._0
{
    [Serializable()]
    class Vertice
    {
        private int x;
        private int y;
        private String name;
        private List<Relacion> lisRelacion;

        public Vertice()
        {
            lisRelacion = new List<Relacion>();
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

        public List<Relacion> listaRelacion
        {
            get
            {
                return lisRelacion;
            }
            set
            {
                lisRelacion = value;

            }
        }

    }
}
