using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Interfaces;
using DeveloperStore.Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Services
{
    public class VendaService
    {
        private readonly IVendaRepository _vendaRepository;
        private readonly ILogger<VendaService> _logger;

        public IVendaRepository Object { get; }

        public VendaService(IVendaRepository vendaRepository, ILogger<VendaService> logger)
        {
            _vendaRepository = vendaRepository;
            _logger = logger;
        }

        public async Task CriarVendaAsync(Venda venda)
        {
            try
            {
                await _vendaRepository.AdicionarAsync(venda);
                RegistrarEventos(venda);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Task<Venda> ObterVenda(int id)
        {
            return _vendaRepository.ObterPorIdAsync(id);
        }

        public Task<IEnumerable<Venda>> ListarVendas()
        {
            return _vendaRepository.ObterTodasAsync();
        }

        public async Task AtualizarVendaAsync(Venda venda)
        {
            venda.MarcarComoModificada(); // importante para gerar o evento
            await _vendaRepository.AtualizarAsync(venda);
            RegistrarEventos(venda);
        }

        public async Task RemoverVendaAsync(int id)
        {
            await _vendaRepository.RemoverAsync(id);
            _logger.LogInformation("Venda removida: {VendaId}", id);
        }

        private void RegistrarEventos(Venda venda)
        {
            foreach (var evento in venda.Events)
            {
                _logger.LogInformation("Evento emitido: {Evento} | Data: {Data} | VendaId: {Id}",
                    evento.GetType().Name, evento.OccurredOn, venda.Id);
            }
        }
    }
}
