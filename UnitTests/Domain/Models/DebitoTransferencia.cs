using System;
using Moq;
using Xunit;
using ContaBancaria.API.Domain.Models;

namespace ContaBancaria.API.UnitTests.Domain.Models
{
    public class DebitoTransferenciaUnitTest
    {
        [Theory]
        [InlineData(12.30, 1)]
        [InlineData(1.06, 1)]
        public void TestDeveriaCalcularATarifaDeTransferenciaCorretamente(decimal value, decimal expected)
        {
            var contaMock = new Mock<IContaCorrente>();

            contaMock.Setup(x => x.Saldo).Returns(0);
            
            var deposito = new DebitoTransferencia(contaMock.Object, DateTime.Now, 0, value, value);

            var tarifa = deposito.CalcularTarifa();

            Assert.Equal(expected, tarifa.Valor);
        }
    }
}