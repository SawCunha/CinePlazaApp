using CinePlazaApp.functions;
using CinePlazaApp.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CinePlazaApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            gera_movies();
        }

        public async void gera_movies()
        {
            Movies movies = await ProcessaHTTP.processaAPI();
            await new MessageDialog(movies.week).ShowAsync();
        }

        private void gera_list_movies()
        {

        }

        private Canvas cria_canvas_movie(Movie movie)
        { /*< Canvas Height = "100" Width = "328" >
               < Image x: Name = "image" Height = "91" Canvas.Left = "6" Canvas.Top = "5" Width = "100" />
               < TextBlock x: Name = "textBlock" Canvas.Left = "118" TextWrapping = "Wrap" Text = "TextBlock" Canvas.Top = "10" Width = "201" Foreground = "Red" Height = "38" SelectionHighlightColor = "#FFFFFDFD" />
               < TextBlock x: Name = "textBlock1" Canvas.Left = "119" TextWrapping = "Wrap" Text = "TextBlock" Canvas.Top = "49" Width = "202" Height = "46" Foreground = "Red" />
            </ Canvas >*/
            return null;
            
        }
    }
}
