namespace FireAlert.DTOs.Create;

public class CreateFireAlertDto
{
    public Decimal Latitude { get; set; }
    public Decimal Longitude { get; set; }
    public String FireDescription { get; set; }
    public String ContactPhoneNumber { get; set; }
    public String ContactName { get; set; }
}