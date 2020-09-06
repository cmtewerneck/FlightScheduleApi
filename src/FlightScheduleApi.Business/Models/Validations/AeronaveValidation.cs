using FluentValidation;
using FlightScheduleApi.Business.Models.Validations.Documents;

namespace FlightScheduleApi.Business.Models.Validations
{
    public class AeronaveValidation : AbstractValidator<Aeronave>
    {
        public AeronaveValidation()
        {
            RuleFor(f => f.Matricula)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser preenchido.")
                .Length(5).WithMessage("O campo {PropertyName} precisa ter entre 5 caracteres.");
 
            RuleFor(f => f.Fabricante)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser preenchido.")
                .Length(1,30).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(f => f.Categoria)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser preenchido.")
                .Length(1,30).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");
                
            RuleFor(f => f.Modelo)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser preenchido.")
                .Length(1,30).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");
            
        }
    }
}
