namespace Domain.Models;

public class Screening
{
    public int Id { get; set; }
    public int movie_id { get; set; }
    public int theater_id { get; set; }
    public DateTime screening_time { get; set; }
    public decimal ticket_price { get; set; }
    public int available_seats { get; set; }
}