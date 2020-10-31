using FluentValidation.Results;
using System.Linq;

namespace Spinner.API.Extensions
{
    public static class ValidationResultFormatter
    {
        public static object ToDTO(this ValidationResult result)
        {
            return new
            {
                message = "Ocorreu um ou mais erros de validação",
                propriedades = result.Errors.Select(e => e.PropertyName)
            };
        }
    }
}
