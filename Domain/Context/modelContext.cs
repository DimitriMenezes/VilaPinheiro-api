using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Domain.Context
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Contact> Contact { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<EventInvitation> EventInvitation { get; set; }
        public virtual DbSet<Family> Family { get; set; }
        public virtual DbSet<FamilyRelationship> FamilyRelationship { get; set; }
        public virtual DbSet<House> House { get; set; }
        public virtual DbSet<Person> Person { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=model;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>(entity =>
            {
                entity.Property(e => e.Cellphone1).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Cellphone2).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Contact)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Contact_Person");
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.Property(e => e.BeginDate).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.EndDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<EventInvitation>(entity =>
            {
                entity.HasKey(e => new { e.PersonId, e.EventId })
                    .HasName("PK_Event_Invitation");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.EventInvitation)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Event_Event_Invitation");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.EventInvitation)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Event_Person_Invented");
            });

            modelBuilder.Entity<Family>(entity =>
            {
                entity.HasOne(d => d.FamilyRelationship)
                    .WithMany(p => p.Family)
                    .HasForeignKey(d => d.FamilyRelationshipId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Family_FamilyRelationship");

                entity.HasOne(d => d.House)
                    .WithMany(p => p.Family)
                    .HasForeignKey(d => d.HouseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Family_House");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Family)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Family_Person");
            });

            modelBuilder.Entity<FamilyRelationship>(entity =>
            {
                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<House>(entity =>
            {
                entity.Property(e => e.Phone).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nickname)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
