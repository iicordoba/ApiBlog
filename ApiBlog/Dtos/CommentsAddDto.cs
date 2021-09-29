using Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos
{
    public class CommentsAddDto
    {
        public string Name { get; set; }
        public string Comment { get; set; }
        public DateTime SubmitedDate { get; set; }
        public Posts Post { get; set; }
        public bool Activo { get; set; }
    }
}
