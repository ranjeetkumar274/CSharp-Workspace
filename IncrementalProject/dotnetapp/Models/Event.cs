namespace dotnetapp.Models;

public class Event
{
    public int Eventld { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public decimal Budget { get; set; }
    public ICollection<Attendee>? Attendees { get; set; }
}