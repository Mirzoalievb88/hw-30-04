namespace Domain.Models;

public class Ticket
{
    public int Id { get; set; }
    public int screening_id { get; set; }
    public string customer_name { get; set; }
    public string seat_number { get; set; }
    public decimal price { get; set; }
}