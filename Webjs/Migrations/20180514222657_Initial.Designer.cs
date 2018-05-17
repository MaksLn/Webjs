﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using Webjs.Models;

namespace Webjs.Migrations
{
    [DbContext(typeof(ModelNewsContext))]
    [Migration("20180514222657_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Webjs.Models.NewsModel", b =>
                {
                    b.Property<string>("Url")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Header")
                        .IsRequired();

                    b.Property<string>("Text");

                    b.Property<DateTime>("TimeOf");

                    b.Property<int>("id");

                    b.HasKey("Url");

                    b.ToTable("newsModels");
                });
#pragma warning restore 612, 618
        }
    }
}