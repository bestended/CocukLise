﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using coreData.data;

namespace coreData.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BirimlerGorevler", b =>
                {
                    b.Property<int>("birimlerbirimID")
                        .HasColumnType("int");

                    b.Property<int>("gorevID")
                        .HasColumnType("int");

                    b.HasKey("birimlerbirimID", "gorevID");

                    b.HasIndex("gorevID");

                    b.ToTable("BirimlerGorevler");
                });

            modelBuilder.Entity("coreModel.Model.Birimler", b =>
                {
                    b.Property<int>("birimID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("birim")
                        .HasColumnType("int");

                    b.Property<string>("birimAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("birimID");

                    b.ToTable("birims");
                });

            modelBuilder.Entity("coreModel.Model.Cocuklar", b =>
                {
                    b.Property<int>("cocukID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DogumTarih")
                        .HasColumnType("datetime2");

                    b.Property<string>("adSoyad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("calisanID")
                        .HasColumnType("int");

                    b.Property<string>("cinsiyet")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("cocukID");

                    b.HasIndex("calisanID");

                    b.ToTable("cocuks");
                });

            modelBuilder.Entity("coreModel.Model.Gorevler", b =>
                {
                    b.Property<int>("gorevID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("gorevAdi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("gorevTanim")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("puan")
                        .HasColumnType("int");

                    b.HasKey("gorevID");

                    b.ToTable("gorevs");
                });

            modelBuilder.Entity("coreModel.Model.Personeller", b =>
                {
                    b.Property<int>("calisanID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("adSoyad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("calisanCinsiyet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("calisanMaas")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("calisanPrim")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("calisanVardiya")
                        .HasColumnType("bit");

                    b.Property<int>("gorevID")
                        .HasColumnType("int");

                    b.Property<DateTime>("iseBaslamaTarih")
                        .HasColumnType("datetime2");

                    b.Property<int>("unvanID")
                        .HasColumnType("int");

                    b.HasKey("calisanID");

                    b.HasIndex("gorevID");

                    b.HasIndex("unvanID");

                    b.ToTable("calisans");
                });

            modelBuilder.Entity("coreModel.Model.Projeler", b =>
                {
                    b.Property<int>("projeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("gorevID")
                        .HasColumnType("int");

                    b.Property<string>("projeAdi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("projeBaslangicTarih")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("projeBitisTarih")
                        .HasColumnType("datetime2");

                    b.HasKey("projeID");

                    b.HasIndex("gorevID");

                    b.ToTable("projes");
                });

            modelBuilder.Entity("coreModel.Model.Unvanlar", b =>
                {
                    b.Property<int>("unvanID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("unvanAdi")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("unvanID");

                    b.ToTable("unvans");
                });

            modelBuilder.Entity("BirimlerGorevler", b =>
                {
                    b.HasOne("coreModel.Model.Birimler", null)
                        .WithMany()
                        .HasForeignKey("birimlerbirimID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("coreModel.Model.Gorevler", null)
                        .WithMany()
                        .HasForeignKey("gorevID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("coreModel.Model.Cocuklar", b =>
                {
                    b.HasOne("coreModel.Model.Personeller", "calisan")
                        .WithMany()
                        .HasForeignKey("calisanID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("calisan");
                });

            modelBuilder.Entity("coreModel.Model.Personeller", b =>
                {
                    b.HasOne("coreModel.Model.Gorevler", "gorev")
                        .WithMany()
                        .HasForeignKey("gorevID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("coreModel.Model.Unvanlar", "unvan")
                        .WithMany()
                        .HasForeignKey("unvanID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("gorev");

                    b.Navigation("unvan");
                });

            modelBuilder.Entity("coreModel.Model.Projeler", b =>
                {
                    b.HasOne("coreModel.Model.Gorevler", "gorev")
                        .WithMany()
                        .HasForeignKey("gorevID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("gorev");
                });
#pragma warning restore 612, 618
        }
    }
}
