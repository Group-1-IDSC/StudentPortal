using CommunityToolkit.Maui.Views;

namespace LoginForm;

public partial class ThemePopup : Popup
{
    public ThemePopup()
    {
        InitializeComponent();
    }

    private void SignOut(object sender, EventArgs e)
    {
        Application.Current.MainPage = new NavigationPage(new MainPage());
    }



    private void OnClosePopup(object sender, EventArgs e)
    {
        Close();
    }
    private async void OnProfileTapped(object sender, EventArgs e)
    {
        await Application.Current.MainPage.Navigation.PushAsync(new ProfilePage());
    }

}
