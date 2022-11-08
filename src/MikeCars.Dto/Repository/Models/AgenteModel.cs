namespace MikeCars.Dto.Repository.Models;

public class AgenteModel : Base
{
    public int IdTipoAgente { get; set; }
    public EnderecoModel EnderecoModel { get; set; }
    public int IdEnderecoModel { get; set; }

    public ContatoInfoModel ContatoInfoModel { get; set; }
    public int IdContatoInfoModel { get; set; }

    public DocumentoModel DocumentoModel { get; set; }
    public int IdDocumentoModel { get; set; }
}
