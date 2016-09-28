using CinePlazaApp.functions;
using CinePlazaApp.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Data.Xml.Dom;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Notifications;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

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
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
            inicializa_app();
            RegisterService.registerService();
        }

        private async void inicializa_app()
        {
           
            if (verifica_conexao())
                gera_movies();
            else
                //Transfere para tela informada
                await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => Frame.Navigate(typeof(ConnectionErro)));
        }

        private bool verifica_conexao()
        {
            try
            {
                /*Verfica se o smartphone está conectado a internet caso
                    esteja trasnfere para a tela de pesquisa, caso não ele
                    informa o usuario que tem que estar conectado 
                */
                if (!NetworkInterface.GetIsNetworkAvailable())
                {
                    return false;
                }
                else
                    return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async void gera_movies()
        {
            Movies movies = null;
            movies = await ProcessaHTTP.processaAPI();
            while (movies == null)
            {
                myProgressRing.Visibility = Visibility.Visible;
                await Task.Delay(TimeSpan.FromSeconds(5));
            }
            myProgressRing.Visibility = Visibility.Collapsed;
            week.Text = movies.week;
            moviesObj = movies.movies;
            gera_list_movies(movies);
        }

        private void gera_list_movies(Movies movies)
        {
            foreach (Movie movie in movies.movies)
            {
                listMovies.Items.Add(cria_canvas_movie(movie));
                listMovies.Items.Add(cria_separador());
            }
        }

        private Canvas cria_separador()
        {
            Canvas canvas = new Canvas();
            canvas.Height = 2;
            return canvas;
        }

        private Canvas cria_canvas_movie(Movie movie)
        { /*< Canvas Height = "100" Width = "328" >
               < Image x: Name = "image" Height = "91" Canvas.Left = "6" Canvas.Top = "5" Width = "100" />
               < TextBlock x: Name = "textBlock" Canvas.Left = "118" TextWrapping = "Wrap" Text = "TextBlock" Canvas.Top = "10" Width = "201" Foreground = "Red" Height = "38" SelectionHighlightColor = "#FFFFFDFD" />
               < TextBlock x: Name = "textBlock1" Canvas.Left = "119" TextWrapping = "Wrap" Text = "TextBlock" Canvas.Top = "49" Width = "202" Height = "46" Foreground = "Red" />
            </ Canvas >*/

            Canvas canvasMovie = new Canvas();

            Rectangle r = new Rectangle();
            r.Height = 107;
            r.Width = listMovies.ActualWidth;
            r.Fill = new SolidColorBrush(Color.FromArgb(100, 22,22,22));

            TextBlock nameMovie = new TextBlock();
            nameMovie.Text = movie.name;
            nameMovie.FontSize = 18;
            nameMovie.TextWrapping = TextWrapping.Wrap;
            nameMovie.Foreground = new SolidColorBrush(Colors.White);
            Canvas.SetLeft(nameMovie, 120);
            Canvas.SetTop(nameMovie, 10);

            TextBlock genreMovie = new TextBlock();
            genreMovie.Text = movie.genre;
            genreMovie.FontSize = 18;
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
            canvasMovie.Height = 107;
            Canvas.SetLeft(r, 0);
            Canvas.SetTop(r, 0);
            canvasMovie.Children.Add(r);
            canvasMovie.Children.Add(nameMovie);
            canvasMovie.Children.Add(genreMovie);
            canvasMovie.Children.Add(image);

            canvasMovie.Name = movie.name;
            canvasMovie.PointerReleased += CanvasMovies_Released;

            return canvasMovie;
        }

        private void CanvasMovies_Released(object sender, PointerRoutedEventArgs e)
        {
            Canvas canvas = (Canvas)sender;
            foreach (Movie movie in moviesObj)
            {
                if (movie.name.Equals(canvas.Name))
                    Frame.Navigate(typeof(MoviePage), movie);
            }
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            //Obtem referencia do app para finalizar
            Application.Current.Exit();
        }
    }
}
