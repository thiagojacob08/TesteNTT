using Ambev.DeveloperEvaluation.Domain.Interfaces;
using Ambev.DeveloperEvaluation.ORM;
using DeveloperStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DeveloperStore.Infrastructure.Repositories
{
    public class VendaRepository : IVendaRepository
    {
        private readonly DefaultContext _context;

        public VendaRepository(DefaultContext context)
        {
            _context = context;
        }

        public void Adicionar(Venda venda)
        {
            _context.Vendas.Add(venda);
            _context.SaveChanges();
        }

        public Venda ObterPorId(Guid id)
        {
            return _context.Vendas.Include(v => v.Itens).FirstOrDefault(v => v.Id == id);
        }

        public IEnumerable<Venda> ObterTodas()
        {
            return _context.Vendas.Include(v => v.Itens).ToList();
        }

        public void Atualizar(Venda venda)
        {
            _context.Vendas.Update(venda);
            _context.SaveChanges();
        }
    }
}
