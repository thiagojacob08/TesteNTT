using Ambev.DeveloperEvaluation.Application.Services;
using Ambev.DeveloperEvaluation.Domain.Interfaces;
using DeveloperStore.Domain.Entities;
using Microsoft.Extensions.Logging;
using Moq;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application
{
    public class VendaServiceTests
    {
        private readonly Mock<IVendaRepository> _vendaRepositoryMock;
        private readonly Mock<ILogger<VendaService>> _LoggerMock;
        private readonly VendaService _vendaService;

        public VendaServiceTests()
        {
            _vendaRepositoryMock = new Mock<IVendaRepository>();

            _vendaService = new VendaService(_vendaRepositoryMock.Object, (ILogger<VendaService>)_LoggerMock);
        }

        [Fact]
        public void CriarVenda_Deve_Chamar_Adicionar_No_Repositorio()
        {
            // Arrange
            var venda = new Venda("Cliente Teste", "Filial A");
            venda.AdicionarItem("Produto A", 3, 50m);

            // Act
            _vendaService.CriarVendaAsync(venda);

            // Assert
            _vendaRepositoryMock.Verify(r => r.AdicionarAsync(venda), Times.Once);
        }

        [Fact]
        public async Task ObterVenda_Deve_Retornar_Venda_Quando_Existe()
        {
            // Arrange
            var venda = new Venda("Cliente 2", "Filial B");
            var vendaId = venda.Id;

            _vendaRepositoryMock.Setup(r => r.ObterPorIdAsync(vendaId)).Returns(Task.FromResult(venda));

            // Act
            var resultado = await _vendaService.ObterVenda(vendaId);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(vendaId, resultado.Id);
        }

        [Fact]
        public async Task ListarVendas_Deve_Retornar_Todas_As_VendasAsync()
        {
            // Arrange
            var lista = new List<Venda>
            {
                new Venda("Cliente 1", "Filial A"),
                new Venda("Cliente 2", "Filial B")
            };

            _vendaRepositoryMock.Setup(r => r.ObterTodasAsync()).Returns(Task.FromResult<IEnumerable<Venda>>(lista));

            // Act
            var resultado = await _vendaService.ListarVendas();

            // Assert
            Assert.Equal(2, resultado.Count());
        }

        [Fact]
        public void AtualizarVenda_Deve_Chamar_Atualizar_No_Repositorio()
        {
            // Arrange
            var venda = new Venda("Cliente Atualizado", "Filial Z");

            // Act
            _vendaService.AtualizarVendaAsync(venda);

            // Assert
            _vendaRepositoryMock.Verify(r => r.AtualizarAsync(venda), Times.Once);
        }
    }
}
