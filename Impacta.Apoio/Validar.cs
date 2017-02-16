using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Impacta.Apoio
{
    public static class Validar
    {
        public static void DataAnnotations(object entidade)
        {
            var context = new ValidationContext(entidade, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();

            if(!Validator.TryValidateObject(entidade, context, results, validateAllProperties: true))
            {
                throw new DataAnnotationValidationException(results);
            }            
        }
    }
}