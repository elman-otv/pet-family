using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Species
{
    public class Species : Shared.Entity<SpeciesId>
    {
        private readonly List<Breed> _breeds = [];
        
        private Species(SpeciesId id) :  base(id)
        {
            
        }

        private Species(SpeciesId speciesId,Name name) : base(speciesId)
        {
            Name = name;
        }
        
        
        public Name Name { get; }
        
        public IReadOnlyCollection<Breed> Breeds => _breeds;

        public static Result<Species> Create(SpeciesId speciesId, Name name)
        {
            return Result.Success(new Species(speciesId, name));
        }
    }
}