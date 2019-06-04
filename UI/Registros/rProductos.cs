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

namespace Parcial1_JuanRosa.UI.Registros
{
    public partial class rProductos : Form
    {
        public rProductos()
        {
            InitializeComponent();
        }
        private void limpiar()
        {
            ProductoIdNumericUpDown.Value = 0;
            DescripcionTextBox.Text = String.Empty;
            CostoTextBox.Text = String.Empty;
            ExistenciaTextBox.Text = String.Empty;
            ValorInventarioTextBox.Text = String.Empty;
            SuperErrorProvider.Clear();
        }
        private Productos llenarClase()
        {
            Productos Producto = new Productos();
            Producto.productoId = Convert.ToInt32(ProductoIdNumericUpDown.Value);
            Producto.Descripcion = DescripcionTextBox.Text.ToString();
            Producto.Existencia = Convert.ToInt32(ExistenciaTextBox.Text);
            Producto.Costo = Convert.ToSingle(CostoTextBox.Text);
            float valor;
            float.TryParse(ValorInventarioTextBox.Text, out valor);
            Producto.ValorExistencia = valor;

            return Producto;
        }

        private bool ExisteEnLaBasedeDatos()
        {
            Productos Producto = ProductosBLL.Buscar((int)ProductoIdNumericUpDown.Value);
            return (Producto != null);
        }

        private void LlenarCampos(Productos Producto)
        {
            ProductoIdNumericUpDown.Value = Producto.productoId;
            DescripcionTextBox.Text = Producto.Descripcion;
            CostoTextBox.Text = Producto.Costo.ToString();
            ExistenciaTextBox.Text = Producto.Existencia.ToString();
            ValorInventarioTextBox.Text = Producto.ValorExistencia.ToString();
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            int id;
            Productos producto = new Productos();
            int.TryParse(ProductoIdNumericUpDown.Value.ToString(), out id);
            limpiar();

            producto = ProductosBLL.Buscar(id);

            if (producto != null)
            {
                MessageBox.Show("Producto Encontrada");
                LlenarCampos(producto);
            }
            else
                MessageBox.Show("Producto no encontrada");
        }


        private void GuardarButton_Click(object sender, EventArgs e)
        {
            Productos Producto;
            bool paso = false;


            if (!Validar())
                return;
            Producto = llenarClase();
            limpiar();

            if (ProductoIdNumericUpDown.Value == 0)
            {
                paso = ProductosBLL.Guardar(Producto);
            }
            else
            {
                if (!ExisteEnLaBasedeDatos())
                {
                    MessageBox.Show("No se puede modificar un producto que no existe", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = ProductosBLL.Modificar(Producto);
            }
            if (paso)
                MessageBox.Show("Guardado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            else
                MessageBox.Show("No se pudo guardar!!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool Validar()
        {
            bool paso = true;

            {
                if (String.IsNullOrWhiteSpace(DescripcionTextBox.Text))
                {
                    SuperErrorProvider.SetError(DescripcionTextBox, "Este campo no debe estar vacio");
                    DescripcionTextBox.Focus();
                    paso = false;
                }

                if (String.IsNullOrWhiteSpace(CostoTextBox.Text))
                {
                    SuperErrorProvider.SetError(CostoTextBox, "Este campo no debe estar vacio");
                    CostoTextBox.Focus();
                    paso = false;
                }

                if (String.IsNullOrWhiteSpace(ExistenciaTextBox.Text))
                {
                    SuperErrorProvider.SetError(ExistenciaTextBox, "Este campo no debe estar vacio");
                    ExistenciaTextBox.Focus();
                    paso = false;
                }

            }

            return paso;
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            SuperErrorProvider.Clear();
            int id;
            int.TryParse(Convert.ToString(ProductoIdNumericUpDown.Value), out id);
            limpiar();
            if (ProductosBLL.Eliminar(id))
                MessageBox.Show("Eliminado");
            else
                SuperErrorProvider.SetError(ProductoIdNumericUpDown, "No se puede eliminar un producto que no existe");

        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void ExistenciaTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {

                int existencia;
                int.TryParse(ExistenciaTextBox.Text, out existencia);
                float costo;
                float.TryParse(CostoTextBox.Text, out costo);
                float ValorInventario = existencia * costo;
                ValorInventarioTextBox.Text = ValorInventario.ToString();
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void CostoTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int existencia;
                int.TryParse(ExistenciaTextBox.Text, out existencia);
                float costo;
                float.TryParse(CostoTextBox.Text, out costo);
                float ValorInventario = existencia * costo;
                ValorInventarioTextBox.Text = Convert.ToString(ValorInventario.ToString());
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void AgregarUbicacionButton_Click(object sender, EventArgs e)
        {
            rUbicacion ub = new rUbicacion();
            ub.Show();
        }

        

        private void RProductos_Load(object sender, EventArgs e)
        {
            Contexto c = new Contexto();
            UbicacionComboBox.DisplayMember = "Descripcion";
            UbicacionComboBox.ValueMember = "UbicacionId";
            UbicacionComboBox.DataSource = c.Ubicaciones.Where(p=>true).ToList();
        }

    
    }
    
}
