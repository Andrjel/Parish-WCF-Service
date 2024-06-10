using Parish.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Parish.Infrastructure
{
    /// <summary>
    /// ParishDB context
    /// </summary>
    public class ParishContext: DbContext
    {
        /// <summary>
        /// Constructor with connection string specified in config
        /// </summary>
        public ParishContext() : base("name=ParishContext")
        {
        }

        /// <summary>
        /// DbSet for Parishes
        /// </summary>
        public DbSet<ParishModel> Parishes { get; set; }

        /// <summary>
        /// Custom model creation - not used
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
