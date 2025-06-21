using Ambev.DeveloperEvaluation.Domain.Entities;
using DeveloperStore.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Interfaces;

public interface IVendaRepository
{
    void Adicionar(Venda venda);
    Venda ObterPorId(Guid id);
    IEnumerable<Venda> ObterTodas();
    void Atualizar(Venda venda);
}
