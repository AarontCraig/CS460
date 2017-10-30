using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Homework5.DAL
{
    public class UserContext : UserContext 
    {
        public UserContext() : base("name=UserContext")
        { }

        public virtual DbSet<UserContext> Users { get; set; }
    }
}