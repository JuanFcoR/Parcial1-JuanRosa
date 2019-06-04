using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using Parcial1_JuanRosa.BLL;
using Parcial1_JuanRosa.DAL;
using Parcial1_JuanRosa.Entidades;

namespace Parcial1_JuanRosa.BLL
{
    public class ValorTotalDeInventarioBLL
    {
        public static bool Guardar(ValorTotalDeInventario valorTotaInventario)
        {
            bool paso = false;
            Contexto context = new Contexto();
            try
            {
                if (context.valorTotalDeInventarios.Add(valorTotaInventario)!=null)
                {
                    context.SaveChanges();
                    paso = true;
                }
                context.Dispose();
            }
            catch (Exception)
            {

                throw;
            }
            return paso;
        }

        public static bool Modificar(ValorTotalDeInventario valorTotaInventario)
        {
            bool paso = false;
            Contexto context = new Contexto();
            try
            {
               
                context.Entry(valorTotaInventario).State = EntityState.Modified;
                paso = context.SaveChanges()>0;
                
                context.Dispose();
            }
            catch (Exception)
            {

                throw;
            }
            return paso;
        }

        public static ValorTotalDeInventario Buscar(int id)
        {
            Contexto contexto = new Contexto();
            ValorTotalDeInventario valor;
            try
            {
                valor = contexto.valorTotalDeInventarios.Find(id);
                contexto.Dispose();
            }

            catch (Exception)
            {

                throw;
            }

            return valor;
        }
    }
}
