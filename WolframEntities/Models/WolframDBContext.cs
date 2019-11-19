using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WolframEntities.Models
{
    public partial class WolframDBContext : DbContext
    {
        public WolframDBContext()
        {
        }

        public WolframDBContext(DbContextOptions<WolframDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ChallengeStatuses> ChallengeStatuses { get; set; }
        public virtual DbSet<ChallengeTypes> ChallengeTypes { get; set; }
        public virtual DbSet<Challenges> Challenges { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=WolframDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChallengeStatuses>(entity =>
            {
                entity.HasKey(e => e.ChallengeStatusId)
                    .HasName("PK__Challeng__0EE3C4763A9283FA");

                entity.Property(e => e.ChallengeStatusId).HasColumnName("challenge_status_id");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ChallengeTypes>(entity =>
            {
                entity.HasKey(e => e.ChallengeTypeId)
                    .HasName("PK__Challeng__CC85ED62D959F28F");

                entity.Property(e => e.ChallengeTypeId).HasColumnName("challenge_type_id");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Challenges>(entity =>
            {
                entity.HasKey(e => e.ChallengeId)
                    .HasName("PK__Challeng__CF635191D7317E84");

                entity.Property(e => e.ChallengeId).HasColumnName("challenge_id");

                entity.Property(e => e.ChallengeStatusId).HasColumnName("challenge_status_id");

                entity.Property(e => e.ChallengeTypeId).HasColumnName("challenge_type_id");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.ChallengeStatus)
                    .WithMany(p => p.Challenges)
                    .HasForeignKey(d => d.ChallengeStatusId)
                    .HasConstraintName("FK_Challenges_ToChallengeStatuses");

                entity.HasOne(d => d.ChallengeType)
                    .WithMany(p => p.Challenges)
                    .HasForeignKey(d => d.ChallengeTypeId)
                    .HasConstraintName("FK_Challenges_ToChallengeTypes");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
