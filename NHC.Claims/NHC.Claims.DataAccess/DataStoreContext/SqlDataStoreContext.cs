using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace NHC.Claims.DataAccess.DataStoreContext
{
    public class SqlDataStoreContext : DbContext
    {
        public SqlDataStoreContext() { }
        public SqlDataStoreContext(DbContextOptions<SqlDataStoreContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public DbSet<DataModel.Claims> Claims { get; set; }
    }
}
