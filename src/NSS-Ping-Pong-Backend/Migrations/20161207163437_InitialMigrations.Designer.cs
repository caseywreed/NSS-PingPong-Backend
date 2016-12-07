using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using NSS_Ping_Pong_Backend.Data;

namespace NSSPingPongBackend.Migrations
{
    [DbContext(typeof(NSSPingPongContext))]
    [Migration("20161207163437_InitialMigrations")]
    partial class InitialMigrations
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

                    b.Property<int>("TeamOneScore");

                    b.Property<int>("TeamTwoScore");

                    b.HasKey("GameId");

                    b.ToTable("Game");
                });

            modelBuilder.Entity("NSS_Ping_Pong_Backend.Models.GamePlayer", b =>
                {
                    b.Property<int>("GamePlayerId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("GameId");

                    b.Property<int?>("PlayerId");

                    b.Property<int>("TeamId");

                    b.HasKey("GamePlayerId");

                    b.HasIndex("GameId");

                    b.HasIndex("PlayerId");

                    b.ToTable("GamePlayer");
                });

            modelBuilder.Entity("NSS_Ping_Pong_Backend.Models.Player", b =>
                {
                    b.Property<int>("PlayerId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Birthday");

                    b.Property<string>("Cohort");

                    b.Property<int>("FirebaseId");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<bool>("LeftHanded");

                    b.HasKey("PlayerId");

                    b.ToTable("Player");
                });

            modelBuilder.Entity("NSS_Ping_Pong_Backend.Models.GamePlayer", b =>
                {
                    b.HasOne("NSS_Ping_Pong_Backend.Models.Game", "Game")
                        .WithMany("GamePlayers")
                        .HasForeignKey("GameId");

                    b.HasOne("NSS_Ping_Pong_Backend.Models.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId");
                });
        }
    }
}
