namespace Domain;

/// <summary>
/// Domain level Patient. 
/// In this project I use it in persistence layer and previously in API layer.
/// Future work would be to har a clear separation of concerns, for example something like:
/// API:            Api.Response.PatientResponse
/// Domain:         Domain.Patient
/// Infrastructure: Infrastructure.Entities.PatientEntity
/// </summary>
public class Patient
{
    public Patient(string fullName, string address, byte[] photo)
    {
        Id = Guid.NewGuid();
        FullName = fullName;
        Address = address;
        Photo = photo;
    }
    public Patient(Guid id, string fullName, string address, byte[] photo)
    {
        Id = id;
        FullName = fullName;
        Address = address;
        Photo = photo;
    }

    public Guid Id { get; init; }
    public string FullName { get; set; }
    public string Address { get; set; }

    /// <summary>
    /// For an MVP with an in-memory SQLite database i added photos directly as a Blob to the DB
    /// This would of course be a bad idea in practice, where instead a reference would suffice. 
    /// The image could then be stored somewhere better suited than a DB.
    /// </summary>
    public byte[] Photo { get; set; }
}
