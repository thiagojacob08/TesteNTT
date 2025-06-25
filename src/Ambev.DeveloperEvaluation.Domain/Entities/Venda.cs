using Ambev.DeveloperEvaluation.Domain.Events;

namespace DeveloperStore.Domain.Entities;

public class Venda
{
    public int Id { get; private set; } 
    public DateTime DataVenda { get; private set; } = DateTime.UtcNow;
    public string Cliente { get; private set; }
    public string Filial { get; private set; }
    public bool Cancelado { get; private set; }

    private readonly List<ItemVenda> _itens = new();
    public IReadOnlyCollection<ItemVenda> Itens => _itens.AsReadOnly();

    private readonly List<DomainEvent> _events = new();
    public IReadOnlyCollection<DomainEvent> Events => _events.AsReadOnly();

    public decimal ValorTotal => _itens.Sum(i => i.ValorTotal);

    public Venda(string cliente, string filial)
    {
        Cliente = cliente ?? throw new ArgumentNullException(nameof(cliente));
        Filial = filial ?? throw new ArgumentNullException(nameof(filial));

        // Evento: VendaCriada
        _events.Add(new VendaCriadaEvent(Id));
    }

    public void AdicionarItem(string produto, int quantidade, decimal precoUnitario)
    {
        var item = new ItemVenda(produto, quantidade, precoUnitario);
        _itens.Add(item);
    }

    public void Cancelar()
    {
        if (Cancelado) return;

        Cancelado = true;

        // Evento: VendaCancelada
        _events.Add(new VendaCanceladaEvent(Id));
    }

    public void MarcarComoModificada()
    {
        _events.Add(new VendaModificadaEvent(Id));
    }
}
