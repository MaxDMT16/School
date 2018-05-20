﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using SchoolSystem.Abstractions.Enums;
using SchoolSystem.Database.Context;
using System;

namespace SchoolSystem.Database.Migrations
{
    [DbContext(typeof(SchoolSystemDbContext))]
    [Migration("20180422064605_AddCmsUser")]
    partial class AddCmsUser
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SchoolSystem.Database.Entities.CmsUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Login");

                    b.Property<string>("Password");

                    b.Property<string>("RefreshToken");

                    b.Property<int>("Scope");

                    b.HasKey("Id");

                    b.ToTable("CmsUsers");
                });

            modelBuilder.Entity("SchoolSystem.Database.Entities.Group", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("SchoolSystem.Database.Entities.Lesson", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("GroupId");

                    b.Property<int>("Subject");

                    b.Property<Guid>("TeacherId");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Lessons");
                });

            modelBuilder.Entity("SchoolSystem.Database.Entities.ScheduleCell", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Day");

                    b.Property<Guid>("LessonId");

                    b.Property<byte>("LessonNumber");

                    b.Property<int>("Room");

                    b.HasKey("Id");

                    b.HasIndex("LessonId");

                    b.ToTable("ScheduleCells");
                });

            modelBuilder.Entity("SchoolSystem.Database.Entities.Users.Pupil", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<Guid>("GroupId");

                    b.Property<string>("LastName");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("Pupils");
                });

            modelBuilder.Entity("SchoolSystem.Database.Entities.Users.Teacher", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("Id");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("SchoolSystem.Database.Entities.Lesson", b =>
                {
                    b.HasOne("SchoolSystem.Database.Entities.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SchoolSystem.Database.Entities.Users.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SchoolSystem.Database.Entities.ScheduleCell", b =>
                {
                    b.HasOne("SchoolSystem.Database.Entities.Lesson", "Lesson")
                        .WithMany()
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SchoolSystem.Database.Entities.Users.Pupil", b =>
                {
                    b.HasOne("SchoolSystem.Database.Entities.Group", "Group")
                        .WithMany("Pupils")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}