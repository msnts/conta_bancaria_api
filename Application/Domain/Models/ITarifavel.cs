namespace ContaBancaria.API.Domain.Models
{
    public interface ITarifavel
    {

        ITarifa Tarifa { get; }

        ITarifa CalcularTarifa();
    }
}