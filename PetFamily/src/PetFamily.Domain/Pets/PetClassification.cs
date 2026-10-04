using PetFamily.Domain.Species;

namespace PetFamily.Domain.Pets;

public record PetClassification
{
    public SpeciesId SpeciesId { get; }
    public BreedId BreedId { get; }
}