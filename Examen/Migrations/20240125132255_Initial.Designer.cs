﻿// <auto-generated />
using System;
using Examen.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Examen.Migrations
{
    [DbContext(typeof(ExamContext))]
    [Migration("20240125132255_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Examen.Models.Many_to_Many.Materie", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Denumire")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Materii");
                });

            modelBuilder.Entity("Examen.Models.Many_to_Many.ModelsRelation", b =>
                {
                    b.Property<Guid>("ProfId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MatId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ProfId", "MatId");

                    b.HasIndex("MatId");

                    b.ToTable("Relationships");
                });

            modelBuilder.Entity("Examen.Models.Many_to_Many.Profesor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tip")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Varsta")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Profesori");
                });

            modelBuilder.Entity("Examen.Models.Many_to_Many.ModelsRelation", b =>
                {
                    b.HasOne("Examen.Models.Many_to_Many.Materie", "Mat")
                        .WithMany("ModelRelations")
                        .HasForeignKey("MatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Examen.Models.Many_to_Many.Profesor", "Prof")
                        .WithMany("ModelRelations")
                        .HasForeignKey("ProfId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mat");

                    b.Navigation("Prof");
                });

            modelBuilder.Entity("Examen.Models.Many_to_Many.Materie", b =>
                {
                    b.Navigation("ModelRelations");
                });

            modelBuilder.Entity("Examen.Models.Many_to_Many.Profesor", b =>
                {
                    b.Navigation("ModelRelations");
                });
#pragma warning restore 612, 618
        }
    }
}
