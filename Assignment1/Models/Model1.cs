namespace Assignment1.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=DeafultConnection")
        {
        }

        public virtual DbSet<Bike> Bikes { get; set; }
        public virtual DbSet<Car> Cars { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bike>()
                .Property(e => e.Bike1)
                .IsFixedLength();

            modelBuilder.Entity<Bike>()
                .Property(e => e.Bike2)
                .IsFixedLength();

            modelBuilder.Entity<Bike>()
                .Property(e => e.Bike3)
                .IsFixedLength();

            modelBuilder.Entity<Car>()
                .Property(e => e.Car1)
                .IsFixedLength();

            modelBuilder.Entity<Car>()
                .Property(e => e.Car2)
                .IsFixedLength();

            modelBuilder.Entity<Car>()
                .Property(e => e.Car3)
                .IsFixedLength();
        }
    }
}
