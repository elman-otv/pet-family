using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Shared;

public record Description
{
    public const int MAX_LENGTH = 2000;
    
    public string Value { get; }

    private Description(string value)
    {
        Value = value;
    }

    public static Result<Description> Create(string value)
    {
        if (value.Length > MAX_LENGTH)
            return Result.Failure<Description>("Description is too long.");
        
        return Result.Success(new Description(value));
    }
    
}   