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
        public DbSet<QuestionType> QuestionTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Program>()
                    .ToContainer("Program")
                    .HasPartitionKey(e => e.Id);


            /*modelBuilder.Entity<BasicInfo>()
                .ToContainer("PersonalInformation")
                .HasPartitionKey(c => c.Id);


            modelBuilder.Entity<QuestionType>()
                .ToContainer("QuestionType")
                .HasPartitionKey(c => c.Id);*/
        }

    }
}
