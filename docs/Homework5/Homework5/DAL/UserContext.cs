using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Homework5.Models;

namespace Homework5.DAL
{
    public class UserContext : DbContext 
    {
        public UserContext() : base("name=OurDBContext")
        { }

        public virtual DbSet<UserContext> Users { get; set; }
    }
}