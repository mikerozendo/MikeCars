using MikeCars.Domain.Enums;

namespace MikeCars.Domain.Entities;

public class Compra : Operacao
{
    public Compra(Funcionario operadorInterno, Agente operadorExterno) 
        : base(EnumTipoOperacao.Compra, operadorInterno, operadorExterno)
    {
    }
}