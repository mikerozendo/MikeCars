namespace MikeCars.Domain.Entities;

public class Ferias
{
    public DateTime Inicio { get; set; }
    public DateTime Termino { get; set; }
    public bool Vendida { get; set; }
    public int DiasVendidos { get; set; }
    public int DiasExercidos { get; set; }
}
