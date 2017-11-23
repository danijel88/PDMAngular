﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using PDMAngular.Persistence;
using System;

namespace PDMAngular.Migrations
{
    [DbContext(typeof(PdmDbContext))]
    [Migration("20171123124413_AddItem")]
    partial class AddItem
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PDMAngular.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Band");

                    b.Property<string>("Color");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Description");

                    b.Property<int?>("Enter");

                    b.Property<int?>("Exit");

                    b.Property<string>("InternalCode")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("ItemTypeId");

                    b.Property<int>("MachineTypeId");

                    b.Property<string>("MadeBy")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<string>("Name");

                    b.Property<int?>("Thickness");

                    b.Property<DateTime?>("UpdateDate");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ItemTypeId");

                    b.HasIndex("MachineTypeId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("PDMAngular.Models.ItemType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<DateTime?>("UpdateDate");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.ToTable("ItemTypes");
                });

            modelBuilder.Entity("PDMAngular.Models.MachineType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<DateTime?>("UpdateDate");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.ToTable("MachineTypes");
                });

            modelBuilder.Entity("PDMAngular.Models.Item", b =>
                {
                    b.HasOne("PDMAngular.Models.ItemType", "ItemType")
                        .WithMany("Items")
                        .HasForeignKey("ItemTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PDMAngular.Models.MachineType", "MachineType")
                        .WithMany("Items")
                        .HasForeignKey("MachineTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
