using Models.Enumeration;
using System;

namespace Models.Domain
{
    public class Roles
    {
        public Guid Id { get; set; }
        public string Rol { get; set; }
        public TipoRol TipoRol { get; set; }
        public bool Activo { get; set; }

        public void Update(Roles rol)
        {
            this.Rol = rol.Rol;
            this.Activo = rol.Activo;
        }
    }
}
