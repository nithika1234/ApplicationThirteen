using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ApplicationThirteen
{
    public partial class DeleteConfirmationPage : Window
    {
        public bool IsConfirmed { get; private set; } = false;

        public DeleteConfirmationPage()
        {
            InitializeComponent();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            IsConfirmed = false;
            this.DialogResult = false;
            this.Close();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            IsConfirmed = true;
            this.DialogResult = true;
            this.Close();
        }
    }
}