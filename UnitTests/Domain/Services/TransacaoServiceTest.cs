using ContaBancaria.API.Domain.Repositories;
using Xunit;
using Moq;
using ContaBancaria.API.Domain.Services;
using ContaBancaria.API.Domain.Models;
using System.Threading.Tasks;
using ContaBancaria.API.Domain.Exceptions;

namespace ContaBancaria.API.UnitTests.Domain.Services
{
    public class TransacaoServiceUnitTest
    {
        [Theory]
        [InlineData(0, 10, 10, 0.10, 9.90)]
        [InlineData(13.31, 11.01, 24.32, 0.11, 24.21)]
        public async Task TestDeveriaDepositarCorretamenteAsync(decimal saldoInicial, decimal valorDeposito, decimal saldoPosDeposito, decimal valorTarifa, decimal saldoPosTarifa)
        {
            IContaCorrente conta = new ContaCorrente(1, saldoInicial);

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
        public void TestDeveriaLancarExcecaoDeContaNaoEncontradaNoDeposito()
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
        public void TestDeveriaLancarExcecaoDeValorInvalidoNoDeposito(decimal valor)
        {
            IContaCorrente conta = new ContaCorrente(1, 0);

            var transacaoRepositoryMock = new Mock<ITransacaoRepository>();
            var contaRepositoryMock = new Mock<IContaCorrenteRepository>();

            contaRepositoryMock.Setup(x => x.FindByIdAsync(1)).Returns(Task.FromResult(conta));

            var transacaoService = new TransacaoService(transacaoRepositoryMock.Object, contaRepositoryMock.Object);

            Assert.ThrowsAsync<ValorDeCreditoInvalidoException>(async () => await transacaoService.DepositarAsync(1, valor));
        }

        [Theory]
        [InlineData(100, 10, 90, 4.0, 86)]
        [InlineData(13.31, 3.01, 10.3, 4.0, 6.3)]
        [InlineData(71.33, 23.75, 47.58, 4.0, 43.58)]
        public async Task TestDeveriaSacarCorretamente(decimal saldoInicial, decimal valorSaque, decimal saldoPosSaque, decimal valorTarifa, decimal saldoPosTarifa)
        {
            IContaCorrente conta = new ContaCorrente(1, saldoInicial);

            var transacaoRepositoryMock = new Mock<ITransacaoRepository>();
            var contaRepositoryMock = new Mock<IContaCorrenteRepository>();

            contaRepositoryMock.Setup(x => x.FindByIdAsync(1)).Returns(Task.FromResult(conta));

            var transacaoService = new TransacaoService(transacaoRepositoryMock.Object, contaRepositoryMock.Object);

            var transacao = await transacaoService.SacarAsync(1, valorSaque);

            Assert.Equal(saldoInicial, transacao.SaldoAnterior);
            Assert.Equal(valorSaque, transacao.Valor);
            Assert.Equal(saldoPosSaque, transacao.SaldoFinal);
            Assert.Equal(saldoPosSaque, transacao.Tarifa.SaldoAnterior);
            Assert.Equal(valorTarifa, transacao.Tarifa.Valor);
            Assert.Equal(saldoPosTarifa, transacao.Tarifa.SaldoFinal);
            Assert.Equal(saldoPosTarifa, transacao.Conta.Saldo);
        }

        [Fact]
        public void TestDeveriaLancarExcecaoDeContaNaoEncontradaNoSaque()
        {
            var transacaoRepositoryMock = new Mock<ITransacaoRepository>();
            var contaRepositoryMock = new Mock<IContaCorrenteRepository>();

            contaRepositoryMock.Setup(x => x.FindByIdAsync(1)).Returns(Task.FromResult((IContaCorrente) null));

            var transacaoService = new TransacaoService(transacaoRepositoryMock.Object, contaRepositoryMock.Object);

            Assert.ThrowsAsync<ContaCorrenteNotFoundException>(async () => await transacaoService.SacarAsync(1, 1));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void TestDeveriaLancarExcecaoDeValorInvalidoNoSaque(decimal valor)
        {
            IContaCorrente conta = new ContaCorrente(1, 0);

            var transacaoRepositoryMock = new Mock<ITransacaoRepository>();
            var contaRepositoryMock = new Mock<IContaCorrenteRepository>();

            contaRepositoryMock.Setup(x => x.FindByIdAsync(1)).Returns(Task.FromResult(conta));

            var transacaoService = new TransacaoService(transacaoRepositoryMock.Object, contaRepositoryMock.Object);

            Assert.ThrowsAsync<ValorDeCreditoInvalidoException>(async () => await transacaoService.SacarAsync(1, valor));
        }

        [Theory]
        [InlineData(0, 10)]
        [InlineData(10, 8)]
        public void TestDeveriaLancarExcecaoDeSaldoInsuficienteNoSaque(decimal saldoInicial, decimal valorSaque)
        {
            IContaCorrente conta = new ContaCorrente(1, saldoInicial);

            var transacaoRepositoryMock = new Mock<ITransacaoRepository>();
            var contaRepositoryMock = new Mock<IContaCorrenteRepository>();

            contaRepositoryMock.Setup(x => x.FindByIdAsync(1)).Returns(Task.FromResult(conta));

            var transacaoService = new TransacaoService(transacaoRepositoryMock.Object, contaRepositoryMock.Object);

            Assert.ThrowsAsync<ValorDeCreditoInvalidoException>(async () => await transacaoService.SacarAsync(1, valorSaque));
        }
    }
}