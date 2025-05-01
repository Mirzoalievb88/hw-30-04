using Domain.Models;

namespace Infrastructure.Interface;

public interface ITheaterService
{
    List<Theater> GetAllTheaters();
    Theater GetTheaterById(int id);
    void CreateTheater(Theater theater);
    void UpdateTheater(Theater theater);
    void DeleteTheater(int id);
    List<Theater> GetCountSeans();
}