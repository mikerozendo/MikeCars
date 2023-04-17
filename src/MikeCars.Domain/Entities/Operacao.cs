using MikeCars.Domain.Enums;

namespace MikeCars.Domain.Entities;

public abstract class Operacao : Base
{
    public EnumTipoOperacao EnumTipoOperacao { get; private set; }
    public EnumSituacaoOperacao EnumSituacaoOperacao { get; set; }
    public Funcionario OperadorInterno { get; protected set; }
    public Agente OperadorExterno { get; protected set; }
    public DateTime Data { get; set; }
    public DateTime UltimaAlteracao { get; set; }
    public decimal ValorTotal { get; private set; }
    public IEnumerable<Ativo> Ativos { get; set; } = new List<Ativo>();

    public Operacao(EnumTipoOperacao enumTipoOperacao, Funcionario operadorInterno, Agente operadorExterno)
    {
        EnumTipoOperacao = enumTipoOperacao;
        OperadorInterno = operadorInterno;
        OperadorExterno = operadorExterno;
    }
}
