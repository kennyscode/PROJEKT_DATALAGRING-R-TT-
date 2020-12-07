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
                ctx.RemoveRange(ctx.Customers);
                ctx.RemoveRange(ctx.Movies);
                ctx.RemoveRange(ctx.Genres);
                ctx.RemoveRange(ctx.LeadingActors);
                ctx.RemoveRange(ctx.Rentals);


                List<Customer> Customers = new List<Customer>
                {
                    new Customer { Användarnamn = "Masterape32", Lösenord = "rZ5JCRrZ96yTaEau", Mailaddress = "hehhek@hotmail.com", Telefonnummer = "0739615518", Postaddress = "30257" },
                    new Customer { Användarnamn = "Kingen321", Lösenord = "hYMfxdVLJJ64Hv2C", Mailaddress = "xopemi1429@menece.com", Telefonnummer = "073152282", Postaddress = "30297" },
                    new Customer { Användarnamn = "Våldmottjänsteman", Lösenord = "PxQyxL5F8nJZAVep", Mailaddress = "bymmupeto-5495@yopmail.com", Telefonnummer = "0737123710", Postaddress = "30257" },
                    new Customer { Användarnamn = "Starwarslover123", Lösenord = "AskiipSiiDmmx1456AiaplfX", Mailaddress = "excellentplay44@hotmail.se", Telefonnummer = "0737885521", Postaddress = "30232" },
                    new Customer { Användarnamn = "quencypromes", Lösenord = "h3wZB9zYMJLscJNE", Mailaddress = "dasadsads@hotmail.com", Telefonnummer = "0736669953", Postaddress = "30296"  },
                    new Customer { Användarnamn = "adamatraore", Lösenord = "a2MvHQLr7tk5PMNz", Mailaddress = "shenashena@hotmail.com", Telefonnummer = "0734412331", Postaddress = "30245"  },
                    new Customer { Användarnamn = "marioluigi", Lösenord = "5fAAT8gSZy6qdbMB", Mailaddress = "beast@hotmail.com", Telefonnummer = "0735555112", Postaddress = "30227"  },
                    new Customer { Användarnamn = "hehe3333", Lösenord = "2yPpCQ8r4u2wv3Nd", Mailaddress = "lmfaoguy@hotmail.com", Telefonnummer = "0736661122", Postaddress = "30259"  },
                    new Customer { Användarnamn = "netflixandc", Lösenord = "tLxS5KuFjRre5cyc", Mailaddress = "whatagod@hotmail.com", Telefonnummer = "073612412", Postaddress = "30212"  },
                    new Customer { Användarnamn = "apestogetherstrong", Lösenord = "aeJg4M7efpxS5MBY", Mailaddress = "johndoe@hotmail.com", Telefonnummer = "0737724354", Postaddress = "30257" },
                    new Customer { Användarnamn = "woooo", Lösenord = "WYZ8p6TWq6cj2YSd", Mailaddress = "meetthewho@hotmail.com", Telefonnummer = "0735435325", Postaddress = "30250"  },
                    new Customer { Användarnamn = "ratioed", Lösenord = "qk5DdTQV7fNpFepR", Mailaddress = "whatsupguy@hotmail.com", Telefonnummer = "0734411243", Postaddress = "30249"  },
                    new Customer { Användarnamn = "slarti", Lösenord = "ataT6sC8GJCgtWwb", Mailaddress = "videogames@hotmail.com", Telefonnummer = "0735382943", Postaddress = "30269"  },
                    new Customer { Användarnamn = "bayerneverlusen", Lösenord = "XP43vz9dHwq36vKb", Mailaddress = "motorised@hotmail.com", Telefonnummer = "0735512579 ", Postaddress = "30232" },
                    new Customer { Användarnamn = "kisssss", Lösenord = "qZX77YzcWPjX22e4", Mailaddress = "yeehaw@hotmail.com", Telefonnummer = "0736321675", Postaddress = "30254"  },
                    new Customer { Användarnamn = "hocuspocus", Lösenord = "ak57kTBJxJzNrNg9", Mailaddress = "sheesh@hotmail.com", Telefonnummer = "0739234992", Postaddress = "30253"  },
                    new Customer { Användarnamn = "mbappe", Lösenord = "rVqMb7aAXuUmbssU", Mailaddress = "wooohooo@hotmail.com", Telefonnummer = "07323483920", Postaddress = "30287"  },
                    new Customer { Användarnamn = "electricfunk", Lösenord = "hLfnmxr7FyRLF3nv", Mailaddress = "rayye@hotmail.com", Telefonnummer = "0735551234", Postaddress = "30217"  },
                    new Customer { Användarnamn = "ebfranvallas", Lösenord = "pqEhr4xeASD3B6ga", Mailaddress = "bayye@hotmail.com", Telefonnummer = "0737993450", Postaddress = "30227"  },
                    new Customer { Användarnamn = "sheeesh", Lösenord = "4Jgf5a6qmzNqwEFH", Mailaddress = "magnus.uggla@hotmail.com", Telefonnummer = "0731133561", Postaddress = "30247"  }

                };
                ctx.AddRange(Customers);


                List<Genre> Genres = new List<Genre>
                {
                    new Genre {Name = "Action"}, //0
                    new Genre {Name = "Adventure"}, //1
                    new Genre {Name = "Animation"}, //2
                    new Genre {Name = "Biography"}, //3
                    new Genre {Name = "Crime"}, //4
                    new Genre {Name = "Comedy"}, //5
                    new Genre {Name = "Drama"}, //6
                    new Genre {Name = "Family"}, //7
                    new Genre {Name = "Fantasy"}, //8
                    new Genre {Name = "Mystery"}, //9
                    new Genre {Name = "Sci-Fi"}, //10
                    new Genre {Name = "Thriller"}, //11
                    new Genre {Name = "Romance"}, //12
                    new Genre {Name = "Musical"}, //13
                    new Genre {Name = "War"}, //14
                    new Genre {Name = "Horror"} //15 test
                    
                };
                ctx.AddRange(Genres);

                List<LeadingActor> LeadingActors = new List<LeadingActor>
                {
                    new LeadingActor {First_name ="Leonardo",    Surname ="DiCaprio"}, //0
                    new LeadingActor {First_name ="Tom",         Surname ="Hanks"}, //1
                    new LeadingActor {First_name ="Denzel",      Surname ="Washington"}, //2
                    new LeadingActor {First_name ="Al",          Surname ="Pacino"}, //3
                    new LeadingActor {First_name ="Anthony",     Surname ="Hopkins"}, //4
                    new LeadingActor {First_name ="Leonardo",    Surname ="DiCaprio"}, //5
                    new LeadingActor {First_name ="Marlon",      Surname ="Brando"}, //6
                    new LeadingActor {First_name ="Morgan ",     Surname ="Freeman"}, //7
                    new LeadingActor {First_name ="Dustin ",     Surname ="Hoffman"}, //8
                    new LeadingActor {First_name ="Gary ",       Surname ="Oldman"}, //9
                    new LeadingActor {First_name ="Joaquin ",    Surname ="Pheonix"}, //10
                    new LeadingActor {First_name ="Christian ",  Surname ="Bale"}, //11
                    new LeadingActor {First_name ="Jack ",       Surname ="Nicholson"} //12

                };
                ctx.AddRange(LeadingActors);



                List<Movie> movies = new List<Movie>
                {
                    new Movie { Filmtitel = "Inception", LeadingActors = new List<LeadingActor> { LeadingActors[5]}, Genres = new List<Genre> { Genres[0], Genres[4], Genres[10] }, Bild = "https://m.media-amazon.com/images/M/MV5BNzA5ZDNlZWMtM2NhNS00NDJjLTk4NDItYTRmY2EwMWZlMTY3XkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_UX182_CR0,0,182,268_AL_.jpg" },
                    new Movie { Filmtitel = "The Dark Knight", LeadingActors = new List<LeadingActor> { LeadingActors[0], LeadingActors[1] }, Genres = new List<Genre> { Genres[0], Genres[1], Genres[3], Genres[11] }, Bild = "https://m.media-amazon.com/images/M/MV5BMTMxNTMwODM0NF5BMl5BanBnXkFtZTcwODAyMTk2Mw@@._V1_UX182_CR0,0,182,268_AL_.jpg" },
                    new Movie { Filmtitel = "The Equalizer", LeadingActors = new List<LeadingActor> { LeadingActors[2] }, Genres = new List<Genre> { Genres[1], Genres[11] }, Bild = "https://images-na.ssl-images-amazon.com/images/I/51GmLzvLbCL._AC_.jpg" },
                    new Movie { Filmtitel = "The Godfather", LeadingActors = new List<LeadingActor> { LeadingActors[3], LeadingActors[6] }, Genres = new List<Genre> { Genres[4], Genres[4] }, Bild = "https://images-na.ssl-images-amazon.com/images/I/510L5ypQBdL._AC_SL1024_.jpg" },
                    new Movie { Filmtitel = "Scarface", LeadingActors = new List<LeadingActor> { LeadingActors[3] }, Genres = new List<Genre> { Genres[4], Genres[4] }, Bild = "https://images-na.ssl-images-amazon.com/images/I/61luAu5kqTL._AC_SL1024_.jpg" },
                    new Movie { Filmtitel = "The Shining", LeadingActors = new List<LeadingActor> { LeadingActors[12] }, Genres = new List<Genre> { Genres[15], Genres[9] }, Bild = "https://images-na.ssl-images-amazon.com/images/I/41AjA9SkVQL._AC_.jpg" },
                    new Movie { Filmtitel = "Joker", LeadingActors = new List<LeadingActor> { LeadingActors[10] }, Genres = new List<Genre> { Genres[4], Genres[6] }, Bild = "https://images-na.ssl-images-amazon.com/images/I/61c8%2Bf32PJL._AC_SL1008_.jpg" },

                };
                ctx.AddRange(movies);

                List<Rental> Rentals = new List<Rental>
                {

                };
                ctx.AddRange(Rentals);

                ctx.SaveChanges();
            }
        }
    }
}


/*
 * var lines = File.ReadAllLines(@"..\..\..\SeedData\MovieGenre.csv");
   for (int i = 1; i < 200; i++)
 imdbId,Imdb Link,Title,IMDB Score,Genre,Poster
var cells = lines[i].Split(',');

var url = cells[5].Trim('"');

// Hoppa över alla icke-fungerande url:erer
try { var test = new Uri(url); }
catch (Exception) { continue; }

movies.Add(new Movie { Filmtitel = cells[2], Bild = url });
*/