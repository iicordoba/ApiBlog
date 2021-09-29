using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Domain
{
    public class Roles
    {
        public Guid Id { get; set; }
        public string Rol { get; set; }
        public bool Activo { get; set; }

        public void Update(Roles rol)
        {
            this.Rol = rol.Rol;
            this.Activo = rol.Activo;
        }
    }
}
