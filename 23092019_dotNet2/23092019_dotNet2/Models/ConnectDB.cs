using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using _23092019_dotNet2.Models;

namespace _23092019_dotNet2.Models
{
    public class ConnectDB: DbContext
    {
        public ConnectDB() : base("dbPath") { }
        public DbSet<User> tbl_User { get; set; }
        public DbSet<User> tbl_GroupUser { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("tbl_User");
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<GroupUser>().ToTable("tbl_GroupUser");
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}