using DeveloperStore.Domain.Entities;
namespace Ambev.DeveloperEvaluation.Domain.Interfaces;

public interface IVendaRepository
{
    Task AdicionarAsync(Venda venda);
    Task<Venda> ObterPorIdAsync(int id);
    Task<IEnumerable<Venda>> ObterTodasAsync();
    Task AtualizarAsync(Venda venda);
    Task RemoverAsync(int id);


}
