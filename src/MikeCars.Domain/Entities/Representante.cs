using MikeCars.Domain.Enums;

namespace MikeCars.Domain.Entities;

public sealed class Representante : PessoaFisica
{
    public PessoaJuridica Empresa { get; set; }

    public Representante(string documentoRepresentante)
        : base(EnumTipoAgente.Representante, EnumTipoDocumento.CPF, documentoRepresentante) { }
}
