// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FoodHub.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20220703141932_changerKeyOfRecieToName")]
    partial class changerKeyOfRecieToName
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FoodHub.Models.Ingreadiant", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Name");

                    b.ToTable("Ingreadiants");
                });

            modelBuilder.Entity("FoodHub.Models.Recipe", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DateOfCreation")
                        .HasColumnType("datetime2");

                    b.Property<string>("Discription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("link")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Name");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("FoodHub.Models.Recipe_Ingreadiant", b =>
                {
                    b.Property<string>("IngreadiantName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RecipeName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("amount")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IngreadiantName", "RecipeName");

                    b.HasIndex("RecipeName");

                    b.ToTable("Recipes_Ingreadiants");
                });

            modelBuilder.Entity("FoodHub.Models.Recipe_Ingreadiant", b =>
                {
                    b.HasOne("FoodHub.Models.Ingreadiant", "ingreadiant")
                        .WithMany("Recipe_Ingreadiants")
                        .HasForeignKey("IngreadiantName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodHub.Models.Recipe", "recipe")
                        .WithMany("Recipe_Ingreadiants")
                        .HasForeignKey("RecipeName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ingreadiant");

                    b.Navigation("recipe");
                });

            modelBuilder.Entity("FoodHub.Models.Ingreadiant", b =>
                {
                    b.Navigation("Recipe_Ingreadiants");
                });

            modelBuilder.Entity("FoodHub.Models.Recipe", b =>
                {
                    b.Navigation("Recipe_Ingreadiants");
                });
#pragma warning restore 612, 618
        }
    }
}
