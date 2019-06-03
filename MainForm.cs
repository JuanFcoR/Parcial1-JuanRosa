using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Parcial1_JuanRosa.UI.Registros;
using Parcial1_JuanRosa.UI.Consultas;

namespace Parcial1_JuanRosa
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void ProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rProductos p = new rProductos();
            p.Visible = true;
        }

        private void ValorTotalDelInventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cValorTotalInventario v = new cValorTotalInventario();
            v.Visible = true;
        }
    }
}
