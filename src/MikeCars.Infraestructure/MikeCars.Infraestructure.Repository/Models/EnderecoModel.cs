namespace MikeCars.Infraestructure.Repository.Models;

public class EnderecoModel 
{
    public int EnderecoModelId { get; set; }

    public string Logradouro { get; set; }
    public string Numero { get; set; }
    public string Bairro { get; set; }
    public string Cidade { get; set; }
    public string PontoReferencia { get; set; }
    public string Uf { get; set; }
    public int IdTipoEndereco { get; set; }
    public AgenteModel AgenteModel { get; set; }
    public int IdAgente { get; set; }
}
