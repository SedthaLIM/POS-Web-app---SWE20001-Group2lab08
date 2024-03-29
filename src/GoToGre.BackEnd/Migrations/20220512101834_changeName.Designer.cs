﻿// <auto-generated />
using System;
using GoToGre.BackEnd.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace GoToGre.BackEnd.Migrations
{
    [DbContext(typeof(GoToGreContext))]
    [Migration("20220512101834_changeName")]
    partial class changeName
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("GoToGre.Common.Models.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("FileType")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("GoToGre.Common.Models.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("ImageURL")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<int>("Points")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Member");
                });

            modelBuilder.Entity("GoToGre.Common.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<double>("GlobalPrice")
                        .HasColumnType("double precision");

                    b.Property<string>("ImageURL")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("ProductType")
                        .HasColumnType("text");

                    b.Property<int>("StockAmmount")
                        .HasColumnType("integer");

                    b.Property<int>("TargetStock")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("GoToGre.Common.Models.Sale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("timestamp without time zone");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("GoToGre.Common.Models.SaleItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("ProductId")
                        .HasColumnType("integer");

                    b.Property<int?>("SaleId")
                        .HasColumnType("integer");

                    b.Property<double>("SoldPrice")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("SaleId");

                    b.ToTable("SaleItems");
                });

            modelBuilder.Entity("GoToGre.Common.Models.Sale", b =>
                {
                    b.HasOne("GoToGre.Common.Models.Member", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("GoToGre.Common.Models.SaleItem", b =>
                {
                    b.HasOne("GoToGre.Common.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.HasOne("GoToGre.Common.Models.Sale", "Sale")
                        .WithMany("SaleItems")
                        .HasForeignKey("SaleId");

                    b.Navigation("Product");

                    b.Navigation("Sale");
                });

            modelBuilder.Entity("GoToGre.Common.Models.Sale", b =>
                {
                    b.Navigation("SaleItems");
                });
#pragma warning restore 612, 618
        }
    }
}
