using Domain.Models;

namespace Infrastructure.Interface;

public interface IScreeningService
{
    List<Screening> GetAllScreenings();
    Screening GetScreeningById(int id);
    void CreateScreening(Screening screening);
    void UpdateScreening(Screening screening);
    void DeleteScreening(int id);
}
