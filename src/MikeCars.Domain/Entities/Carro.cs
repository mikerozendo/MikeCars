using MikeCars.Domain.Enums;

namespace MikeCars.Domain.Entities;

public class Carro : Base
{
    public string Placa { get; set; }
    public string Modelo { get; set; }
    public string Marca { get; set; }
    public DateTime AnoLançamento { get; set; }
    public decimal ValorTabela { get; set; }
    public double Km { get; set; }
    public EnumCorCarro EnumCorCarro { get; set; }
}
