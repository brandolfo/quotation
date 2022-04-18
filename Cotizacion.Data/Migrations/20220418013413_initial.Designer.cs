﻿// <auto-generated />
using System;
using Cotizacion.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Cotizacion.Data.Migrations
{
    [DbContext(typeof(CotizacionContext))]
    [Migration("20220418013413_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Cotizacion.Data.Model.Coin", b =>
                {
                    b.Property<Guid>("CoinId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("QuotationId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CoinId");

                    b.HasIndex("QuotationId");

                    b.ToTable("Coins");
                });

            modelBuilder.Entity("Cotizacion.Data.Model.Quotation", b =>
                {
                    b.Property<Guid>("QuotationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("Buy")
                        .HasColumnType("real");

                    b.HasKey("QuotationId");

                    b.ToTable("Quotations");
                });

            modelBuilder.Entity("Cotizacion.Data.Model.Coin", b =>
                {
                    b.HasOne("Cotizacion.Data.Model.Quotation", "Quotation")
                        .WithMany()
                        .HasForeignKey("QuotationId");

                    b.Navigation("Quotation");
                });
#pragma warning restore 612, 618
        }
    }
}