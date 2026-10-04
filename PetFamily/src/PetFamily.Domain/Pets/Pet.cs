using CSharpFunctionalExtensions;
using PetFamily.Domain.Pets.Enums;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Pets;

public class Pet : Shared.Entity<PetId>
{
    private readonly List<DonationDetail> _donationDetails = [];
    
    private Pet(PetId id) : base(id)
    {
        
    }

    private Pet(PetId petId, Name name, PetClassification classification, Description description, Color color, 
        HealthInfo healthInfo, Address address, Weight weight, Height height, PhoneNumber ownerPhoneNumber, 
        bool isNeutered, DateOnly birthDate, bool isVaccinated, HelpStatus helpStatus) : base(petId)
    {
        Name = name;
        PetClassification = classification;
        Description = description;
        Color = color;
        HealthInfo = healthInfo;
        Address = address;
        Weight = weight;
        Height = height;
        OwnerPhoneNumber = ownerPhoneNumber;
        IsNeutered = isNeutered;
        BirthDate = birthDate;
        IsVaccinated = isVaccinated;
        HelpStatus = helpStatus;
        CreatedAt = DateTime.UtcNow;
    }
    
    public Name Name { get; private set; }
    public PetClassification PetClassification { get; private set; }
    public Description Description { get; private set; }
    public Color Color { get; private set; }
    public HealthInfo HealthInfo { get; private set; }
    public Address Address { get; private set; }
    public Weight Weight { get; private set; }
    public Height Height { get; private set; }
    public PhoneNumber OwnerPhoneNumber { get; private set; }
    public bool IsNeutered { get; private set; }
    public DateOnly BirthDate { get; private set; }
    public bool IsVaccinated { get; private set; }
    public HelpStatus HelpStatus { get; private set; }
    public IReadOnlyCollection<DonationDetail> DonationDetails => _donationDetails;
    public DateTime CreatedAt { get; private set; }

    public static Result<Pet> Create(PetId petId, Name name, PetClassification classification, Description description, Color color, 
        HealthInfo healthInfo, Address address, Weight weight, Height height, PhoneNumber ownerPhoneNumber, 
        bool isNeutered, DateOnly birthDate, bool isVaccinated, HelpStatus helpStatus)
    {
        return Result.Success(new Pet(petId, name, classification, description, color, healthInfo, 
            address, weight, height, ownerPhoneNumber, isNeutered, birthDate, isVaccinated, helpStatus));
    }
}