using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.DTO
{
    public class VendaResponse
    {
        public Guid Id { get; set; }
        public string Cliente { get; set; }
        public string Filial { get; set; }
        public bool Cancelado { get; set; }
        public DateTime DataVenda { get; set; }
        public decimal ValorTotal { get; set; }
        public List<ItemVendaResponse> Itens { get; set; }
    }
}
