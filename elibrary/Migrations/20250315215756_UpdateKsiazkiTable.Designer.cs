﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using elibrary.Data;

#nullable disable

namespace elibrary.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250315215756_UpdateKsiazkiTable")]
    partial class UpdateKsiazkiTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("elibrary.Models.Autor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("ProfilePictureURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Autorzy");
                });

            modelBuilder.Entity("elibrary.Models.Autor_Ksiazka", b =>
                {
                    b.Property<int>("KsiazkaId")
                        .HasColumnType("int");

                    b.Property<int>("AutorId")
                        .HasColumnType("int");

                    b.HasKey("KsiazkaId", "AutorId");

                    b.HasIndex("AutorId");

                    b.ToTable("Autor_Ksiazki");
                });

            modelBuilder.Entity("elibrary.Models.Biblioteka", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DescBib")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LogoBib")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameBib")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Biblioteki");
                });

            modelBuilder.Entity("elibrary.Models.Ksiazka", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BibId")
                        .HasColumnType("int");

                    b.Property<string>("DescKs")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameKs")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PublikacjaTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("WydId")
                        .HasColumnType("int");

                    b.Property<int>("ksiazkaCategory")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BibId");

                    b.HasIndex("WydId");

                    b.ToTable("Ksiazki");
                });

            modelBuilder.Entity("elibrary.Models.Wydawnictwo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DescWyd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameWyd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WydPictureURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Wydawnictwa");
                });

            modelBuilder.Entity("elibrary.Models.Autor_Ksiazka", b =>
                {
                    b.HasOne("elibrary.Models.Autor", "Autorzy")
                        .WithMany("Autor_Ksiazki")
                        .HasForeignKey("AutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("elibrary.Models.Ksiazka", "Ksiazki")
                        .WithMany("Autor_Ksiazki")
                        .HasForeignKey("KsiazkaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Autorzy");

                    b.Navigation("Ksiazki");
                });

            modelBuilder.Entity("elibrary.Models.Ksiazka", b =>
                {
                    b.HasOne("elibrary.Models.Biblioteka", "Biblioteki")
                        .WithMany("Ksiazki")
                        .HasForeignKey("BibId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("elibrary.Models.Wydawnictwo", "Wydawnictwa")
                        .WithMany("Ksiazki")
                        .HasForeignKey("WydId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Biblioteki");

                    b.Navigation("Wydawnictwa");
                });

            modelBuilder.Entity("elibrary.Models.Autor", b =>
                {
                    b.Navigation("Autor_Ksiazki");
                });

            modelBuilder.Entity("elibrary.Models.Biblioteka", b =>
                {
                    b.Navigation("Ksiazki");
                });

            modelBuilder.Entity("elibrary.Models.Ksiazka", b =>
                {
                    b.Navigation("Autor_Ksiazki");
                });

            modelBuilder.Entity("elibrary.Models.Wydawnictwo", b =>
                {
                    b.Navigation("Ksiazki");
                });
#pragma warning restore 612, 618
        }
    }
}
