using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Interfaces;
using DeveloperStore.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Ambev.DeveloperEvaluation.Application.Services
{
    public class VendaService
    {
        private readonly IVendaRepository _vendaRepository;

        public VendaService(IVendaRepository vendaRepository)
        {
            _vendaRepository = vendaRepository;
        }

        public void CriarVenda(Venda venda)
        {
            // Aqui pode implementar regras de negócio antes de adicionar
            _vendaRepository.AdicionarAsync(venda);

            // Opcional: registrar evento no log, se quiser
        }

        public Task<Venda> ObterVenda(Guid id)
        {
            return _vendaRepository.ObterPorIdAsync(id);
        }

        public Task<IEnumerable<Venda>> ListarVendas()
        {
            return _vendaRepository.ObterTodasAsync();
        }

        public void AtualizarVenda(Venda venda)
        {
            // Regras de negócio antes da atualização
            _vendaRepository.AtualizarAsync(venda);

            // Opcional: evento no log
        }
    }
}
