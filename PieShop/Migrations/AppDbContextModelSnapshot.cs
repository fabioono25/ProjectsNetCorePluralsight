﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PieShop.Models;

namespace PieShop.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0-preview.2.20159.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PieShop.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Fruit Pies",
                            Description = "Tasty fruid pies"
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "Cheeese Pies",
                            Description = "Cheese fruid pies"
                        },
                        new
                        {
                            CategoryId = 3,
                            CategoryName = "Salty Pies",
                            Description = "Salty fruid pies"
                        });
                });

            modelBuilder.Entity("PieShop.Models.Pie", b =>
                {
                    b.Property<int>("PieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AllergyInformation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("ImageThumbnailUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("InStock")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPieOfTheWeek")
                        .HasColumnType("bit");

                    b.Property<string>("LongDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ShortDescription")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("PieId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Pies");

                    b.HasData(
                        new
                        {
                            PieId = 1,
                            AllergyInformation = "",
                            CategoryId = 1,
                            ImageThumbnailUrl = "https://images-gmi-pmc.edge-generalmills.com/75593ed5-420b-4782-8eae-56bdfbc2586b.jpg",
                            ImageUrl = "https://images-gmi-pmc.edge-generalmills.com/75593ed5-420b-4782-8eae-56bdfbc2586b.jpg",
                            InStock = true,
                            IsPieOfTheWeek = true,
                            LongDescription = "Famous apple pie very famous!",
                            Name = "Apple Pie",
                            Price = 12.3m,
                            ShortDescription = "Famous apple pie!"
                        },
                        new
                        {
                            PieId = 2,
                            AllergyInformation = "",
                            CategoryId = 2,
                            ImageThumbnailUrl = "https://s3.amazonaws.com/finecooking.s3.tauntonclud.com/app/uploads/2017/04/18134327/051093069-01-blueberry-blackberry-pie-main.jpg",
                            ImageUrl = "https://s3.amazonaws.com/finecooking.s3.tauntonclud.com/app/uploads/2017/04/18134327/051093069-01-blueberry-blackberry-pie-main.jpg",
                            InStock = true,
                            IsPieOfTheWeek = false,
                            LongDescription = "Famous blueberry pie very famous!",
                            Name = "Blueberry Pie",
                            Price = 22.0m,
                            ShortDescription = "Famous blueberry pie!"
                        },
                        new
                        {
                            PieId = 3,
                            AllergyInformation = "",
                            CategoryId = 3,
                            ImageThumbnailUrl = "https://www.valitalia.com/eu/pub/media/wysiwyg/torta_salata_with_broccoli_and_sausage.jpg",
                            ImageUrl = "https://www.valitalia.com/eu/pub/media/wysiwyg/torta_salata_with_broccoli_and_sausage.jpg",
                            InStock = true,
                            IsPieOfTheWeek = true,
                            LongDescription = "Famous salty pie very famous!",
                            Name = "The Salty Pie",
                            Price = 14.0m,
                            ShortDescription = "Famous salty pie!"
                        });
                });

            modelBuilder.Entity("PieShop.Models.ShoppingCartItem", b =>
                {
                    b.Property<int>("ShoppingCartItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int?>("PieId")
                        .HasColumnType("int");

                    b.Property<string>("ShoppingCartId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ShoppingCartItemId");

                    b.HasIndex("PieId");

                    b.ToTable("ShoppingCartItems");
                });

            modelBuilder.Entity("PieShop.Models.Pie", b =>
                {
                    b.HasOne("PieShop.Models.Category", "Category")
                        .WithMany("Pies")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PieShop.Models.ShoppingCartItem", b =>
                {
                    b.HasOne("PieShop.Models.Pie", "Pie")
                        .WithMany()
                        .HasForeignKey("PieId");
                });
#pragma warning restore 612, 618
        }
    }
}
