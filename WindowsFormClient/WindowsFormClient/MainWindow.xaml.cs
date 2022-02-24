using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using WindowsFormClient.Managers;
using WindowsFormClient.Models;

namespace WindowsFormClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IMovieListCommandManager _movieListCommandManager;
        public MainWindow()
        {
            _movieListCommandManager = new HttpManager(); 
            InitializeComponent();
            var movies = _movieListCommandManager.GetMovieList();
            foreach (var title in movies)
            {
                var item = new ListItem(title.Name, title.Rating.ToString(), title.Id, this);
                item.AddButton.Visibility = Visibility.Collapsed;
                item.EmptyBox.Visibility= Visibility.Collapsed;
                item.StarImage.Visibility = Visibility.Visible;
                item.EditButton.Visibility = Visibility.Visible;
                item.DeleteButton.Visibility = Visibility.Visible;
                Movies.Children.Add(item);
            }

            Movies.Children.Add(new ListItem("", "", null, this));
        }
    }
}
