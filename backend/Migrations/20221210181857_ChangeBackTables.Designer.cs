﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using desafio_rsm.Data;

#nullable disable

namespace desafiorsm.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20221210181857_ChangeBackTables")]
    partial class ChangeBackTables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PersonAddress", b =>
                {
                    b.Property<long>("AddressId")
                        .HasColumnType("bigint");

                    b.Property<long>("PersonId")
                        .HasColumnType("bigint");

                    b.HasKey("AddressId", "PersonId");

                    b.HasIndex("PersonId");

                    b.ToTable("PersonAddress");
                });

            modelBuilder.Entity("desafio_rsm.Models.Address", b =>
                {
                    b.Property<long>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("address_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("AddressId"));

                    b.Property<bool>("Active")
                        .HasColumnType("boolean")
                        .HasColumnName("active");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("cep");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("city");

                    b.Property<string>("Complement")
                        .HasColumnType("text")
                        .HasColumnName("complement");

                    b.Property<DateTime?>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("deleted_at");

                    b.Property<string>("Neighborhood")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("neighborhood");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("number");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("street");

                    b.Property<string>("Uf")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("uf");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("AddressId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("desafio_rsm.Models.Person", b =>
                {
                    b.Property<long>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("person_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("PersonId"));

                    b.Property<bool>("Active")
                        .HasColumnType("boolean")
                        .HasColumnName("active");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("deleted_at");

                    b.Property<string>("Document")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("document");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<DateTime>("ReferenceDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("reference_date");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("PersonId");

                    b.ToTable("People");
                });

            modelBuilder.Entity("PersonAddress", b =>
                {
                    b.HasOne("desafio_rsm.Models.Address", null)
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("desafio_rsm.Models.Person", null)
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}