using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Pets;

public record Weight
{
    private Weight(decimal kilograms)
    {
        Kilograms = kilograms;
    }

    public decimal Kilograms { get; set; }

    public static Result<Weight> Create(decimal kilograms)
    {
        if (kilograms <= 0)
            return Result.Failure<Weight>("Weight must be greater than zero.");
        if (kilograms > 500)
            return Result.Failure<Weight>("Weight is too large");

        return Result.Success(new Weight(kilograms));
    }
}