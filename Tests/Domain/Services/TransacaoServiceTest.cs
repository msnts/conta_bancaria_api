using ContaBancaria.API.Domain.Repositories;
using Xunit;
using Moq;
using ContaBancaria.API.Domain.Services;
using ContaBancaria.API.Domain.Models;
using System.Threading.Tasks;
using ContaBancaria.API.Domain.Exceptions;

namespace ContaBancaria.API.Tests.Domain.Services
{
    public class TransacaoServiceUnitTest
    {
        [Theory]
        [InlineData(0, 10, 10, 0.10, 9.90)]
        [InlineData(13.31, 11.01, 24.32, 0.11, 24.21)]
        public async Task TestDeveriaDepositarCorretamenteAsync(decimal saldoInicial, decimal valorDeposito, decimal saldoPosDeposito, decimal valorTarifa, decimal saldoPosTarifa)
        {
            IContaCorrente conta = new ContaCorrente(saldoInicial);

            var transacaoRepositoryMock = new Mock<ITransacaoRepository>();
            var contaRepositoryMock = new Mock<IContaCorrenteRepository>();

            contaRepositoryMock.Setup(x => x.FindByIdAsync(1)).Returns(Task.FromResult(conta));

            var transacaoService = new TransacaoService(transacaoRepositoryMock.Object, contaRepositoryMock.Object);

            var transacao = await transacaoService.DepositarAsync(1, valorDeposito);

            Assert.Equal(saldoInicial, transacao.SaldoAnterior);
            Assert.Equal(valorDeposito, transacao.Valor);
            Assert.Equal(saldoPosDeposito, transacao.SaldoFinal);
            Assert.Equal(saldoPosDeposito, transacao.Tarifa.SaldoAnterior);
            Assert.Equal(valorTarifa, transacao.Tarifa.Valor);
            Assert.Equal(saldoPosTarifa, transacao.Tarifa.SaldoFinal);
            Assert.Equal(saldoPosTarifa, transacao.Conta.Saldo);
        }

        [Fact]
        public void TestDeveriaLancarExcecaoDeContaNaoEncontradaAsync()
        {
            var transacaoRepositoryMock = new Mock<ITransacaoRepository>();
            var contaRepositoryMock = new Mock<IContaCorrenteRepository>();

            contaRepositoryMock.Setup(x => x.FindByIdAsync(1)).Returns(Task.FromResult((IContaCorrente) null));

            var transacaoService = new TransacaoService(transacaoRepositoryMock.Object, contaRepositoryMock.Object);

            Assert.ThrowsAsync<ContaCorrenteNotFoundException>(async () => await transacaoService.DepositarAsync(1, 1));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void TestDeveriaLancarExcecaoDeValorInvalidoAsync(decimal valor)
        {
            IContaCorrente conta = new ContaCorrente(0);

            var transacaoRepositoryMock = new Mock<ITransacaoRepository>();
            var contaRepositoryMock = new Mock<IContaCorrenteRepository>();

            contaRepositoryMock.Setup(x => x.FindByIdAsync(1)).Returns(Task.FromResult(conta));

            var transacaoService = new TransacaoService(transacaoRepositoryMock.Object, contaRepositoryMock.Object);

            Assert.ThrowsAsync<ValorDeCreditoInvalidoException>(async () => await transacaoService.DepositarAsync(1, valor));
        }
    }
}