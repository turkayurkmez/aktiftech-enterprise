using FluentValidation.Results;

namespace eshop.Catalog.Application.Exceptions
{
    public class BadEntityRequestException : Exception
    {
        public BadEntityRequestException(string message) : base(message)
        {

        }

        public BadEntityRequestException(string message, ValidationResult validationResult) : base(message)
        {
            Errors = new List<string>();
            validationResult.Errors.ForEach(error => Errors.Add(error.ErrorMessage));
        }

        public List<string> Errors { get; set; }

    }
}
