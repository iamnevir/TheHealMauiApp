using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHealMauiApp.Models;

public record KeHoachCollection(string Image, string Title,string Mota,string Ten)
{
    public static KeHoachCollection[] KeHoachs = new KeHoachCollection[]
    {
        new KeHoachCollection("banhmikep","Hãy thử something mới","Ngon và mang lại nhiều năng lượng cùng trải nghiệm thú vị","Bánh mì kẹp"),
        new KeHoachCollection("xienque","Đặc sắc","Bắt đầu một ngày mới với một xiên salad healthy","Xiên que rau củ"),
        new KeHoachCollection("rauxao","Bắt đầu chế độ ăn mới","Không gì tuyệt vời hơn một bát rau xào ngũ vị","Rau ngũ vị"),
    };
}
