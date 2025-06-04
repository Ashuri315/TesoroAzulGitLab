using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace TesoroAzul.Application.CustomValidation
{
    public class ValidName : ValidationAttribute
    {
        public ValidName()
        {
            // Asigna un mensaje de error personalizado para este atributo
            ErrorMessage = "El nombre solo puede contener letras y espacios.";
        }

        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
            {
                // Mensaje si el valor es nulo o está vacío
                return new ValidationResult("El nombre no puede estar vacío.");
            }

            string nombre = value.ToString()!;

            // Validación: solo letras y espacios permitidos
            if (!Regex.IsMatch(nombre, @"^[A-Za-z\s]+$"))
            {
                // Usar el mensaje de error que hemos establecido
                return new ValidationResult(ErrorMessage);  // Muestra "El nombre solo puede contener letras y espacios."
            }

            return ValidationResult.Success!;
        }
    }
}
