﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Events
{
    public class VendaCriadaEvent : DomainEvent
    {
        public int VendaId { get; }

        public VendaCriadaEvent(int vendaId)
        {
            VendaId = vendaId;
        }
    }
}
