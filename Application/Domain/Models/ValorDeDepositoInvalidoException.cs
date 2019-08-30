using System;
using System.Runtime.Serialization;

namespace ContaBancaria.API.Domain.Models
{
    [Serializable]
    public class ValorDeDepositoInvalidoException : ArgumentException
    {
        public ValorDeDepositoInvalidoException()
        {
        }

        public ValorDeDepositoInvalidoException(string message) : base(message)
        {
        }

        public ValorDeDepositoInvalidoException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ValorDeDepositoInvalidoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}