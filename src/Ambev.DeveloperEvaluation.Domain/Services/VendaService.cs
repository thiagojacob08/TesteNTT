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
            _vendaRepository.Adicionar(venda);

            // Opcional: registrar evento no log, se quiser
        }

        public Venda ObterVenda(Guid id)
        {
            return _vendaRepository.ObterPorId(id);
        }

        public IEnumerable<Venda> ListarVendas()
        {
            return _vendaRepository.ObterTodas();
        }

        public void AtualizarVenda(Venda venda)
        {
            // Regras de negócio antes da atualização
            _vendaRepository.Atualizar(venda);

            // Opcional: evento no log
        }
    }
}
