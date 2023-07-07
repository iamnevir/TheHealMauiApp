using MauiReactor;
using Microsoft.Extensions.DependencyInjection;
using SkiaSharp.Views.Maui.Controls.Hosting;
using System;
using System.Net.Http;
using TheHealMauiApp.Pages;
using TheHealMauiApp.Services;

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
            builder.Services.AddHttpClient(TheMealServices.MealHttpClientName, httpClient =>
                httpClient.BaseAddress = new Uri("https://www.themealdb.com/"));
            return builder.Build();
        }
    }
}