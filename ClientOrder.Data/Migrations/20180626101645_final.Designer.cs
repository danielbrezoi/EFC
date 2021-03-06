﻿// <auto-generated />
using System;
using ClientOrder.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ClientOrder.Data.Migrations
{
    [DbContext(typeof(ClientOrderContext))]
    [Migration("20180626101645_final")]
    partial class final
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ClientOrder.Domain.Entities.Address", b =>
                {
                    b.Property<Guid>("AddressId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FullAddress")
                        .IsRequired();

                    b.Property<bool>("IsDirty");

                    b.HasKey("AddressId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("ClientOrder.Domain.Entities.Client", b =>
                {
                    b.Property<Guid>("ClientId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<bool>("IsDirty");

                    b.Property<string>("LastName");

                    b.HasKey("ClientId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("ClientOrder.Domain.Entities.ClientAddress", b =>
                {
                    b.Property<Guid>("ClientId");

                    b.Property<Guid>("AddressId");

                    b.Property<bool>("IsDirty");

                    b.HasKey("ClientId", "AddressId");

                    b.HasIndex("AddressId");

                    b.ToTable("ClientAddresses");
                });

            modelBuilder.Entity("ClientOrder.Domain.Entities.Order", b =>
                {
                    b.Property<Guid>("OrderId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsDirty");

                    b.Property<string>("Name");

                    b.HasKey("OrderId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("ClientOrder.Domain.Entities.OrderDetails", b =>
                {
                    b.Property<Guid>("OrderDetailsId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Details");

                    b.Property<bool>("IsDirty");

                    b.Property<Guid>("OrderId");

                    b.HasKey("OrderDetailsId");

                    b.HasIndex("OrderId")
                        .IsUnique();

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("ClientOrder.Domain.Entities.Product", b =>
                {
                    b.Property<Guid>("ProductId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsDirty");

                    b.Property<string>("Name");

                    b.Property<Guid?>("OrderId");

                    b.Property<int>("Price");

                    b.HasKey("ProductId");

                    b.HasIndex("OrderId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ClientOrder.Domain.Entities.ClientAddress", b =>
                {
                    b.HasOne("ClientOrder.Domain.Entities.Address", "Address")
                        .WithMany("Client")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ClientOrder.Domain.Entities.Client", "Client")
                        .WithMany("Address")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ClientOrder.Domain.Entities.OrderDetails", b =>
                {
                    b.HasOne("ClientOrder.Domain.Entities.Order", "Order")
                        .WithOne("OrderDetails")
                        .HasForeignKey("ClientOrder.Domain.Entities.OrderDetails", "OrderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ClientOrder.Domain.Entities.Product", b =>
                {
                    b.HasOne("ClientOrder.Domain.Entities.Order")
                        .WithMany("Products")
                        .HasForeignKey("OrderId");
                });
#pragma warning restore 612, 618
        }
    }
}
