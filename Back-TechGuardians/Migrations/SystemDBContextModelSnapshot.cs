﻿// <auto-generated />
using Back_TechGuardians.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Back_TechGuardians.Migrations
{
    [DbContext(typeof(SystemDBContext))]
    partial class SystemDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Back_TechGuardians.Models.EquipamentModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.Property<int>("Stats")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Equipaments");
                });

            modelBuilder.Entity("Back_TechGuardians.Models.MonitoringModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Block")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<int>("EquipamentId")
                        .HasColumnType("int");

                    b.Property<string>("Room")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EquipamentId");

                    b.HasIndex("UserId");

                    b.ToTable("Monitorings");
                });

            modelBuilder.Entity("Back_TechGuardians.Models.UserModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Back_TechGuardians.Models.MonitoringModel", b =>
                {
                    b.HasOne("Back_TechGuardians.Models.EquipamentModel", "Equipament")
                        .WithMany()
                        .HasForeignKey("EquipamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Back_TechGuardians.Models.UserModel", "User")
                        .WithMany("Monitoring")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipament");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Back_TechGuardians.Models.UserModel", b =>
                {
                    b.Navigation("Monitoring");
                });
#pragma warning restore 612, 618
        }
    }
}
