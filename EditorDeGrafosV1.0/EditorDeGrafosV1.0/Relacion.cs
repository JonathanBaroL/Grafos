using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorDeGrafosV1._0
{
    [Serializable()]
    public class Relacion
    {
        private int gm;
        private int gM;
        private String relacion;

        public int Gmenor
        {
            get
            {
                return gm;
            }
            set
            {
                gm = value;
            }

        }

        public int GMayor
        {
            get
            {
                return gM;
            }
            set
            {
                gM = value;
            }

        }

        public String Rela
        {
            get
            {
                return relacion;
            }
            set
            {
                relacion = value;
            }

        }
    }
}
