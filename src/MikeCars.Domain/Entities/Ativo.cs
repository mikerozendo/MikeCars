using MikeCars.Domain.Enums;

namespace MikeCars.Domain.Entities;

public class Ativo : Base
{
    public Carro Carro { get; set; }
    public decimal ValorVenda { get; set; }
    public decimal ValorAquisicao { get; set; }
    public decimal LucroProvisionado { get; set; }
    public DateTime Entrada { get; set; }
    public DateTime Saida { get; set; }
    public bool EmEstoque { get; set; }
    public EnumSituacaoAquisicao EnumSituacaoAquisicao { get; set; }

    public void CalculaLucroProvisionado(decimal percentualComissao)
    {
        decimal comissaoAPagar =  ValorVenda * percentualComissao / 100;
        decimal provisionado = ValorVenda - ValorAquisicao - comissaoAPagar;
        LucroProvisionado = provisionado;
    }
}
