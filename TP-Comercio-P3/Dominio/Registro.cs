﻿using System;
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
        public Nullable<decimal> MontoTotal { get; set; }
        public Nullable<decimal> Porcentaje { get; set; }
        public Nullable<decimal> PrecioXCantidad { get; set; }
        // atributo fecha
        public DateTime Fecha { get; set; }
        public int Estado { get; set; }

        [DisplayName("Articulo")]
        public Articulo articulo { get; set; }

        [DisplayName("Proveedor")]
        public Proveedor proveedor { get; set; }

        [DisplayName("Cliente")]
        public Cliente cliente { get; set; }
        public int IdFactura { get; set; }

    }
}
