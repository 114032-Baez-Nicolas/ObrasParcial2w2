namespace Parcial_2w2.Dominio.Response;

public class BaseReponse<T>
{
    public bool Success { get; set; }
    public T? Data { get; set; }
    public string? Message { get; set; }
}
