using Npgsql;
using Domain.Models;
using Infrastructure.Interface;

namespace Infrastructure.Services;

public class TheaterService : ITheaterService
{
    private const string connectionString = "Server=localhost;Database=hw-30-04;Port=5432;User Id=postgres;Password=12345;";  

    public List<Theater> GetAllTheaters()
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();
            var cmd = $"select * from theaters";
            var command = new NpgsqlCommand(cmd, connection);
            var reader = command.ExecuteReader();
            var theaters = new List<Theater>();

            while(reader.Read())
            {
                theaters.Add(new Theater
                {
                    Id = reader.GetInt32(0),
                    name = reader.GetString(1),
                    location = reader.GetString(2),
                    manager = reader.GetString(3),
                    phone = reader.GetString(4),
                    capacity = reader.GetInt32(5)    
                });
            }
            return theaters;
        }
    }

    public Theater GetTheaterById(int id)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();
            var cmd = $"Select * from theaters where id = {id}";
            var command = new NpgsqlCommand(cmd, connection);
            var reader = command.ExecuteReader();
            
            if (reader.Read())
            {
                return new Theater
                {
                    Id = reader.GetInt32(0),
                    name = reader.GetString(1),
                    location = reader.GetString(2),
                    manager = reader.GetString(3),
                    phone = reader.GetString(4),
                    capacity = reader.GetInt32(5)
                };
            }
            return null;
        }
    }

    public void CreateTheater(Theater theater)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();
            var cmd = $"insert into theaters(name, location, manager, phone, capacity) values {theater.name}, {theater.location}, {theater.manager}, {theater.phone}, {theater.capacity}";
            var command = new NpgsqlCommand(cmd, connection);
            command.ExecuteNonQuery();
        }
    }

    public void UpdateTheater(Theater theater)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();
            var cmd = $"update theaters set name = {theater.name}, location = {theater.location}, manager = {theater.manager}, phone = {theater.phone}, capacity = {theater.capacity} where id = {theater.Id}";
            var command = new NpgsqlCommand(cmd, connection);
            command.ExecuteNonQuery();
        }
    }

    public void DeleteTheater(int id)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();
            var cmd = $"delete from theaters where id = {id}";
            var command = new NpgsqlCommand(cmd, connection);
            command.ExecuteNonQuery();
        }
    }

    public List<Screening> GetScreeningByTheater(int theaterId)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();
            var cmd = $"select * from screenings where theater_id = {theaterId}";
            var command = new NpgsqlCommand(cmd, connection);
            var reader = command.ExecuteReader();
            var screenings = new List<Screening>();

            while (reader.Read())
            {
                screenings.Add(new Screening
                {
                    Id = reader.GetInt32(0),
                    movie_id = reader.GetInt32(1),
                    theater_id = reader.GetInt32(2),
                    screening_time = reader.GetDateTime(3),
                    ticket_price = reader.GetDecimal(4),
                    available_seats = reader.GetInt32(5)
                });
            }
            return screenings;
        }
    }

    public List<Ticket> GetTicketsByTheater(int theaterId)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();
            var cmd = $"select * from tickets where screening_id in (select id from screenings where theater_id = {theaterId})";
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

    public List<Theater> GetCountSeans()
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();
            var cmd = @$"select * from theaters
                      where capacity > 5";
            var command = new NpgsqlCommand(cmd, connection);
            var reader = command.ExecuteReader();
            var theaters = new List<Theater>();

            while (reader.Read())
            {
                theaters.Add(new Theater
                {
                    Id = reader.GetInt32(0),
                    name = reader.GetString(1),
                    location = reader.GetString(2),
                    manager = reader.GetString(3),
                    phone = reader.GetString(4),
                    capacity = reader.GetInt32(5)
                });
            }
            return theaters;
        }
    }
}
