﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Ms_Panne.Domain.Poulina.MSpanne.Domain.Data;

namespace Poulina.MSpanne.Data.Migrations
{
    [DbContext(typeof(PoulinaDbContext))]
    [Migration("20200824140002_ajout_prior_idmach")]
    partial class ajout_prior_idmach
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Ms_Panne.Domain.Poulina.MSpanne.Domain.Models.Intervention", b =>
                {
                    b.Property<Guid>("id_intervention")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("Panneid_panne")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("Type_interventionid_type_intervention")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("date_intervention")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description_intervention")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("id_panne")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("type_intervention")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("id_intervention");

                    b.HasIndex("Panneid_panne");

                    b.HasIndex("Type_interventionid_type_intervention");

                    b.ToTable("Intervention");
                });

            modelBuilder.Entity("Ms_Panne.Domain.Poulina.MSpanne.Domain.Models.Panne", b =>
                {
                    b.Property<Guid>("id_panne")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("Interventionid_intervention")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("id_machine")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("id_type_panne")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("état_panne")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_panne");

                    b.HasIndex("Interventionid_intervention");

                    b.ToTable("Panne");
                });

            modelBuilder.Entity("Ms_Panne.Domain.Poulina.MSpanne.Domain.Models.Type_intervention", b =>
                {
                    b.Property<Guid>("id_type_intervention")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("Interventionid_intervention")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("type_intervention")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("état_intervention")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_type_intervention");

                    b.HasIndex("Interventionid_intervention");

                    b.ToTable("Type_intervention");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Type_intervention");
                });

            modelBuilder.Entity("Ms_Panne.Domain.Poulina.MSpanne.Domain.Models.Type_panne", b =>
                {
                    b.Property<Guid>("id_type_panne")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("Panneid_panne")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("label")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("priorité")
                        .HasColumnType("int");

                    b.HasKey("id_type_panne");

                    b.HasIndex("Panneid_panne");

                    b.ToTable("Type_panne");
                });

            modelBuilder.Entity("Ms_Panne.Domain.Poulina.MSpanne.Domain.Models.Intervention_externe", b =>
                {
                    b.HasBaseType("Ms_Panne.Domain.Poulina.MSpanne.Domain.Models.Type_intervention");

                    b.Property<Guid>("id_fournisseur")
                        .HasColumnType("uniqueidentifier");

                    b.HasDiscriminator().HasValue("Intervention_externe");
                });

            modelBuilder.Entity("Ms_Panne.Domain.Poulina.MSpanne.Domain.Models.Intervention_interne", b =>
                {
                    b.HasBaseType("Ms_Panne.Domain.Poulina.MSpanne.Domain.Models.Type_intervention");

                    b.Property<Guid>("matricule")
                        .HasColumnType("uniqueidentifier");

                    b.HasDiscriminator().HasValue("Intervention_interne");
                });

            modelBuilder.Entity("Ms_Panne.Domain.Poulina.MSpanne.Domain.Models.Intervention", b =>
                {
                    b.HasOne("Ms_Panne.Domain.Poulina.MSpanne.Domain.Models.Panne", "Panne")
                        .WithMany()
                        .HasForeignKey("Panneid_panne");

                    b.HasOne("Ms_Panne.Domain.Poulina.MSpanne.Domain.Models.Type_intervention", "Type_intervention")
                        .WithMany()
                        .HasForeignKey("Type_interventionid_type_intervention");
                });

            modelBuilder.Entity("Ms_Panne.Domain.Poulina.MSpanne.Domain.Models.Panne", b =>
                {
                    b.HasOne("Ms_Panne.Domain.Poulina.MSpanne.Domain.Models.Intervention", "Intervention")
                        .WithMany("Pannes")
                        .HasForeignKey("Interventionid_intervention");
                });

            modelBuilder.Entity("Ms_Panne.Domain.Poulina.MSpanne.Domain.Models.Type_intervention", b =>
                {
                    b.HasOne("Ms_Panne.Domain.Poulina.MSpanne.Domain.Models.Intervention", "Intervention")
                        .WithMany("Type_interventions")
                        .HasForeignKey("Interventionid_intervention");
                });

            modelBuilder.Entity("Ms_Panne.Domain.Poulina.MSpanne.Domain.Models.Type_panne", b =>
                {
                    b.HasOne("Ms_Panne.Domain.Poulina.MSpanne.Domain.Models.Panne", "Panne")
                        .WithMany("Type_pannes")
                        .HasForeignKey("Panneid_panne");
                });
#pragma warning restore 612, 618
        }
    }
}