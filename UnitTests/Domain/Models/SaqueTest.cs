using System;
using Moq;
using Xunit;
using ContaBancaria.API.Domain.Models;

namespace ContaBancaria.API.UnitTests.Domain.Models
{
    public class SaqueTest
    {
        [Theory]
        [InlineData(12.30, 4)]
        [InlineData(1.06, 4)]
        public void TestDeveriaCalcularTarifaCorretamente(decimal value, decimal expected)
        {
            var contaMock = new Mock<IContaCorrente>();

            contaMock.Setup(x => x.Saldo).Returns(100);
            
            var saque = new Saque(contaMock.Object, DateTime.Now, 0, value, value);

            var tarifa = saque.CalcularTarifa();

            Assert.Equal(expected, tarifa.Valor);
        }
    }
}