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
    public partial class Peso : Form
    {
        public int peso = 0;
        public int res = 0;
        public Peso()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        { 
            peso = Convert.ToInt32(textBox1.Text);
            this.DialogResult = DialogResult.OK;
            this.Visible = false;

        }
    }
}
