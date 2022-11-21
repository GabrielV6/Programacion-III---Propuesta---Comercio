using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Registro
    {
        public int Id { get; set; }
        public int Tipo { get; set; }
        public int Destinatario { get; set; }
        public int Cantidad { get; set; }
        public Nullable<decimal> Monto { get; set; }
        public int Estado { get; set; }

        [DisplayName("Articulo")]
        public Articulo articulo { get; set; }
    }
}
