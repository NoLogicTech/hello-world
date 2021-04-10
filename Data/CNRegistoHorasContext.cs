using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CNRegistoHorasMVC.Models
{
    public partial class CNRegistoHorasContext : DbContext
    {
        public CNRegistoHorasContext()
        {
        }

        public CNRegistoHorasContext(DbContextOptions<CNRegistoHorasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Centrodecusto> Centrodecusto { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Colaborador> Colaborador { get; set; }
        public virtual DbSet<Papel> Papel { get; set; }
        public virtual DbSet<Servico> Servico { get; set; }
        public virtual DbSet<Tiposervico> Tiposervico { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=172.31.55.155;Initial Catalog=CNRegistoHoras;Persist Security Info=True;User ID=sa;Password=SqlCascata@1;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Centrodecusto>(entity =>
            {
                entity.ToTable("centrodecusto");

                entity.Property(e => e.CentrodecustoId).HasColumnName("centrodecustoId");

                entity.Property(e => e.CentrodecustoNome)
                    .IsRequired()
                    .HasColumnName("centrodecustoNome")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("cliente");

                entity.Property(e => e.ClienteId)
                    .HasColumnName("clienteId")
                    .ValueGeneratedNever();

                entity.Property(e => e.ClienteAbreviatura)
                    .HasColumnName("clienteAbreviatura")
                    .HasMaxLength(10);

                entity.Property(e => e.ClienteDescricao)
                    .HasColumnName("clienteDescricao")
                    .HasColumnType("text");

                entity.Property(e => e.ClienteEmail)
                    .HasColumnName("clienteEmail")
                    .HasMaxLength(50);

                entity.Property(e => e.ClienteErpid).HasColumnName("clienteErpid");

                entity.Property(e => e.ClienteNome)
                    .IsRequired()
                    .HasColumnName("clienteNome")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Colaborador>(entity =>
            {
                entity.ToTable("colaborador");

                entity.Property(e => e.ColaboradorId).HasColumnName("colaboradorId");

                entity.Property(e => e.ColaboradorAlcunha)
                    .IsRequired()
                    .HasColumnName("colaboradorAlcunha")
                    .HasMaxLength(50);

                entity.Property(e => e.ColaboradorApelido)
                    .HasColumnName("colaboradorApelido")
                    .HasMaxLength(50);

                entity.Property(e => e.ColaboradorEmail)
                    .IsRequired()
                    .HasColumnName("colaboradorEMail")
                    .HasMaxLength(50);

                entity.Property(e => e.ColaboradorEstado).HasColumnName("colaboradorEstado");

                entity.Property(e => e.ColaboradorNif).HasColumnName("colaboradorNif");

                entity.Property(e => e.ColaboradorNome)
                    .HasColumnName("colaboradorNome")
                    .HasMaxLength(50);

                entity.Property(e => e.ColaboradorNomedeutilizador)
                    .IsRequired()
                    .HasColumnName("colaboradorNomedeutilizador")
                    .HasMaxLength(50);

                entity.Property(e => e.ColaboradorSenha)
                    .IsRequired()
                    .HasColumnName("colaboradorSenha")
                    .HasMaxLength(50);

                entity.Property(e => e.PapelId).HasColumnName("papel_Id");

                entity.HasOne(d => d.Papel)
                    .WithMany(p => p.Colaborador)
                    .HasForeignKey(d => d.PapelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_colaborador_papel");
            });

            modelBuilder.Entity<Papel>(entity =>
            {
                entity.ToTable("papel");

                entity.Property(e => e.PapelId).HasColumnName("papelId");

                entity.Property(e => e.PapelNome)
                    .HasColumnName("papelNome")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Servico>(entity =>
            {
                entity.ToTable("servico");

                entity.Property(e => e.ServicoId).HasColumnName("servicoId");

                entity.Property(e => e.ClienteId).HasColumnName("cliente_Id");

                entity.Property(e => e.ColaboradorId).HasColumnName("colaborador_Id");

                entity.Property(e => e.ServicoDataregisto)
                    .IsRequired()
                    .HasColumnName("servicoDataregisto")
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.ServicoDataservico)
                    .HasColumnName("servicoDataservico")
                    .HasColumnType("date");

                entity.Property(e => e.ServicoDescricao)
                    .IsRequired()
                    .HasColumnName("servicoDescricao")
                    .HasColumnType("text");

                entity.Property(e => e.ServicoHoras).HasColumnName("servicoHoras");

                entity.Property(e => e.TiposervicoId).HasColumnName("tiposervico_Id");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Servico)
                    .HasForeignKey(d => d.ClienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_servico_cliente");

                entity.HasOne(d => d.Colaborador)
                    .WithMany(p => p.Servico)
                    .HasForeignKey(d => d.ColaboradorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_servico_colaborador");

                entity.HasOne(d => d.Tiposervico)
                    .WithMany(p => p.Servico)
                    .HasForeignKey(d => d.TiposervicoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_servico_tiposervico");
            });

            modelBuilder.Entity<Tiposervico>(entity =>
            {
                entity.ToTable("tiposervico");

                entity.Property(e => e.TiposervicoId).HasColumnName("tiposervicoId");

                entity.Property(e => e.CentrodecustoId).HasColumnName("centrodecusto_Id");

                entity.Property(e => e.TiposervicoCategoria)
                    .IsRequired()
                    .HasColumnName("tiposervicoCategoria")
                    .HasMaxLength(50);

                entity.Property(e => e.TiposervicoNome)
                    .IsRequired()
                    .HasColumnName("tiposervicoNome")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Centrodecusto)
                    .WithMany(p => p.Tiposervico)
                    .HasForeignKey(d => d.CentrodecustoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tiposervico_centrodecusto");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
