using System;

namespace Models.Domain
{
    public class Users
    {
        public Guid Id { get; set; }
        public string User { get; set; }
        public string Pass { get; set; }
        public bool Activo { get; set; }
        public Roles Rol { get; set; }

        public void Update(Users user)
        {
            this.User = user.User;
            this.Pass = user.Pass;
            this.Activo = user.Activo;
            this.Rol = user.Rol;
        }
    }
}
