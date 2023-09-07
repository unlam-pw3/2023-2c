using System.ComponentModel.DataAnnotations;

namespace Clase3.LayoutsValidaciones.Web.Models;

public class EncuestaViewModel
{
    [Required(ErrorMessage = "El campo Nombre es requerido")]
    [StringLength(50, ErrorMessage = "El campo Nombre no puede superar los 50 caracteres")]
    public string Nombre { get; set; }

    [Required(ErrorMessage = "El campo Apellido es requerido")]
    [StringLength(50, ErrorMessage = "El campo Apellido no puede superar los 50 caracteres")]
    public string Apellido { get; set; }

    [Required(ErrorMessage = "El campo Email es requerido")]
    [EmailAddress(ErrorMessage = "El campo Email no es una dirección de correo válida")]
    public string Email { get; set; }

    [Compare("Email", ErrorMessage = "El campo Email y Reingrese Email deben ser iguales")]
    public string ReEmail { get; set; }

    //[CustomValidation(typeof(EncuestaViewModel), "ValidarTelefono")]
    [Required(ErrorMessage = "El campo Teléfono es requerido")]
    [StringLength(20, ErrorMessage = "El campo Teléfono no puede superar los 20 caracteres")]
    [ValidarTelefonoAttribute]
    public string Telefono { get; set; }

    [Required(ErrorMessage = "El campo Comentario es requerido")]
    [StringLength(500, ErrorMessage = "El campo Comentario no puede superar los 500 caracteres")]
    [RegularExpression(@"^[a-zA-Z0-9\s]*$", ErrorMessage = "El campo Comentario solo puede contener letras y números")]
    public string Comentario { get; set; }

    [Required(ErrorMessage = "El campo Horas Disponibles Por Dia es requerido")]
    [Range(1, 24, ErrorMessage = "El campo Horas Disponibles Por Dia debe ser un valor entre 1 y 24")]
    public int HorasDisponiblesPorDia { get; set; }

    //Custom ValidarTelefono
    //public static ValidationResult ValidarTelefono(string telefono, ValidationContext context)
    //{
    //    if (telefono.StartsWith("11"))
    //    {
    //        return ValidationResult.Success!;
    //    }

    //    return new ValidationResult("El campo Teléfono debe comenzar con 11");
    //}
}
public class ValidarTelefonoAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is string telefono && telefono.StartsWith("11"))
        {
            return ValidationResult.Success;
        }

        return new ValidationResult("El campo Teléfono debe comenzar con 11");
    }
}