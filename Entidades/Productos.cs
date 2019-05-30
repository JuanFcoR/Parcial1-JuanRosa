using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Parcial1_JuanRosa.Entidades
{
    
    public class Productos
    {
        [Key]
        public int productoId { get; set; }
        public string Descripcion { get; set; }
        public int Existencia { get; set; }
        public double Costo { get; set; }
        public double ValorExistencia { get; set; }

        public Productos()
        {
            productoId = 0;
            Descripcion = String.Empty;
            Existencia = 0;
            Costo = 0;
            ValorExistencia = 0;
        }

    }
}
