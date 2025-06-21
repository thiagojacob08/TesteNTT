namespace DeveloperStore.Domain.Entities;

public class ItemVenda
{
    public string Produto { get; private set; }
    public int Quantidade { get; private set; }
    public decimal PrecoUnitario { get; private set; }
    public decimal Desconto { get; private set; }
    public decimal ValorTotal => (PrecoUnitario * Quantidade) - Desconto;

    public ItemVenda(string produto, int quantidade, decimal precoUnitario)
    {
        if (string.IsNullOrWhiteSpace(produto))
            throw new ArgumentException("Produto inválido", nameof(produto));

        if (quantidade <= 0)
            throw new ArgumentException("Quantidade deve ser maior que zero", nameof(quantidade));

        if (quantidade > 20)
            throw new ArgumentException("Não é permitido vender mais de 20 unidades.");

        Produto = produto;
        Quantidade = quantidade;
        PrecoUnitario = precoUnitario;

        CalcularDesconto();
    }

    private void CalcularDesconto()
    {
        if (Quantidade >= 10)
            Desconto = 0.20m * (PrecoUnitario * Quantidade);
        else if (Quantidade >= 4)
            Desconto = 0.10m * (PrecoUnitario * Quantidade);
        else
            Desconto = 0;
    }
}
