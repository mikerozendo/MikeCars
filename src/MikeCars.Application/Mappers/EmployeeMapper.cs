using MikeCars.Domain.Entities;
using MikeCars.Domain.Enums;
using MikeCars.Application.ViewModels;

namespace MikeCars.Application.Mappers;

public static class EmployeeMapper
{
    public static Funcionario ToDomainModel(this EmployeeViewModel employeeViewModel)
    {

        var funcionario = new Funcionario((EnumTipoFuncionario)employeeViewModel.TypeEmployeeId, (EnumDepartamentoEmpresa)employeeViewModel.DepartmentId, employeeViewModel.DocumentNumber)
        {
            Admissao = employeeViewModel.ContractStartDate,
            Demissao = employeeViewModel.ContractEndDate,
            //Ativo = true;
            Nascimento = employeeViewModel.BirthDate,
            Salario = employeeViewModel.SalaryAmount,
            Nome = employeeViewModel.FirstName,
            Sobrenome = employeeViewModel.LastName,
            ContatoInfo = new ContatoInfo()
            {
                Email = employeeViewModel.Email,
                TelefoneCelular = employeeViewModel.CellPhone
            }
        };

        return funcionario;
    }
}
