using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace ApplicationThirteen
{
    public partial class ViewEditItemPage : Window
    {
        public ViewEditItemPage()
        {
            InitializeComponent();

            // Set image path (use a relative path and make sure image is included in your project)
            string imagePath = "Assets/sample_image.jpg"; // Replace with your actual image
            ItemImage.Source = new BitmapImage(new Uri(imagePath, UriKind.Relative));
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // Or navigate back
        }

        private void View_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Viewing image...");
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Editing image...");
        }
    }
}
