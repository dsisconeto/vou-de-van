﻿// <auto-generated />

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Business.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20190814000309_CreateTransportationCompanies")]
    partial class CreateTransportationCompanies
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VouDeVan.Core.Business.Domains.Geo.City", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<Guid>("StateId");

                    b.Property<DateTime>("UpdateAt");

                    b.HasKey("Id");

                    b.HasIndex("StateId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("VouDeVan.Core.Business.Domains.Geo.State", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Initials")
                        .IsRequired()
                        .HasMaxLength(2);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("UpdateAt");

                    b.HasKey("Id");

                    b.ToTable("States");
                });

            modelBuilder.Entity("VouDeVan.Core.Business.Domains.TransportationCompanies.TransportationCompany", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(400);

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasMaxLength(14);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("FantasyName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Logo");

                    b.Property<string>("Observation")
                        .HasColumnType("text")
                        .HasMaxLength(1000);

                    b.Property<string>("RepresentativeName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("RepresentativePhone")
                        .IsRequired()
                        .HasMaxLength(11);

                    b.Property<string>("SocialName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("Status")
                        .HasMaxLength(40);

                    b.Property<DateTime>("UpdateAt");

                    b.HasKey("Id");

                    b.ToTable("TransportationCompanies");
                });

            modelBuilder.Entity("VouDeVan.Core.Business.Domains.Geo.City", b =>
                {
                    b.HasOne("VouDeVan.Core.Business.Domains.Geo.State", "State")
                        .WithMany()
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}