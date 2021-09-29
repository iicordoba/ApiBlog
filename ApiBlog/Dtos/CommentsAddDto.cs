using System;

namespace ApiBlog.Dtos
{
    public class CommentsAddDto
    {
        public string Name { get; set; }
        public string Comment { get; set; }
        public Guid PostId { get; set; }
        public bool Activo { get; set; }
    }
}
