using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Events
{
    public class VendaCanceladaEvent : DomainEvent
    {
        public int VendaId { get; }

        public VendaCanceladaEvent(int vendaId)
        {
            VendaId = vendaId;
        }
    }
}
