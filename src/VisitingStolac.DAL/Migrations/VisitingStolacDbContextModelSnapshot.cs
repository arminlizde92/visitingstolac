﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VisitingStolac.DAL.Context;

namespace VisitingStolac.DAL.Migrations
{
    [DbContext(typeof(VisitingStolacDbContext))]
    partial class VisitingStolacDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VisitingStolac.DAL.Administrator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<bool>("IsActive");

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Administrators");
                });

            modelBuilder.Entity("VisitingStolac.DAL.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<bool>("IsActive");

                    b.Property<string>("Name");

                    b.Property<string>("PhoneNumber");

                    b.Property<byte>("Type");

                    b.HasKey("Id");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("VisitingStolac.DAL.Contribution", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PostId");

                    b.Property<int>("SubscriberId");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("SubscriberId");

                    b.ToTable("Contributions");
                });

            modelBuilder.Entity("VisitingStolac.DAL.FAQ", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AnswerId");

                    b.Property<int>("QuestionId");

                    b.HasKey("Id");

                    b.HasIndex("AnswerId")
                        .IsUnique();

                    b.HasIndex("QuestionId")
                        .IsUnique();

                    b.ToTable("FAQs");
                });

            modelBuilder.Entity("VisitingStolac.DAL.Media", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GroupId");

                    b.Property<string>("PublicId");

                    b.Property<string>("Source");

                    b.Property<byte>("Type");

                    b.Property<string>("Url")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("Medias");
                });

            modelBuilder.Entity("VisitingStolac.DAL.MediaGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte>("Type");

                    b.HasKey("Id");

                    b.ToTable("MediaGroups");
                });

            modelBuilder.Entity("VisitingStolac.DAL.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AdministratorId");

                    b.Property<DateTime>("Created");

                    b.Property<int>("MediaGroupId");

                    b.Property<DateTime>("Modified");

                    b.Property<int>("TextId");

                    b.Property<int>("TitleId");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.HasIndex("AdministratorId");

                    b.HasIndex("MediaGroupId");

                    b.HasIndex("TextId")
                        .IsUnique();

                    b.HasIndex("TitleId")
                        .IsUnique();

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("VisitingStolac.DAL.PostContact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ContactId");

                    b.Property<int>("PostId");

                    b.HasKey("Id");

                    b.HasIndex("ContactId");

                    b.HasIndex("PostId");

                    b.ToTable("PostContacts");
                });

            modelBuilder.Entity("VisitingStolac.DAL.Subscriber", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsSubscribedOnNews");

                    b.Property<bool>("IsSubscribedOnPosts");

                    b.HasKey("Id");

                    b.ToTable("Subscribers");
                });

            modelBuilder.Entity("VisitingStolac.DAL.TextContent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created");

                    b.HasKey("Id");

                    b.ToTable("TextContents");
                });

            modelBuilder.Entity("VisitingStolac.DAL.TextContentTranslation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte>("Locale");

                    b.Property<string>("Text");

                    b.Property<int>("TextContentId");

                    b.HasKey("Id");

                    b.HasIndex("TextContentId");

                    b.ToTable("TextContentTranslations");
                });

            modelBuilder.Entity("VisitingStolac.DAL.Contribution", b =>
                {
                    b.HasOne("VisitingStolac.DAL.Post", "Post")
                        .WithMany()
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("VisitingStolac.DAL.Subscriber", "Subscriber")
                        .WithMany()
                        .HasForeignKey("SubscriberId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VisitingStolac.DAL.FAQ", b =>
                {
                    b.HasOne("VisitingStolac.DAL.TextContent", "Answer")
                        .WithOne()
                        .HasForeignKey("VisitingStolac.DAL.FAQ", "AnswerId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("VisitingStolac.DAL.TextContent", "Question")
                        .WithOne()
                        .HasForeignKey("VisitingStolac.DAL.FAQ", "QuestionId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("VisitingStolac.DAL.Media", b =>
                {
                    b.HasOne("VisitingStolac.DAL.MediaGroup", "Group")
                        .WithMany("Medias")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VisitingStolac.DAL.Post", b =>
                {
                    b.HasOne("VisitingStolac.DAL.Administrator", "Administrator")
                        .WithMany()
                        .HasForeignKey("AdministratorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("VisitingStolac.DAL.MediaGroup", "MediaGroup")
                        .WithMany()
                        .HasForeignKey("MediaGroupId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("VisitingStolac.DAL.TextContent", "Text")
                        .WithOne()
                        .HasForeignKey("VisitingStolac.DAL.Post", "TextId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("VisitingStolac.DAL.TextContent", "Title")
                        .WithOne()
                        .HasForeignKey("VisitingStolac.DAL.Post", "TitleId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("VisitingStolac.DAL.PostContact", b =>
                {
                    b.HasOne("VisitingStolac.DAL.Contact", "Contact")
                        .WithMany()
                        .HasForeignKey("ContactId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("VisitingStolac.DAL.Post", "Post")
                        .WithMany()
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VisitingStolac.DAL.TextContentTranslation", b =>
                {
                    b.HasOne("VisitingStolac.DAL.TextContent", "TextContent")
                        .WithMany("Translations")
                        .HasForeignKey("TextContentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
