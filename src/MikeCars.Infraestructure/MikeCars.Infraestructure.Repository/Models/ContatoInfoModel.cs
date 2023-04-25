namespace MikeCars.Infraestructure.Repository.Models;

public class ContatoInfoModel 
{
    public int ContatoInfoModelId { get; set; }
    public string TelefoneResidencial { get; set; }
    public string TelefoneCelular { get; set; }
    public string Email { get; set; }
    public AgenteModel AgenteModel { get; set; }
    public int IdAgente { get; set; }
}
