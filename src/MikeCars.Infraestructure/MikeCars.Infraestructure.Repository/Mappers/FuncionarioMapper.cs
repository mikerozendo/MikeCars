using MikeCars.Domain.Entities;
using MikeCars.Infraestructure.Repository.Models;

namespace MikeCars.Infraestructure.Repository.Mappers;

public static class FuncionarioMapper
{
    public static FuncionarioModel ToDomain(this Funcionario entity)
    {
        var model = new FuncionarioModel()
        {
            Admissao = entity.Admissao,
            Demissao = entity.Demissao,
            Ativo = entity.Ativo,
            Salario = entity.Salario,
            DepartamentoEmpresa = new DepartamentoEmpresaModel()
            {
                IdDepartamentoEmpresa = (int)entity.DepartamentoEmpresa.EnumDepartamentoEmpresa,
                Nome = entity.DepartamentoEmpresa.Nome,
                Id = entity.DepartamentoEmpresa.Id
            },
            UltimasFerias = entity.FeriasSinteticoInfo.UltimasFerias,
            IdAgenteModel = entity.Id,
            IdTipoFuncionario = (int)entity.EnumTipoFuncionario,
            IdDepartamento = (int)entity.DepartamentoEmpresa.EnumDepartamentoEmpresa,                  
        };

        return model;
    }
}
