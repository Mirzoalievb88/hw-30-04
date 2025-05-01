using System;
using System.Collections.Generic;
using Infrastructure.Services;
using Domain.Models;

var movieService = new MovieService();
var theaterService = new TheaterService();
var screeningService = new ScreeningService();
var ticketService = new TicketService();

PrintMovies(movieService);
PrintTheaters(theaterService);
PrintScreenings(screeningService);
PrintTickets(ticketService);

// var newMovie = new Movie { title = "forrest dump", Director = "Режиссёр", year = 2022, duration = 120, genre = "Драма", description = "Описание" };
// movieService.CreateMovie(newMovie);

// var newTheater = new Theater { name = "Новый кинотеатр", location = "Адрес", manager = "Менеджер", phone = "Телефон", capacity = 100 };
// theaterService.CreateTheater(newTheater);

// var newScreening = new Screening { movie_id = 1, theater_id = 1, screening_time = DateTime.Now, ticket_price = 100, available_seats = 50 };
// screeningService.CreateScreening(newScreening);

// var newTicket = new Ticket { screening_id = 1, customer_name = "Имя покупателя", seat_number = "Номер места", price = 100 };
// ticketService.CreateTicket(newTicket);
    

static void PrintMovies(MovieService movieService)
{
    Console.WriteLine("Список фильмов:");
    var movies = movieService.GetAllMovies();
    foreach (var movie in movies)
    {
        Console.WriteLine($"Id: {movie.Id}, Title: {movie.title}, Director: {movie.Director}, Year: {movie.year}");
    }
}

static void PrintTheaters(TheaterService theaterService)
{
    Console.WriteLine("Список кинотеатров:");
    var theaters = theaterService.GetAllTheaters();
    foreach (var theater in theaters)
    {
        Console.WriteLine($"Id: {theater.Id}, Name: {theater.name}, Location: {theater.location}, Manager: {theater.manager}, Phone: {theater.phone}, Capacity: {theater.capacity}");
    }
}

static void PrintScreenings(ScreeningService screeningService)
{
    Console.WriteLine("Список сеансов:");
    var screenings = screeningService.GetAllScreenings();
    foreach (var screening in screenings)
    {
        Console.WriteLine($"Id: {screening.Id}, MovieId: {screening.movie_id}, TheaterId: {screening.theater_id}, ScreeningTime: {screening.screening_time}, TicketPrice: {screening.ticket_price}, AvailableSeats: {screening.available_seats}");
    }
}

static void PrintTickets(TicketService ticketService)
{
    Console.WriteLine("Список билетов:");
    var tickets = ticketService.GetAllTickets();
    foreach (var ticket in tickets)
    {
        Console.WriteLine($"Id: {ticket.Id}, ScreeningId: {ticket.screening_id}, CustomerName: {ticket.customer_name}, SeatNumber: {ticket.seat_number}, Price: {ticket.price}");
    }
}

movieService.GetMovieByDuration();

var NewMovie = movieService.GetMoviesDistinct();

foreach (var item in NewMovie)
{
    System.Console.WriteLine($"ID = {item.Id}");
    System.Console.WriteLine($"TITLE = {item.title}");
    System.Console.WriteLine($"Director = {item.Director}");
    System.Console.WriteLine($"Year = {item.year}");
    System.Console.WriteLine($"Duration = {item.duration}");
    System.Console.WriteLine($"Genre = {item.genre}");
    System.Console.WriteLine($"Description = {item.description}");
}

var newTheater = new List<Theater>();

foreach (var item in newTheater)
{
    System.Console.WriteLine(item);
}

ticketService.SelectSumOfPrice();

var NewTickets = new List<Ticket>();

foreach (var item in NewTickets)
{
    System.Console.WriteLine(item);
}

System.Console.WriteLine("VVedite svoy janr");
var movieNew = movieService.GetAllMoviesOfCommedy(Console.ReadLine());

foreach (var item in movieNew)
{
    System.Console.WriteLine(item.Id);
    System.Console.WriteLine(item.title);
    System.Console.WriteLine(item.Director);
    System.Console.WriteLine(item.year);
    System.Console.WriteLine(item.duration);
    System.Console.WriteLine(item.genre);
    System.Console.WriteLine(item.description);
}

var newDirectors = movieService.GetDirectors();

foreach (var item in newDirectors)
{
    System.Console.WriteLine(item.Id);
    System.Console.WriteLine(item.title);
    System.Console.WriteLine(item.Director);
    System.Console.WriteLine(item.year);
    System.Console.WriteLine(item.duration);
    System.Console.WriteLine(item.genre);
    System.Console.WriteLine(item.description);
}

newScreenings = ScreeningService.GetAllScreeningsSortedByTime();

foreach (var item in newScreenings)
{
    System.Console.WriteLine(item);
}

