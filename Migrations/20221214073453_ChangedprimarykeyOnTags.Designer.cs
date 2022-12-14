﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TheYellowCarrot.Data;

#nullable disable

namespace TheYellowCarrot.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20221214073453_ChangedprimarykeyOnTags")]
    partial class ChangedprimarykeyOnTags
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TheYellowCarrot.Models.Ingredient", b =>
                {
                    b.Property<int>("IngredientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IngredientId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Quantity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RecipeId")
                        .HasColumnType("int");

                    b.HasKey("IngredientId");

                    b.HasIndex("RecipeId");

                    b.ToTable("Ingredients");

                    b.HasData(
                        new
                        {
                            IngredientId = 1,
                            Name = "Cheese",
                            Quantity = "100g",
                            RecipeId = 1
                        },
                        new
                        {
                            IngredientId = 2,
                            Name = "Bread",
                            Quantity = "2 Skivor",
                            RecipeId = 1
                        },
                        new
                        {
                            IngredientId = 3,
                            Name = "Butter",
                            Quantity = "30g",
                            RecipeId = 1
                        },
                        new
                        {
                            IngredientId = 4,
                            Name = "Macaroni",
                            Quantity = "150g",
                            RecipeId = 2
                        },
                        new
                        {
                            IngredientId = 5,
                            Name = "Meatballs",
                            Quantity = "100g",
                            RecipeId = 2
                        });
                });

            modelBuilder.Entity("TheYellowCarrot.Models.Recipe", b =>
                {
                    b.Property<int>("RecipeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RecipeId"));

                    b.Property<string>("CookTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TagId")
                        .HasColumnType("int");

                    b.Property<string>("TagName")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("RecipeId");

                    b.HasIndex("TagName");

                    b.ToTable("Recipes");

                    b.HasData(
                        new
                        {
                            RecipeId = 1,
                            CookTime = "15 min",
                            Name = "Grilled Cheese Sandwich"
                        },
                        new
                        {
                            RecipeId = 2,
                            CookTime = "30 min",
                            Name = "Macaroni n Meatballs",
                            TagId = 4
                        });
                });

            modelBuilder.Entity("TheYellowCarrot.Models.Tag", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Name");

                    b.ToTable("Tags");

                    b.HasData(
                        new
                        {
                            Name = "Vegetarian"
                        },
                        new
                        {
                            Name = "Vegan"
                        },
                        new
                        {
                            Name = "Glutenfri"
                        },
                        new
                        {
                            Name = "Laktosfri"
                        });
                });

            modelBuilder.Entity("TheYellowCarrot.Models.Ingredient", b =>
                {
                    b.HasOne("TheYellowCarrot.Models.Recipe", "recipes")
                        .WithMany("Ingredients")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("recipes");
                });

            modelBuilder.Entity("TheYellowCarrot.Models.Recipe", b =>
                {
                    b.HasOne("TheYellowCarrot.Models.Tag", "Tag")
                        .WithMany("Recipes")
                        .HasForeignKey("TagName");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("TheYellowCarrot.Models.Recipe", b =>
                {
                    b.Navigation("Ingredients");
                });

            modelBuilder.Entity("TheYellowCarrot.Models.Tag", b =>
                {
                    b.Navigation("Recipes");
                });
#pragma warning restore 612, 618
        }
    }
}