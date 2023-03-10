using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GymManagementSystem.Models;

public partial class GymDatabaseContext : DbContext
{
    public GymDatabaseContext()
    {
    }

    public GymDatabaseContext(DbContextOptions<GymDatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Equipment> Equipment { get; set; }

    public virtual DbSet<Member> Members { get; set; }

    public virtual DbSet<MembershipType> MembershipTypes { get; set; }

    public virtual DbSet<Trainer> Trainers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=PSL-G357XM3;Database=GymDatabase;Trusted_Connection=True;Encrypt=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Equipment>(entity =>
        {
            entity.HasKey(e => e.EquipmentId).HasName("PK__Equipmen__197068AF5F5D0FCE");

            entity.Property(e => e.EquipmentId).HasColumnName("equipment_id");
            entity.Property(e => e.EquipmentName)
                .HasMaxLength(20)
                .HasColumnName("equipment_name");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Member__3214EC07A7C84C75");

            entity.ToTable("Member");

            entity.Property(e => e.ExpiryDate)
                .HasColumnType("date")
                .HasColumnName("expiry_date");
            entity.Property(e => e.JoinDate)
                .HasColumnType("date")
                .HasColumnName("join_date");
            entity.Property(e => e.MembershipId).HasColumnName("membership_id");
            entity.Property(e => e.TrainerId).HasColumnName("trainer_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Membership).WithMany(p => p.Members)
                .HasForeignKey(d => d.MembershipId)
                .HasConstraintName("FK__Member__membersh__2F10007B");

            entity.HasOne(d => d.Trainer).WithMany(p => p.Members)
                .HasForeignKey(d => d.TrainerId)
                .HasConstraintName("FK__Member__trainer___2E1BDC42");

            entity.HasOne(d => d.User).WithMany(p => p.Members)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Member__user_id__2D27B809");
        });

        modelBuilder.Entity<MembershipType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__membersh__3214EC07EB772344");

            entity.ToTable("membership_types");

            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .HasColumnName("description");
            entity.Property(e => e.Fee)
                .HasMaxLength(10)
                .HasColumnName("fee");
            entity.Property(e => e.MembershipName)
                .HasMaxLength(20)
                .HasColumnName("membership_name");
        });

        modelBuilder.Entity<Trainer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__trainer__3214EC070F25D71A");

            entity.ToTable("trainer");

            entity.Property(e => e.JoiningDate)
                .HasColumnType("date")
                .HasColumnName("joining_date");
            entity.Property(e => e.Salary)
                .HasMaxLength(50)
                .HasColumnName("salary");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Trainers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__trainer__user_id__286302EC");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__3214EC07E27513D2");

            entity.ToTable("User");

            entity.Property(e => e.FullName)
                .HasMaxLength(100)
                .HasColumnName("full_name");
            entity.Property(e => e.MobileNo)
                .HasMaxLength(15)
                .HasColumnName("mobile_no");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
