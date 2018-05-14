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

        public void AgregarGrados()
        {
            foreach (Vertice v in ListaVert)
            {
                int cont = 0, cont2 = 0;
                foreach (Arista a in lisAris)
                {
                    if (v.Name == a.VI.Name)
                    {
                        cont++;
                    }
                    if (v.Name == a.VF.Name)
                    {
                        cont2++;
                    }

                }
                v.GradoS = cont;
                v.GradoE = cont2;
            }
        }

        public void AgregaAdyacencias()
        {
            foreach (Vertice v in ListaVert)
            {
                foreach (Arista a in lisAris)
                {
                    if (v.Name == a.VF.Name)
                    { 
                        v.listaVert.Add(a.VI);
                    }
                }
            }
        }

        public void AgregaAdyacenciasNo()
        {
            try
            {
                foreach (Vertice v in ListaVert)
                {
                    foreach (Arista a in lisAris)
                    {
                        if (v.Name == a.VF.Name)
                        {
                            v.listaVert.Add(a.VI);
                        }
                        if (v.Name == a.VI.Name)
                        {
                            v.listaVert.Add(a.VF);
                        }
                    }
                }
            }
            catch
            {

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
