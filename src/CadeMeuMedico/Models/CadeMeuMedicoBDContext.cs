using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;

namespace CadeMeuMedico.Models
{
    public partial class CadeMeuMedicoBDContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=CadeMeuMedicoBD;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cidades>(entity =>
            {
                entity.HasKey(e => e.IDCidade);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnType("varchar");
            });

            modelBuilder.Entity<Especialidades>(entity =>
            {
                entity.HasKey(e => e.IDEspecialidade);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasColumnType("varchar");
            });

            modelBuilder.Entity<Medicos>(entity =>
            {
                entity.HasKey(e => e.IDMedico);

                entity.Property(e => e.Bairro)
                    .IsRequired()
                    .HasMaxLength(60)
                    .HasColumnType("varchar");

                entity.Property(e => e.CRM)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnType("varchar");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnType("varchar");

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnType("varchar");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasColumnType("varchar");

                entity.Property(e => e.WebsiteBlog)
                    .HasMaxLength(80)
                    .HasColumnType("varchar");

                entity.HasOne(d => d.IDCidadeNavigation).WithMany(p => p.Medicos).HasForeignKey(d => d.IDCidade).OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.IDEspecialidadeNavigation).WithMany(p => p.Medicos).HasForeignKey(d => d.IDEspecialidade).OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.IDUsuario);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnType("varchar");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnType("varchar");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasColumnType("varchar");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnType("varchar");
            });
        }

        public virtual DbSet<Cidades> Cidades { get; set; }
        public virtual DbSet<Especialidades> Especialidades { get; set; }
        public virtual DbSet<Medicos> Medicos { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
    }
}