using Parcial1_JuanRosa.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1_JuanRosa.DAL
{
    public class Contexto:DbContext
    {
        public DbSet<Productos> Productos { get; set; }
        public DbSet<ValorTotalDeInventario> valorTotalDeInventarios { get; set; }
        public DbSet<Ubicaciones> Ubicaciones { get; set; }

        public Contexto():base("ConStr")
        {

        }
    }
}
