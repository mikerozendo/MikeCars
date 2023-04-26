using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MikeCars.Infraestructure.Repository.Models;
using System.Data.Common;

namespace MikeCars.Infraestructure.Repository.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        ChangeTracker.AutoDetectChangesEnabled = false;
    }

    public AppDbContext()
    {
        ChangeTracker.AutoDetectChangesEnabled = false;
    }

    public DbSet<PessoaFisicaModel> Pessoas { get; set; }
    //public DbSet<RepresentanteModel> Representantes { get; set; }
    public DbSet<AgenteModel> Agentes { get; set; }
    //public DbSet<PessoaJuridicaModel> Empresas { get; set; }
    public DbSet<DocumentoModel> Documentos { get; set; }
    public DbSet<EnderecoModel> Enderecos { get; set; }
    public DbSet<ContatoInfoModel> ContatoInfo { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer("Server=localhost,1433;Initial Catalog=MikeCars;User ID=sa;Password=123@Mudar;TrustServerCertificate=True",
            b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

        #region AgenteModel

        modelBuilder.Entity<AgenteModel>()
            .ToTable("Agente");

        modelBuilder.Entity<AgenteModel>()
            .HasKey(x => x.AgenteModelId)
            .HasName("pkAgente");

        modelBuilder.Entity<AgenteModel>()
            .Property(x => x.AgenteModelId)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<AgenteModel>()
            .HasIndex(x => x.AgenteModelId)
            .HasDatabaseName("idxAgente");

        modelBuilder.Entity<AgenteModel>()
            .Property(x => x.IdTipoAgente)
            .HasColumnName("IdTipoAgente")
            .IsRequired();

        modelBuilder.Entity<AgenteModel>()
            .Property(x => x.IdContatoinfoModel)
            .HasColumnName("IdContatoInfo");

        modelBuilder.Entity<AgenteModel>()
            .Property(x => x.IdDocumentoModel)
            .HasColumnName("IdDocumento");

        modelBuilder.Entity<AgenteModel>()
            .Property(x => x.IdEnderecoModel)
            .HasColumnName("IdEndereco");

        modelBuilder.Entity<AgenteModel>()
            .Property(x => x.IdPessoaFisicaModel)
            .HasColumnType("int")
            .IsRequired(false);

        modelBuilder.Entity<AgenteModel>()
            .HasOne(x => x.DocumentoModel)
            .WithOne(x => x.AgenteModel)
            .HasForeignKey<AgenteModel>(x => x.IdDocumentoModel)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<AgenteModel>()
            .HasOne(x => x.EnderecoModel)
            .WithOne(x => x.AgenteModel)
            .HasForeignKey<AgenteModel>(x => x.IdEnderecoModel)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<AgenteModel>()
            .HasOne(x => x.ContatoInfoModel)
            .WithOne(x => x.AgenteModel)
            .HasForeignKey<AgenteModel>(x => x.IdContatoinfoModel)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<AgenteModel>()
            .HasOne(x => x.PessoaFisicaModel)
            .WithOne(x => x.AgenteModel)
            .HasForeignKey<AgenteModel>(x => x.IdPessoaFisicaModel)
            .OnDelete(DeleteBehavior.Cascade);

        //modelBuilder.Entity<AgenteModel>()
        //    .HasOne(x => x.PessoaJuridicaModel)
        //    .WithOne(x => x.AgenteModel)
        //    .HasForeignKey<PessoaJuridicaModel>(x => x.PessoaJuridicaModelId)
        //    .OnDelete(DeleteBehavior.Cascade);
        #endregion

        #region PessoaFisicaModel

        modelBuilder.Entity<PessoaFisicaModel>()
            .ToTable("PessoaFisica");

        modelBuilder.Entity<PessoaFisicaModel>()
            .HasKey(x => x.PessoaFisicaModelId)
            .HasName("IdPessoa");

        modelBuilder.Entity<PessoaFisicaModel>()
            .Property(x => x.PessoaFisicaModelId)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<PessoaFisicaModel>()
            .HasIndex(x => x.PessoaFisicaModelId)
            .HasDatabaseName("idxpessoafisica");

        modelBuilder.Entity<PessoaFisicaModel>()
            .Property(x => x.Nascimento)
            .HasColumnType("datetime")
            .HasColumnName("Nascimento")
            .IsRequired();

        modelBuilder.Entity<PessoaFisicaModel>()
            .Property(x => x.Nome)
            .HasColumnType("varchar")
            .HasMaxLength(100)
            .HasColumnName("Nome")
            .IsRequired();

        modelBuilder.Entity<PessoaFisicaModel>()
            .Property(x => x.Sobrenome)
            .HasColumnType("varchar")
            .HasMaxLength(300)
            .HasColumnName("Sobrenome")
            .IsRequired();

        modelBuilder.Entity<PessoaFisicaModel>()
            .HasOne(x => x.AgenteModel)
            .WithOne(x => x.PessoaFisicaModel)
            .HasForeignKey<PessoaFisicaModel>(x => x.IdAgenteModel)
            .OnDelete(DeleteBehavior.Cascade);

        #endregion

        #region DocumentoModel

        modelBuilder.Entity<DocumentoModel>()
            .ToTable("Documento");

        modelBuilder.Entity<DocumentoModel>()
            .HasKey(x => x.DocumentoModelId)
            .HasName("PkDocumento");

        modelBuilder.Entity<DocumentoModel>()
            .HasIndex(x => x.DocumentoModelId)
            .HasDatabaseName("idxiddocumento");

        modelBuilder.Entity<DocumentoModel>()
            .Property(x => x.DocumentoModelId)
            .HasColumnName("Id");

        modelBuilder.Entity<DocumentoModel>()
            .HasIndex(x => x.Numero)
            .HasDatabaseName("idxnumerodocumento");

        modelBuilder.Entity<DocumentoModel>()
            .Property(x => x.IdTipoDocumento)
            .HasColumnType("int")
            .HasColumnName("IdTipoDocumento")
            .IsRequired();

        modelBuilder.Entity<DocumentoModel>()
            .Property(x => x.Numero)
            .HasColumnType("varchar")
            .HasMaxLength(15)
            .HasColumnName("Numero")
            .IsRequired();

        modelBuilder.Entity<DocumentoModel>()
            .Property(x => x.IdAgente)
            .HasColumnType("int")
            .HasColumnName("IdAgente");

        modelBuilder.Entity<DocumentoModel>()
            .HasOne(x => x.AgenteModel)
            .WithOne(x => x.DocumentoModel)
            .HasForeignKey<DocumentoModel>(x => x.IdAgente)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

        #endregion

        #region EnderecoModel
        modelBuilder.Entity<EnderecoModel>()
            .ToTable("Endereco");

        modelBuilder.Entity<EnderecoModel>()
            .HasKey(x => x.EnderecoModelId)
            .HasName("pkendereco");

        modelBuilder.Entity<EnderecoModel>()
            .Property(x => x.EnderecoModelId)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<EnderecoModel>()
            .Property(x => x.Logradouro)
            .HasColumnType("varchar")
            .HasMaxLength(150)
            .HasColumnName("Logradouro")
            .IsRequired(false);

        modelBuilder.Entity<EnderecoModel>()
            .Property(x => x.Bairro)
            .HasColumnType("varchar")
            .HasColumnName("Bairro")
            .HasMaxLength(150)
            .IsRequired(false);

        modelBuilder.Entity<EnderecoModel>()
            .Property(x => x.Cidade)
            .HasColumnType("varchar")
            .HasColumnName("Cidade")
            .HasMaxLength(150)
            .IsRequired(false);

        modelBuilder.Entity<EnderecoModel>()
            .Property(x => x.IdTipoEndereco)
            .HasColumnType("int")
            .HasColumnName("IdTipoEndereco");

        modelBuilder.Entity<EnderecoModel>()
            .Property(x => x.Numero)
            .HasColumnType("varchar")
            .HasMaxLength(20)
            .HasColumnName("Numero")
            .IsRequired(false);

        modelBuilder.Entity<EnderecoModel>()
            .Property(x => x.PontoReferencia)
            .HasColumnType("varchar")
            .HasColumnName("PontoReferencia")
            .HasMaxLength(225)
            .IsRequired(false);

        modelBuilder.Entity<EnderecoModel>()
            .Property(x => x.Uf)
            .HasColumnType("varchar")
            .HasColumnName("Uf")
            .HasMaxLength(2)
            .IsRequired(false);

        modelBuilder.Entity<EnderecoModel>()
            .HasOne(x => x.AgenteModel)
            .WithOne(x => x.EnderecoModel)
            .HasForeignKey<EnderecoModel>(x => x.IdAgente)
            .OnDelete(DeleteBehavior.Cascade);
        #endregion

        #region ContatoInfoModel

        modelBuilder.Entity<ContatoInfoModel>()
            .ToTable("ContatoInfo");

        modelBuilder.Entity<ContatoInfoModel>()
            .HasKey(x => x.ContatoInfoModelId)
            .HasName("PkContatoInfo");

        modelBuilder.Entity<ContatoInfoModel>()
            .Property(x => x.ContatoInfoModelId)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<ContatoInfoModel>()
            .Property(x => x.Email)
            .HasColumnType("varchar")
            .HasColumnName("Email")
            .HasMaxLength(25)
            .IsRequired(false);

        modelBuilder.Entity<ContatoInfoModel>()
            .Property(x => x.TelefoneCelular)
            .HasColumnType("varchar")
            .HasColumnName("Celular")
            .HasMaxLength(20)
            .IsRequired(false);

        modelBuilder.Entity<ContatoInfoModel>()
            .Property(x => x.TelefoneResidencial)
            .HasColumnType("varchar")
            .HasColumnName("TelefoneResidencial")
            .HasMaxLength(20)
            .IsRequired(false);

        modelBuilder.Entity<ContatoInfoModel>()
            .HasOne(x => x.AgenteModel)
            .WithOne(x => x.ContatoInfoModel)
            .HasForeignKey<ContatoInfoModel>(x => x.IdAgente)
            .OnDelete(DeleteBehavior.Cascade);
        #endregion

        #region PessoaJuridicaModel

        //modelBuilder.Entity<PessoaJuridicaModel>()
        //    .HasKey(x => x.Id)
        //    .HasName("pkpessoajuridica");

        //modelBuilder.Entity<PessoaJuridicaModel>()
        //    .Property(x => x.Id)
        //    .HasColumnType("int")
        //    .HasColumnName("Id")
        //    .ValueGeneratedOnAdd();

        //modelBuilder.Entity<PessoaJuridicaModel>()
        //    .Property(x => x.Abertura)
        //    .HasColumnType("datetime")
        //    .HasColumnName("abertura")
        //    .IsRequired();

        //modelBuilder.Entity<PessoaJuridicaModel>()
        //    .Property(x => x.RazaoSocial)
        //    .HasColumnType("varchar")
        //    .HasColumnName("razaosocial")
        //    .HasMaxLength(225)
        //    .IsRequired();

        //modelBuilder.Entity<PessoaJuridicaModel>()
        //    .Property(x => x.NomeFantasia)
        //    .HasColumnType("varchar")
        //    .HasColumnName("nomefantasia")
        //    .HasMaxLength(225)
        //    .IsRequired();

        //modelBuilder.Entity<PessoaJuridicaModel>()
        //    .HasOne(x => x.AgenteModel)
        //    .WithOne()
        //    .HasForeignKey<AgenteModel>(x => x.Id)
        //    .OnDelete(DeleteBehavior.Cascade);

        //modelBuilder.Entity<PessoaJuridicaModel>()
        //    .HasOne(x => x.RepresentanteModel)
        //    .WithOne(x => x.PessoaJuridicaModel)
        //    .HasForeignKey<RepresentanteModel>(x => x.Id)
        //    .OnDelete(DeleteBehavior.Cascade);

        #endregion

        #region RepresentanteModel

        //modelBuilder.Entity<RepresentanteModel>()
        //    .ToTable("trepresentante");

        //modelBuilder.Entity<RepresentanteModel>()
        //    .HasKey(x => x.Id)
        //    .HasName("pkrepresentante");

        //modelBuilder.Entity<RepresentanteModel>()
        //    .HasIndex(x => x.Id)
        //    .HasDatabaseName("idxrepresentante")
        //    .IsUnique();

        //modelBuilder.Entity<RepresentanteModel>()
        //    .HasIndex(x => x.PessoaJuridicaModelId)
        //    .HasDatabaseName("idxrepresentantepessoajuridicaid");

        //modelBuilder.Entity<RepresentanteModel>()
        //    .HasIndex(x => x.PessoaFisicaModelId)
        //    .HasDatabaseName("idxrepresentantepessoafisicaid");

        //modelBuilder.Entity<RepresentanteModel>()
        //    .Property(x => x.Id)
        //    .HasColumnName("Id")
        //    .ValueGeneratedOnAdd();

        //modelBuilder.Entity<RepresentanteModel>()
        //    .Property(x => x.PessoaFisicaModelId)
        //    .HasColumnName("idpessoafisica")
        //    .ValueGeneratedOnAdd();

        //modelBuilder.Entity<RepresentanteModel>()
        //    .Property(x => x.PessoaJuridicaModelId)
        //    .HasColumnName("idpessoajuridica")
        //    .ValueGeneratedOnAdd();

        //modelBuilder.Entity<RepresentanteModel>()
        //    .HasOne(x => x.PessoaJuridicaModel)
        //    .WithOne(x => x.RepresentanteModel)
        //    .HasForeignKey<RepresentanteModel>(x => x.PessoaJuridicaModel.Id)
        //    .OnDelete(DeleteBehavior.Cascade);

        //modelBuilder.Entity<RepresentanteModel>()
        //    .HasOne(x => x.PessoaFisicaModel)
        //    .WithOne()
        //    .HasForeignKey<RepresentanteModel>(x => x.PessoaFisicaModel.Id)
        //    .OnDelete(DeleteBehavior.Cascade);

        #endregion
    }
}
