using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace LabourZillaZoneee.Models
{
    public partial class LabourZillaZoneContext : DbContext
    {
        public LabourZillaZoneContext()
        {
        }

        public LabourZillaZoneContext(DbContextOptions<LabourZillaZoneContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Labour> Labours { get; set; }
        public virtual DbSet<Test> Tests { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tcp:labourzilla123.database.windows.net,1433;Initial Catalog=LabourZillaZone;Persist Security Info=False;User ID=LabourZilla123;Password=Pragya@123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.LoginId)
                    .HasName("PK__Admin__4DDA2818EA939EE7");

                entity.ToTable("Admin");

                entity.Property(e => e.LoginId).HasMaxLength(50);

                entity.Property(e => e.AdminName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Apassword)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("APassword");

                entity.Property(e => e.RoleA)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Role_A");
            });

            modelBuilder.Entity<Labour>(entity =>
            {
                entity.ToTable("labour");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .HasColumnName("ID");

                entity.Property(e => e.Available).HasMaxLength(20);

                entity.Property(e => e.CityAddress).HasMaxLength(100);

                entity.Property(e => e.Cnfrmpswd).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Lcontact)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("LContact");

                entity.Property(e => e.Ppic)
                    .HasMaxLength(100)
                    .HasColumnName("PPic");

                entity.Property(e => e.Profession).HasMaxLength(50);

                entity.Property(e => e.Pswd)
                    .HasMaxLength(50)
                    .HasColumnName("pswd");

                entity.Property(e => e.RoleL)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Role_L");

                entity.Property(e => e.StateL).HasMaxLength(50);

                entity.Property(e => e.TimeDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Test>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Test");

                entity.Property(e => e.Tdate)
                    .HasColumnType("datetime")
                    .HasColumnName("TDate");

                entity.Property(e => e.Temail)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Tname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("TName");

                entity.Property(e => e.TprojectName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).HasMaxLength(100);

                entity.Property(e => e.CityAddress).HasMaxLength(100);

                entity.Property(e => e.ConfirmPassword)
                    .HasMaxLength(100)
                    .HasColumnName("Confirm_password");

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Lcontact)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("LContact");

                entity.Property(e => e.PasswordC).HasMaxLength(100);

                entity.Property(e => e.RoleU)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Role_U");

                entity.Property(e => e.StateC).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
