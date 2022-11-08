using MikeCars.Domain.Enums;

namespace MikeCars.Domain.Entities;

public class Compra : Operacao
{
    //public Compra(agente) : base(EnumTipoOperacao.Compra, agente)
    //{
    //}
    public Compra(Funcionario operadorInterno, Agente operadorExterno) 
        : base(EnumTipoOperacao.Compra, operadorInterno, operadorExterno)
    {
    }
}