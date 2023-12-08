using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ApahidaTheatherWeb.Data;
using System;
using System.Linq;

namespace ApahidaTheatherWeb.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApahidaTheatherWebContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApahidaTheatherWebContext>>()))
            {
                // Look for any movies.
                if (context.Play.Any() || context.User.Any() || context.Ticket.Any())
                {
                    return;   // DB has been seeded
                }

                Play play1 = new Play
                {
                    Title = "Hamlet",
                    Director = "Shakespeare",
                    Actors = "Bob, Mary, John",
                    Premiere = DateTime.Parse("1989-2-12"),
                    NoTickets = 100
                };

                Play play2 = new Play
                {
                    Title = "Tartuffle",
                    Director = "Moliere",
                    Actors = "Jean, Pierre, Francois",
                    Premiere = DateTime.Parse("1986-2-23"),
                    NoTickets = 85
                };

                Play play3 = new Play
                {
                    Title = "Oedipus Rex",
                    Director = "Sophocles",
                    Actors = "Desdemona, Danse, Max",
                    Premiere = DateTime.Parse("1959-4-15"),
                    NoTickets = 45
                };

                Play play4 = new Play
                {
                    Title = "The Bald Soprano",
                    Director = "Eugen Ionescu",
                    Actors = "Michael, Billy, Maria",
                    Premiere = DateTime.Parse("1984-3-13"),
                    NoTickets = 150
                };

                context.Ticket.AddRange(
                    new Ticket
                    {
                        Row = 1,
                        Number = 8,
                        PlayID = 16
                    },

                    new Ticket
                    {
                        Row = 3,
                        Number = 1,
                        PlayID = 17
                    },

                    new Ticket
                    {
                        Row = 6,
                        Number = 3,
                        PlayID = 18
                    },

                    new Ticket
                    {
                        Row = 10,
                        Number = 7,
                        PlayID = 19
                    }
                ); ;

                context.User.AddRange(
                    new User
                    { 
                        Username = "Billy",
                        Password = "Billy1"
                    },

                    new User
                    {
                        Username = "Mike",
                        Password = "Mike1"
                    },

                    new User
                    {
                        Username = "John",
                        Password = "John1"
                    },

                    new User
                    {
                        Username = "Mary",
                        Password = "Mary2"
                    }
                );

                context.Play.AddRange(play1,play2,play3,play4);
                context.SaveChanges();
            }
        }
    }
}