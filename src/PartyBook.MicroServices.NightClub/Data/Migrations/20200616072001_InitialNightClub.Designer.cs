﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PartyBook.MicroServices.NightClub.Data;

namespace PartyBook.MicroServices.NightClub.Migrations
{
    [DbContext(typeof(NightClubDbContext))]
    [Migration("20200616072001_InitialNightClub")]
    partial class InitialNightClub
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PartyBook.MicroServices.NightClub.Data.Models.BookRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsApproved")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRejected")
                        .HasColumnType("bit");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NightClubId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("NumberOfPeople")
                        .HasColumnType("int");

                    b.Property<string>("TelephoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("When")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("NightClubId");

                    b.ToTable("BookRequests");
                });

            modelBuilder.Entity("PartyBook.MicroServices.NightClub.Data.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("NightClubId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PictureUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<DateTime>("When")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("NightClubId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("PartyBook.MicroServices.NightClub.Data.Models.NightClub", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BusinessHours")
                        .IsRequired()
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<string>("CoverUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("TelephoneForReservations")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("NightClubs");
                });

            modelBuilder.Entity("PartyBook.MicroServices.NightClub.Data.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<string>("NightClubId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Raiting")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("NightClubId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("PartyBook.MicroServices.NightClub.Data.Models.BookRequest", b =>
                {
                    b.HasOne("PartyBook.MicroServices.NightClub.Data.Models.NightClub", "NightClub")
                        .WithMany("Requests")
                        .HasForeignKey("NightClubId");
                });

            modelBuilder.Entity("PartyBook.MicroServices.NightClub.Data.Models.Event", b =>
                {
                    b.HasOne("PartyBook.MicroServices.NightClub.Data.Models.NightClub", "NightClub")
                        .WithMany("Events")
                        .HasForeignKey("NightClubId");
                });

            modelBuilder.Entity("PartyBook.MicroServices.NightClub.Data.Models.Review", b =>
                {
                    b.HasOne("PartyBook.MicroServices.NightClub.Data.Models.NightClub", "NightClub")
                        .WithMany("Reviewes")
                        .HasForeignKey("NightClubId");
                });
#pragma warning restore 612, 618
        }
    }
}
