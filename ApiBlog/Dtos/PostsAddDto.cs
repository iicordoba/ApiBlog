using System;

namespace ApiBlog.Dtos
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