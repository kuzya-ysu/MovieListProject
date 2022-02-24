using System;
using System.Collections.Generic;
using System.Text;
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
    /// Interaction logic for ListItem.xaml
    /// </summary>
    public partial class ListItem: UserControl
    {
        private IMovieListCommandManager _movieListCommandManager;
        private int? _titleId;
        private MainWindow _mainWindow;
        public ListItem(string text, string rating, int? titleId, MainWindow mainWindow)
        {
            _titleId = titleId;
            _mainWindow = mainWindow;
            InitializeComponent();
            NameTextBox.Text= text;
            RatingTextBox.Text = rating;
            _movieListCommandManager = new HttpManager();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddButton.Visibility = Visibility.Collapsed;
            EmptyBox.Visibility=Visibility.Collapsed;
            NameTextBox.Background = new SolidColorBrush(Color.FromRgb(76, 66, 120));
            NameTextBox.MinWidth = 220;
            StarImage.Visibility = Visibility.Visible;
            RatingTextBox.Background = new SolidColorBrush(Color.FromRgb(76, 66, 120));
            AcceptButton.Visibility = Visibility.Visible;
            CancelButton.Visibility = Visibility.Visible;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            AddButton.Visibility = Visibility.Visible;
            EmptyBox.Visibility = Visibility.Visible;
            var transparentBrush = new SolidColorBrush(Color.FromRgb(76, 66, 120))
            {
                Opacity = 0
            };
            NameTextBox.Background = transparentBrush;
            NameTextBox.MinWidth = 0;
            StarImage.Visibility = Visibility.Collapsed;
            RatingTextBox.Background = transparentBrush;
            AcceptButton.Visibility = Visibility.Collapsed;
            CancelButton.Visibility = Visibility.Collapsed;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            _movieListCommandManager.DeleteTitle(_titleId.Value);
            _mainWindow = new MainWindow();
            _mainWindow.Show();
        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            if (_titleId == null)
            {
                var name = NameTextBox.Text;
                var rating = int.Parse(RatingTextBox.Text);
                var title = new Title { Name = name, Rating = rating };
                _movieListCommandManager.CreateTitle(title);
            }
            else
            {
                var name = NameTextBox.Text;
                var rating = int.Parse(RatingTextBox.Text);
                var title = new Title { Name = name, Rating = rating };
                _movieListCommandManager.UpdateTitle(_titleId.Value,title);
            }

            _mainWindow = new MainWindow();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            EditButton.Visibility = Visibility.Collapsed;
            DeleteButton.Visibility = Visibility.Collapsed;
            NameTextBox.Background = new SolidColorBrush(Color.FromRgb(76, 66, 120));
            NameTextBox.MinWidth = 220;
            StarImage.Visibility = Visibility.Visible;
            RatingTextBox.Background = new SolidColorBrush(Color.FromRgb(76, 66, 120));
            AcceptButton.Visibility = Visibility.Visible;
            CancelButton.Visibility = Visibility.Visible;
            _mainWindow = new MainWindow();
        }
    }
}
