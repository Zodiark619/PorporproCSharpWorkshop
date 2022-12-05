using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ConsoleApp1.Data{
    public class DataContextEF:DbContext{

   // private IConfiguration _config;
       private IConfiguration _config;

        public DataContextEF(IConfiguration config){

_config=config;
        }

public DbSet<Computer>? Computer {get;set;}
        protected override void OnConfiguring(DbContextOptionsBuilder options){
            if(!options.IsConfigured){
                options.UseSqlServer(_config.GetConnectionString("DefaultConnection"),
                    options=>options.EnableRetryOnFailure());
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.HasDefaultSchema("tutorialappschema");
            modelBuilder.Entity<Computer>()
                //.HasNoKey();
                .HasKey(x=>x.ComputerId);
//                .ToTable("computer","tutorialappschema");
        }
    }
}