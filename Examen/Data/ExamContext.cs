using Examen.Models.Many_to_Many;
using Microsoft.EntityFrameworkCore;

namespace Examen.Data
{
    public class ExamContext:DbContext
    {
        public DbSet<Profesor> Profesori { get; set; }
        public DbSet<Materie> Materii { get; set; }
        public DbSet<ModelsRelation> Relationships { get; set; }

        public ExamContext(DbContextOptions<ExamContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ModelsRelation>().HasKey(mr => new { mr.ProfId, mr.MatId });

            
            modelBuilder.Entity<ModelsRelation>()
                        .HasOne(mr => mr.Prof)
                        .WithMany(prof => prof.ModelRelations)
                        .HasForeignKey(mr => mr.ProfId)
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ModelsRelation>()
                        .HasOne(mr => mr.Mat)
                        .WithMany(mat => mat.ModelRelations)
                        .HasForeignKey(mr => mr.MatId)
                        .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}
