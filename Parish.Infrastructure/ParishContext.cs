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
        public ParishContext() : base("Server=localhost,1401;Database=ParishDB;User Id=sa;Password=Password!23;")
        {
        }

        public DbSet<ParishDTO> Parishes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        //public class ParishDBInitializer : DropCreateDatabaseAlways<ParishContext>
        //{
        //    protected override void Seed(ParishContext context)
        //    {
        //        base.Seed(context);
        //        context.Parishes.Add(new ParishModel { Id = Guid.NewGuid(), Name = "Parafia 1",Street = "Adres 1", City = "Miasto 1"});
        //        context.Parishes.Add(new ParishModel { Id = Guid.NewGuid(), Name = "Parafia 2", Street = "Adres 2", City = "Miasto 2"});
        //        context.SaveChanges();
        //    }
        //}
    }
}
