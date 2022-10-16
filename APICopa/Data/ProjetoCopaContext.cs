using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ProjetoCopa.Models;

namespace ProjetoCopa.Data
{
    public partial class ProjetoCopaContext : DbContext
    {
        public ProjetoCopaContext()
        {
        }

        public ProjetoCopaContext(DbContextOptions<ProjetoCopaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; } = null!;
        public virtual DbSet<Clube> Clubes { get; set; } = null!;
        public virtual DbSet<FaseCampeonato> FaseCampeonatos { get; set; } = null!;
        public virtual DbSet<Jogo> Jogos { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.IdAdmin)
                    .HasName("PRIMARY");

                entity.ToTable("admin");

                entity.Property(e => e.IdAdmin).HasColumnName("id_admin");

                entity.Property(e => e.Email)
                    .HasMaxLength(55)
                    .HasColumnName("email");

                entity.Property(e => e.Senha)
                    .HasMaxLength(70)
                    .HasColumnName("senha");
            });

            modelBuilder.Entity<Clube>(entity =>
            {
                entity.HasKey(e => e.IdClube)
                    .HasName("PRIMARY");

                entity.ToTable("clube");

                entity.Property(e => e.IdClube).HasColumnName("id_clube");

                entity.Property(e => e.Nome)
                    .HasMaxLength(45)
                    .HasColumnName("nome");

                entity.Property(e => e.UrlFoto)
                    .HasMaxLength(255)
                    .HasColumnName("url_foto");
            });

            modelBuilder.Entity<FaseCampeonato>(entity =>
            {
                entity.HasKey(e => e.IdFase)
                    .HasName("PRIMARY");

                entity.ToTable("fase_campeonato");

                entity.Property(e => e.IdFase).HasColumnName("id_fase");

                entity.Property(e => e.Nome)
                    .HasMaxLength(45)
                    .HasColumnName("nome");
            });

            modelBuilder.Entity<Jogo>(entity =>
            {
                entity.HasKey(e => e.IdJogo)
                    .HasName("PRIMARY");

                entity.ToTable("jogo");

                entity.HasIndex(e => e.ClubeB, "clube_b_idx");

                entity.HasIndex(e => e.ClubeA, "fk_Jogo_Clube1_idx");

                entity.HasIndex(e => e.IdFase, "fk_Jogo_Fase_Campeonato_idx");

                entity.Property(e => e.IdJogo).HasColumnName("id_jogo");

                entity.Property(e => e.ClubeA).HasColumnName("clube_a");

                entity.Property(e => e.ClubeB).HasColumnName("clube_b");

                entity.Property(e => e.GolsClubeA).HasColumnName("gols_clube_a");

                entity.Property(e => e.GolsClubeB).HasColumnName("gols_clube_b");

                entity.Property(e => e.IdFase).HasColumnName("id_fase");

                entity.Property(e => e.JogoFinalizado)
                    .HasColumnType("datetime")
                    .HasColumnName("jogo_finalizado");

                entity.Property(e => e.JogoIniciado)
                    .HasColumnType("datetime")
                    .HasColumnName("jogo_iniciado");

                entity.Property(e => e.TempoAtual)
                    .HasColumnType("datetime")
                    .HasColumnName("tempo_atual");

                entity.HasOne(d => d.ClubeANavigation)
                    .WithMany(p => p.JogoClubeANavigations)
                    .HasForeignKey(d => d.ClubeA)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("clube_a");

                entity.HasOne(d => d.ClubeBNavigation)
                    .WithMany(p => p.JogoClubeBNavigations)
                    .HasForeignKey(d => d.ClubeB)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("clube_b");

                entity.HasOne(d => d.IdFaseNavigation)
                    .WithMany(p => p.Jogos)
                    .HasForeignKey(d => d.IdFase)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Jogo_Fase_Campeonato");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
