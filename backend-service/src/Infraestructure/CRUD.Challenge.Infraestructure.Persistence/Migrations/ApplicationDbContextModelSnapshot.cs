﻿// <auto-generated />
using System;
using CRUD.Challenge.Infraestructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CRUD.Challenge.Infraestructure.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CRUD.Challenge.Core.Domain.Entities.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CityId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CityId");

                    b.ToTable("City", (string)null);
                });

            modelBuilder.Entity("CRUD.Challenge.Core.Domain.Entities.TEDTalk", b =>
                {
                    b.Property<int>("TEDTalkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TEDTalkId"));

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfEvent")
                        .HasColumnType("datetime2");

                    b.Property<string>("Speaker")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("auditoriumName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TEDTalkId");

                    b.HasIndex("CityId");

                    b.ToTable("TEDTalk", (string)null);
                });

            modelBuilder.Entity("CRUD.Challenge.Core.Domain.Entities.TEDTalk", b =>
                {
                    b.HasOne("CRUD.Challenge.Core.Domain.Entities.City", "City")
                        .WithMany("TEDTalks")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("CRUD.Challenge.Core.Domain.Entities.City", b =>
                {
                    b.Navigation("TEDTalks");
                });
#pragma warning restore 612, 618
        }
    }
}
