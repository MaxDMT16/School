﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using SchoolSystem.Abstractions.Enums;
using SchoolSystem.Database.Context;
using System;

namespace SchoolSystem.Database.Migrations
{
    [DbContext(typeof(SchoolSystemDbContext))]
    [Migration("20180624073610_CmsRefreshTokens")]
    partial class CmsRefreshTokens
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

                    b.Property<Guid>("SubjectId");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("SubjectId");

                    b.ToTable("Lessons");
                });

            modelBuilder.Entity("SchoolSystem.Database.Entities.ScheduleCell", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Day");

                    b.Property<Guid>("LessonId");

                    b.Property<int>("LessonNumber");

                    b.Property<string>("Room");

                    b.HasKey("Id");

                    b.HasIndex("LessonId");

                    b.ToTable("ScheduleCells");
                });

            modelBuilder.Entity("SchoolSystem.Database.Entities.Subject", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("SchoolSystem.Database.Entities.TeacherLesson", b =>
                {
                    b.Property<Guid>("TeacherId");

                    b.Property<Guid>("LessonId");

                    b.HasKey("TeacherId", "LessonId");

                    b.HasIndex("LessonId");

                    b.ToTable("TeachersLessons");
                });

            modelBuilder.Entity("SchoolSystem.Database.Entities.Users.CmsUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Login");

                    b.Property<string>("Password");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.ToTable("CmsUsers");
                });

            modelBuilder.Entity("SchoolSystem.Database.Entities.Users.CmsUserRefreshToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CmsUserId");

                    b.Property<string>("DeviceId");

                    b.Property<string>("Token");

                    b.HasKey("Id");

                    b.HasIndex("CmsUserId");

                    b.ToTable("CmsUserRefreshTokens");
                });

            modelBuilder.Entity("SchoolSystem.Database.Entities.Users.UserBase", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Login");

                    b.Property<string>("Password");

                    b.HasKey("Id");

                    b.ToTable("UserBase");

                    b.HasDiscriminator<string>("Discriminator").HasValue("UserBase");
                });

            modelBuilder.Entity("SchoolSystem.Database.Entities.Users.UserRefreshToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DeviceId");

                    b.Property<string>("Token");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserRefreshTokens");
                });

            modelBuilder.Entity("SchoolSystem.Database.Entities.Users.Pupil", b =>
                {
                    b.HasBaseType("SchoolSystem.Database.Entities.Users.UserBase");

                    b.Property<Guid>("GroupId");

                    b.HasIndex("GroupId");

                    b.ToTable("Pupil");

                    b.HasDiscriminator().HasValue("Pupil");
                });

            modelBuilder.Entity("SchoolSystem.Database.Entities.Users.Teacher", b =>
                {
                    b.HasBaseType("SchoolSystem.Database.Entities.Users.UserBase");


                    b.ToTable("Teacher");

                    b.HasDiscriminator().HasValue("Teacher");
                });

            modelBuilder.Entity("SchoolSystem.Database.Entities.Lesson", b =>
                {
                    b.HasOne("SchoolSystem.Database.Entities.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SchoolSystem.Database.Entities.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SchoolSystem.Database.Entities.ScheduleCell", b =>
                {
                    b.HasOne("SchoolSystem.Database.Entities.Lesson", "Lesson")
                        .WithMany("ScheduleCells")
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SchoolSystem.Database.Entities.TeacherLesson", b =>
                {
                    b.HasOne("SchoolSystem.Database.Entities.Lesson", "Lesson")
                        .WithMany("TeachersLessons")
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SchoolSystem.Database.Entities.Users.Teacher", "Teacher")
                        .WithMany("TeachersLessons")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SchoolSystem.Database.Entities.Users.CmsUserRefreshToken", b =>
                {
                    b.HasOne("SchoolSystem.Database.Entities.Users.CmsUser", "CmsUser")
                        .WithMany()
                        .HasForeignKey("CmsUserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SchoolSystem.Database.Entities.Users.UserRefreshToken", b =>
                {
                    b.HasOne("SchoolSystem.Database.Entities.Users.UserBase", "UserBase")
                        .WithMany()
                        .HasForeignKey("UserId")
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
