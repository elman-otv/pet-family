using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Pets;

public record Height
{
    private Height(decimal centimeters)
    {
        Centimeters = centimeters;
    }

    public decimal Centimeters { get; set; }

    public static Result<Height> Create(decimal centimeters)
    {
        if (centimeters <= 0)
            return Result.Failure<Height>("Height must be greater than zero.");
        if (centimeters > 300)
            return Result.Failure<Height>("Height is too large");

        return Result.Success(new Height(centimeters));
    }
}