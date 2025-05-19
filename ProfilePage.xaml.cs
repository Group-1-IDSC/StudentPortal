using CommunityToolkit.Maui.Views;

namespace LoginForm;

public partial class ProfilePage : ContentPage
{
    bool isEditing = false;

    private bool isSidebarVisible = false;
    public ProfilePage()
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
        await ExpandIcon.RotateTo(isExpanded ? 0 : 90, 200, Easing.CubicInOut);

    }


    protected override async void OnAppearing()
    {
        base.OnAppearing();

        // Load profile image from SQLite

        var profile = await DatabaseService.GetLatestProfileAsync();
        if (profile?.ProfileImage != null)
        {
            ProfileImageButton.Source = ImageSource.FromStream(() => new MemoryStream(profile.ProfileImage));
            Console.WriteLine("✅ Loaded saved profile image from DB");
        }
        else
        {
            ProfileImageButton.Source = "profile_avatar.png";
            Console.WriteLine("❌ No profile image found. Using default.");
        }

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
    private async void OnAnnouncementFeedTapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AnnouncementFeed());
    }
    private async void OnProfileImageClicked(object sender, EventArgs e)
    {
        var result = await FilePicker.PickAsync(new PickOptions
        {
            FileTypes = FilePickerFileType.Images,
            PickerTitle = "Select Profile Image"
        });

        if (result != null)
        {
            using var stream = await result.OpenReadAsync();
            using var ms = new MemoryStream();
            await stream.CopyToAsync(ms);
            byte[] imageBytes = ms.ToArray();

            await DatabaseService.SaveOrUpdateProfileImageAsync(imageBytes);
            Console.WriteLine("✅ Image saved to SQLite"); // Add this for confirmation

            ProfileImageButton.Source = ImageSource.FromStream(() => new MemoryStream(imageBytes));
        }
    }









}



