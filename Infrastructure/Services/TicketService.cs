using Npgsql;
using Domain.Models;
using Infrastructure.Interface;

namespace Infrastructure.Services;

public class TicketService : ITicketService
{
    private const string connectionString = "Server=localhost;Database=hw-30-04;Port=5432;User Id=postgres;Password=12345;";

    public List<Ticket> GetAllTickets()
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();
            var cmd = $"select * from tickets";
            var command = new NpgsqlCommand(cmd, connection);
            var reader = command.ExecuteReader();
            var tickets = new List<Ticket>();

            while (reader.Read())
            {
                tickets.Add(new Ticket
                {
                    Id = reader.GetInt32(0),
                    screening_id = reader.GetInt32(1),
                    customer_name = reader.GetString(2),
                    seat_number = reader.GetString(3),
                    price = reader.GetDecimal(4)   
                });
            }
            return tickets;
        }
    }

    public Ticket GetTicketById(int id)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();
            var cmd = $"select * from tickets where id = {id}";
            var command = new NpgsqlCommand(cmd, connection);
            var reader = command.ExecuteReader();

            if (reader.Read())
            {
                return new Ticket
                {
                    Id = reader.GetInt32(0),
                    screening_id = reader.GetInt32(1),
                    customer_name = reader.GetString(2),
                    seat_number = reader.GetString(3),
                    price = reader.GetDecimal(4)
                };
            }
            return null;
        }
    }

    public void CreateTicket(Ticket ticket)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();
            var cmd = $"insert into tickets(screening_id, customer_name, seat_number, price) values({ticket.screening_id}, {ticket.customer_name}, {ticket.seat_number}, {ticket.price})";
            var command = new NpgsqlCommand(cmd, connection);
            command.ExecuteNonQuery();
        }
    }

    public void UpdateTicket(Ticket ticket)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();
            var cmd = $"update tickets set screening_id = {ticket.screening_id}, customer_name = {ticket.customer_name}, seat_number = {ticket.seat_number}, price = {ticket.price} WHERE id = {ticket.Id}";
            var command = new NpgsqlCommand(cmd, connection);
            command.ExecuteNonQuery();
        }
    }

    public void DeleteTicket(int id)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();
            var cmd = $"delete from tickets where id = {id}";
            var command = new NpgsqlCommand(cmd, connection);
            command.ExecuteNonQuery();
        }
    }

    public List<Ticket> GetTicketsByScreening(int screeningId)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();
            var cmd = $"select * from tickets where screening_id = {screeningId}";
            var command = new NpgsqlCommand(cmd, connection);
            var reader = command.ExecuteReader();
            var tickets = new List<Ticket>();

            while (reader.Read())
            {
                tickets.Add(new Ticket
                {
                    Id = reader.GetInt32(0),
                    screening_id = reader.GetInt32(1),
                    customer_name = reader.GetString(2),
                    seat_number = reader.GetString(3),
                    price = reader.GetDecimal(4)
                });
            }
            return tickets;
        }
    }

    public List<Ticket> GetTicketsByCustomer(string customerName)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();
            var cmd = $"select * from tickets where customer_name = {customerName}";
            var command = new NpgsqlCommand(cmd, connection);
            var reader = command.ExecuteReader();
            var tickets = new List<Ticket>();

            while (reader.Read())
            {
                tickets.Add(new Ticket
                {
                    Id = reader.GetInt32(0),
                    screening_id = reader.GetInt32(1),
                    customer_name = reader.GetString(2),
                    seat_number = reader.GetString(3),
                    price = reader.GetDecimal(4)
                });
            }
            return tickets;
        }
    }

    public void SelectSumOfPrice()
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();
            var cmd = @$"select sum(price) from tickets";
            var command = new NpgsqlCommand(cmd, connection);
            System.Console.WriteLine(command.ExecuteNonQuery());
        }
    }

    public List<Ticket> GetSumOfSeans()
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();
            var cmd = @$"select * from tickets
                        where price > (select avg(price) from tickets)";
            var command = new NpgsqlCommand(cmd, connection);
            var reader = command.ExecuteReader();
            var tickets = new List<Ticket>();

            while (reader.Read())
            {
                tickets.Add(new Ticket
                {
                Id = reader.GetInt32(0),
                screening_id = reader.GetInt32(1),
                customer_name = reader.GetString(2),
                seat_number = reader.GetString(3),
                price = reader.GetDecimal(4)
                });
            
            }
            
            return tickets;
        }
    }
}
