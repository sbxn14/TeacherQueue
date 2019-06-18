using Microsoft.EntityFrameworkCore;
using TeacherQueue.Models.DatabaseModels;

namespace TeacherQueue.DAL
{
    public class QueueContext : DbContext
    {
        public QueueContext(DbContextOptions<QueueContext> options) : base(options)
        {
        }

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Queue> Queues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentQueue>()
                .HasKey(t => new { t.StudentId, t.QueueId });
        }
    }
}
