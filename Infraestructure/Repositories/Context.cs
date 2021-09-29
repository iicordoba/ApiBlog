﻿using Microsoft.EntityFrameworkCore;
using Models.Domain;

namespace Repositories
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<Posts> Posts { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}