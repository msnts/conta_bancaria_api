using ContaBancaria.API.Domain.Models;
using Xunit;

namespace ContaBancaria.API.Tests.Domain.Models
{
    public class ContaCorrenteUnitTest
    {
        private readonly ContaCorrente _contaCorrente;

        public ContaCorrenteUnitTest() => _contaCorrente = new ContaCorrente(0);

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void TestDepositoInvalido(decimal value)
        {
            Assert.Throws<ValorDeDepositoInvalidoException>(() => _contaCorrente.Depositar(value));
        }

        [Theory]
        [InlineData(0.01, 0, 0.01)]
        [InlineData(3.3, 10.01, 13.31)]
        public void TestDepositoSemErro(decimal value, decimal initial, decimal expected)
        {
            var conta = new ContaCorrente(initial);

            conta.Depositar(value);
        
            Assert.Equal(expected, conta.Saldo);
        }
    }
}