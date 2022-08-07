using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Assignment_2.Models;

namespace Assignment_2.MyContext
{
    public class ApllicationContext : DbContext
    {
        public ApllicationContext() : base("Sindesmos")
        {

        }

        public virtual DbSet<Trainer> Trainers { get; set; }
    }
}