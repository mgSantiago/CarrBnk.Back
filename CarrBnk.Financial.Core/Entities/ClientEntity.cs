namespace Core.Entities
{
    public record ClientEntity
    {
        public ClientEntity(Guid code, string businessName, int registrationNumber, DateTime creationDate)
        {
            Code = code;
            BusinessName = businessName;
            RegistrationNumber = registrationNumber;
            CreationDate = creationDate;
        }

        public Guid Code { get; private set; }
        public string BusinessName { get; private set; }
        public int RegistrationNumber { get; private set; }
        public DateTime CreationDate { get; private set; }
    }
}
