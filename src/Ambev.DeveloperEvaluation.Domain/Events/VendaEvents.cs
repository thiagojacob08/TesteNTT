namespace Ambev.DeveloperEvaluation.Domain.Events;

public class VendaCriadaEvent
{
    public Guid VendaId { get; init; }
    public DateTime Data { get; init; } = DateTime.UtcNow;
}

public class VendaCanceladaEvent
{
    public Guid VendaId { get; init; }
    public DateTime Data { get; init; } = DateTime.UtcNow;
}
