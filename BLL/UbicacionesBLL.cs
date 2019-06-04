using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parcial1_JuanRosa.Entidades;
using System.Data.Entity;
using Parcial1_JuanRosa.DAL;
using System.Linq.Expressions;

namespace Parcial1_JuanRosa.BLL
{
   public class UbicacionesBLL
    {
        public static bool Guardar(Ubicaciones ubicaciones)
        {
            bool paso = false;
            Contexto c = new Contexto();

            try
            {
                if(c.Ubicaciones.Add(ubicaciones)!=null)
                {
                    c.SaveChanges();
                    paso = true;
                }
                c.Dispose();
            }
            catch (Exception)
            {

                throw;
            }

            return paso;
        }

        public static bool Modificar(Ubicaciones ubicaciones)
        {
            bool paso = false;
            Contexto c = new Contexto();
            try
            {
                c.Entry(ubicaciones).State = EntityState.Modified;
                paso = c.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }

            return paso;
        }

        public static Ubicaciones Buscar(int id)
        {
            Contexto c = new Contexto();
            Ubicaciones ubicaciones;
                
            try
            {
               ubicaciones=c.Ubicaciones.Find(id);
                c.Dispose();
            }
            
            catch (Exception)
            {

                throw;
            }

            return ubicaciones;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto c = new Contexto();
            Ubicaciones ubicaciones;

            try
            {
                ubicaciones = c.Ubicaciones.Find(id);
                paso = c.SaveChanges() > 0;
                c.Dispose();
            }

            catch (Exception)
            {

                throw;
            }

            return paso;
        }
        public static List<Ubicaciones> GetList(Expression<Func<Ubicaciones, bool>> expression)
        {
            List<Ubicaciones> ubicacion = new List<Ubicaciones>();
            Contexto contexto = new Contexto();

            try
            {
                contexto.Ubicaciones.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {

                throw;
            }

            return ubicacion;
        }
    }
}
