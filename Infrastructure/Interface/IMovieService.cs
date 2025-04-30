using Domain.Models;

namespace Infrastructure.Interface;

public interface IMovieService
{
    List<Movie> GetAllMovies();
    Movie GetMovieById(int id);
    void CreateMovie(Movie movie);
    void UpdateMovie(Movie movie);
    void DeleteMovie(int id);
}