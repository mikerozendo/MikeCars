namespace MikeCars.Dto.Repository.Models;

public class DocumentoModel : Base
{
    public string Numero { get; set; }
    public int IdTipoDocumento { get; set; }
    public AgenteModel AgenteModel { get; set; }
    public int IdAgente { get; set; }
}
