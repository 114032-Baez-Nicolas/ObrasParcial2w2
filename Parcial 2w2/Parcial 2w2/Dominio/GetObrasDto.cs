namespace Parcial_2w2.Dominio;

public class GetObrasDto
{
    public Guid Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string DatosVarios { get; set; } = null!;

    public string NombreObra { get; set; }

    public int CantidadAlbaniles { get; set; }
}
