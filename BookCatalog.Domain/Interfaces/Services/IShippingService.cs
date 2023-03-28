using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalog.Domain.Interfaces.Services
{
    public interface IShippingService
    {
        decimal CalculateShipping(decimal price);
    }
}
