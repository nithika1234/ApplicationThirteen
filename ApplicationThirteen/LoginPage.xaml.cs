using DigitalWorkflowApp;
using System;
using System.Windows;
using System.Windows.Controls;

namespace DigiWorkflowApp
{
    public partial class LoginPage : Window
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string tokenId = TokenIdTextBox.Text;

            if (!string.IsNullOrWhiteSpace(tokenId))
            {
                // Navigate to HomePage
                HomePage homePage = new HomePage();
                homePage.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Please enter a valid token ID.");
            }
        }
    }
}


