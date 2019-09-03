using System;
using System.Runtime.Serialization;

namespace ContaBancaria.API.Domain.Exceptions
{
    [Serializable]
    public class ValorDeDebitoInvalidoException : ArgumentException
    {
        public ValorDeDebitoInvalidoException()
        {
        }

        public ValorDeDebitoInvalidoException(string message) : base(message)
        {
        }

        public ValorDeDebitoInvalidoException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ValorDeDebitoInvalidoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}