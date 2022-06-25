using System;
using FoodHub.Models;
using Microsoft.EntityFrameworkCore;

public class ApplicationDBContext : DbContext 
{
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) :base(options)
    {
        
    }

    public DbSet<Recipe> Recipes {get; set;}
}
