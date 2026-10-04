using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Species;

public class Breed : Shared.Entity<BreedId>
{
    private Breed(BreedId id) : base(id)
    {
        
    }
    
    public Breed(BreedId breedId, Name name) : base(breedId)
    {
        Name = name;
    }
    
    
    public Name Name { get; private set; }

    
    public static Result<Breed> Create(BreedId breedId, Name name)
    {
        return Result.Success(new Breed(breedId, name));
    }
}