using CSharpFunctionalExtensions;
using PetFamily.Domain.Pets;
using PetFamily.Domain.Pets.Enums;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Volunteers;

public class Volunteer : Shared.Entity<VolunteerId>
{
    private readonly List<SocialNetwork> _socialNetworks = [];
    private readonly List<DonationDetail> _donationDetails = [];
    private readonly List<Pet> _pets = [];
    
    private Volunteer(VolunteerId id) : base(id)
    {
        
    }

    private Volunteer(VolunteerId volunteerId, FullName fullName, Email email, Description description, 
        int experienceYears, PhoneNumber phoneNumber) : base(volunteerId)
    {
        FullName = fullName;
        Email = email;
        Description = description;
        ExperienceYears = experienceYears;
        PhoneNumber = phoneNumber;
    }
    
    public FullName FullName { get; private set; }
    
    public Email Email { get; private set; }
    
    public Description Description { get; private set; }
    
    public int ExperienceYears { get; private set; }
    
    public int GetAdoptedPetsCount(IEnumerable<Pet> pets) => pets.Count(x => x.HelpStatus == HelpStatus.FoundHome);
    
    public int GetPetsLookingForHome(IEnumerable<Pet> pets) => pets.Count(x => x.HelpStatus == HelpStatus.LookingForHome);
    
    public int GetPetsUnderTreatmentCount(IEnumerable<Pet> pets) => pets.Count(x => x.HealthInfo == HealthInfo.UnderTreatment);
    
    public PhoneNumber PhoneNumber { get; private set; }
    
    public IReadOnlyCollection<SocialNetwork> SocialNetworks => _socialNetworks;
    
    public IReadOnlyCollection<DonationDetail> DonationDetails => _donationDetails;
    
    public IReadOnlyCollection<Pet> Pets => _pets;
    

    public static Result<Volunteer> Create(VolunteerId volunteerId, FullName fullName, Email email, Description description, int experienceYears,
        PhoneNumber phoneNumber)
    {
        return Result.Success(new Volunteer(volunteerId, fullName, email, description, experienceYears, phoneNumber));
    }
    
}