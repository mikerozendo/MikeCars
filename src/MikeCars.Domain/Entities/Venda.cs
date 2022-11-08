using MikeCars.Domain.Enums;

namespace MikeCars.Domain.Entities;

public sealed class Venda : Operacao
{
    public Venda(Vendedor operador, Agente operadorExterno) : base(EnumTipoOperacao.Venda, operador, operadorExterno) { }
}
