using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Volunteers;

public record SocialNetwork
{
    private SocialNetwork()
    {
        
    }
    private SocialNetwork(Name name, string url)
    {
        Name = name;
        Url = url;
    }

    public Name Name { get; set; }
    public string Url { get; set; }

    public Result<SocialNetwork> Create(Name name, string url)
    {
        if (string.IsNullOrEmpty(url))
            return Result.Failure<SocialNetwork>("Url is missing");

        return Result.Success(new SocialNetwork(name, url));
    }
}