using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorDeGrafosV1._0
{
    [Serializable()]
    class Grafo
    {
        private List<Vertice> lisVert;
        private List<Arista> lisAris;
        private String name;
        private int tipoGrfo;

        public Grafo()
        {
            lisVert = new List<Vertice>();
            lisAris = new List<Arista>();
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

        public int Tipo
        {
            get
            {
                return tipoGrfo;
            }
            set
            {
                tipoGrfo = value;

            }
        }

        public List<Vertice> ListaVert
        {
            get
            {
                return lisVert;
            }
            set
            {
                lisVert = value;

            }
        }

        public List<Arista> ListaArista
        {
            get
            {
                return lisAris;
            }
            set
            {
                lisAris = value;

            }
        }
    }
}
