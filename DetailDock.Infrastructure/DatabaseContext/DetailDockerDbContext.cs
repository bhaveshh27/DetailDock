using DetailDock.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetailDock.Infrastructure.DatabaseContext
{
    public class DetailDockerDbContext:DbContext
    {
        public DetailDockerDbContext(DbContextOptions<DetailDockerDbContext> options):base(options)
        {
                
        }
        public DbSet<Program> Programs { get; set; }
        public DbSet<BasicInfo> BasicInfo { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Response> responses { get; set; }
        public DbSet<ResponseData> responseDatas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Program>()
                    .ToContainer("Program")
                    .HasPartitionKey(e => e.Id);


            /*modelBuilder.Entity<BasicInfo>()
                .ToContainer("BasicInfo")
                .HasPartitionKey(c => c.Id);


            modelBuilder.Entity<Question>()
                .ToContainer("Question")
                .HasPartitionKey(c => c.Id);*/
        }

    }
}
