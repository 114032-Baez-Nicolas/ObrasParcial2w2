namespace Parcial_2w2.Dominio;

public class PostAlbanilXObraDto
{
    public Guid Id { get; set; }

    public Guid IdAlbanil { get; set; }

    public Guid IdObra { get; set; }

    public string TareaArealizar { get; set; } = null!;
}
