using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoices.Data.Models
{
    public class ProductClient
    {
        [ForeignKey(nameof(ProductId))]
        public int ProductId { get; set; }

        public virtual Product Product { get; set; } = null!;

        [ForeignKey(nameof(ClientId))]
        public int ClientId { get; set; }

        public virtual Client Client { get; set; } = null!;
    }
}
