namespace DeveloperStore.Domain.Entities;

public class Venda
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public DateTime DataVenda { get; private set; } = DateTime.UtcNow;
    public string Cliente { get; private set; }
    public string Filial { get; private set; }
    public bool Cancelado { get; private set; }

    private readonly List<ItemVenda> _itens = new();
    public IReadOnlyCollection<ItemVenda> Itens => _itens.AsReadOnly();

    public decimal ValorTotal => _itens.Sum(i => i.ValorTotal);

    public Venda(string cliente, string filial)
    {
        Cliente = cliente ?? throw new ArgumentNullException(nameof(cliente));
        Filial = filial ?? throw new ArgumentNullException(nameof(filial));
    }

    public void AdicionarItem(string produto, int quantidade, decimal precoUnitario)
    {
        var item = new ItemVenda(produto, quantidade, precoUnitario);
        _itens.Add(item);
    }

    public void Cancelar()
    {
        Cancelado = true;
    }
}
