﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos
{
    public class PostsAddDto
    {
        public string Tittle { get; set; }
        public string Post { get; set; }
        public int Status { get; set; }
        public Guid SubmitedById { get; set; }
        public bool Activo { get; set; }

    }
}