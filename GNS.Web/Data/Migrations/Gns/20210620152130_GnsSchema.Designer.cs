﻿// <auto-generated />
using System;
using GNS.Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GNS.Web.Data.Migrations.Gns
{
    [DbContext(typeof(GnsEntities))]
    [Migration("20210620152130_GnsSchema")]
    partial class GnsSchema
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GNS.Core.Models.Game", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GameGroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GameGroupId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("GNS.Core.Models.GameGroup", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("LedgerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("GameGroups");
                });

            modelBuilder.Entity("GNS.Core.Models.Player", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("GameGroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("GameId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GameGroupId");

                    b.HasIndex("GameId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("GNS.Core.Models.Game", b =>
                {
                    b.HasOne("GNS.Core.Models.GameGroup", null)
                        .WithMany("Games")
                        .HasForeignKey("GameGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GNS.Core.Models.Player", b =>
                {
                    b.HasOne("GNS.Core.Models.GameGroup", null)
                        .WithMany("Players")
                        .HasForeignKey("GameGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GNS.Core.Models.Game", null)
                        .WithMany("Winners")
                        .HasForeignKey("GameId");
                });

            modelBuilder.Entity("GNS.Core.Models.Game", b =>
                {
                    b.Navigation("Winners");
                });

            modelBuilder.Entity("GNS.Core.Models.GameGroup", b =>
                {
                    b.Navigation("Games");

                    b.Navigation("Players");
                });
#pragma warning restore 612, 618
        }
    }
}
