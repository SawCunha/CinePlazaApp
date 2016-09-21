using CinePlazaApp.functions;
using CinePlazaApp.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CinePlazaApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        private List<Movie> moviesObj;

        public MainPage()
        {
            this.InitializeComponent();

            gera_movies();
        }

        public async void gera_movies()
        {
            Movies movies = await ProcessaHTTP.processaAPI();
            week.Text = movies.week;
            moviesObj = movies.movies;
            gera_list_movies(movies);
        }

        private void gera_list_movies(Movies movies)
        {
            foreach (Movie movie in movies.movies)
            {
                listMovies.Items.Add(cria_canvas_movie(movie));
            }
        }

        private Canvas cria_canvas_movie(Movie movie)
        { /*< Canvas Height = "100" Width = "328" >
               < Image x: Name = "image" Height = "91" Canvas.Left = "6" Canvas.Top = "5" Width = "100" />
               < TextBlock x: Name = "textBlock" Canvas.Left = "118" TextWrapping = "Wrap" Text = "TextBlock" Canvas.Top = "10" Width = "201" Foreground = "Red" Height = "38" SelectionHighlightColor = "#FFFFFDFD" />
               < TextBlock x: Name = "textBlock1" Canvas.Left = "119" TextWrapping = "Wrap" Text = "TextBlock" Canvas.Top = "49" Width = "202" Height = "46" Foreground = "Red" />
            </ Canvas >*/

            Canvas canvasMovie = new Canvas();

            TextBlock nameMovie = new TextBlock();
            nameMovie.Text = movie.name;
            nameMovie.FontSize = 25;
            nameMovie.TextWrapping = TextWrapping.Wrap;
            nameMovie.Foreground = new SolidColorBrush(Colors.White);
            Canvas.SetLeft(nameMovie, 120);
            Canvas.SetTop(nameMovie, 10);

            TextBlock genreMovie = new TextBlock();
            genreMovie.Text = movie.genre;
            genreMovie.FontSize = 25;
            genreMovie.TextWrapping = TextWrapping.Wrap;
            genreMovie.Foreground = new SolidColorBrush(Colors.White);
            Canvas.SetLeft(genreMovie, 120);
            Canvas.SetTop(genreMovie, 49);

            //Define a Imagem e a posição dela no canvas...
            Image image = new Image();
            image.Width = 115;
            image.Height = 100;
            image.Source = new BitmapImage(new Uri(movie.cover));
            Canvas.SetLeft(image, 6);
            Canvas.SetTop(image, 5);

            canvasMovie.Height = 105;

            canvasMovie.Children.Add(nameMovie);
            canvasMovie.Children.Add(genreMovie);
            canvasMovie.Children.Add(image);
            canvasMovie.Name = movie.name;
            canvasMovie.DoubleTapped += CanvasMovie_DoubleTapped;

            return canvasMovie;  
        }

        private void CanvasMovie_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            Canvas canvas = (Canvas)sender;
            foreach (Movie movie in moviesObj)
            {
                if(movie.name.Equals(canvas.Name))
                    Frame.Navigate(typeof(MoviePage),movie);
            }
            
        }
    }
}
