using MikeCars.Domain.Entities;

namespace MikeCars.Domain.Builders;

public static class FuncionarioBuilder
{
    public static Funcionario WithSalary(this Funcionario funcionario, decimal salario)
    {
        funcionario.Salario = salario; return funcionario;
    }

    public static Funcionario WithSalary(this Funcionario funcionario, string nome)
    {
        funcionario.Nome = nome; return funcionario;
    }

    public static Funcionario WithSirName(this Funcionario funcionario, string sobrenome)
    {
        funcionario.Sobrenome = sobrenome; return funcionario;
    }

    public static Funcionario WithAdmission(this Funcionario funcionario, DateTime admissao)
    {
        funcionario.Admissao = admissao; return funcionario;
    }

    public static Funcionario WithLastVacation(this Funcionario funcionario, DateTime ultimasFerias)
    {
        funcionario.UltimasFerias = ultimasFerias; return funcionario;
    }
}
