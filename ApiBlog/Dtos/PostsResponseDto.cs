using Models.Domain;
using Models.Enumeration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBlog.Dtos
{
    public class PostsResponseDto
    {
        public string Tittle { get; set; }
        public string Post { get; set; }
        public EstadoPost Status { get; set; }
        public DateTime SubmitedDate { get; set; }
        public Users SubmitedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Users UpdatedBy { get; set; }
        public DateTime PublishedDate { get; set; }
        public bool Activo { get; set; }
    }
}
