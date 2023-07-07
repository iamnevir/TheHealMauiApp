using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Net.Http;
using TheHealMauiApp.Models;

namespace TheHealMauiApp.Services;

public class TheMealServices
{
    public const string MealHttpClientName = "TheMealServices";
    readonly IHttpClientFactory _httpClientFactory;
    public TheMealServices(IHttpClientFactory httpClientFactory)
    { _httpClientFactory = httpClientFactory; }
    HttpClient _httpClient => _httpClientFactory.CreateClient(MealHttpClientName);
    
    public async Task<IEnumerable<Category>> GetCategoryAsync()
    {
        var categories = await _httpClient.GetFromJsonAsync<CategoriesList>($"{TheMealUrl.Category}");
        return categories.Categories.Select(r => r.ToCategoryObject());
    }
}
public static class TheMealUrl
{
    public const string Category = "api/json/v1/1/categories.php";
}
public class CategoriesList
{
    public CategoryResult[] Categories { get; set; }
}
public class CategoryResult
{
    public string idCategory { get; set; }

    public string strCategory { get; set; }
    public string strCategoryThumb { get; set; }
    public string strCategoryDescription { get; set; }

    public Category ToCategoryObject() =>
        new()
        {
            Id = idCategory,
            Name = strCategory,
            Thumnail = strCategoryThumb,
            Description = strCategoryDescription
        };

}