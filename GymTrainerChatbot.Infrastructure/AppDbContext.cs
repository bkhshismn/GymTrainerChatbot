using GymTrainerChatbot.Domain.Entities; // اضافه کردن namespace که موجودیت‌ها در آن قرار دارند
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace GymTrainerChatbot.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }


        public DbSet<User> Users { get; set; }
        public DbSet<TrainingSession> TrainingSessions { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<Answer> Answers { get; set; }
        // public DbSet<AnotherEntity> AnotherEntities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //  تنظیمات مدل‌سازی، قواعد اعتبارسنجی و روابط بین جداول
            // modelBuilder.Entity<User>().HasKey(u => u.Id); 
            // modelBuilder.Entity<TrainingSession>().HasOne(ts => ts.User).WithMany(u => u.TrainingSessions).HasForeignKey(ts => ts.UserId);
        }
    }
}
