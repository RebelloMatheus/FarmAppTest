using System;

namespace FarmApp.Dominio.Extensoes
{
    public class FarmAppException : Exception
    {
        public FarmAppException()
        { }

        public FarmAppException(string message)
            : base(message)
        { }

        public FarmAppException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}