using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Homework5.Models;

namespace Homework5.DAL
{
    //Setting up the DBContext class
    public class UserContext : DbContext 
    {
        public UserContext() : base("name=OurDBContext")
        { }
        //The set of Users from my DB
        public virtual DbSet<User> Users { get; set; }
    }
}