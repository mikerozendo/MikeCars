using MikeCars.Domain.Enums;

namespace MikeCars.Domain.Entities;

public sealed class Comprador : Funcionario
{
    public IEnumerable<Compra> Compras { get; set; } = new List<Compra>();

    public Comprador(string numeroDocumento) 
        : base(EnumTipoFuncionario.Comprador, EnumDepartamentoEmpresa.Compras, numeroDocumento) { }
}
