using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheHealMauiApp.Models;

namespace TheHealMauiApp.Services;

public interface ITheMealServices
{
    Task<IEnumerable<Category>> GetCategoryAsync();
}
public static class ServiceCollectionExtensions
{
    public static void AddMealServices(this IServiceCollection services, Uri serverUri)
    {
        services.AddSingleton<ITheMealServices, TheMealServices>();

        services.AddHttpClient("TheMealServices", httpClient =>
        {
            httpClient.BaseAddress = serverUri;
        });
    }
}