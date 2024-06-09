using Parish.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Parish.Infrastructure
{
    public class ParishContext: DbContext
    {
        public ParishContext() : base("name=ParishContext")
        {
        }

        public DbSet<ParishModel> Parishes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
