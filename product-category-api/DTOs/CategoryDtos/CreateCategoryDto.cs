using FluentValidation;

namespace product_category_api.DTOs.CategoryDtos;

public class CreateCategoryDto
{
    public string Name { get; set; }
}

public class CreateCategoryDtoValidator : AbstractValidator<CreateCategoryDto>
{
    public CreateCategoryDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull()
            .WithMessage("Name cannot be empty")
            .MinimumLength(3)
            .WithMessage("Name must be at least 3 characters long");
    }
}