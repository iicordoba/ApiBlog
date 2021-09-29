using System;

namespace Models.Domain
{
    public class Comments
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public DateTime SubmitedDate { get; set; }
        public Posts Post { get; set; }
        public bool Activo { get; set; }
    }
}
