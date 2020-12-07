using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace DatabaseConnection
{
    class Seeding
    {
        static void Main() 
        {
            using (var ctx = new Context())
            {
                ctx.RemoveRange(ctx.Rentals);
                ctx.RemoveRange(ctx.Genres);
                ctx.RemoveRange(ctx.Movies);
                ctx.RemoveRange(ctx.Customers);
                ctx.RemoveRange(ctx.LeadingActors);


                ctx.AddRange(new List<Customer> {
                    new Customer { Användarnamn = "Björn" },
                    new Customer { Användarnamn = "Robin" },
                    new Customer { Användarnamn = "Kalle" },
                });

                List<Genre> Genres = new List<Genre>
                {
                    new Genre {Name = "Action"},
                    new Genre {Name = "Adventure"},
                    new Genre {Name = "Animation"},
                    new Genre {Name = "Biography"},
                    new Genre {Name = "Crime"},
                    new Genre {Name = "Comedy"},
                    new Genre {Name = "Drama"},
                    new Genre {Name = "Family"},
                    new Genre {Name = "Fantasy"},
                    new Genre {Name = "Mystery"},
                    new Genre {Name = "Sci-Fi"},
                    new Genre {Name = "Thriller"},
                    new Genre {Name = "Romance"},
                    new Genre {Name = "Musical"},
                    new Genre {Name = "War"}
                };
                ctx.AddRange(Genres);

                // Här laddas data in från SeedData foldern för att fylla ut Movies tabellen
                var movies = new List<Movie>();
                var lines = File.ReadAllLines(@"..\..\..\SeedData\MovieGenre.csv");
                for (int i = 1; i < 200; i++)
                {
                    // imdbId,Imdb Link,Title,IMDB Score,Genre,Poster
                    var cells = lines[i].Split(',');

                    var url = cells[5].Trim('"');

                    // Hoppa över alla icke-fungerande url:erer
                    try{ var test = new Uri(url); }
                    catch (Exception) { continue; }

                    movies.Add(new Movie { Filmtitel = cells[2], Bild = url });
                }
                ctx.AddRange(movies);

                List<LeadingActor> LeadingActors = new List<LeadingActor>
                {
                    new LeadingActor {First_name ="Leonardo ",      Surname ="DiCaprio"}




                };
                ctx.AddRange(LeadingActors);


                ctx.SaveChanges();
            }
        }
    }
}
