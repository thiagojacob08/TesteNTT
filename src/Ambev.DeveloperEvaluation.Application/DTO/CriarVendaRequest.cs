    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.DTO
{
    public class CriarVendaRequest
    {
        public string Cliente { get; set; }
        public string Filial { get; set; }
        public List<ItemVendaRequest> Itens { get; set; }
    }
}
