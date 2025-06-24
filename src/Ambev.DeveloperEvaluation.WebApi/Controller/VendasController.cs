using Ambev.DeveloperEvaluation.Application.DTO;
using Ambev.DeveloperEvaluation.Application.Services;
using DeveloperStore.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendasController : ControllerBase
    {
        private readonly VendaService _vendaService;

        public VendasController(VendaService vendaService)
        {
            _vendaService = vendaService;
        }

        [HttpPost]
        public IActionResult Criar([FromBody] CriarVendaRequest request)
        {
            Venda venda = new Venda(request.Cliente, request.Filial);

            foreach (ItemVendaRequest item in request.Itens)
            {
                venda.AdicionarItem(item.Produto, item.Quantidade, item.PrecoUnitario);
            }

            _vendaService.CriarVenda(venda);

            return CreatedAtAction(nameof(ObterPorId), new { id = venda.Id }, venda.Id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            Venda venda = await _vendaService.ObterVenda(id);
            if (venda == null) return NotFound();

            VendaResponse response = new VendaResponse
            {
                Id = venda.Id,
                Cliente = venda.Cliente,
                Filial = venda.Filial,
                Cancelado = venda.Cancelado,
                DataVenda = venda.DataVenda,
                ValorTotal = venda.ValorTotal,
                Itens = venda.Itens.Select(i => new ItemVendaResponse
                {
                    Produto = i.Produto,
                    Quantidade = i.Quantidade,
                    PrecoUnitario = i.PrecoUnitario,
                    ValorTotal = i.ValorTotal
                }).ToList()
            };

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var vendas = await _vendaService.ListarVendas();

            var response = vendas.Select(v => new VendaResponse
            {
                Id = v.Id,
                Cliente = v.Cliente,
                Filial = v.Filial,
                Cancelado = v.Cancelado,
                DataVenda = v.DataVenda,
                ValorTotal = v.ValorTotal,
                Itens = v.Itens.Select(i => new ItemVendaResponse
                {
                    Produto = i.Produto,
                    Quantidade = i.Quantidade,
                    PrecoUnitario = i.PrecoUnitario,
                    ValorTotal = i.ValorTotal
                }).ToList()
            });

            return Ok(response);
        }

        [HttpPut("{id}/cancelar")]
        public async Task<IActionResult> Cancelar(Guid id)
        {
            Venda venda = await _vendaService.ObterVenda(id);
            if (venda == null) return NotFound();

            venda.Cancelar();
            _vendaService.AtualizarVenda(venda);

            return NoContent();
        }
    }
}
