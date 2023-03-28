using BookCatalog.Domain.Enums;
using BookCatalog.Domain.Interfaces.Services;
using BookCatalog.Domain.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalog.Domain.Tests.Services
{
    [TestClass]
    public class ShippingServiceTests
    {
        private readonly IShippingService _shippingService;

        public ShippingServiceTests()
        {
            _shippingService = new ShippingService();
        }

        [TestMethod]
        public void Dado_um_preco_valido_deve_retornar_valor()
        {
            decimal validPrice= 217.99m;
            decimal expectedShipping = 43.60m;

            decimal shipping = _shippingService.CalculateShipping(validPrice);

            Assert.AreEqual(shipping, expectedShipping);
        }

        [TestMethod]
        public void Dado_um_preco_invalido_nao_deve_retornar_valor()
        {
            decimal invalidPrice = -15.76m;

            decimal shipping = _shippingService.CalculateShipping(invalidPrice);

            Assert.AreEqual(shipping, 0);
        }
    }
}
