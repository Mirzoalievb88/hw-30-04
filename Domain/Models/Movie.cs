namespace Domain.Models;

public class Movie
{
    public int Id { get; set; }
    public string title { get; set; }
    public string Director { get; set; }
    public int year { get; set; }
    public int duration { get; set; }
    public string genre { get; set; }
    public string description { get; set; }
}