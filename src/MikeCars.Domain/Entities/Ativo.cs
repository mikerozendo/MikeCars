using MikeCars.Domain.Enums;

namespace MikeCars.Domain.Entities;

public class Ativo : Base
{
    public Carro Carro { get; set; }
    public decimal ValorAtivo { get; set; }
    public DateTime Entrada { get; set; }
    public EnumSituacaoAquisicao EnumSituacaoAquisicao { get; set; }
}
