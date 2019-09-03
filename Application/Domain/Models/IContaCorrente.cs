namespace ContaBancaria.API.Domain.Models
{
    public interface IContaCorrente
    {
        int Id { get; set; }
        
        decimal Saldo { get; }

        void Creditar(decimal value);
        void Debitar(decimal value);
        void Transferir(decimal value, IContaCorrente contaDestino);
    }
}