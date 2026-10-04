using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Pets;

public record Address
{
    private Address(string city, string street, string house, string postalCode)
    {
        City = city;
        Street = street;
        House = house;
        PostalCode = postalCode;
    }
    
    public string City { get; }
    public string Street { get; }
    public string House { get; }
    public string PostalCode { get; }

    public static Result<Address> Create(string city, string street, string house, string postalCode)
    {
        if (string.IsNullOrWhiteSpace(city))
            return Result.Failure<Address>("City is required");
        if (string.IsNullOrWhiteSpace(street))
            return Result.Failure<Address>("Street is required");
        if (string.IsNullOrWhiteSpace(house))
            return Result.Failure<Address>("Number is required");
        if (string.IsNullOrWhiteSpace(postalCode))
            return Result.Failure<Address>("Postal code is required");

        return Result.Success(new Address(city, street, house, postalCode));
    }
}