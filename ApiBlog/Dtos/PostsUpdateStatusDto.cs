using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBlog.Dtos
{
    public class PostsUpdateStatusDto
    {
        public Guid Id { get; set; }
        public int Status { get; set; }
    }
}
