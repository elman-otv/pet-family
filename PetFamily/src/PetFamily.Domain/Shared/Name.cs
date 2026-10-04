using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Shared;

public record Name
{
    public const int MAX_LENGTH = 100;
    
    public string Value { get; }

    private Name(string value)
    {
        Value = value;
    }

    public static Result<Name> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return Result.Failure<Name>("Name cannot be empty.");
        
        if(value.Length > MAX_LENGTH)
            return Result.Failure<Name>("Name is too long.");

        return Result.Success(new Name(value));
    }
}
