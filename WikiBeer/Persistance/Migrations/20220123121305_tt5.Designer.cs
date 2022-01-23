﻿// <auto-generated />
using System;
using Ipme.WikiBeer.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Ipme.WikiBeer.Persistance.Migrations
{
    [DbContext(typeof(WikiBeerSqlContext))]
    [Migration("20220123121305_tt5")]
    partial class tt5
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BeerEntityIngredientEntity", b =>
                {
                    b.Property<Guid>("BeersId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IngredientsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("BeersId", "IngredientsId");

                    b.HasIndex("IngredientsId");

                    b.ToTable("BeerIngredient", (string)null);
                });

            modelBuilder.Entity("Ipme.WikiBeer.Entities.BeerColorEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ColorId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("ColorId");

                    b.ToTable("BeerColor", (string)null);
                });

            modelBuilder.Entity("Ipme.WikiBeer.Entities.BeerEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("BeerId");

                    b.Property<Guid>("BreweryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ColorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("Degree")
                        .HasColumnType("real");

                    b.Property<float?>("Ibu")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("StyleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id")
                        .HasName("BeerId");

                    b.HasIndex("BreweryId");

                    b.HasIndex("ColorId");

                    b.HasIndex("StyleId");

                    b.ToTable("Beer", (string)null);
                });

            modelBuilder.Entity("Ipme.WikiBeer.Entities.BeerStyleEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("StyleId");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("StyleId");

                    b.ToTable("BeerStyle", (string)null);
                });

            modelBuilder.Entity("Ipme.WikiBeer.Entities.BreweryEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("BreweryId");

                    b.Property<Guid>("CountryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("BreweryId");

                    b.HasIndex("CountryId");

                    b.ToTable("Brewery", (string)null);
                });

            modelBuilder.Entity("Ipme.WikiBeer.Entities.CountryEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("CountryId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("CountryId");

                    b.ToTable("Country", (string)null);
                });

            modelBuilder.Entity("Ipme.WikiBeer.Entities.Ingredients.IngredientEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("IngredientId");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id")
                        .HasName("IngredientId");

                    b.ToTable("Ingredient", (string)null);

                    b.HasDiscriminator<string>("Type").HasValue("IngredientEntity");
                });

            modelBuilder.Entity("Ipme.WikiBeer.Entities.Ingredients.AdditiveEntity", b =>
                {
                    b.HasBaseType("Ipme.WikiBeer.Entities.Ingredients.IngredientEntity");

                    b.Property<string>("Use")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Additive");
                });

            modelBuilder.Entity("Ipme.WikiBeer.Entities.Ingredients.CerealEntity", b =>
                {
                    b.HasBaseType("Ipme.WikiBeer.Entities.Ingredients.IngredientEntity");

                    b.Property<float>("Ebc")
                        .HasColumnType("real");

                    b.HasDiscriminator().HasValue("Cereal");
                });

            modelBuilder.Entity("Ipme.WikiBeer.Entities.Ingredients.HopEntity", b =>
                {
                    b.HasBaseType("Ipme.WikiBeer.Entities.Ingredients.IngredientEntity");

                    b.Property<float>("AlphaAcid")
                        .HasColumnType("real");

                    b.HasDiscriminator().HasValue("Hop");
                });

            modelBuilder.Entity("BeerEntityIngredientEntity", b =>
                {
                    b.HasOne("Ipme.WikiBeer.Entities.BeerEntity", null)
                        .WithMany()
                        .HasForeignKey("BeersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ipme.WikiBeer.Entities.Ingredients.IngredientEntity", null)
                        .WithMany()
                        .HasForeignKey("IngredientsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Ipme.WikiBeer.Entities.BeerEntity", b =>
                {
                    b.HasOne("Ipme.WikiBeer.Entities.BreweryEntity", "Brewery")
                        .WithMany("Beers")
                        .HasForeignKey("BreweryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ipme.WikiBeer.Entities.BeerColorEntity", "Color")
                        .WithMany()
                        .HasForeignKey("ColorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ipme.WikiBeer.Entities.BeerStyleEntity", "Style")
                        .WithMany()
                        .HasForeignKey("StyleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brewery");

                    b.Navigation("Color");

                    b.Navigation("Style");
                });

            modelBuilder.Entity("Ipme.WikiBeer.Entities.BreweryEntity", b =>
                {
                    b.HasOne("Ipme.WikiBeer.Entities.CountryEntity", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Ipme.WikiBeer.Entities.BreweryEntity", b =>
                {
                    b.Navigation("Beers");
                });
#pragma warning restore 612, 618
        }
    }
}
