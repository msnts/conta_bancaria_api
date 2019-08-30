using System;
using System.Runtime.Serialization;

namespace ContaBancaria.API.Domain.Exceptions
{
    [Serializable]
    public class ValorDeSaqueInvalidoException : ArgumentException
    {
        public ValorDeSaqueInvalidoException()
        {
        }

        public ValorDeSaqueInvalidoException(string message) : base(message)
        {
        }

        public ValorDeSaqueInvalidoException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ValorDeSaqueInvalidoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}