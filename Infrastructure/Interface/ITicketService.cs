using Domain.Models;

namespace Infrastructure.Interface;

public interface ITicketService
{
    List<Ticket> GetAllTickets();
    Ticket GetTicketById(int id);
    void CreateTicket(Ticket ticket);
    void UpdateTicket(Ticket ticket);
    void DeleteTicket(int id);
    void SelectSumOfPrice();
    List<Ticket> GetSumOfSeans();
}
