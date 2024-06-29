﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TicTacToe.Multiplayer;

#nullable disable

namespace TicTacToe.Multiplayer.Migrations
{
    [DbContext(typeof(TTTContext))]
    partial class TTTContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-preview.3.23174.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("TicTacToe.Multiplayer.Box", b =>
                {
                    b.Property<int>("Field")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasColumnType("varchar(1)");

                    b.HasKey("Field");

                    b.ToTable("Boxes");
                });

            modelBuilder.Entity("TicTacToe.Multiplayer.Player", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("FirstOrder")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Won")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("YourTurn")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("ID");

                    b.ToTable("Players");
                });
#pragma warning restore 612, 618
        }
    }
}
