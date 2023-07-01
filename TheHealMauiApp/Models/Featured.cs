using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHealMauiApp.Models;

public record Featured(string Image,string Name)
{
    public static Featured[] Featureds1 = new Featured[]
    {
        new Featured("healthy","Healthy"),
        new Featured("meat","Thịt gà"),
        new Featured("cake","Bánh ngọt"),
    };
    public static Featured[] Featureds11 = new Featured[]
    {
        new Featured("cooking","Nấu ăn"),
        new Featured("breakfast","Bữa sáng"),
        new Featured("vegetable","Rau xanh"),
    };
}
public record ForYou(string BgImage, string Title)
{
    public static ForYou[] ForYous = new ForYou[]
    {
        new ForYou("bg2","Công thức cho tình trạng sức khỏe của bạn"),
        new ForYou("bg1","Tìm công thức bằng những nguyên liệu bạn có trong bếp"),
        new ForYou("bg3","Video công thức nấu ăn miễn phí"),
    };
}
