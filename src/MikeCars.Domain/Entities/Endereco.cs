using MikeCars.Domain.Enums;

namespace MikeCars.Domain.Entities;

public class Endereco : Base
{
    public string Logradouro { get; set; }
    public string Numero { get; set; }
    public string Bairro { get; set; }
    public string Cidade { get; set; }
    public string PontoReferencia { get; set; }
    public EnumUf EnumUf { get; private set; }
    public EnumTipoEndereco EnumTipoEndereco { get; private set; }

    public Endereco(EnumTipoEndereco tipoEndereco, EnumUf uf)
    {
        EnumTipoEndereco = tipoEndereco;
        EnumUf = uf;
    }
    public Endereco() { }
}
