﻿// <auto-generated />
using System;
using Drin.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Drin.Data.Migrations
{
    [DbContext(typeof(DrinDbContext))]
    [Migration("20221006121025_AddingUser")]
    partial class AddingUser
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Drin.Core.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2022, 10, 6, 15, 10, 25, 121, DateTimeKind.Local).AddTicks(1957),
                            Name = "Kalemler"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2022, 10, 6, 15, 10, 25, 121, DateTimeKind.Local).AddTicks(1964),
                            Name = "Kitaplar"
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2022, 10, 6, 15, 10, 25, 121, DateTimeKind.Local).AddTicks(1965),
                            Name = "Defterler"
                        });
                });

            modelBuilder.Entity("Drin.Core.Entities.OperationClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("OperationClaim");
                });

            modelBuilder.Entity("Drin.Core.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            CreatedDate = new DateTime(2022, 10, 6, 15, 10, 25, 121, DateTimeKind.Local).AddTicks(2214),
                            Name = "Uçlu Kalem",
                            Price = 100m,
                            Stock = 20
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            CreatedDate = new DateTime(2022, 10, 6, 15, 10, 25, 121, DateTimeKind.Local).AddTicks(2216),
                            Name = "Tükenmez Kalem",
                            Price = 10m,
                            Stock = 200
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 2,
                            CreatedDate = new DateTime(2022, 10, 6, 15, 10, 25, 121, DateTimeKind.Local).AddTicks(2217),
                            Name = "Roamn",
                            Price = 50m,
                            Stock = 100
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 3,
                            CreatedDate = new DateTime(2022, 10, 6, 15, 10, 25, 121, DateTimeKind.Local).AddTicks(2218),
                            Name = "Çizgili Defter",
                            Price = 80m,
                            Stock = 40
                        });
                });

            modelBuilder.Entity("Drin.Core.Entities.ProductFeature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Colour")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<decimal>("Weight")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.ToTable("ProductFeature");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Colour = "Black",
                            ProductId = 1,
                            Weight = 40m
                        },
                        new
                        {
                            Id = 2,
                            Colour = "Blue",
                            ProductId = 2,
                            Weight = 10m
                        });
                });

            modelBuilder.Entity("Drin.Core.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("MailConfirm")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Drin.Core.Entities.Product", b =>
                {
                    b.HasOne("Drin.Core.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Drin.Core.Entities.ProductFeature", b =>
                {
                    b.HasOne("Drin.Core.Entities.Product", "Product")
                        .WithOne("ProductFeature")
                        .HasForeignKey("Drin.Core.Entities.ProductFeature", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Drin.Core.Entities.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Drin.Core.Entities.Product", b =>
                {
                    b.Navigation("ProductFeature")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
