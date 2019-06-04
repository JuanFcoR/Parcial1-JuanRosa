using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Parcial1_JuanRosa.BLL;
using Parcial1_JuanRosa.DAL;
using Parcial1_JuanRosa.Entidades;
using Parcial1_JuanRosa.UI.Registros;

namespace Parcial1_JuanRosa.UI.Registros
{
    public partial class rUbicacion : Form
    {
        public rUbicacion()
        {
            InitializeComponent();
        }

        private Ubicaciones LlenarClase()
        {
            Ubicaciones ubicaciones = new Ubicaciones();
            ubicaciones.UbicacionId = Convert.ToInt32(UbicacionIdNumericupDown.Value);
            ubicaciones.Descripcion = DescripcionTextBox.Text;

            return ubicaciones;
        }

        private bool ExisteEnLaBasedeDatos()
        {
            Ubicaciones ubicaciones = UbicacionesBLL.Buscar((int)UbicacionIdNumericupDown.Value);
            return (ubicaciones != null);
        }

        private bool validar()
        {
            bool paso = true;

            
                if (String.IsNullOrWhiteSpace(DescripcionTextBox.Text))
                {
                    SuperErrorProvider.SetError(DescripcionTextBox, "Este campo no debe estar vacio");
                    DescripcionTextBox.Focus();
                    paso = false;
                }
            return paso;
        }

        private void ObtenerCampos(Ubicaciones ubicaciones)
        {
            UbicacionIdNumericupDown.Value = ubicaciones.UbicacionId;
            DescripcionTextBox.Text = ubicaciones.Descripcion;
        }

        private void limpiar()
        {
            UbicacionIdNumericupDown.Value = 0;
            DescripcionTextBox.Text = String.Empty;
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            int id;
            Ubicaciones ubicaciones = new Ubicaciones();
            int.TryParse(UbicacionIdNumericupDown.Value.ToString(), out id);
            limpiar();

            ubicaciones = UbicacionesBLL.Buscar(id);

            if (ubicaciones != null)
            {
                MessageBox.Show("Ubicacion Encontrada");
                ObtenerCampos(ubicaciones);
            }
            else
                MessageBox.Show("Ubicacion no encontrada");



        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void GuardarButton_Click(object sender, EventArgs e)

        {
            Ubicaciones ubicaciones;
            bool paso = false;


            if (!validar())
                return;
            ubicaciones = LlenarClase();
            limpiar();

            if (UbicacionIdNumericupDown.Value == 0)
            {
                if (!validarBase(DescripcionTextBox.Text))
                    return;
                paso = UbicacionesBLL.Guardar(ubicaciones);
            }
            else
            {
                if (!ExisteEnLaBasedeDatos())
                {
                    MessageBox.Show("No se puede modificar una ubicacion que no existe", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = UbicacionesBLL.Modificar(ubicaciones);
            }
            if (paso)
                MessageBox.Show("Guardado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            else
                MessageBox.Show("No se pudo guardar!!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        private bool validarBase(string campo)
        {

            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                if (db.Ubicaciones.Any(p => p.Descripcion.Equals(campo)))
                {
                    paso = true;
                }
            }
            catch (Exception)
            {
                throw;
            }



            return paso;

        }


        private void EliminarButton_Click(object sender, EventArgs e)
        {
            SuperErrorProvider.Clear();
            int id;
            int.TryParse(Convert.ToString(UbicacionIdNumericupDown.Value), out id);
            limpiar();
            if (UbicacionesBLL.Eliminar(id))
                MessageBox.Show("Eliminado");
            else
                SuperErrorProvider.SetError(UbicacionIdNumericupDown, "No se puede eliminar una ubicacion que no existe");
        }
    }
}
