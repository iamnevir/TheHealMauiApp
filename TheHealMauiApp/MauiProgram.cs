
using MauiReactor;
using Microsoft.Extensions.DependencyInjection;
using SkiaSharp.Views.Maui.Controls.Hosting;
using System;
using System.Net.Http;
using TheHealMauiApp.Pages;
using TheHealMauiApp.Services;
using Xe.AcrylicView;

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
                 .UseAcrylicView()
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
            builder.Services.AddMealServices(new Uri("https://www.themealdb.com/"));
            return builder.Build();
        }
    }
}