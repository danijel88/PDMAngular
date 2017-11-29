using Microsoft.EntityFrameworkCore;
using PDMAngular.Models;

namespace PDMAngular.Persistence
{
    public class PdmDbContext : DbContext
    {
        public DbSet<ItemType> ItemTypes { get; set; }
        public DbSet<MachineType> MachineTypes { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemHist> ItemHists { get; set; }

        public PdmDbContext(DbContextOptions<PdmDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemType>(entity =>
            {
                entity.HasKey(it => it.Id);

                entity.Property(it => it.Id)
                .ValueGeneratedOnAdd();

                entity.Property(it => it.Name)
                .IsRequired()
                .HasMaxLength(150);

                entity
                .HasMany(it => it.Items)
                .WithOne(i => i.ItemType)
                .IsRequired();

                entity
                .HasMany(it => it.ItemHists)
                .WithOne(ih => ih.ItemType);

            });

            modelBuilder.Entity<MachineType>(entity =>
            {
                entity.HasKey(mt => mt.Id);

                entity.Property(mt => mt.Id)
                .ValueGeneratedOnAdd();

                entity.Property(mt => mt.Name)
                .IsRequired()
                .HasMaxLength(150);

                entity
                .HasMany(mt => mt.Items)
                .WithOne(i => i.MachineType)
                .IsRequired();

                entity
                .HasMany(mt => mt.ItemHists)
                .WithOne(ih => ih.MachineType);
            });

            modelBuilder.Entity<Item>(entity =>
            {

                entity.HasKey(i => i.Id);

                entity.Property(i => i.Id)
                .ValueGeneratedOnAdd();

                entity
                .HasIndex(i => i.InternalCode)
                .IsUnique(true);


                entity.Property(i => i.InternalCode)
                .IsRequired()
                .HasMaxLength(50);

                entity.HasIndex(i => i.MadeBy);

                entity.Property(i => i.MadeBy)
                .IsRequired()
                .HasMaxLength(150);

                entity
                .HasMany(i => i.ItemHists)
                .WithOne(ih => ih.Item)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            });

            modelBuilder.Entity<ItemHist>(entity =>
            {

                entity.HasKey(ih => ih.Id);

                entity.Property(ih => ih.Id)
                .ValueGeneratedOnAdd();

                entity.Property(ih => ih.InternalCode)
                .HasMaxLength(50)
                .IsRequired();

                entity.Property(ih => ih.MadeBy)
                .HasMaxLength(150)
                .IsRequired();

            });





        }
    }
}
