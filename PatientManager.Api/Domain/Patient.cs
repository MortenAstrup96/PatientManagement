namespace Domain;
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

    public Guid Id { get; set; }
    public string FullName { get; set; }
    public string Address { get; set; }
    public byte[] Photo { get; set; }
}
