using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1_JuanRosa.Entidades
{
    public class ValorTotalDeInventario
    {
        [Key]
        public int ValorTotalInventarioId { get; set; }
        public float ValorTotalInventario { get; set; }

        public ValorTotalDeInventario()
        {
            ValorTotalInventarioId = 0;
            ValorTotalInventario = 0;
        }

    }
}
