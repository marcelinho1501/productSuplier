﻿// <auto-generated />
using System;
using Api.AutoGlass.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Api.AutoGlass.Infrastructure.Migrations
{
    [DbContext(typeof(InfraContext))]
    partial class InfraContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Api.AutoGlass.Domain.Entities.Product", b =>
                {
                    b.Property<int>("Code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("cd_produto");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Code"));

                    b.Property<string>("Cnpj")
                        .HasColumnType("text")
                        .HasColumnName("ds_cnpj");

                    b.Property<DateTime?>("DateManufacturing")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("dt_fabricacao");

                    b.Property<DateTime?>("DateValidate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("dt_validade");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("ds_produto");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("tp_situacao");

                    b.Property<int?>("SupplierCode")
                        .HasColumnType("integer")
                        .HasColumnName("cd_fornecedor");

                    b.Property<string>("SupplierDescription")
                        .HasColumnType("text")
                        .HasColumnName("ds_fornecedor");

                    b.HasKey("Code");

                    b.ToTable("product");
                });
#pragma warning restore 612, 618
        }
    }
}