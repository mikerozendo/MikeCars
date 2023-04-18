namespace MikeCars.Infraestructure.Repository.Models;

public class DocumentoModel : BaseModel
{
    public string Numero { get; set; }
    public int IdTipoDocumento { get; set; }
    public AgenteModel AgenteModel { get; set; }
    public int IdAgente { get; set; }
}
