using MauiReactor;
using SkiaSharp.Views.Maui.Controls.Hosting;
using TheHealMauiApp.Pages;


namespace TheHealMauiApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiReactorApp<MainPage>()
                .UseSkiaSharp()
#if DEBUG
            .EnableMauiReactorHotReload()
#endif
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-SemiBold.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-SemiBold.ttf", "OpenSansSemiBold");
                    fonts.AddFont("Poppins-Bold.ttf", "PoppinsBold");
                });
            Controls.Native.BorderlessEntry.Configure();
            return builder.Build();
        }
    }
}