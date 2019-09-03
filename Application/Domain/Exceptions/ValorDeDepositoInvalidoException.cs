using System;
using System.Runtime.Serialization;

namespace ContaBancaria.API.Domain.Exceptions
{
    [Serializable]
    public class ValorDeCreditoInvalidoException : ArgumentException
    {
        public ValorDeCreditoInvalidoException()
        {
        }

        public ValorDeCreditoInvalidoException(string message) : base(message)
        {
        }

        public ValorDeCreditoInvalidoException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ValorDeCreditoInvalidoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}