using System;
using System.Runtime.Serialization;

namespace ContaBancaria.API.Domain.Exceptions
{
    [Serializable]
    public class ContaCorrenteNotFoundException : ResourceNotFoundException
    {
        public ContaCorrenteNotFoundException()
        {
        }

        public ContaCorrenteNotFoundException(string message) : base(message)
        {
        }

        public ContaCorrenteNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ContaCorrenteNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}