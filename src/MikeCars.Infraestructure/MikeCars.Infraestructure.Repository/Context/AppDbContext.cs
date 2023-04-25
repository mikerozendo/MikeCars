using Microsoft.EntityFrameworkCore;
using MikeCars.Infraestructure.Repository.Models;

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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

        #region AgenteModel
        modelBuilder.Entity<AgenteModel>()
            .ToTable("[t-agente]");

        modelBuilder.Entity<AgenteModel>()
            .HasKey(x => x.AgenteModeId)
            .HasName("[pk-agente]");

        modelBuilder.Entity<AgenteModel>()
            .Property(x => x.AgenteModeId)
            .HasColumnName("[id]")
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<AgenteModel>()
            .HasIndex(x => x.AgenteModeId)
            .HasDatabaseName("[idx-agente]");

        modelBuilder.Entity<AgenteModel>()
            .Property(x => x.IdTipoAgente)
            .HasColumnType("int")
            .HasColumnName("[id-tipo-agente]")
            .IsRequired();

        modelBuilder.Entity<AgenteModel>()
            .Property(x => x.IdContatoInfoModel)
            .HasColumnType("int")
            .HasColumnName("[id-contato-info]");

        modelBuilder.Entity<AgenteModel>()
            .Property(x => x.IdDocumentoModel)
            .HasColumnType("int")
            .HasColumnName("[id-documento]");

        modelBuilder.Entity<AgenteModel>()
            .Property(x => x.IdEnderecoModel)
            .HasColumnType("int")
            .HasColumnName("[id-endereco]");

        modelBuilder.Entity<AgenteModel>()
            .HasOne(x => x.DocumentoModel)
            .WithOne(x => x.AgenteModel)
            .HasForeignKey<DocumentoModel>(x => x.DocumentoModelId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<AgenteModel>()
            .HasOne(x => x.EnderecoModel)
            .WithOne(x => x.AgenteModel)
            .HasForeignKey<EnderecoModel>(x => x.EnderecoModelId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<AgenteModel>()
            .HasOne(x => x.ContatoInfoModel)
            .WithOne(x => x.AgenteModel)
            .HasForeignKey<ContatoInfoModel>(x => x.ContatoInfoModelId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<AgenteModel>()
            .HasOne(x => x.PessoaFisicaModel)
            .WithOne(x => x.AgenteModel)
            .HasForeignKey<PessoaFisicaModel>(x => x.PessoaFisicaModelId)
            .OnDelete(DeleteBehavior.Cascade);

        //modelBuilder.Entity<AgenteModel>()
        //    .HasOne(x => x.PessoaJuridicaModel)
        //    .WithOne(x => x.AgenteModel)
        //    .HasForeignKey<PessoaJuridicaModel>(x => x.PessoaJuridicaModelId)
        //    .OnDelete(DeleteBehavior.Cascade);
        #endregion

        #region PessoaFisicaModel

        modelBuilder.Entity<PessoaFisicaModel>()
            .ToTable("[t-pessoa-fisica]");

        modelBuilder.Entity<PessoaFisicaModel>()
            .HasKey(x => x.PessoaFisicaModelId)
            .HasName("[id-pessoa]");

        modelBuilder.Entity<PessoaFisicaModel>()
            .Property(x => x.PessoaFisicaModelId)
            .HasColumnName("[id]")
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<PessoaFisicaModel>()
            .HasIndex(x => x.PessoaFisicaModelId)
            .HasDatabaseName("[dx-pessoa-fisica]");

        modelBuilder.Entity<PessoaFisicaModel>()
            .Property(x => x.Nascimento)
            .HasColumnType("datetime")
            .HasColumnName("[nascimento]")
            .IsRequired();

        modelBuilder.Entity<PessoaFisicaModel>()
            .Property(x => x.Nome)
            .HasColumnType("varchar")
            .HasMaxLength(300)
        .HasColumnName("[nome]")
            .IsRequired();

        modelBuilder.Entity<PessoaFisicaModel>()
            .HasOne(x => x.AgenteModel)
            .WithOne(x => x.PessoaFisicaModel)
            .HasForeignKey<AgenteModel>(x => x.AgenteModeId)
            .OnDelete(DeleteBehavior.Cascade);

        #endregion

        #region DocumentoModel

        modelBuilder.Entity<DocumentoModel>()
            .ToTable("[t-documento]");

        modelBuilder.Entity<DocumentoModel>()
            .HasKey(x => x.DocumentoModelId)
            .HasName("[pk-documento]");

        modelBuilder.Entity<DocumentoModel>()
            .HasIndex(x => x.DocumentoModelId)
            .HasDatabaseName("[idx-id-documento]");

        modelBuilder.Entity<DocumentoModel>()
            .Property(x => x.DocumentoModelId)
            .HasColumnName("[id]");

        modelBuilder.Entity<DocumentoModel>()
            .HasIndex(x => x.Numero)
            .HasDatabaseName("[idx-numero-documento]");

        modelBuilder.Entity<DocumentoModel>()
            .Property(x => x.IdTipoDocumento)
            .HasColumnType("int")
            .HasColumnName("[id-tipo-documento]")
            .IsRequired();

        modelBuilder.Entity<DocumentoModel>()
            .Property(x => x.Numero)
            .HasColumnType("varchar")
            .HasMaxLength(15)
            .HasColumnName("documento")
            .IsRequired();

        modelBuilder.Entity<DocumentoModel>()
            .Property(x => x.IdAgente)
            .HasColumnType("int")
            .HasColumnName("[id-agente]");

        modelBuilder.Entity<DocumentoModel>()
            .HasOne(x => x.AgenteModel)
            .WithOne(x => x.DocumentoModel)
            .HasForeignKey<AgenteModel>(x => x.AgenteModeId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

        #endregion

        #region EnderecoModel
        modelBuilder.Entity<EnderecoModel>()
            .ToTable("[t-endereco]");

        modelBuilder.Entity<EnderecoModel>()
            .HasKey(x => x.EnderecoModelId)
            .HasName("[pk-endereco]");

        modelBuilder.Entity<EnderecoModel>()
            .Property(x => x.EnderecoModelId)
            .HasColumnName("[id]")
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<EnderecoModel>()
            .Property(x => x.Logradouro)
            .HasColumnType("varchar")
            .HasColumnName("[logradouro]")
            .IsRequired(false);

        modelBuilder.Entity<EnderecoModel>()
            .Property(x => x.Bairro)
            .HasColumnType("varchar")
            .HasColumnName("[bairro]")
            .HasMaxLength(45)
            .IsRequired(false);

        modelBuilder.Entity<EnderecoModel>()
            .Property(x => x.Cidade)
            .HasColumnType("varchar")
            .HasColumnName("[cidade]")
            .HasMaxLength(150)
            .IsRequired(false);

        modelBuilder.Entity<EnderecoModel>()
            .Property(x => x.IdTipoEndereco)
            .HasColumnType("int")
            .HasColumnName("[id-tipo-endereco]");

        modelBuilder.Entity<EnderecoModel>()
            .Property(x => x.Numero)
            .HasColumnType("varchar")
            .HasColumnName("[numero]")
            .HasMaxLength(10)
            .IsRequired(false);

        modelBuilder.Entity<EnderecoModel>()
            .Property(x => x.PontoReferencia)
            .HasColumnType("varchar")
            .HasColumnName("[ponto-referencia]")
            .HasMaxLength(225)
            .IsRequired(false);

        modelBuilder.Entity<EnderecoModel>()
            .Property(x => x.Uf)
            .HasColumnType("varchar")
            .HasColumnName("[uf]")
            .HasMaxLength(2)
            .IsRequired(false);

        modelBuilder.Entity<EnderecoModel>()
            .HasOne(x => x.AgenteModel)
            .WithOne(x => x.EnderecoModel)
            .HasForeignKey<AgenteModel>(x => x.AgenteModeId)
            .OnDelete(DeleteBehavior.Cascade);
        #endregion

        #region ContatoInfoModel

        modelBuilder.Entity<ContatoInfoModel>()
            .ToTable("[t-contato-info]");

        modelBuilder.Entity<ContatoInfoModel>()
            .HasKey(x => x.ContatoInfoModelId)
            .HasName("[pk-contato-info]");

        modelBuilder.Entity<ContatoInfoModel>()
            .Property(x => x.ContatoInfoModelId)
            .HasColumnName("[id]")
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<ContatoInfoModel>()
            .Property(x => x.Email)
            .HasColumnType("varchar")
            .HasColumnName("[email]")
            .HasMaxLength(25)
            .IsRequired(false);

        modelBuilder.Entity<ContatoInfoModel>()
            .Property(x => x.TelefoneCelular)
            .HasColumnType("varchar")
            .HasColumnName("[celular]")
            .HasMaxLength(20)
            .IsRequired(false);

        modelBuilder.Entity<ContatoInfoModel>()
            .Property(x => x.TelefoneResidencial)
            .HasColumnType("varchar")
            .HasColumnName("[telefone-residencia]")
            .HasMaxLength(20)
            .IsRequired(false);

        modelBuilder.Entity<ContatoInfoModel>()
            .HasOne(x => x.AgenteModel)
            .WithOne(x => x.ContatoInfoModel)
            .HasForeignKey<AgenteModel>(x => x.AgenteModeId)
            .OnDelete(DeleteBehavior.Cascade);
        #endregion

        #region PessoaJuridicaModel

        //modelBuilder.Entity<PessoaJuridicaModel>()
        //    .HasKey(x => x.Id)
        //    .HasName("[pk-pessoa-juridica]");

        //modelBuilder.Entity<PessoaJuridicaModel>()
        //    .Property(x => x.Id)
        //    .HasColumnType("int")
        //    .HasColumnName("[id]")
        //    .ValueGeneratedOnAdd();

        //modelBuilder.Entity<PessoaJuridicaModel>()
        //    .Property(x => x.Abertura)
        //    .HasColumnType("datetime")
        //    .HasColumnName("[abertura]")
        //    .IsRequired();

        //modelBuilder.Entity<PessoaJuridicaModel>()
        //    .Property(x => x.RazaoSocial)
        //    .HasColumnType("varchar")
        //    .HasColumnName("[razao-social]")
        //    .HasMaxLength(225)
        //    .IsRequired();

        //modelBuilder.Entity<PessoaJuridicaModel>()
        //    .Property(x => x.NomeFantasia)
        //    .HasColumnType("varchar")
        //    .HasColumnName("[nome-fantasia]")
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
        //    .ToTable("t-representante");

        //modelBuilder.Entity<RepresentanteModel>()
        //    .HasKey(x => x.Id)
        //    .HasName("pk-representante");

        //modelBuilder.Entity<RepresentanteModel>()
        //    .HasIndex(x => x.Id)
        //    .HasDatabaseName("idx-representante")
        //    .IsUnique();

        //modelBuilder.Entity<RepresentanteModel>()
        //    .HasIndex(x => x.PessoaJuridicaModelId)
        //    .HasDatabaseName("idx-representante-pessoa-juridica-id");

        //modelBuilder.Entity<RepresentanteModel>()
        //    .HasIndex(x => x.PessoaFisicaModelId)
        //    .HasDatabaseName("idx-representante-pessoa-fisica-id");

        //modelBuilder.Entity<RepresentanteModel>()
        //    .Property(x => x.Id)
        //    .HasColumnName("id")
        //    .ValueGeneratedOnAdd();

        //modelBuilder.Entity<RepresentanteModel>()
        //    .Property(x => x.PessoaFisicaModelId)
        //    .HasColumnName("id-pessoa-fisica")
        //    .ValueGeneratedOnAdd();

        //modelBuilder.Entity<RepresentanteModel>()
        //    .Property(x => x.PessoaJuridicaModelId)
        //    .HasColumnName("id-pessoa-juridica")
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
