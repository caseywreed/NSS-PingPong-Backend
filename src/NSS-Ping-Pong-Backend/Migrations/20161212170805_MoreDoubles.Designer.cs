﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using NSS_Ping_Pong_Backend.Data;

namespace NSSPingPongBackend.Migrations
{
    [DbContext(typeof(NSSPingPongContext))]
    [Migration("20161212170805_MoreDoubles")]
    partial class MoreDoubles
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NSS_Ping_Pong_Backend.Models.Game", b =>
                {
                    b.Property<int>("GameId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DatePlayed");

                    b.Property<double>("TeamOneScore");

                    b.Property<double>("TeamTwoScore");

                    b.HasKey("GameId");

                    b.ToTable("Game");
                });

            modelBuilder.Entity("NSS_Ping_Pong_Backend.Models.GamePlayer", b =>
                {
                    b.Property<int>("GamePlayerId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("GameId");

                    b.Property<int>("PlayerId");

                    b.Property<double?>("PointDiff");

                    b.Property<int>("Team");

                    b.Property<bool?>("Won");

                    b.HasKey("GamePlayerId");

                    b.HasIndex("GameId");

                    b.ToTable("GamePlayer");
                });

            modelBuilder.Entity("NSS_Ping_Pong_Backend.Models.Player", b =>
                {
                    b.Property<int>("PlayerId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Cohort");

                    b.Property<int>("FirebaseId");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<bool>("LeftHanded");

                    b.HasKey("PlayerId");

                    b.ToTable("Player");
                });

            modelBuilder.Entity("NSS_Ping_Pong_Backend.Models.Stats", b =>
                {
                    b.Property<int>("StatsId")
                        .ValueGeneratedOnAdd();

                    b.Property<double?>("AvgPointDiff");

                    b.Property<double>("Games");

                    b.Property<double>("Losses");

                    b.Property<int>("PlayerId");

                    b.Property<double?>("Rating");

                    b.Property<double?>("WinPercentage");

                    b.Property<double>("Wins");

                    b.HasKey("StatsId");

                    b.HasIndex("PlayerId")
                        .IsUnique();

                    b.ToTable("Stats");
                });

            modelBuilder.Entity("NSS_Ping_Pong_Backend.Models.GamePlayer", b =>
                {
                    b.HasOne("NSS_Ping_Pong_Backend.Models.Game")
                        .WithMany("GamePlayers")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NSS_Ping_Pong_Backend.Models.Stats", b =>
                {
                    b.HasOne("NSS_Ping_Pong_Backend.Models.Player")
                        .WithOne("Stats")
                        .HasForeignKey("NSS_Ping_Pong_Backend.Models.Stats", "PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
