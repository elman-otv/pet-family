using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Shared;

public record DonationDetail
{
    public Name Name { get; set; }
    public Description Description { get; set; }

    private DonationDetail()
    {
        
    }
    
    private DonationDetail(Name name, Description description)
    {
        Name = name;
        Description = description;
    }

    public static Result<DonationDetail> Create(Name name, Description description)
    {
        return Result.Success(new DonationDetail(name, description));
    }
}