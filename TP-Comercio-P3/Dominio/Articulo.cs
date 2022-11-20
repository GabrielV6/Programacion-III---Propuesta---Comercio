using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Articulo
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        
        //public Nullable<int> IdMarca { get; set; }
        //public Nullable<int> IdCategoria { get; set; }
        
        public Nullable<decimal> Precio { get; set; }
        public string ImagenUrl { get; set; }

        [DisplayName("Marca")]
        public Marca marca { get; set; }

        [DisplayName("Categoria")]
        public Categoria categoria { get; set; }

        public int Stock { get; set; }

    }
}
