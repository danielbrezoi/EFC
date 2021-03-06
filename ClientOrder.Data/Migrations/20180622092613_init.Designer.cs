﻿// <auto-generated />
using System;
using ClientOrder.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClientOrder.Data.Migrations
{
    [DbContext(typeof(ClientOrderContext))]
    [Migration("20180622092613_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ClientOrder.Domain.Address", b =>
                {
                    b.Property<Guid>("AddressId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FullAddress");

                    b.HasKey("AddressId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("ClientOrder.Domain.Client", b =>
                {
                    b.Property<Guid>("ClientId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("ClientId");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("ClientOrder.Domain.ClientAddress", b =>
                {
                    b.Property<Guid>("ClientId");

                    b.Property<Guid>("AddressId");

                    b.HasKey("ClientId", "AddressId");

                    b.HasIndex("AddressId");

                    b.ToTable("ClientAddress");
                });

            modelBuilder.Entity("ClientOrder.Domain.Order", b =>
                {
                    b.Property<Guid>("OrderId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("OrderId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("ClientOrder.Domain.Product", b =>
                {
                    b.Property<Guid>("ProductId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<Guid?>("OrderId");

                    b.Property<int>("Price");

                    b.HasKey("ProductId");

                    b.HasIndex("OrderId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ClientOrder.Domain.ClientAddress", b =>
                {
                    b.HasOne("ClientOrder.Domain.Address", "Address")
                        .WithMany("Client")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ClientOrder.Domain.Client", "Client")
                        .WithMany("Address")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ClientOrder.Domain.Product", b =>
                {
                    b.HasOne("ClientOrder.Domain.Order")
                        .WithMany("Products")
                        .HasForeignKey("OrderId");
                });
#pragma warning restore 612, 618
        }
    }
}
