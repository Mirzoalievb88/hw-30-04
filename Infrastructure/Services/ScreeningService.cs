using Npgsql;
using Domain.Models;
using Infrastructure.Interface;

namespace Infrastructure.Services;

public class ScreeningService : IScreeningService
{
    private const string connectionString = "Server=localhost;Database=hw-30-04;Port=5432;User Id=postgres;Password=12345;";

    public List<Screening> GetAllScreenings()
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();
            var cmd = $"select * from screenings";
            var command = new NpgsqlCommand(cmd, connection);
            var screenings = new List<Screening>();

            var reader = command.ExecuteReader();

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

    public Screening GetScreeningById(int id)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();
            var cmd = $"select * from screenings where id = {id}";
            var command = new NpgsqlCommand(cmd, connection);
            var reader = command.ExecuteReader();

            if (reader.Read())
            {
                return new Screening
                {
                    Id = reader.GetInt32(0),
                    movie_id = reader.GetInt32(1),
                    theater_id = reader.GetInt32(2),
                    screening_time = reader.GetDateTime(3),
                    ticket_price = reader.GetDecimal(4),
                    available_seats = reader.GetInt32(5)
                };
            }
            return null;
        }
    }

    public void CreateScreening(Screening screening)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();
            var cmd = $"insert into screenings(movie_id, theater_id, screening_time, ticket_price, available_seats) set ({screening.movie_id}, {screening.theater_id}, {screening.screening_time}, {screening.ticket_price}, {screening.available_seats})";
            var command = new NpgsqlCommand(cmd, connection);
            command.ExecuteNonQuery();
        }
    }

    public void UpdateScreening(Screening screening)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();
            var cmd = $"UPDATE screenings SET movie_id = {screening.movie_id}, theater_id = {screening.theater_id}, screening_time = {screening.screening_time}, ticket_price = {screening.ticket_price}, available_seats = {screening.available_seats} WHERE id = {screening.Id}";
            var command = new NpgsqlCommand(cmd, connection);
            command.ExecuteNonQuery();
        }
    }

    public void DeleteScreening(int id)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();
            var cmd = $"delete from screenings where id = {id}";
            var command = new NpgsqlCommand(cmd, connection);
            command.ExecuteNonQuery();
        }
    }

    public List<Screening> GetScreeningOrderByTime()
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();
            var cmd = $"Select * from screenings order by screening_time";
            var command = new NpgsqlCommand(cmd,connection);
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

    public List<Screening> GetFisrtFiveScreening()
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();
            var cmd = $"select * from screenings limit 5";
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

    public List<Screening> GetAllScreeningsSortedByTime()
    {
        var screenings = new List<Screening>();
        using var connection = new NpgsqlConnection(connectionString);
        connection.Open();
        var cmd = "select * from screenings where screening_time > now()";
        using var command = new NpgsqlCommand(cmd, connection);
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            var screening = new Screening
            {
                id = reader.GetInt32(0),
                movie_id = reader.GetInt32(1),
                theater_id = reader.GetInt32(2),
                screening_time = reader.GetDateTime(3)
            };
            screenings.Add(screening);
        }
        return screenings;
    }

}
