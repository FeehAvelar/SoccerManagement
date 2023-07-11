﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SoccerManagement.Data;

#nullable disable

namespace SoccerManagement.Migrations
{
    [DbContext(typeof(SoccerManagementContext))]
    [Migration("20230710030207_ChangeOnDeletePlayer")]
    partial class ChangeOnDeletePlayer
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("GamePlayers", b =>
                {
                    b.Property<int>("FkGame")
                        .HasColumnType("int");

                    b.Property<int>("FkPlayer")
                        .HasColumnType("int");

                    b.HasKey("FkGame", "FkPlayer");

                    b.HasIndex("FkPlayer");

                    b.ToTable("GamePlayers");
                });

            modelBuilder.Entity("SoccerManagement.Models.Enities.Financial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateAdd")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DatePayment")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DateUpdate")
                        .HasColumnType("datetime(6)");

                    b.Property<byte>("FinanceOrigin")
                        .HasColumnType("tinyint unsigned");

                    b.Property<int>("IdOrigin")
                        .HasColumnType("int");

                    b.Property<int>("IdOwner")
                        .HasColumnType("int");

                    b.Property<int?>("IdWhoChange")
                        .HasColumnType("int");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.Property<byte>("TypeFinance")
                        .HasColumnType("tinyint unsigned");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("WhoChangeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.HasIndex("WhoChangeId");

                    b.ToTable("financial");
                });

            modelBuilder.Entity("SoccerManagement.Models.Enities.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateAdd")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DateUpdate")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("DayAmount")
                        .HasColumnType("decimal(65,30)");

                    b.Property<DateTime>("GameDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("IdOwner")
                        .HasColumnType("int");

                    b.Property<int?>("IdWhoChange")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdOwner");

                    b.HasIndex("IdWhoChange");

                    b.ToTable("Game");
                });

            modelBuilder.Entity("SoccerManagement.Models.Enities.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cellphone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DateAdd")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DateUpdate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("IdUser")
                        .HasColumnType("int");

                    b.Property<int?>("IdWhoChange")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("IdUser")
                        .IsUnique();

                    b.HasIndex("IdWhoChange")
                        .IsUnique();

                    b.ToTable("Player");
                });

            modelBuilder.Entity("SoccerManagement.Models.Enities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateAdd")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DateUpdate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("IdPlayer")
                        .HasColumnType("int");

                    b.Property<int?>("IdWhoChange")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("GamePlayers", b =>
                {
                    b.HasOne("SoccerManagement.Models.Enities.Game", null)
                        .WithMany()
                        .HasForeignKey("FkGame")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SoccerManagement.Models.Enities.Player", null)
                        .WithMany()
                        .HasForeignKey("FkPlayer")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SoccerManagement.Models.Enities.Financial", b =>
                {
                    b.HasOne("SoccerManagement.Models.Enities.Player", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SoccerManagement.Models.Enities.User", "WhoChange")
                        .WithMany()
                        .HasForeignKey("WhoChangeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");

                    b.Navigation("WhoChange");
                });

            modelBuilder.Entity("SoccerManagement.Models.Enities.Game", b =>
                {
                    b.HasOne("SoccerManagement.Models.Enities.Player", "Owner")
                        .WithMany()
                        .HasForeignKey("IdOwner")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SoccerManagement.Models.Enities.User", "WhoChange")
                        .WithMany()
                        .HasForeignKey("IdWhoChange");

                    b.Navigation("Owner");

                    b.Navigation("WhoChange");
                });

            modelBuilder.Entity("SoccerManagement.Models.Enities.Player", b =>
                {
                    b.HasOne("SoccerManagement.Models.Enities.User", "User")
                        .WithOne()
                        .HasForeignKey("SoccerManagement.Models.Enities.Player", "IdUser");

                    b.HasOne("SoccerManagement.Models.Enities.User", "WhoChange")
                        .WithOne()
                        .HasForeignKey("SoccerManagement.Models.Enities.Player", "IdWhoChange")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("User");

                    b.Navigation("WhoChange");
                });
#pragma warning restore 612, 618
        }
    }
}
