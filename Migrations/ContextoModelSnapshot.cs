﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MissingPet.Models;

#nullable disable

namespace MissingPet.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MissingPet.Models.Animal", b =>
                {
                    b.Property<int>("AnimalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("AnimalId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AnimalId"));

                    b.Property<string>("AnimalCor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("AnimalCor");

                    b.Property<DateTime>("AnimalDtDesaparecimento")
                        .HasColumnType("datetime2")
                        .HasColumnName("AnimalDtDesaparecimento");

                    b.Property<DateTime?>("AnimalDtEncontro")
                        .HasColumnType("datetime2")
                        .HasColumnName("AnimalDtEncontro");

                    b.Property<string>("AnimalFoto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("AnimalFoto");

                    b.Property<string>("AnimalNome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("AnimalNome");

                    b.Property<string>("AnimalObservacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("AnimalObservacao");

                    b.Property<string>("AnimalRaca")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("AnimalRaca");

                    b.Property<string>("AnimalSexo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("AnimalSexo");

                    b.Property<byte>("AnimalStatus")
                        .HasColumnType("tinyint")
                        .HasColumnName("AnimalStatus");

                    b.Property<string>("AnimalTipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("AnimalTipo");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("AnimalId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Animal");
                });

            modelBuilder.Entity("MissingPet.Models.Observacao", b =>
                {
                    b.Property<int>("ObservacaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ObservacaoId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ObservacaoId"));

                    b.Property<int>("AnimalId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ObservacaoData")
                        .HasColumnType("datetime2")
                        .HasColumnName("ObservacaoData");

                    b.Property<string>("ObservacaoDescricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ObservacaoDescricao");

                    b.Property<string>("ObservacaoLocal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ObservacaoLocal");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("ObservacaoId");

                    b.HasIndex("AnimalId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Observacao");
                });

            modelBuilder.Entity("MissingPet.Models.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("UsuarioId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UsuarioId"));

                    b.Property<string>("UsuarioEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("UsuarioEmail");

                    b.Property<string>("UsuarioNome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("UsuarioNome");

                    b.Property<string>("UsuarioSenha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("UsuarioSenha");

                    b.Property<string>("UsuarioTelefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("UsuarioTelefone");

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("MissingPet.Models.Animal", b =>
                {
                    b.HasOne("MissingPet.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("MissingPet.Models.Observacao", b =>
                {
                    b.HasOne("MissingPet.Models.Animal", "Animal")
                        .WithMany()
                        .HasForeignKey("AnimalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MissingPet.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Animal");

                    b.Navigation("Usuario");
                });
#pragma warning restore 612, 618
        }
    }
}
