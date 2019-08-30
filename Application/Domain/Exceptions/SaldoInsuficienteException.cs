using System;
using System.Runtime.Serialization;

namespace ContaBancaria.API.Domain.Exceptions
{
    [Serializable]
    public class SaldoInsuficienteException : Exception
    {
        public SaldoInsuficienteException()
        {
        }

        public SaldoInsuficienteException(string message) : base(message)
        {
        }

        public SaldoInsuficienteException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected SaldoInsuficienteException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}