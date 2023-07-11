using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHealMauiApp.Models;

record ThucPham(int Id,int BachKhoaToanThuId,string Name, string Image, double Calo, double Protein, double Fat, double Cab, double ChatXo)
{
    public static ObservableCollection<ThucPham> ThucPham1 = new(new[]
    {
        new ThucPham(1,2,"Cải ngồng","raucaingong",16,1.5,0,4.5,2),
        new ThucPham(2,2,"Bí đao","bidao",14,0,0,3,1),
        new ThucPham(3,2,"Mướp đắng","muopdang",16,1,0,4,2),
        new ThucPham(4,2,"Dưa chuột","duachuot",15,1,0,0,4),
    });
    public static ObservableCollection<ThucPham> ThucPham2 = new (new[]
    {
        new ThucPham(1,3,"Đu đủ","dudu",39,1,0,10,2),
        new ThucPham(2,3,"Ổi","oi",68,2.6,0.4,14,5),
        new ThucPham(3,3,"Xoài","xoai",59,0.8,0.1,15,1.6),
        new ThucPham(4,3,"Dứa","dua",50,0.5,0,13,1.4),
    });
    public static ObservableCollection<ThucPham> ThucPham3 = new(new[]
    {
        new ThucPham(1,1,"Tôm","tom",100,16,0,0,0),
        new ThucPham(2,1,"Thịt bòa","boa",278,17.5,25.5,0,0),
        new ThucPham(3,1,"Ức gà","ucga",211,23,1,0,0),
        new ThucPham(4,1,"Vai lợn","vailon",148,20,7,0,0),
    });
    public static ObservableCollection<ThucPham> ThucPham4 = new (new[]
   {
        new ThucPham(1,4,"Hạch nhân","",597,24,50,18.5,12),
        new ThucPham(2,4,"Óc chó","",655,15.3,65.2,13.7,1.9),
        new ThucPham(3,4,"Hạt điều","",605,18.4,46.3,28.7,0.6),
        new ThucPham(4,4,"Đậu phộng","",567,25.8,49.2,16.1,8.5),
   });
}

record BachKhoaToanThu(int Id,string Name,string Image, ObservableCollection<ThucPham> ThucPhams)
{
    public static ObservableCollection<BachKhoaToanThu> BachKhoaToanThus = new(new[]
    {
        new BachKhoaToanThu(1,"Thịt cá","thit",ThucPham.ThucPham3),
        new BachKhoaToanThu(2,"Rau củ","lettuce",ThucPham.ThucPham1),
        new BachKhoaToanThu(3,"Trái cây","fruit",ThucPham.ThucPham2),
        new BachKhoaToanThu(4,"Hạt","seed",ThucPham.ThucPham4),
    });
}

