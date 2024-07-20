using FluentValidation;
using Parcial_2w2.Dominio;

namespace Parcial_2w2.Validators;

public class PostAlbanilDtoValidator : AbstractValidator<PostAlbanilDto>
{
    public PostAlbanilDtoValidator()
    {
        RuleFor(x => x.Nombre).NotEmpty().WithMessage("El nombre no puede ser nulo");
        RuleFor(x => x.Apellido).NotEmpty().WithMessage("El apellido no puede ser nulo");
        RuleFor(x => x.Dni).NotEmpty().WithMessage("El dni no puede ser nulo");
    }
}
