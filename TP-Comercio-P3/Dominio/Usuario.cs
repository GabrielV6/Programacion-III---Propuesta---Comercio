using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public enum RolUsuario
    {
        Administrador = 1000,
        Usuario = 1001
    }
    public class Usuario
    {
        public int Id { get; set; }
        public string user { get; set; }
        public string pass { get; set; }
        public RolUsuario rolusuario { get; set; }
        public string patron { get; set; }
        
        public Usuario(string user, string pass, bool Administrador, string patron)
        {
            this.user = user;
            this.pass = pass;
            this.rolusuario = Administrador ? RolUsuario.Administrador : RolUsuario.Usuario;
            this.patron = patron;
        }


    }
}
