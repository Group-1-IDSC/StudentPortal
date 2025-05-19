using CommunityToolkit.Maui.Views;

namespace LoginForm;

public partial class AnnouncementFeed : ContentPage
{

    private bool isSidebarVisible = false;
    public AnnouncementFeed()
    {

        InitializeComponent();
        StartDateTimeUpdater();
    }
    private async void OnStudentInfoTapped(object sender, EventArgs e)
    {
        bool isExpanded = StudentInfoItems.IsVisible;
        StudentInfoItems.IsVisible = !isExpanded;

        // Update icon text
       

        // Smooth rotate animation
        await ExpandIcon.RotateTo(isExpanded ? 0 : 90, 300, Easing.CubicInOut);
    }


    protected override void OnAppearing()
    {
        base.OnAppearing();

        // Debug output
        Console.WriteLine($"Student Info Items Visible: {StudentInfoItems.IsVisible}");
        Console.WriteLine($"Grades item children count: {StudentInfoItems.Children.Count}");

        // Force visibility for testing
        StudentInfoItems.IsVisible = false;
    }
    private void StartDateTimeUpdater()
    {
        Dispatcher.StartTimer(TimeSpan.FromSeconds(1), () =>
        {
            // Update the label with current date and time
            dateTimeLabel.Text = DateTime.Now.ToString("dddd, dd/MM/yyyy  hh:mm:ss tt");
            return true; // return true to keep the timer running
        });
    }
    private void OnToggleSidebar(object sender, TappedEventArgs e)
    {
        isSidebarVisible = !isSidebarVisible;

        // Show/hide sidebar
        Sidebar.IsVisible = isSidebarVisible;

        // Adjust column width
        SidebarColumn.Width = isSidebarVisible ? new GridLength(210) : new GridLength(0);
    }
    private async void OnAssessmentTapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AssessmentPage());
    }
    private void ShowThemePopup(object sender, EventArgs e)
    {
        var popup = new ThemePopup();
        this.ShowPopup(popup); // Requires CommunityToolkit.Maui
    }
    private async void OnWebsiteTapped(object sender, EventArgs e)
    {
        var uri = new Uri("https://www.edukasyon.ph/schools/infotech-development-systems-colleges");
        await Launcher.Default.OpenAsync(uri);
    }
    private async void OnSchedulesTapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SchedulesCOR());
    }
    private async void OnFacultyEvaluationTapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new FacultyEvaluation());
        // OR if using Shell navigation:
        // await Shell.Current.GoToAsync(nameof(FacultyEvaluationPage));
    }
    private async void OnDashboardTapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new DashboardPage());
    }
    private async void OnCalendarTapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CalendarOfEvents());
    }
    private async void OnGradesTapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Grades());
    }
}

