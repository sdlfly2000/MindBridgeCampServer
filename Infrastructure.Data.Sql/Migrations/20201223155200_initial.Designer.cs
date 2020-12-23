﻿// <auto-generated />
using System;
using Infrastructure.Data.Sql;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Data.Sql.Migrations
{
    [DbContext(typeof(MindBridgeCampDbContext))]
    [Migration("20201223155200_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Infrastructure.Data.Sql.LearningRoom.Entities.ChatEntity", b =>
                {
                    b.Property<string>("chatId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("content")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("createdBy")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("createdOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("roomId")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("chatId");

                    b.ToTable("Chats");
                });

            modelBuilder.Entity("Infrastructure.Data.Sql.LearningRoom.Entities.ParticipantEntity", b =>
                {
                    b.Property<string>("participantId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("roomId")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("userId")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("participantId");

                    b.ToTable("Participants");
                });

            modelBuilder.Entity("Infrastructure.Data.Sql.LearningRoom.Entities.RoomEntity", b =>
                {
                    b.Property<string>("roomId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("endDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("learningContent")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("participantCount")
                        .HasColumnType("int");

                    b.Property<string>("place")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("startDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("title")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("roomId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("Infrastructure.Data.Sql.LearningRoom.Entities.SignInEntity", b =>
                {
                    b.Property<string>("signInId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("participant")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("roomId")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("signInOn")
                        .HasColumnType("datetime(6)");

                    b.HasKey("signInId");

                    b.ToTable("SignIns");
                });

            modelBuilder.Entity("Infrastructure.Data.Sql.User.Entities.HobbyEntity", b =>
                {
                    b.Property<Guid>("hobbyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("UserEntityuserId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<bool>("isActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("hobbyId");

                    b.HasIndex("UserEntityuserId");

                    b.ToTable("HobbyEntity");
                });

            modelBuilder.Entity("Infrastructure.Data.Sql.User.Entities.UserEntity", b =>
                {
                    b.Property<string>("userId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("expectationAfterGraduation")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int?>("gender")
                        .HasColumnType("int");

                    b.Property<int?>("height")
                        .HasColumnType("int");

                    b.Property<string>("majorIn")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("studyContent")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int?>("weight")
                        .HasColumnType("int");

                    b.HasKey("userId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Infrastructure.Data.Sql.User.Entities.UserInfoEntity", b =>
                {
                    b.Property<string>("openId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("avatarUrl")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("city")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("country")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("language")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("nickName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("province")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("openId");

                    b.ToTable("UserInfos");
                });

            modelBuilder.Entity("Infrastructure.Data.Sql.User.Entities.HobbyEntity", b =>
                {
                    b.HasOne("Infrastructure.Data.Sql.User.Entities.UserEntity", null)
                        .WithMany("hobbies")
                        .HasForeignKey("UserEntityuserId");
                });
#pragma warning restore 612, 618
        }
    }
}
