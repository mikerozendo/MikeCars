namespace MikeCars.Domain.Entities;

public class FeriasSinteticoInfo
{
    public List<Ferias> Ferias { get; set; } = new List<Ferias>();
    private Funcionario Funcionario { get; set; }

    public bool FeriasVencida
    {
        get
        {
            return DiasVencimentoProximaFerias > 365;
        }
    }

    public int DiasVencimentoProximaFerias
    {
        get
        {
            if(ProximaFerias.HasValue)
            {
                return ProximaFerias.Value.Date.Subtract(DateTime.Now.Date).Days;
            }

            return 0;
        }
    }

    public DateTime? UltimasFerias
    {
        get
        {
            if (Ferias.Any())
            {
                var proximasFerias = Ferias
                    .Where(x => x.Inicio < DateTime.Now)
                    .ToList();

                if (proximasFerias.Any())
                {
                    return proximasFerias.OrderByDescending(x => x.Inicio).First().Inicio;
                }
                return null;
            }

            return null;
        }
    }

    public DateTime? ProximaFerias
    {
        get
        {
            if (Funcionario.Ativo)
            {
                if (UltimasFerias is null)
                {
                    DateTime admissaoFuncionario = Funcionario.Admissao;
                    return admissaoFuncionario.AddYears(1);
                }
                else
                {
                    return UltimasFerias.Value.AddYears(1);
                }
            }
            else
            {
                return null;
            }
        }
    }

    public FeriasSinteticoInfo(Funcionario funcionario)
    {
        Funcionario = funcionario;
    }
}
