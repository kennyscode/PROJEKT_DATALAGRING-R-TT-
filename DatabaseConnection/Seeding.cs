﻿using System;
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
                    new LeadingActor {First_name ="Leonardo",    Surname ="DiCaprio"}
                    new LeadingActor {First_name ="Tom",         Surname ="Hanks"}
                    new LeadingActor {First_name ="Denzel",      Surname ="Washington"}
                    new LeadingActor {First_name ="Al",          Surname ="Pacino"}
                    new LeadingActor {First_name ="Anthony",     Surname ="Hopkins"}
                    new LeadingActor {First_name ="Leonardo",    Surname ="DiCaprio"}
                    new LeadingActor {First_name ="Marlon",      Surname ="Brando"}
                    new LeadingActor {First_name ="Morgan ",     Surname ="Freeman"}
                    new LeadingActor {First_name ="Dustin ",     Surname ="Hoffman"}
                    new LeadingActor {First_name ="Gary ",       Surname ="Oldman"}
                    new LeadingActor {First_name ="Joaquin ",    Surname ="Pheonix"}
                    new LeadingActor {First_name ="Christian ",  Surname ="Bale"}
                    new LeadingActor {First_name ="Jack ",       Surname ="Nicholson"}





                };
                ctx.AddRange(LeadingActors);


                ctx.SaveChanges();
            }
        }
    }
}
