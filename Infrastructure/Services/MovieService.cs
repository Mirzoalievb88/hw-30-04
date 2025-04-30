using Npgsql;
using Domain.Models;
using Infrastructure.Interface;

namespace Infrastructure.Services;

public class MovieService : IMovieService
{
    private const string connectionString = "Server=localhost;Database=hw-30-04;Port=5432;User Id=postgres;Password=12345;";

    public List<Movie> GetAllMovies()
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();
            
            var cmd = $"select * from movies";

            var command = new NpgsqlCommand(cmd, connection);

            var reader = command.ExecuteReader();    

            var movies = new List<Movie>();
            while (reader.Read())
            {
                movies.Add(new Movie 
                {
                    Id = reader.GetInt32(0),
                    title = reader.GetString(1),
                    Director = reader.GetString(2),
                    year = reader.GetInt32(3),
                    duration = reader.GetInt32(4),
                    genre = reader.GetString(5),
                    description = reader.GetString(6)   
                });
            }
            return movies;
        }
    }

    public Movie GetMovieById(int id)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();

            var cmd = $"select * from movies where id = {id}";

            var command = new NpgsqlCommand(cmd, connection);

            var reader = command.ExecuteReader();

            if (reader.Read())
            {
                return new Movie
                {
                    Id = reader.GetInt32(0),
                    title = reader.GetString(1),
                    Director = reader.GetString(2),
                    year = reader.GetInt32(3),
                    duration = reader.GetInt32(4),
                    genre = reader.GetString(5),
                    description = reader.GetString(6)                    
                };
            }
            return null;
        }
    }

    public void CreateMovie(Movie movie)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();
            var cmd = $"insert into movies(title, director, year, duration, genre, description) values({movie.title}, {movie.Director}, {movie.year}, {movie.duration}, {movie.genre}, {movie.description})";
            var command = new NpgsqlCommand(cmd, connection);
            var result = command.ExecuteNonQuery();
            System.Console.WriteLine(result);
        }
    }

    public void UpdateMovie(Movie movie)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();
            var cmd = $"Update movie set title = {movie.title}, director = {movie.Director}, year = {movie.year}, duration = {movie.duration}, genre = {movie.genre}, description = {movie.description} where id = {movie.Id}";
            var command = new NpgsqlCommand(cmd, connection);
            command.ExecuteNonQuery();
        }
    }

    public void DeleteMovie(int id)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();
            var cmd = $"delete from movies where id = {id}";
            var command = new NpgsqlCommand(cmd, connection);
            command.ExecuteNonQuery();
        }
    }

    public List<Movie> GetMoviesByGenre(string genre)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();
            var cmd = $"select * from movies where genre = {genre}";
            var command = new NpgsqlCommand(cmd, connection);
            var reader = command.ExecuteReader();
            var movies = new List<Movie>();

            while (reader.Read())
            {
                movies.Add(new Movie 
                {
                    Id = reader.GetInt32(0),
                    title = reader.GetString(1),
                    Director = reader.GetString(2),
                    year = reader.GetInt32(3),
                    duration = reader.GetInt32(4),
                    genre = reader.GetString(5),
                    description = reader.GetString(6)
                });
            }
            return movies;
        }
    }

    public List<string> GetUniqueDirectors()
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();
            var cmd = $"select distinct director from movies";
            var command = new NpgsqlCommand(cmd, connection);
            var reader = command.ExecuteReader();
            var directors = new List<string>();

            while (reader.Read())
            {
                directors.Add(reader.GetString(0));
            }

            return directors;
        }
    }
}