namespace Api.Dto;

public record PatientResponse
{
    public Guid Id { get; init; }
    public string FullName { get; init; }
    public string Address { get; init; }
    public string Photo { get; init; }
    public PatientResponse(Guid id, string fullName, string address, string photo)
    {
        Id = id;
        FullName = fullName;
        Address = address;
        Photo = photo;
    }
}
