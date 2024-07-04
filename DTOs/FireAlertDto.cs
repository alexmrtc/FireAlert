namespace FireAlert.DTOs;

public class FireAlertDto
{
    public int Id { get; set; }
    public Decimal Latitude { get; set; }
    public Decimal Longitude { get; set; }
    public String FireDescription { get; set; }
    public String ContactPhoneNumber { get; set; }
    public String ContactName { get; set; }
}