﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using buzzerApi.Models;

namespace buzzerApi.Migrations
{
    [DbContext(typeof(BuzzerApiContext))]
    [Migration("20200113122415_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity("buzzerApi.Models.Propositions", b =>
                {
                    b.Property<byte[]>("Id")
                        .ValueGeneratedOnAdd()
                        .HasConversion(new ValueConverter<byte[], byte[]>(v => default(byte[]), v => default(byte[]), new ConverterMappingHints(size: 16)));

                    b.Property<byte[]>("QuestionId")
                        .IsRequired()
                        .HasConversion(new ValueConverter<byte[], byte[]>(v => default(byte[]), v => default(byte[]), new ConverterMappingHints(size: 16)));

                    b.Property<string>("proposition")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Propositions");
                });

            modelBuilder.Entity("buzzerApi.Models.Question", b =>
                {
                    b.Property<byte[]>("Id")
                        .ValueGeneratedOnAdd()
                        .HasConversion(new ValueConverter<byte[], byte[]>(v => default(byte[]), v => default(byte[]), new ConverterMappingHints(size: 16)));

                    b.Property<string>("Interogation")
                        .IsRequired();

                    b.Property<string>("QuestionTypeId");

                    b.Property<string>("Reponse")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("QuestionTypeId");

                    b.ToTable("Question");
                });

            modelBuilder.Entity("buzzerApi.Models.QuestionType", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Type")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("QuestionType");
                });

            modelBuilder.Entity("buzzerApi.Models.User", b =>
                {
                    b.Property<byte[]>("Id")
                        .ValueGeneratedOnAdd()
                        .HasConversion(new ValueConverter<byte[], byte[]>(v => default(byte[]), v => default(byte[]), new ConverterMappingHints(size: 16)));

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("Telephone")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("buzzerApi.Models.Propositions", b =>
                {
                    b.HasOne("buzzerApi.Models.Question", "Question")
                        .WithMany("Propositions")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("buzzerApi.Models.Question", b =>
                {
                    b.HasOne("buzzerApi.Models.QuestionType", "QuestionType")
                        .WithMany()
                        .HasForeignKey("QuestionTypeId");
                });
#pragma warning restore 612, 618
        }
    }
}