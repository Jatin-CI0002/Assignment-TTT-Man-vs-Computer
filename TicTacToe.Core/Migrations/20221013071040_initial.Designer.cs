﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TicTacToe.Core;

namespace TicTacToe.Core.Migrations
{
    [DbContext(typeof(GameContext))]
    [Migration("20221013071040_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.30")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("TicTacToe.Contracts.Models.GameResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Draw")
                        .HasColumnType("boolean");

                    b.Property<string>("Loser")
                        .HasColumnType("text");

                    b.Property<int>("OCount")
                        .HasColumnType("integer");

                    b.Property<string>("Winner")
                        .HasColumnType("text");

                    b.Property<int>("XCount")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("GameResults");
                });
#pragma warning restore 612, 618
        }
    }
}
