﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBlog.Dtos
{
    public class RolesResponseDto
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }
    }
}
