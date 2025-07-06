namespace Domain;
public class Patient
{
    public Patient(string fullName, string address)
    {
        Id = Guid.NewGuid();
        FullName = fullName;
        Address = address;
    }
    public Patient(Guid id, string fullName, string address)
    {
        Id = id;
        FullName = fullName;
        Address = address;
    }

    public Guid Id { get; set; }
    public string FullName { get; set; }
    public string Address { get; set; }
}
