namespace dotnetapp.Models;

public class Attendee
{
    public int Attendeeld { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Age { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int? Eventld { get; set; }
    public Event? Event { get; set; }
}