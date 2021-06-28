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
    [Migration("20210628000746_GnsMigration2")]
    partial class GnsMigration2
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
                    b.Property<Guid>("GameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("GroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GameId");

                    b.HasIndex("GroupId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("GNS.Core.Models.Group", b =>
                {
                    b.Property<Guid>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("LedgerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GroupId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("GNS.Core.Models.Player", b =>
                {
                    b.Property<Guid>("PlayerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("GroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("RecordId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PlayerId");

                    b.HasIndex("GroupId");

                    b.HasIndex("RecordId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("GNS.Core.Models.Record", b =>
                {
                    b.Property<Guid>("RecordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("GameId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RecordId");

                    b.HasIndex("GameId");

                    b.ToTable("Records");
                });

            modelBuilder.Entity("GNS.Core.Models.Game", b =>
                {
                    b.HasOne("GNS.Core.Models.Group", "Group")
                        .WithMany("Games")
                        .HasForeignKey("GroupId");

                    b.Navigation("Group");
                });

            modelBuilder.Entity("GNS.Core.Models.Player", b =>
                {
                    b.HasOne("GNS.Core.Models.Group", "Group")
                        .WithMany("Players")
                        .HasForeignKey("GroupId");

                    b.HasOne("GNS.Core.Models.Record", null)
                        .WithMany("Winners")
                        .HasForeignKey("RecordId");

                    b.Navigation("Group");
                });

            modelBuilder.Entity("GNS.Core.Models.Record", b =>
                {
                    b.HasOne("GNS.Core.Models.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameId");

                    b.Navigation("Game");
                });

            modelBuilder.Entity("GNS.Core.Models.Group", b =>
                {
                    b.Navigation("Games");

                    b.Navigation("Players");
                });

            modelBuilder.Entity("GNS.Core.Models.Record", b =>
                {
                    b.Navigation("Winners");
                });
#pragma warning restore 612, 618
        }
    }
}
