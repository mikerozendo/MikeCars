using MikeCars.Domain.Enums;

namespace MikeCars.Domain.Entities;

public abstract class PessoaFisica : Agente
{
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public DateTime Nascimento { get; set; }

    public PessoaFisica(EnumTipoAgente enumTipoAgente, EnumTipoDocumento enumTipoDocumento, string numeroDocumento) 
        : base(enumTipoAgente, enumTipoDocumento, numeroDocumento)
    {
    }
}

