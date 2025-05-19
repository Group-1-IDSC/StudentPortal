using CommunityToolkit.Maui.Views;
using System.Collections.ObjectModel;


namespace LoginForm;

    public class ScheduleItem
{
    public string Code { get; set; }
    public string Course { get; set; }
    public string TimeSchedule { get; set; }
    public string Room { get; set; }
    public string Instructor { get; set; }
}
public partial class SchedulesCOR : ContentPage
{
    public ObservableCollection<ScheduleItem> Schedules { get; set; }
    private bool isSidebarVisible = false;

    public SchedulesCOR()
	{
		InitializeComponent();
        StartDateTimeUpdater();

        Schedules = new ObservableCollection<ScheduleItem>
            {
                new ScheduleItem
                {
                    Code = "Educ 5",
                    Course = "The Teacher and the School Curriculum",
                    TimeSchedule = "Tue Thu 02:30 PM - 04:00 PM",
                    Room = "SB 15",
                    Instructor = "Capate, Ruby Liza M."
                },
                new ScheduleItem
                {
                    Code = "Eng Ed 9",
                    Course = "Children and Adolescent Literature",
                    TimeSchedule = "Tue Thu 04:00 PM - 05:30 PM",
                    Room = "SB 4",
                    Instructor = "Albao, Evelyn R."
                },
                new ScheduleItem
                {
                    Code = "Eng Ed 12",
                    Course = "Remedial Instruction",
                    TimeSchedule = "Tue 05:30 PM - 08:30 PM",
                    Room = "SB 4",
                    Instructor = "Clet, Gemma"
                },
              
                 new ScheduleItem
                {
                    Code = "Eng Ed 12",
                    Course = "Remedial Instruction",
                    TimeSchedule = "Tue 05:30 PM - 08:30 PM",
                    Room = "SB 4",
                    Instructor = "Clet, Gemma"
                }// Add remaining schedule items
            };

        // Bind the collection to the UI (if using data binding)
        BindingContext = this;
    }

    private void OnSemesterSelectorTapped(object sender, TappedEventArgs e)
    {
        // Implement semester selection logic
        // Could show a popup or another page to select different semesters
    }
    private async void OnStudentInfoTapped(object sender, EventArgs e)
    {
        bool isExpanded = StudentInfoItems.IsVisible;
        StudentInfoItems.IsVisible = !isExpanded;

        // Update icon text


        // Smooth rotate animation
        await ExpandIcon.RotateTo(isExpanded ? 0 : 90, 200, Easing.CubicInOut);
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
    private async void OnDashboardTapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new DashboardPage());
    }
    private async void OnWebsiteTapped(object sender, EventArgs e)
    {
        var uri = new Uri("https://www.edukasyon.ph/schools/infotech-development-systems-colleges");
        await Launcher.Default.OpenAsync(uri);
    }
    private async void OnFacultyEvaluationTapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new FacultyEvaluation());
        // OR if using Shell navigation:
        // await Shell.Current.GoToAsync(nameof(FacultyEvaluationPage));
    }
    private async void OnCalendarTapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CalendarOfEvents());
    }
    private async void OnSchedulesTapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SchedulesCOR());
    }
    private async void OnGradesTapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Grades());
    }


}
