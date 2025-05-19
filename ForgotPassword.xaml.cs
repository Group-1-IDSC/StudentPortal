namespace LoginForm;

public partial class ForgotPassword : ContentPage
{
	public ForgotPassword()
	{
		InitializeComponent();
	}
    private async void OnBackToLoginClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }

}