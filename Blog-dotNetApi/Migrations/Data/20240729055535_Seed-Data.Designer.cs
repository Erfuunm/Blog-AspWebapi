﻿// <auto-generated />
using System;
using Blog_dotNetApi.Cors.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Blog_dotNetApi.Migrations.Data
{
    [DbContext(typeof(DataContext))]
    [Migration("20240729055535_Seed-Data")]
    partial class SeedData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Blog_dotNetApi.Cors.Entities.Article", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PblId")
                        .HasColumnType("int");

                    b.Property<int>("PublisherID")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("PublisherID");

                    b.ToTable("Totalarticles");
                });

            modelBuilder.Entity("Blog_dotNetApi.Cors.Entities.ArticleCategory", b =>
                {
                    b.Property<int>("ArticleId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.HasKey("ArticleId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("ArticleCategories");
                });

            modelBuilder.Entity("Blog_dotNetApi.Cors.Entities.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("categories");
                });

            modelBuilder.Entity("Blog_dotNetApi.Cors.Entities.Publisher", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("ArticleId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PublishDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("publishers");
                });

            modelBuilder.Entity("Blog_dotNetApi.Cors.Entities.Article", b =>
                {
                    b.HasOne("Blog_dotNetApi.Cors.Entities.Publisher", "Publisher")
                        .WithMany("articles")
                        .HasForeignKey("PublisherID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("Blog_dotNetApi.Cors.Entities.ArticleCategory", b =>
                {
                    b.HasOne("Blog_dotNetApi.Cors.Entities.Article", "Article")
                        .WithMany("articleCategories")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Blog_dotNetApi.Cors.Entities.Category", "Category")
                        .WithMany("articleCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Article");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Blog_dotNetApi.Cors.Entities.Article", b =>
                {
                    b.Navigation("articleCategories");
                });

            modelBuilder.Entity("Blog_dotNetApi.Cors.Entities.Category", b =>
                {
                    b.Navigation("articleCategories");
                });

            modelBuilder.Entity("Blog_dotNetApi.Cors.Entities.Publisher", b =>
                {
                    b.Navigation("articles");
                });
#pragma warning restore 612, 618
        }
    }
}
