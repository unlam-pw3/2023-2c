using System.ComponentModel.DataAnnotations;
namespace Clase3.LayoutsValidaciones.Web.Models;

public class RegistroViewModel{

    [Required(ErrorMessage = "El campo Nombre es requerido")]
    [StringLength(10, ErrorMessage = "El campo Nombre no puede superar los 10 caracteres")]
    public string Nombre { get; set; }

    [Required(ErrorMessage = "El campo Apellido es requerido")]
    [StringLength(10, ErrorMessage = "El campo Apellido no puede superar los 10 caracteres")]
    public string Apellido { get; set; }

    [Required(ErrorMessage = "El campo Nickname es requerido")]
    [StringLength(10, ErrorMessage = "El campo Nickname no puede superar los 10 caracteres")]
    public string Nickname { get; set; }
    
    [Required(ErrorMessage = "El campo Email es requerido")]
    [EmailAddress(ErrorMessage = "El campo Email no es una dirección de correo válida")]
    public string Email { get; set; }

    [Required(ErrorMessage = "El campo Password debe contener al menos 8 caracteres, minimo una letra y un número")]
    //[StringLength(8, ErrorMessage = "El campo Password debe contener al menos 8 caracteres, minimo una letra y un número")]
    [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$",ErrorMessage = "El campo Password debe contener al menos 8 caracteres, minimo una letra y un número")]
    public string Password { get; set; }

    [Compare("Password", ErrorMessage = "El campo Password y ConfirmarPassword deben ser iguales")]
    public string ConfirmarPassword { get; set; }

    [Required(ErrorMessage = "El campo Edad es requerido")]
    [Range(18, 99, ErrorMessage = "El campo Edad debe ser mayor a 18 y menor a 99")]    
    public int Edad { get; set; }

    [Required(ErrorMessage = "El campo Fecha de Nacimiento es requerido")]
    [ValidarFechaAttribute]
    public DateTime FechaNacimiento { get; set; }

    
    public string Layout { get; set; } = "_OceanoLayout";
}

public class ValidarFechaAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
         if((DateTime)value > DateTime.Now){
              return new ValidationResult("La fecha de nacimiento no puede ser mayor a la fecha actual");
         }
            return ValidationResult.Success;
    }
}