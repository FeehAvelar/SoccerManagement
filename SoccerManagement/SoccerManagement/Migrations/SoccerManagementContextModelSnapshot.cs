﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SoccerManagement.Data;

#nullable disable

namespace SoccerManagement.Migrations
{
    [DbContext(typeof(SoccerManagementContext))]
    partial class SoccerManagementContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("GamePlayer", b =>
                {
                    b.Property<int>("GamesId")
                        .HasColumnType("int");

                    b.Property<int>("PlayersId")
                        .HasColumnType("int");

                    b.HasKey("GamesId", "PlayersId");

                    b.HasIndex("PlayersId");

                    b.ToTable("GamePlayer");
                });

            modelBuilder.Entity("SoccerManagement.Models.Enities.Financial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AccountableId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateAdd")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DatePayment")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DateUpdate")
                        .HasColumnType("datetime(6)");

                    b.Property<byte>("FinanceOrigin")
                        .HasColumnType("tinyint unsigned");

                    b.Property<int>("IdAccountable")
                        .HasColumnType("int");

                    b.Property<int>("IdCreator")
                        .HasColumnType("int");

                    b.Property<int>("IdOrigin")
                        .HasColumnType("int");

                    b.Property<int?>("IdWhoChange")
                        .HasColumnType("int");

                    b.Property<byte>("TypeFinance")
                        .HasColumnType("tinyint unsigned");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.HasIndex("AccountableId");

                    b.HasIndex("IdCreator");

                    b.HasIndex("IdWhoChange")
                        .IsUnique();

                    b.ToTable("Financial");
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

                    b.Property<int>("IdCreator")
                        .HasColumnType("int");

                    b.Property<int?>("IdWhoChange")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdCreator");

                    b.HasIndex("IdWhoChange")
                        .IsUnique();

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

            modelBuilder.Entity("GamePlayer", b =>
                {
                    b.HasOne("SoccerManagement.Models.Enities.Game", null)
                        .WithMany()
                        .HasForeignKey("GamesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SoccerManagement.Models.Enities.Player", null)
                        .WithMany()
                        .HasForeignKey("PlayersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SoccerManagement.Models.Enities.Financial", b =>
                {
                    b.HasOne("SoccerManagement.Models.Enities.Player", "Accountable")
                        .WithMany()
                        .HasForeignKey("AccountableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SoccerManagement.Models.Enities.Player", "Creator")
                        .WithMany()
                        .HasForeignKey("IdCreator")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SoccerManagement.Models.Enities.User", "WhoChange")
                        .WithOne()
                        .HasForeignKey("SoccerManagement.Models.Enities.Financial", "IdWhoChange")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Accountable");

                    b.Navigation("Creator");

                    b.Navigation("WhoChange");
                });

            modelBuilder.Entity("SoccerManagement.Models.Enities.Game", b =>
                {
                    b.HasOne("SoccerManagement.Models.Enities.Player", "Creator")
                        .WithMany()
                        .HasForeignKey("IdCreator")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SoccerManagement.Models.Enities.User", "WhoChange")
                        .WithOne()
                        .HasForeignKey("SoccerManagement.Models.Enities.Game", "IdWhoChange")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Creator");

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
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("User");

                    b.Navigation("WhoChange");
                });
#pragma warning restore 612, 618
        }
    }
}
