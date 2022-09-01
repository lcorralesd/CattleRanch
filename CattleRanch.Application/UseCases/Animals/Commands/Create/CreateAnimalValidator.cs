using CattleRanch.Core.Domain.Enums;
using CattleRanch.Kernel.Exceptions.Wrappers;
using FluentValidation;

namespace CattleRanch.Application.UseCases.Animals.Commands.Create;
public class CreateAnimalValidator : ValidatorWrapper<CreateAnimalCommand>
{
    public CreateAnimalValidator()
    {
        RuleFor(c => c.Code)
            .NotEmpty().WithMessage("Debe ingresar un Código para el Animal.")
            .MaximumLength(15).WithMessage("El Código no debe ser mayor a 15 caracteres");

        RuleFor(c => c.EarTag)
            .MaximumLength(15).WithMessage("El Código de Oreja no debe ser mayor a 15 caracteres");

        RuleFor(c => c.Name)
            .MaximumLength(20).WithMessage("El Nombre no debe ser mayor a 20 caracteres");

        RuleFor(c => c.Colour)
            .MaximumLength(20).WithMessage("El Color no debe ser mayor a 20 caracteres");

        RuleFor(c => c.Brand)
            .MaximumLength(3).WithMessage("El Hierro no debe ser mayor a 3 caracteres");

        RuleFor(c => c.HornStatus)
            .IsEnumName(typeof(HornStatus), true)
            .WithMessage("Debe ingresar el estado de los cuernos del animal entre Descornado o Cuernos");

        RuleFor(c => c.Sex)
            .IsEnumName(typeof(Sex), true)
            .WithMessage("Debe ingresar un valor para el sexo del animal entre Hembra o Macho");

        RuleFor(c => c.Origin)
            .IsEnumName(typeof(Origin), true)
            .WithMessage("Debe ingresar un valor para la procedencia del animal entre Comprado o Criado");
    }
}
