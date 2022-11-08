using MikeCars.Domain.Enums;

namespace MikeCars.Domain.Entities;

public sealed class Vendedor : Funcionario
{
    public IEnumerable<Venda> Vendas { get; set; } = new List<Venda>();
    public decimal ComissaoPorVenda { get; set; }
    public decimal ComissaoTotal { get; private set; }
    public decimal SalarioTotal { get; set; }

    public Vendedor(string numeroDocumento)
        : base(EnumTipoFuncionario.Vendedor, EnumDepartamentoEmpresa.Comercial, numeroDocumento) { }

    public void CalculaComissaoTotal()
    {
        decimal valorTotalVendas = 0;

        foreach (var item in Vendas)
        {
            valorTotalVendas += item.ValorTotal;
        }

        if (valorTotalVendas > 0)
        {
            ComissaoTotal = 0;
        }
        else
        {
            ComissaoTotal = ComissaoPorVenda * valorTotalVendas / 100;
        }
    }

    public void CalculaSalarioTotal()
    {
        Salario = ComissaoTotal;
    }
}
