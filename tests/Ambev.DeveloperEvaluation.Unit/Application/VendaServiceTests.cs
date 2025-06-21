using Ambev.DeveloperEvaluation.Application.Services;
using Ambev.DeveloperEvaluation.Domain.Interfaces;
using DeveloperStore.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application
{
    public class VendaServiceTests
    {
        private readonly Mock<IVendaRepository> _vendaRepositoryMock;
        private readonly VendaService _vendaService;

        public VendaServiceTests()
        {
            _vendaRepositoryMock = new Mock<IVendaRepository>();
            _vendaService = new VendaService(_vendaRepositoryMock.Object);
        }

        [Fact]
        public void CriarVenda_Deve_Chamar_Adicionar_No_Repositorio()
        {
            // Arrange
            var venda = new Venda("Cliente Teste", "Filial A");
            venda.AdicionarItem("Produto A", 3, 50m);

            // Act
            _vendaService.CriarVenda(venda);

            // Assert
            _vendaRepositoryMock.Verify(r => r.Adicionar(venda), Times.Once);
        }

        [Fact]
        public void ObterVenda_Deve_Retornar_Venda_Quando_Existe()
        {
            // Arrange
            var venda = new Venda("Cliente 2", "Filial B");
            var vendaId = venda.Id;

            _vendaRepositoryMock.Setup(r => r.ObterPorId(vendaId)).Returns(venda);

            // Act
            var resultado = _vendaService.ObterVenda(vendaId);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(vendaId, resultado.Id);
        }

        [Fact]
        public void ListarVendas_Deve_Retornar_Todas_As_Vendas()
        {
            // Arrange
            var lista = new List<Venda>
            {
                new Venda("Cliente 1", "Filial A"),
                new Venda("Cliente 2", "Filial B")
            };

            _vendaRepositoryMock.Setup(r => r.ObterTodas()).Returns(lista);

            // Act
            var resultado = _vendaService.ListarVendas();

            // Assert
            Assert.Equal(2, resultado.Count());
        }

        [Fact]
        public void AtualizarVenda_Deve_Chamar_Atualizar_No_Repositorio()
        {
            // Arrange
            var venda = new Venda("Cliente Atualizado", "Filial Z");

            // Act
            _vendaService.AtualizarVenda(venda);

            // Assert
            _vendaRepositoryMock.Verify(r => r.Atualizar(venda), Times.Once);
        }
    }
}
