﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DatabaseConnection;

namespace Store
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var allGenres = API.GetAllGenres().ToList();

            foreach(var genre in allGenres)
            {
                comboboxGenre.Items.Add(genre.Name.ToString());
            }

            int movie_skip_count = 0;
            int movie_take_count = 30;
            State.Movies = API.GetMovieSlice(movie_skip_count, movie_take_count);

            int column_count = MovieGrid.ColumnDefinitions.Count;

            
            
            int row_count = (int)Math.Ceiling((double)State.Movies.Count / (double)column_count);

            for (int y = 0; y < row_count; y++)
            {
                // Skapa en rad-definition för att bestämma hur hög just denna raden är.
                MovieGrid.RowDefinitions.Add(
                    new RowDefinition() { Height = new GridLength(140, GridUnitType.Pixel)
                    });

                // Lägga till en film i varje cell för en rad
                for (int x = 0; x < column_count; x++)
                {
                    // Räkna ut vilken film vi ska ploppa in härnäst utifrån mina x,y koordinater
                    int i = y * column_count + x;
                    // Kolla så att vi inte försöker fylla mer Grid celler än vi har filmrecords.
                    if (i < State.Movies.Count)
                    {
                        // Hämta ett film record
                        var movie = State.Movies[i];
                        
                        // Försök att skapa en Image Controller(legobit) och
                        // placera den i rätt Grid cell enl. x,y koordinaterna
                        // Skapa en Image som visar filmomslaget
                        var image = new Image()
                        {
                            Cursor = Cursors.Hand, // Visa en 'click me' hand när man hovrar över bilden
                            HorizontalAlignment = HorizontalAlignment.Center,
                            VerticalAlignment = VerticalAlignment.Center,
                            Margin = new Thickness(4, 4, 4, 4),
                        };
                        image.MouseUp += Image_MouseUp;

                        try
                        {
                            image.Source = new BitmapImage(new Uri(movie.Bild)); // Hämta hem bildlänken till RAM
                        }
                        catch (Exception e) when
                            (e is ArgumentNullException ||
                             e is System.IO.FileNotFoundException ||
                             e is UriFormatException)
                        {
                            // Om något gick fel så lägger vi in en placeholder 
                            image.Source = new BitmapImage(new Uri("https://wolper.com.au/wp-content/uploads/2017/10/image-placeholder.jpg"));
                        }

                        // Lägg till Image i Grid
                        MovieGrid.Children.Add(image);

                        // Placera in Image i Grid
                        Grid.SetRow(image, y);
                        Grid.SetColumn(image, x);
                    }
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string GenreName = comboboxGenre.SelectedItem.ToString();
            Genre nGenre = null;
            foreach(var genre in API.GetAllGenres())
            {
                if(genre.Name == GenreName)
                {
                    nGenre = genre;
                }
            }
            if (nGenre != null)
            {
                var movies = API.GetMovieByGenre(nGenre);
                MovieGrid.Children.Clear();
                int x = 0, y = 0;
                foreach(Movie movie in movies)
                {
                    
                    var image = new Image()
                    {
                        Cursor = Cursors.Hand, // Visa en 'click me' hand när man hovrar över bilden
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center,
                        Margin = new Thickness(4, 4, 4, 4),
                    };
                    image.MouseUp += Image_MouseUp;

                    try
                    {
                        image.Source = new BitmapImage(new Uri(movie.Bild)); // Hämta hem bildlänken till RAM
                    }
                    catch (Exception Guns) when
                        (Guns is ArgumentNullException ||
                         Guns is System.IO.FileNotFoundException ||
                         Guns is UriFormatException)
                    {
                        // Om något gick fel så lägger vi in en placeholder 
                        image.Source = new BitmapImage(new Uri("https://wolper.com.au/wp-content/uploads/2017/10/image-placeholder.jpg"));
                    }
                    MovieGrid.Children.Add(image);
                    Grid.SetRow(image, y);
                    Grid.SetColumn(image, x);
                    x++;
                }
            }

        }
    }
}
