namespace Subhub.Domain.Entities;

//Subscription will inherit from BaseEntity
// plus defines properties and behaviors specific to a subscription object

public class Subscription : BaseEntity
{
    public string Name { get; set; }
    public string Category { get; set; }
    public string Type { get; set; }
    public int Cost { get; set; }
    public DateTime PaymentDate { get; set; }
    public int Period { get; set; }
    public bool IsActive { get; set; }
}
//Each property has a getter and setter ({ get; set; }), 
//indicating that they are auto-implemented properties. These properties provide access to the corresponding fields and allow read/write operations.