using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace DatabaseConnection
{
    public static class API
    {
        // Här har jag ett kontext tillgängligt för alla API metoder.
        static Context ctx;

        // Statiska konstruktorer kallas på innan den statiska klassen används.
        static API()
        {
            ctx = new Context();
        }

        public static List<Movie> GetMovieSlice(int skip_x, int take_x)
        {
            return ctx.Movies
                .OrderBy(m => m.Filmtitel)
                .Skip(skip_x)
                .Take(take_x)
                .ToList();
        }
        public static Customer GetCustomerByName(string Användarnamn)
        {
            return ctx.Customers
                .FirstOrDefault(c => c.Användarnamn.ToLower() == Användarnamn.ToLower());

        }
        public static bool RegisterSale(Customer customer, Movie movie)
        {
            // Försök att lägga till ett nytt sales record
            try
            {
                ctx.Add(new Rental() { Date = DateTime.Now, Customer = customer, Movie = movie });

                bool one_record_added = ctx.SaveChanges() == 1;
                return one_record_added;
            }
            catch(DbUpdateException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                System.Diagnostics.Debug.WriteLine(e.InnerException.Message);
                return false;
            }

        }

        public static List<Movie> GetMovieByName(string Filmtitel)
        {
            return ctx.Movies.AsEnumerable().Where(m => m.Filmtitel.Contains(Filmtitel, StringComparison.OrdinalIgnoreCase)).ToList();
        }


        public static List<Movie> GetMovieByGenre(Genre genre)
        {
            using var ctx = new Context();

            var movies = ctx.Movies.Where(m => m.Genres.Any(g => g.Name.ToLower() == genre.Name.ToLower())).ToList();

            return movies;
        }

    }
    }
