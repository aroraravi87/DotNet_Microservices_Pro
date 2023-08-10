﻿// <auto-generated />
using Mango.Services.CoupanAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Mango.Services.CoupanAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230809130612_AddCoupantoDB")]
    partial class AddCoupantoDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Mango.Services.CoupanAPI.Models.Coupan", b =>
                {
                    b.Property<int>("CoupanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CoupanId"));

                    b.Property<string>("CoupanCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("DiscountAmount")
                        .HasColumnType("float");

                    b.Property<int>("MinAmount")
                        .HasColumnType("int");

                    b.HasKey("CoupanId");

                    b.ToTable("Coupans");
                });
#pragma warning restore 612, 618
        }
    }
}