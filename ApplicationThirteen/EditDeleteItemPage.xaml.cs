using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ApplicationThirteen
{
    public partial class EditDeleteItemPage : Window
    {
        public EditDeleteItemPage()
        {
            InitializeComponent();
        }

        private void SearchBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (SearchBox.Text == "Search")
            {
                SearchBox.Text = "";
                SearchBox.Foreground = Brushes.Black;
            }
        }

        private void SearchBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SearchBox.Text))
            {
                SearchBox.Text = "Search";
                SearchBox.Foreground = Brushes.Gray;
            }
        }
    }
}
