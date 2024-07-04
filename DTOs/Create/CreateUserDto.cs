namespace FireAlert.DTOs.Create;

public class CreateUserDto
{
    public String Name {get;set; }
    public String Surnames {get;set; }
    public DateTime RegisterDate { get; set; }
    public String Mail {get;set; }
    public String Username {get;set; }
    public String Pwd {get;set; }
}