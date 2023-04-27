using MikeCars.Domain.Entities;

namespace MikeCars.Infraestructure.Repository.Models;

public class FuncionarioModel
{
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public DateTime Nascimento { get; set; }
    public decimal Salario { get; set; }
    public DateTime Admissao { get; set; }
    public DateTime? Demissao { get; set; }
    public bool Ativo { get; set; }
    public string NumeroDocumentoFormatado { get; set; }
    public string Email { get; set; }
    public string TelefoneResidencial { get; set; }
    public string TelefoneCelular { get; set; }
    public string Logradouro { get; set; }
    public string Bairro { get; set; }
    public string Cidade { get; set; }
    public string Uf { get; set; }
    public string Numero { get; set; }
    public string PontoReferencia { get; set; }
    public string Cep { get; set; }
    public string InicioExpediente { get; set; }
    public string TerminoExpediente { get; set; }

    public FuncionarioModel(Funcionario entity)
    {
        Nome = entity.Nome;
        Sobrenome = entity.Sobrenome;
        Nascimento = entity.Nascimento;
        Salario = entity.Salario;
        Admissao = entity.Admissao;
        Demissao = entity.Demissao;
        Ativo = entity.Ativo;
        NumeroDocumentoFormatado = entity.Documento.NumeroFormatado;
        Email = entity.ContatoInfo.Email;
        TelefoneResidencial = entity.ContatoInfo.TelefoneResidencial;
        TelefoneCelular = entity.ContatoInfo.TelefoneCelular;
        Logradouro = entity.Endereco.Logradouro;
        Bairro = entity.Endereco.Bairro;
        Logradouro = entity.Endereco.Logradouro;
        Cidade = entity.Endereco.Cidade;
        Uf = entity.Endereco.Uf;
        PontoReferencia = entity.Endereco.PontoReferencia;
        Cep = entity.Endereco.Cep;
        Numero = entity.Endereco.Numero;
    }
}
