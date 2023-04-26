namespace MikeCars.Infraestructure.Repository.Models;

public class AgenteModel 
{
    public int AgenteModelId { get; set; }
    public int IdTipoAgente { get; set; }

    public EnderecoModel? EnderecoModel { get; set; }
    public int IdEnderecoModel { get; set; }

    public ContatoInfoModel? ContatoInfoModel { get; set; }
    public int IdContatoinfoModel { get; set; }

    public DocumentoModel? DocumentoModel { get; set; }
    public int IdDocumentoModel { get; set; }

    public PessoaFisicaModel? PessoaFisicaModel { get; set; }
    public int? IdPessoaFisicaModel { get; set; }

    //public PessoaJuridicaModel? PessoaJuridicaModel { get; set; }
    //public int IdPessoaJuridicaModel { get; set; }
}
