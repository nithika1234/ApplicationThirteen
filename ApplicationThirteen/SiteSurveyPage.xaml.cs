using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DigitalWorkflowApp
{
    public partial class SiteSurveyPage : Window
    {
        public SiteSurveyPage()
        {
            InitializeComponent();
            RemarksTextBox.Text = "Insert Remarks Here";
            RemarksTextBox.Foreground = Brushes.Gray;
            RemarksTextBox.FontStyle = FontStyles.Italic;
        }

        private void TakePhoto_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Camera capture functionality not yet implemented.");
        }

        private void UploadPhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Select an Image",
                Filter = "Image files (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                BitmapImage bitmap = new BitmapImage(new Uri(openFileDialog.FileName));
                ImagePreview.Source = bitmap;
                TextPreview.Visibility = Visibility.Collapsed;
                ImagePreview.Visibility = Visibility.Visible;
            }
        }

        private void RemarksTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (RemarksTextBox.Text == "Insert Remarks Here")
            {
                RemarksTextBox.Text = "";
                RemarksTextBox.Foreground = Brushes.Black;
                RemarksTextBox.FontStyle = FontStyles.Normal;
            }
        }

        private void RemarksTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(RemarksTextBox.Text))
            {
                RemarksTextBox.Text = "Insert Remarks Here";
                RemarksTextBox.Foreground = Brushes.Gray;
                RemarksTextBox.FontStyle = FontStyles.Italic;
            }
        }
    }
}
