using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Events
{
    public class VendaModificadaEvent : DomainEvent
    {
        public int VendaId { get; }

        public VendaModificadaEvent(int vendaId)
        {
            VendaId = vendaId;
        }
    }
}
