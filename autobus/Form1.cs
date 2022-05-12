using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace autobus
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void vectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            csVector vector = new csVector();   
            vector.ShowDialog();    
        }

        private void matrizToolStripMenuItem_Click(object sender, EventArgs e)
        {
            csMatriz matriz = new csMatriz();   
            matriz.ShowDialog();
        }
    }
}
