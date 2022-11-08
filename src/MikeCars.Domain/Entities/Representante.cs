using MikeCars.Domain.Enums;

namespace MikeCars.Domain.Entities;

public sealed class Representante : PessoaFisica
{
    public Representante(string numeroDocumento) : base(EnumTipoAgente.Representante, EnumTipoDocumento.CPF, numeroDocumento) { }
}
