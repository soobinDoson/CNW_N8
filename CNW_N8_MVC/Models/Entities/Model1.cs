namespace CNW_N8_MVC.Models.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<homestay_bookings> homestay_bookings { get; set; }
        public virtual DbSet<homestay> homestays { get; set; }
        public virtual DbSet<hotel_bookings> hotel_bookings { get; set; }
        public virtual DbSet<hotel> hotels { get; set; }
        public virtual DbSet<location> locations { get; set; }
        public virtual DbSet<user> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<homestay>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<homestay>()
                .Property(e => e.more_imformation)
                .IsUnicode(false);

            modelBuilder.Entity<homestay>()
                .HasMany(e => e.homestay_bookings)
                .WithOptional(e => e.homestay)
                .HasForeignKey(e => e.homestay_id);

            modelBuilder.Entity<hotel>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<hotel>()
                .Property(e => e.more_imformation)
                .IsUnicode(false);

            modelBuilder.Entity<hotel>()
                .HasMany(e => e.hotel_bookings)
                .WithOptional(e => e.hotel)
                .HasForeignKey(e => e.hotel_id);

            modelBuilder.Entity<location>()
                .HasMany(e => e.homestays)
                .WithOptional(e => e.location)
                .HasForeignKey(e => e.location_id);

            modelBuilder.Entity<location>()
                .HasMany(e => e.hotels)
                .WithOptional(e => e.location)
                .HasForeignKey(e => e.location_id);

            modelBuilder.Entity<user>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.password)
                .IsUnicode(false);
        }
    }
}
