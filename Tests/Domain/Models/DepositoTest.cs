using System;
using Moq;
using Xunit;
using ContaBancaria.API.Domain.Models;

namespace ContaBancaria.API.Tests.Domain.Models
{
    public class DepositoUnitTest
    {
        [Theory]
        [InlineData(12.30, 0.12)]
        [InlineData(1.06, 0.01)]
        public void TestDeveriaCalcularATarifaCorretamente(decimal value, decimal expected)
        {
            var contaMock = new Mock<IContaCorrente>();

            contaMock.Setup(x => x.Saldo).Returns(0);
            
            var deposito = new Deposito(contaMock.Object, DateTime.Now, 0, value, value);

            var tarifa = deposito.CalcularTarifa();

            Assert.Equal(expected, tarifa.Valor);
        }
    }
}