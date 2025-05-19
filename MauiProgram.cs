using Syncfusion.Maui.Core.Hosting;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;

namespace LoginForm;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        builder
            .ConfigureSyncfusionCore()
            .UseMauiApp<App>() // Must be first in the chain
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Services.AddSingleton<MainPage>();
#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}