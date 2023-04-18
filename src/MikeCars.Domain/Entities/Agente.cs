using MikeCars.Domain.Enums;

namespace MikeCars.Domain.Entities;

public abstract class Agente : PessoaBase
{
    public EnumTipoAgente EnumTipoAgente { get; private set; }
    public bool Ativo { get; set; }

    protected Agente(EnumTipoAgente enumTipoAgente, EnumTipoDocumento enumTipoDocumento, string numeroDocumento) 
        : base(enumTipoDocumento, numeroDocumento)
    {
        EnumTipoAgente = enumTipoAgente;
    }
}