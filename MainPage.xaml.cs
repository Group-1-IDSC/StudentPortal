namespace LoginForm;

public partial class MainPage : ContentPage
{

    public MainPage()
    {

        InitializeComponent();
    }
    private async void OnForgotPasswordTapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ForgotPassword());
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        // Optional: Add login validation logic here

        // Navigate to DashboardPage
        await Navigation.PushAsync(new DashboardPage());
    }

}

