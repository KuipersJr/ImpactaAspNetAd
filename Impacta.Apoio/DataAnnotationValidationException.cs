using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Impacta.Apoio
{
    [Serializable]
    public class DataAnnotationValidationException : Exception
    {
        public List<ValidationResult> ErrosValidacao { get; set; }

        public DataAnnotationValidationException()
        {
        }

        public DataAnnotationValidationException(string message) : base(message)
        {
        }

        public DataAnnotationValidationException(List<ValidationResult> results)
        {
            this.ErrosValidacao = results;
        }

        public DataAnnotationValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DataAnnotationValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}