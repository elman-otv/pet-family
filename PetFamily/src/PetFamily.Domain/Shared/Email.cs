using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Shared;

public record Email
{
    public Email(string value)
    {
        Value = value;
    }
    
    public string Value { get; set; }

    public static Result<Email> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return Result.Failure<Email>("Email cannot be empty.");
        
        return Result.Success(new Email(value));
    }
}