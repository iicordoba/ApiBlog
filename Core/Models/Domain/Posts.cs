﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Domain
{
    public class Posts
    {
        public Guid Id { get; set; }
        public string Tittle { get; set; }
        public string Post { get; set; }
        public int Status { get; set; }
        public DateTime SubmitedDate { get; set; }
        public Users SubmitedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Users UpdatedBy { get; set; }
        public DateTime PublishedDate { get; set; }
        public bool Activo { get; set; }

        public void Update(Posts post, Users user)
        {
            this.Tittle = post.Tittle;
            this.Post = post.Post;
            this.Status = post.Status;
            this.UpdatedDate = DateTime.Now;
            this.UpdatedBy = user;
            this.PublishedDate = post.PublishedDate;
            this.Activo = post.Activo;
        }

        public void Publish(Posts post, Users user)
        {
            this.Tittle = post.Tittle;
            this.Post = post.Post;
            this.Status = post.Status;//set status as published
            this.UpdatedDate = DateTime.Now;
            this.UpdatedBy = user;
            this.PublishedDate = DateTime.Now;
            this.Activo = post.Activo;
        }

    }
}
