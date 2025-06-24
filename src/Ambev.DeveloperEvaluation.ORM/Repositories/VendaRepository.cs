using Ambev.DeveloperEvaluation.Domain.Interfaces;
using Ambev.DeveloperEvaluation.ORM;
using DeveloperStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeveloperStore.Infrastructure.Repositories
{
    public class VendaRepository : IVendaRepository
    {
        private readonly DefaultContext _context;

        public VendaRepository(DefaultContext context)
        {
            _context = context;
        }

        public async Task AdicionarAsync(Venda venda)
        {
            _context.Vendas.Add(venda);
            await EfCoreRetryHelper.ExecuteWithRetryAsync(() => _context.SaveChangesAsync());
        }

        public async Task<Venda> ObterPorIdAsync(Guid id)
        {
            return await _context.Vendas.Include(v => v.Itens).FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task<IEnumerable<Venda>> ObterTodasAsync()
        {
            return await _context.Vendas.Include(v => v.Itens).ToListAsync();
        }

        public async Task AtualizarAsync(Venda venda)
        {
            _context.Vendas.Update(venda);
            await EfCoreRetryHelper.ExecuteWithRetryAsync(() => _context.SaveChangesAsync());
        }
    }
}
