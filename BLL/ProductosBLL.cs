using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parcial1_JuanRosa.Entidades;
using Parcial1_JuanRosa.DAL;
using System.Data.Entity;

namespace Parcial1_JuanRosa.BLL
{
    public class ProductosBLL
    {
        public static bool Guardar(Productos Producto)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                if (contexto.Productos.Add(Producto)!=null)
                {
                    contexto.SaveChanges();
                    paso = true;
                }
                contexto.Dispose();

            }
            catch (Exception)
            {

                throw;
            }
            

            return paso;
        }

        public static bool Modificar(Productos Producto)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Entry(Producto).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            return paso;
        }

        
    }
}
