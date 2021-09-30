using System;

namespace ApiBlog.Dtos
{
    public class PostsUpdateDto
    {
        public Guid Id { get; set; }
        public string Tittle { get; set; }
        public string Post { get; set; }
        public int Status { get; set; }
        public Guid UpdatedById { get; set; }
        public bool Activo { get; set; }
    }
}
