using MikeCars.Domain.Enums;

namespace MikeCars.Domain.Entities;

public class PessoaJuridica : Agente
{
    public Representante Representante { get; set; }
    public string RazaoSocial { get; set; }
    public string NomeFantasia { get; set; }
    public DateTime Abertura { get; set; }

    public PessoaJuridica(
            string documentoRepresentante,
            string documentoEmpresa,
            EnumTipoAgente tipoAgente) : base(tipoAgente, EnumTipoDocumento.CNPJ, documentoEmpresa)
    {
        Representante = new(documentoRepresentante);
    }
}
