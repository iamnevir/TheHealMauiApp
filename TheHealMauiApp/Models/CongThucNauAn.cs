using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHealMauiApp.Models;

public record CongThucNauAn(string Image, string Title)
{
    public static CongThucNauAn[] CongThucs = new CongThucNauAn[]
    {
        new CongThucNauAn("vietquat","Việt quất"),
        new CongThucNauAn("mangtay","Măng tây"),
        new CongThucNauAn("saladrau","Salad rau xanh"),
        new CongThucNauAn("banhmytrung","Bánh mì trứng"),
        new CongThucNauAn("thitbo","Beef Steak"),
    };
}
