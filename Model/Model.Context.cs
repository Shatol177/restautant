//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Restaurant.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ARM_RestoranEntities : DbContext
    {
        public ARM_RestoranEntities()
            : base("name=ARM_RestoranEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Admins> Admins { get; set; }
        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<Dishes> Dishes { get; set; }
        public virtual DbSet<Managers> Managers { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<receipt> receipt { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Tables> Tables { get; set; }
        public virtual DbSet<Wraiters> Wraiters { get; set; }
    }
}
