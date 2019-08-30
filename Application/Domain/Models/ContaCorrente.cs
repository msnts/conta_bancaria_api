namespace ContaBancaria.API.Domain.Models
{
    public class ContaCorrente
    {
        public int Id { get; set; }

        public decimal Saldo { get; private set;}

        private ContaCorrente()
        {
            Saldo = 0m;
        }

        public ContaCorrente(decimal saldo)
        {
            Saldo = saldo;
        }

        public void Depositar(decimal value)
        {
            if (value < 0.01m) {
                throw new ValorDeDepositoInvalidoException("Valor de depósito inválido");
            }

           Saldo += value;
        }
    }
}