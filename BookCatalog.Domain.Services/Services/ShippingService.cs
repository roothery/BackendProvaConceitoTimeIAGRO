using BookCatalog.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalog.Domain.Services.Services
{
    public class ShippingService : IShippingService
    {
        public decimal CalculateShipping(decimal price)
        {
            if (price < 0 || price == 0) return 0;

            var shippingValue = Math.Round((price * 0.2m),2);
            return shippingValue;
        }
    }
}
