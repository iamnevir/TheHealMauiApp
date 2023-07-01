using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHealMauiApp.Models;

public record SearchOption(string Title)
{
    public static SearchOption[] AnKieng = new SearchOption[]
    {
        new SearchOption("Thuần chay"),
        new SearchOption("Không đường"),
        new SearchOption("Ít Fat"),
        new SearchOption("Ít Carb"),
        new SearchOption("Không dầu"),
    };
    public static SearchOption[] MienPhi = new SearchOption[]
    {
        new SearchOption("Salad"),
        new SearchOption("Nước sạch"),
        new SearchOption("Rau xanh"),
        new SearchOption("Hoa quả"),
    };
    public static SearchOption[] Protein = new SearchOption[]
    {
        new SearchOption("Trứng"),
        new SearchOption("Đậu phộng"),
        new SearchOption("Whey protein"),
        new SearchOption("Ức gà"),
        new SearchOption("Thịt bòa"),

    };

}

