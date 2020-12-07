using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseConnection
{
   public class Customer
    {
        public int Id { get; set; }
        public string Användarnamn { get; set; }
        public string Lösenord { get; set; }
        public string Telefonnummer { get; set; }
        public string Mailaddress { get; set; }
        public string Postaddress { get; set; }
        public virtual List<Rental> Rentals { get; set; }
    }
    
    public class Movie
    {
        public int Id { get; set; }
        public string Filmtitel { get; set; }
        public string Bild { get; set; }
        public virtual List<LeadingActor> LeadingActors { get; set; }
        public virtual List<Genre> Genres { get; set; }
        public virtual List<Rental> Rentals { get; set; }
    }
    
    public class Rental
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Movie Movie { get; set; }

    }
     
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Movie> Movies { get; set; }

    }
    public class LeadingActor
    {
        public int LeadingActorid { get; set; }
        public string First_name { get; set; }
        public string Surname { get; set; }
        public virtual List<Movie> Movies { get; set; }
    }


}
