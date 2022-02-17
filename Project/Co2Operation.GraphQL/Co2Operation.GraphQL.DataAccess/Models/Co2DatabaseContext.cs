using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Co2Operation.GraphQL.DataAccess.Models
{
    public partial class Co2DatabaseContext : DbContext
    {
        public Co2DatabaseContext()
        {
        }

        public Co2DatabaseContext(DbContextOptions<Co2DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Car> Car { get; set; }
        public virtual DbSet<CarbonHistroy> CarbonHistroy { get; set; }
        public virtual DbSet<LoginInfo> LoginInfo { get; set; }
        public virtual DbSet<TransportMethods> TransportMethods { get; set; }
        public virtual DbSet<Trip> Trip { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=Co2Database;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>(entity =>
            {
                entity.Property(e => e.Model).IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Car)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Car__UserId__267ABA7A");
            });

            modelBuilder.Entity<CarbonHistroy>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.Day })
                    .HasName("PK__CarbonHi__3B8BCD5DF2BDBECA");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Day).HasColumnType("date");

                entity.Property(e => e.TotalFootPrint).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CarbonHistroy)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CarbonHis__UserI__31EC6D26");
            });

            modelBuilder.Entity<LoginInfo>(entity =>
            {
                entity.HasKey(e => e.Email)
                    .HasName("PK__LoginInf__A9D10535566B0632");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Password).IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.LoginInfo)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LoginInfo__UserI__2F10007B");
            });

            modelBuilder.Entity<TransportMethods>(entity =>
            {
                entity.Property(e => e.AverageCo2).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<Trip>(entity =>
            {
                entity.Property(e => e.Distance).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.Property(e => e.TotalCo2).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.TransportMethod)
                    .WithMany(p => p.Trip)
                    .HasForeignKey(d => d.TransportMethodId)
                    .HasConstraintName("FK__Trip__TransportM__2C3393D0");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Trip)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Trip__UserID__2B3F6F97");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.TotalFootPrint).HasColumnType("decimal(18, 0)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
