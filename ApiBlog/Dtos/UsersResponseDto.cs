using Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBlog.Dtos
{
    public class UsersResponseDto
    {
        public Guid Id { get; set; }
        public string User { get; set; }
        public string Pass { get; set; }
        public bool Activo { get; set; }
        public Roles Rol { get; set; }
    }
}
