namespace MedbaseLibrary.Models;

public class User
{
    public int ID { get; set; }
    public Guid UserGuid { get; set; }
    public string Username { get; set; }
    public string PhoneNumber { get; set; }
    public int YearOfStudy { get; set; }
    public string Degree { get; set; }
}
