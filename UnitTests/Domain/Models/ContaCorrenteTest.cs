using ContaBancaria.API.Domain.Exceptions;
using ContaBancaria.API.Domain.Models;
using Xunit;

namespace ContaBancaria.API.UnitTests.Domain.Models
{
    public class ContaCorrenteUnitTest
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void TestDepositoInvalido(decimal value)
        {
            var conta = new ContaCorrente(1, 0);

            Assert.Throws<ValorDeCreditoInvalidoException>(() => conta.Creditar(value));
        }

        [Theory]
        [InlineData(0.01, 0, 0.01)]
        [InlineData(3.3, 10.01, 13.31)]
        public void TestDepositoSemErro(decimal value, decimal initial, decimal expected)
        {
            var conta = new ContaCorrente(1, initial);

            conta.Creditar(value);
        
            Assert.Equal(expected, conta.Saldo);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(0.000001, 0)]
        [InlineData(-1, 0)]
        [InlineData(-0.000001, 0)]
        public void TestSaqueValorInvalido(decimal value, decimal initial)
        {
            var conta = new ContaCorrente(1, initial);

            Assert.Throws<ValorDeDebitoInvalidoException>(() => conta.Debitar(value));
        }

        [Theory]
        [InlineData(0.01, 0)]
        [InlineData(1, 0.01)]
        [InlineData(9999, 1.87)]
        public void TestSaqueComSaldoInsuficiente(decimal value, decimal initial)
        {
            var conta = new ContaCorrente(1, initial);

            Assert.Throws<SaldoInsuficienteException>(() => conta.Debitar(value));
        }
    }
}