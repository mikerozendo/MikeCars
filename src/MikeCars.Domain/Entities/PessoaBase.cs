using MikeCars.Domain.ValueObjects;
using MikeCars.Domain.Enums;

namespace MikeCars.Domain.Entities;

public abstract class PessoaBase : Base
{
    public Documento Documento { get; protected set; }
    public Endereco Endereco { get; set; }
    public ContatoInfo ContatoInfo { get; set; }

    public PessoaBase(EnumTipoDocumento enumTipoDocumento, string numeroDocumento)
    {
        Documento = new(enumTipoDocumento, numeroDocumento);
    }
}
