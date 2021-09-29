using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
