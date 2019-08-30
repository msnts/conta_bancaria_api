namespace ContaBancaria.API.Domain.Models
{
    public interface IContaCorrente
    {
        int Id { get; set; }
        
        decimal Saldo { get; }

        void Depositar(decimal value);
        void Sacar(decimal value);
        void Transferir(decimal value, IContaCorrente contaDestino);
    }
}