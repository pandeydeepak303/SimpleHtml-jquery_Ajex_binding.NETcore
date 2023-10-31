using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
namespace PracticeProjectLive.Empmodel
{
    public partial class DemoLiveContext : DbContext
    {
        public DemoLiveContext()
        {
        }

        public DemoLiveContext(DbContextOptions<DemoLiveContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblCompany> TblCompany { get; set; }
        public virtual DbSet<TblDepartment> TblDepartment { get; set; }
        public virtual DbSet<TblDetails> TblDetails { get; set; }
        public virtual DbSet<TblEmployee> TblEmployee { get; set; }
        public virtual DbSet<TblUser> TblUser { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            optionsBuilder.UseSqlServer("Server= DESKTOP-MNV89QG\\SQLEXPRESS;Database=DemoLive;Integrated Security=True;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblCompany>(entity =>
            {
                entity.HasKey(e => e.Cid);

                entity.ToTable("Tbl_Company");

                entity.Property(e => e.Cid).HasColumnName("CId");

                entity.Property(e => e.Cname)
                    .HasColumnName("CName")
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblDepartment>(entity =>
            {
                entity.HasKey(e => e.Did)
                    .HasName("PK_Department");

                entity.ToTable("Tbl_Department");

                entity.Property(e => e.Did).HasColumnName("DId");

                entity.Property(e => e.DepName)
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblDetails>(entity =>
            {
                entity.HasKey(e => e.EdId);

                entity.ToTable("Tbl_Details");

                entity.Property(e => e.EdId).HasColumnName("ED_Id");

                entity.Property(e => e.Address)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Education)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Percentage)
                    .HasColumnName("percentage")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Qualification)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.QualificationYear)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.E)
                    .WithMany(p => p.TblDetails)
                    .HasForeignKey(d => d.Eid)
                    .HasConstraintName("FK_Tbl_Details_Tbl_Employee");
            });

            modelBuilder.Entity<TblEmployee>(entity =>
            {
                entity.HasKey(e => e.Eid);

                entity.ToTable("Tbl_Employee");

                entity.Property(e => e.Eid).HasColumnName("EId");

                entity.Property(e => e.Cid).HasColumnName("CId");

                entity.Property(e => e.Did).HasColumnName("DId");

                entity.Property(e => e.EmpName)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.C)
                    .WithMany(p => p.TblEmployee)
                    .HasForeignKey(d => d.Cid)
                    .HasConstraintName("FK_Tbl_Employee_Tbl_Company");

                entity.HasOne(d => d.D)
                    .WithMany(p => p.TblEmployee)
                    .HasForeignKey(d => d.Did)
                    .HasConstraintName("FK_Tbl_Employee_Tbl_Department");
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("Tbl_User");

                entity.Property(e => e.Email)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Mobile)
                    .HasColumnName("mobile")
                    .HasMaxLength(50)
                    .IsUnicode(false);


                entity.Property(e => e.Password)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
