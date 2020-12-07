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

                ctx.AddRange(new List<Customer> {
                    new Customer { Användarnamn = "Masterape32", Mailaddress = "hehhek@hotmail.com", Telefonnummer = "0739615518", Postaddress = "30257", Lösenord = "rZ5JCRrZ96yTaEau"  },
                    new Customer { Användarnamn = "Kingen321", Mailaddress = "xopemi1429@menece.com", Telefonnummer = "073152282", Postaddress = "30297", Lösenord = "hYMfxdVLJJ64Hv2C"  },
                    new Customer { Användarnamn = "Våldmottjänsteman", Mailaddress = "bymmupeto-5495@yopmail.com", Telefonnummer = "0737123710", Postaddress = "30257", Lösenord = "UNaw4zFhx4nMZq9q"  },
                    new Customer { Användarnamn = "Starwarslover123", Mailaddress = "excellentplay44@hotmail.se", Telefonnummer = "0737885521", Postaddress = "30257", Lösenord = "PxQyxL5F8nJZAVep"  },
                    new Customer { Användarnamn = "quencypromes", Mailaddress = "dasadsads@hotmail.com", Telefonnummer = "0736669953", Postaddress = "30296", Lösenord = "h3wZB9zYMJLscJNE"  },
                    new Customer { Användarnamn = "adamatraore", Mailaddress = "kingen123@hotmail.com", Telefonnummer = "0734412331", Postaddress = "30245", Lösenord = "a2MvHQLr7tk5PMNz"  },
                    new Customer { Användarnamn = "marioluigi", Mailaddress = "beast@hotmail.com", Telefonnummer = "0735555112", Postaddress = "30227", Lösenord = "5fAAT8gSZy6qdbMB"  },
                    new Customer { Användarnamn = "hehe3333", Mailaddress = "lmfaoguy@hotmail.com", Telefonnummer = "0736661122", Postaddress = "30259", Lösenord = "2yPpCQ8r4u2wv3Nd"  },
                    new Customer { Användarnamn = "netflixandc", Mailaddress = "whatagod@hotmail.com", Telefonnummer = "073612412", Postaddress = "30212", Lösenord = "tLxS5KuFjRre5cyc"  },
                    new Customer { Användarnamn = "apestogetherstrong", Mailaddress = "johndoe@hotmail.com", Telefonnummer = "0737724354", Postaddress = "30257", Lösenord = "aeJg4M7efpxS5MBY"  },
                    new Customer { Användarnamn = "woooo", Mailaddress = "meetthewho@hotmail.com", Telefonnummer = "0735435325", Postaddress = "30250", Lösenord = "WYZ8p6TWq6cj2YSd"  },
                    new Customer { Användarnamn = "ratioed", Mailaddress = "whatsupguy@hotmail.com", Telefonnummer = "0734411243", Postaddress = "30249", Lösenord = "qk5DdTQV7fNpFepR"  },
                    new Customer { Användarnamn = "slarti", Mailaddress = "videogames@hotmail.com", Telefonnummer = "0735382943", Postaddress = "30269", Lösenord = "ataT6sC8GJCgtWwb"  },
                    new Customer { Användarnamn = "bayerneverlusen", Mailaddress = "motorised@hotmail.com", Telefonnummer = "0735512579", Postaddress = "30232", Lösenord = "XP43vz9dHwq36vKb"  },
                    new Customer { Användarnamn = "kisssss", Mailaddress = "yeehaw@hotmail.com", Telefonnummer = "0736321675", Postaddress = "30254", Lösenord = "qZX77YzcWPjX22e4"  },
                    new Customer { Användarnamn = "hocuspocus", Mailaddress = "sheesh@hotmail.com", Telefonnummer = "0739234992", Postaddress = "30253", Lösenord = "ak57kTBJxJzNrNg9"  },
                    new Customer { Användarnamn = "mbappe", Mailaddress = "wooohooo@hotmail.com", Telefonnummer = "07323483920", Postaddress = "30287", Lösenord = "rVqMb7aAXuUmbssU"  },
                    new Customer { Användarnamn = "electricfunk", Mailaddress = "rayye@hotmail.com", Telefonnummer = "0735551234", Postaddress = "30217", Lösenord = "hLfnmxr7FyRLF3nv"  },
                    new Customer { Användarnamn = "ebfranvallas", Mailaddress = "bayye@hotmail.com", Telefonnummer = "0737993450", Postaddress = "30227", Lösenord = "pqEhr4xeASD3B6ga"  },
                    new Customer { Användarnamn = "sheeesh", Mailaddress = "magnus.uggla@hotmail.com", Telefonnummer = "0731133561", Postaddress = "30247", Lösenord = "4Jgf5a6qmzNqwEFH"  }

                });

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

                ctx.SaveChanges();
            }
        }
    }
}
