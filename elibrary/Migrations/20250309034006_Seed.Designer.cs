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
    [Migration("20250309034006_Seed")]
    partial class Seed
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("elibrary.Models.Autor", b =>
                {
                    b.Property<int>("AutorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AutorId"));

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilePictureURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AutorId");

                    b.ToTable("Autorzy");
                });

            modelBuilder.Entity("elibrary.Models.Bib_Ksiazka", b =>
                {
                    b.Property<int>("KsiazkaId")
                        .HasColumnType("int");

                    b.Property<int>("BibId")
                        .HasColumnType("int");

                    b.HasKey("KsiazkaId", "BibId");

                    b.HasIndex("BibId");

                    b.ToTable("Bib_Ksiazki");
                });

            modelBuilder.Entity("elibrary.Models.Biblioteka", b =>
                {
                    b.Property<int>("BibId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BibId"));

                    b.Property<string>("DescBib")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LogoBib")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameBib")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BibId");

                    b.ToTable("Biblioteki");
                });

            modelBuilder.Entity("elibrary.Models.Ksiazka", b =>
                {
                    b.Property<int>("KsiazkaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KsiazkaId"));

                    b.Property<int>("AutorId")
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

                    b.HasKey("KsiazkaId");

                    b.HasIndex("AutorId");

                    b.HasIndex("WydId");

                    b.ToTable("Ksiazki");
                });

            modelBuilder.Entity("elibrary.Models.Wydawnictwo", b =>
                {
                    b.Property<int>("WydawnictwoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WydawnictwoId"));

                    b.Property<string>("DescWyd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameWyd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WydPictureURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WydawnictwoId");

                    b.ToTable("Wydawnictwa");
                });

            modelBuilder.Entity("elibrary.Models.Bib_Ksiazka", b =>
                {
                    b.HasOne("elibrary.Models.Biblioteka", "Bib")
                        .WithMany("Bib_Ksiazka")
                        .HasForeignKey("BibId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("elibrary.Models.Ksiazka", "Ksiazka")
                        .WithMany("Bib_Ksiazkas")
                        .HasForeignKey("KsiazkaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bib");

                    b.Navigation("Ksiazka");
                });

            modelBuilder.Entity("elibrary.Models.Ksiazka", b =>
                {
                    b.HasOne("elibrary.Models.Autor", "Autor")
                        .WithMany("ksiazkas")
                        .HasForeignKey("AutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("elibrary.Models.Wydawnictwo", "Wydawnictwo")
                        .WithMany("ksiazkas")
                        .HasForeignKey("WydId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Autor");

                    b.Navigation("Wydawnictwo");
                });

            modelBuilder.Entity("elibrary.Models.Autor", b =>
                {
                    b.Navigation("ksiazkas");
                });

            modelBuilder.Entity("elibrary.Models.Biblioteka", b =>
                {
                    b.Navigation("Bib_Ksiazka");
                });

            modelBuilder.Entity("elibrary.Models.Ksiazka", b =>
                {
                    b.Navigation("Bib_Ksiazkas");
                });

            modelBuilder.Entity("elibrary.Models.Wydawnictwo", b =>
                {
                    b.Navigation("ksiazkas");
                });
#pragma warning restore 612, 618
        }
    }
}
