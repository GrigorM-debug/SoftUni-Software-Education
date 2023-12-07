using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventMI.Infrastructure.Contracts
{
    public interface IDeletable
    {
        bool IsActive { get; set; }

        DateTime? DeletedOn { get; set; }
    }
}
