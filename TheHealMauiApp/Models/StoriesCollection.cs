

using TheHealMauiApp.Resources.Styles;

namespace TheHealMauiApp.Models;

public record StoriesCollection(string Image, string Mota, Color Mau)
{
    public static StoriesCollection[] Stories = new StoriesCollection
[]
    {
        new     StoriesCollection("like","Tầm quan trọng của công thức nấu ăn",Theme.Lam),
        new     StoriesCollection("diabetes","Cái gì gây ra bệnh tiểu đường?",Colors.Yellow),
        new     StoriesCollection("salad","Công thức nấu ăn cho bệnh tiểu đường là gì?",Theme.Tim),
        new     StoriesCollection("recipe","Các món ăn cho bệnh tiểu đường có dễ làm?",Colors.Red),
        new     StoriesCollection("lunch","Công thức nấu ăn này bao gồm thực phẩm gì",Theme.Green),
    };
}
