using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Marca
    {
        public int Id { get; set; }
        public int Estado { get; set; }

        [DisplayName("Marcas")]
        public string DescripcionMarca { get; set; }

        public override string ToString()
        {
            return DescripcionMarca;
        }
    }
}
