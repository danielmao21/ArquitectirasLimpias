namespace Domain.Entities;

public class Client
{
    public Guid Id { get; private set; }
    public string FullName { get; private set; }
    public string IdentificationDocument { get; private set; }
    public string Address { get; private set; }
    public ClientStatus Status { get; private set; }
    public DateTime RegistrationDate { get; private set; }

    public Client(string fullName, string identificationDocument, string address)
    {
        Id = Guid.NewGuid();
        FullName = fullName;
        IdentificationDocument = identificationDocument;
        Address = address;
        Status = ClientStatus.Active;
        RegistrationDate = DateTime.UtcNow;
    }

    public void UpdatePersonalInformation(string newFullName, string newAddress)
    {
        FullName = newFullName;
        Address = newAddress;
    }
    public void BlockClient()
    {
        Status = ClientStatus.Blocked;
    }

    public void ReactivateClient()
    {
        Status = ClientStatus.Active;
    }
}

public enum ClientStatus
{
    Active,
    Blocked
}
