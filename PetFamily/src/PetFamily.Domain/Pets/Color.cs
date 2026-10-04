using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Pets;

public record Color
{
    private Color(string value)
    {
        Value = value;
    }
    
    public string Value { get; }

    public static Result<Color> Create(string value)
    {
        if(string.IsNullOrWhiteSpace(value))
            return Result.Failure<Color>("Color must not be empty");
        
        if(value.Length > Constants.MAX_LOW_LENGTH)
            return Result.Failure<Color>("Color is too long");

        return Result.Success(new Color(value));
    }

}