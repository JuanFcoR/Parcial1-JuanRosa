using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Parcial1_JuanRosa.Entidades;
using Parcial1_JuanRosa.BLL;
using Parcial1_JuanRosa.DAL;
using System.Data.Entity;

namespace Parcial1_JuanRosa.UI.Consultas
{
    public partial class cValorTotalInventario : Form
    {
        public cValorTotalInventario()
        {
            InitializeComponent();
        }

        private bool ExisteEnLaBasedeDatos()
        {
            ValorTotalDeInventario vl = ValorTotalDeInventarioBLL.Buscar(1);
            return (vl != null);
        }

        private ValorTotalDeInventario llenarClase()
        {
            Contexto c = new Contexto();
            ValorTotalDeInventario vl = new ValorTotalDeInventario();
            vl.ValorTotalInventarioId = 1;
            var suma = c.Productos.Sum(p => p.ValorExistencia);
            vl.ValorTotalInventario = vl.ValorTotalInventario = Convert.ToSingle(suma);
            c.SaveChanges();
            c.Dispose();
            return vl;

        }
        private void RefresacrButton_Click(object sender, EventArgs e)
        {
            bool paso = false;
            Contexto c = new Contexto();
            ValorTotalDeInventario vl;
            vl = llenarClase();

            if (vl.ValorTotalInventarioId == 0)
            {
                ValorTotalDeInventarioBLL.Guardar(vl);
            }
            else
            {

                paso = ValorTotalDeInventarioBLL.Modificar(vl);
            }
            ValorTextBox.Text = vl.ValorTotalInventario.ToString();

        }
    }
}

