using System.ComponentModel.DataAnnotations;

namespace MEC.ControleRDO.Enum
{
    public class PerfilEnumValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            var perfil = (PerfilEnum)value;

            if (perfil != PerfilEnum.Admin && perfil != PerfilEnum.Padrao)
            {
                return new ValidationResult("O perfil selecionado não é válido.");
            }

            return ValidationResult.Success;
        }
    }
}
