using MikeCars.Domain.Enums;

namespace MikeCars.Domain.Entities;

public sealed class Vendedor : Operador
{
    public IEnumerable<Venda> Vendas { get; set; } = new List<Venda>();
    public decimal PercentualComissao { get; set; }
    //public decimal ComissaoTotal { get; private set; }

    public Vendedor(string numeroDocumento)
        : base(EnumTipoFuncionario.Vendedor, EnumDepartamentoEmpresa.Comercial, numeroDocumento) { }

    //public void CalculaComissaoTotal()
    //{
    //    decimal valorTotalVendas = Vendas.Sum(x => x.ValorTotal);

    //    if (valorTotalVendas > 0)
    //    {
    //        ComissaoTotal = 0;
    //    }
    //    else
    //    {
    //        ComissaoTotal = PercentualComissao * valorTotalVendas / 100;
    //    }
    //}

    //public void CalculaSalarioTotal()
    //{
    //    Salario += ComissaoTotal;
    //}
}
