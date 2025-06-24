using Ambev.DeveloperEvaluation.Domain.Entities;
using DeveloperStore.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Interfaces;

public interface IVendaRepository
{
    Task AdicionarAsync(Venda venda);
    Task<Venda> ObterPorIdAsync(Guid id);
    Task<IEnumerable<Venda>> ObterTodasAsync();
    Task AtualizarAsync(Venda venda);

}
