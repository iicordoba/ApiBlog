using Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos
{
    public class UsersAddDto
    {
        public string User { get; set; }
        public string Pass { get; set; }
        public bool Activo { get; set; }
        public Guid RolId { get; set; }
    }
}
