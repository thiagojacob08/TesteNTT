using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Events
{
    public abstract class DomainEvent
    {
        [Key]
        public int Id { get; set; }
        public DateTime OccurredOn { get; private set; } = DateTime.UtcNow;
    }

}
