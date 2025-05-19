namespace LoginForm;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        MainPage = new NavigationPage(new ProfilePage());

        MainPage = new NavigationPage(new MainPage());
    }
}
