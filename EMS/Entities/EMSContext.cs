using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace EMS.Entities
{
    public partial class EMSContext : DbContext
    {
        public EMSContext()
        {
        }

        public EMSContext(DbContextOptions<EMSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Prof> Profs { get; set; }
        public virtual DbSet<Selection> Selections { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Term> Terms { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-8PHTQ0D;Database=EMS;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Persian_100_CI_AS_SC_UTF8");

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Course");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Prof>(entity =>
            {
                entity.ToTable("Prof");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Selection>(entity =>
            {
                entity.Property(e => e.Sid).HasColumnName("SId");

                entity.Property(e => e.Tid).HasColumnName("TId");

                entity.HasOne(d => d.SidNavigation)
                    .WithMany(p => p.Selections)
                    .HasForeignKey(d => d.Sid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Selections_Student");

                entity.HasOne(d => d.TidNavigation)
                    .WithMany(p => p.Selections)
                    .HasForeignKey(d => d.Tid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Selections_Term");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Term>(entity =>
            {
                entity.ToTable("Term");

                entity.Property(e => e.Cid).HasColumnName("CId");

                entity.Property(e => e.Pid).HasColumnName("PId");

                entity.HasOne(d => d.CidNavigation)
                    .WithMany(p => p.Terms)
                    .HasForeignKey(d => d.Cid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Term_Course");

                entity.HasOne(d => d.PidNavigation)
                    .WithMany(p => p.Terms)
                    .HasForeignKey(d => d.Pid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Term_Prof");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
