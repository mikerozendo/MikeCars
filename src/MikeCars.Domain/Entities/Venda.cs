using MikeCars.Domain.Enums;

namespace MikeCars.Domain.Entities;

public sealed class Venda : Operacao
{
    public decimal LucroProvisionadoSintetico { get; private set; }
    public Venda(Vendedor operador, Agente operadorExterno) 
        : base(EnumTipoOperacao.Venda, operador, operadorExterno) { }

    public void CalculaCustoOperacional()
    {
        LucroProvisionadoSintetico = Ativos.Sum(x => x.LucroProvisionado);
    }
}
