﻿// <auto-generated />
using System;
using EventProject.Repository.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EventProject.Repository.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230904141155_initialCatalog")]
    partial class initialCatalog
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EventProject.Core.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("date");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("date");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("EventProject.Core.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("date");

                    b.Property<int>("CustomerAge")
                        .HasColumnType("int");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("date");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("EventProject.Core.Entities.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("date");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("date");

                    b.Property<int>("EventAgeControl")
                        .HasColumnType("int");

                    b.Property<int>("EventAttends")
                        .HasColumnType("int");

                    b.Property<DateTime>("EventFinishDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EventLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("EventName")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)");

                    b.Property<decimal>("EventPrice")
                        .HasColumnType("decimal(10,2)");

                    b.Property<DateTime>("EventStartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("EventProject.Core.Entities.EventDetail", b =>
                {
                    b.Property<int>("EventDetailId")
                        .HasColumnType("int");

                    b.Property<string>("EventMail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EventPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EventDetailId");

                    b.ToTable("EventDetails");
                });

            modelBuilder.Entity("EventProject.Core.Entities.Ticket", b =>
                {
                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TicketDate")
                        .HasColumnType("datetime2");

                    b.HasKey("EventId", "CustomerId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("EventProject.Core.Entities.Event", b =>
                {
                    b.HasOne("EventProject.Core.Entities.Category", "Category")
                        .WithMany("Events")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("EventProject.Core.Entities.EventDetail", b =>
                {
                    b.HasOne("EventProject.Core.Entities.Event", "Event")
                        .WithOne("EventDetail")
                        .HasForeignKey("EventProject.Core.Entities.EventDetail", "EventDetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");
                });

            modelBuilder.Entity("EventProject.Core.Entities.Ticket", b =>
                {
                    b.HasOne("EventProject.Core.Entities.Customer", "Customer")
                        .WithMany("Tickets")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EventProject.Core.Entities.Event", "Event")
                        .WithMany("Tickets")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Event");
                });

            modelBuilder.Entity("EventProject.Core.Entities.Category", b =>
                {
                    b.Navigation("Events");
                });

            modelBuilder.Entity("EventProject.Core.Entities.Customer", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("EventProject.Core.Entities.Event", b =>
                {
                    b.Navigation("EventDetail")
                        .IsRequired();

                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
