using System;
using FoodHub.Models;
using Microsoft.EntityFrameworkCore;

public class ApplicationDBContext : DbContext 
{
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) :base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
     modelBuilder.Entity<Recipe_Ingreadiant>().HasKey(pk=> new{pk.IngreadiantName,pk.RecipeName});
     modelBuilder.Entity<Recipe_Ingreadiant>().HasOne(r=>r.recipe).WithMany(ri=> ri.Recipe_Ingreadiants).HasForeignKey(rid=> rid.RecipeName);
     modelBuilder.Entity<Recipe_Ingreadiant>().HasOne(r=>r.ingreadiant).WithMany(ri=> ri.Recipe_Ingreadiants).HasForeignKey(rid=> rid.IngreadiantName);  
    }
    public DbSet<Recipe> Recipes {get; set;}
    public DbSet<Ingreadiant> Ingreadiants {get; set;}
    public DbSet<Recipe_Ingreadiant> Recipes_Ingreadiants {get; set;}
}
