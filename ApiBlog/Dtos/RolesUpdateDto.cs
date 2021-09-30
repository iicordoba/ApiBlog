using System;

namespace ApiBlog.Dtos
{
    public class RolesUpdateDto
    {
        public Guid Id { get; set; }
        public string Rol { get; set; }
        public bool Activo { get; set; }
    }
}
