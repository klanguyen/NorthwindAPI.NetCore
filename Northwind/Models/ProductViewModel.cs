using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.Models
{
    public class ProductViewModel
    {
        public IEnumerable<Product> Products { get; set; }
    }
}
