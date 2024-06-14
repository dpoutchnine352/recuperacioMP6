﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using dpc.InternetSalesAPI;

#nullable disable

namespace InternetSalesAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240614074753_init8")]
    partial class init8
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("dpc.InternetSalesAPI.CreditCard", b =>
                {
                    b.Property<string>("CardNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CardHolder")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExpirationDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CardNumber");

                    b.ToTable("CreditCards");
                });

            modelBuilder.Entity("dpc.InternetSalesAPI.Customer", b =>
                {
                    b.Property<string>("DNI")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DNI");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("dpc.InternetSalesAPI.CustomerItem", b =>
                {
                    b.Property<string>("ItemCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CustomerDNI")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("ItemCode", "CustomerDNI", "Date");

                    b.HasIndex("CustomerDNI");

                    b.ToTable("CustomerItems");
                });

            modelBuilder.Entity("dpc.InternetSalesAPI.ECommerce", b =>
                {
                    b.Property<int>("ECommerceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ECommerceId"));

                    b.HasKey("ECommerceId");

                    b.ToTable("ECommerces");
                });

            modelBuilder.Entity("dpc.InternetSalesAPI.Item", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Code");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("dpc.InternetSalesAPI.Order", b =>
                {
                    b.Property<int>("OrderNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderNumber"));

                    b.HasKey("OrderNumber");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("dpc.InternetSalesAPI.Shipping", b =>
                {
                    b.Property<int>("ShippingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ShippingId"));

                    b.HasKey("ShippingId");

                    b.ToTable("Shippings");
                });

            modelBuilder.Entity("dpc.InternetSalesAPI.ShoppingCart", b =>
                {
                    b.Property<int>("ShoppingCartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ShoppingCartId"));

                    b.HasKey("ShoppingCartId");

                    b.ToTable("ShoppingCarts");
                });

            modelBuilder.Entity("dpc.InternetSalesAPI.CustomerItem", b =>
                {
                    b.HasOne("dpc.InternetSalesAPI.Customer", "CustomerObj")
                        .WithMany("Items")
                        .HasForeignKey("CustomerDNI")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("dpc.InternetSalesAPI.Item", "ItemObj")
                        .WithMany("Customers")
                        .HasForeignKey("ItemCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CustomerObj");

                    b.Navigation("ItemObj");
                });

            modelBuilder.Entity("dpc.InternetSalesAPI.Customer", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("dpc.InternetSalesAPI.Item", b =>
                {
                    b.Navigation("Customers");
                });
#pragma warning restore 612, 618
        }
    }
}
