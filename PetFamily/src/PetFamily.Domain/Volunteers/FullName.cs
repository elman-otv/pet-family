using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Volunteers;

public record FullName
{
    private FullName(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
    
    public string FirstName { get; }
    public string LastName { get; }

    public static Result<FullName> Create(string firstName, string lastName)
    {
        if(string.IsNullOrWhiteSpace(firstName))
            return Result.Failure<FullName>("First name cannot be empty.");
        if (string.IsNullOrWhiteSpace(lastName))
            return Result.Failure<FullName>("Last name cannot be empty.");

        return Result.Success(new FullName(firstName, lastName));
    }
}