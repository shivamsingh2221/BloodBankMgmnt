using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FinalAPI.Models
{
    public partial class inventoryContext : DbContext
    {
      

        public inventoryContext(DbContextOptions<inventoryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Donor> Donor { get; set; }
        public virtual DbSet<Receiver> Receiver { get; set; }
        public virtual DbSet<TotalBlood> TotalBlood { get; set; }

     
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Donor>(entity =>
            {
                entity.ToTable("donor");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.BloodGroup)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Receiver>(entity =>
            {
                entity.ToTable("receiver");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.BloodGroup)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TotalBlood>(entity =>
            {
                // entity.HasNoKey();
                entity.HasKey(e => e.DonorId);
                entity.Property(e => e.DonorId).HasColumnName("Donor_ID");

                entity.Property(e => e.ReceiverId).HasColumnName("Receiver_ID");

                entity.HasOne(d => d.Donor)
                    .WithMany()
                    .HasForeignKey(d => d.DonorId)
                    .HasConstraintName("FK__TotalBloo__Donor__2D27B809");

                entity.HasOne(d => d.Receiver)
                    .WithMany()
                    .HasForeignKey(d => d.ReceiverId)
                    .HasConstraintName("FK__TotalBloo__Recei__2E1BDC42");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
