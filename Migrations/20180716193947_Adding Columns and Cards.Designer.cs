﻿// <auto-generated />
using System;
using Donatello.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace donatello.Migrations
{
    [DbContext(typeof(DonatelloContext))]
    [Migration("20180716193947_Adding Columns and Cards")]
    partial class AddingColumnsandCards
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Donatello.Models.Board", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Boards");
                });

            modelBuilder.Entity("Donatello.Models.Card", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ColumnId");

                    b.Property<string>("Contents");

                    b.HasKey("Id");

                    b.HasIndex("ColumnId");

                    b.ToTable("Card");
                });

            modelBuilder.Entity("Donatello.Models.Column", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("BoardId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("BoardId");

                    b.ToTable("Column");
                });

            modelBuilder.Entity("Donatello.Models.Card", b =>
                {
                    b.HasOne("Donatello.Models.Column")
                        .WithMany("Cards")
                        .HasForeignKey("ColumnId");
                });

            modelBuilder.Entity("Donatello.Models.Column", b =>
                {
                    b.HasOne("Donatello.Models.Board")
                        .WithMany("Columns")
                        .HasForeignKey("BoardId");
                });
#pragma warning restore 612, 618
        }
    }
}