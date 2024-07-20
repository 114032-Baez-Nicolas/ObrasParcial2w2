using FluentValidation;
using Parcial_2w2.Dominio;

namespace Parcial_2w2.Validators;

public class PostAlbanilXObraDtoValidator : AbstractValidator<PostAlbanilXObraDto>
{
    public PostAlbanilXObraDtoValidator()
    {
        RuleFor(x => x.IdAlbanil).NotEmpty().WithMessage("El id del albañil no puede ser nulo");
        RuleFor(x => x.IdObra).NotEmpty().WithMessage("El id de la obra no puede ser nulo");
        RuleFor(x => x.TareaArealizar).NotEmpty().WithMessage("La tarea a realizar no puede ser nula");
    }
}
