using System.Windows;

namespace DigitalWorkflowApp
{
    public partial class LoginRegisterPage : Window
    {
        public LoginRegisterPage()
        {
            InitializeComponent();
        }

        // Event handler for Login button
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            // Example validation (replace with actual logic)
            string username = LoginUsernameTextBox.Text;
            string password = LoginPasswordBox.Password;

            if (username == "admin" && password == "password")
            {
                MessageBox.Show("Login successful!", "Login", MessageBoxButton.OK, MessageBoxImage.Information);
                // Navigate to the main application page here
            }
            else
            {
                MessageBox.Show("Invalid credentials. Please try again.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Event handler for Register button
        private void Register_Click(object sender, RoutedEventArgs e)
        {
            string fullName = RegisterNameTextBox.Text;
            string email = RegisterEmailTextBox.Text;
            string password = RegisterPasswordBox.Password;

            // You can validate and save the registration data here
            MessageBox.Show("Registration complete!", "Register", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}