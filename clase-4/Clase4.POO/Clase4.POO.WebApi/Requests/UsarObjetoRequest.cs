namespace Clase4.POO.WebApi.Requests;

public class UsarObjetoRequest
{
    public Guid PersonajeOrigenId { get; set; }
    public Guid PersonajeDestinoId { get; set; }
    public Guid ObjetoMagicoId { get; set; }
}