
namespace PROG2PRY1.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<T_Categoria> T_Categoria { get; set; }
        public virtual DbSet<T_Clientes> T_Clientes { get; set; }
        public virtual DbSet<T_Productos> T_Productos { get; set; }
    }
}
