using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parcial1_JuanRosa.Entidades;

namespace Parcial1_JuanRosa.DAL
{
    class ValorContext:DbContext
    {
        public DbSet<ValorTotalDeInventario> ValorTotalDeInventarios;
        public ValorContext() : base("ConStr") { }
    }
}
