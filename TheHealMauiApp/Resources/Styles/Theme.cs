using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHealMauiApp.Resources.Styles;

public  class Theme
{
    public static Color Shadow { get; } = Color.FromUint(0xFF4A5367);
    public static MauiControls.Brush ShadowBrush { get; } = new MauiControls.SolidColorBrush(Shadow);
    public static Color Purple { get; } = Color.FromArgb("#6633CC");
    public static Color Trang { get; } = Color.FromArgb("#FFFFFF");
    public static Color Green { get; } = Color.FromArgb("#00CC00");
    public static Color Cam { get; } = Color.FromArgb("#FF9900");
    public static Color Hong { get; } = Color.FromArgb("#CC00CC");
    public static Color Luc { get; } = Color.FromArgb("#007700");
    public static Color Lam { get; } = Color.FromArgb("#00CCFF");
    public static Color Tim { get; } = Color.FromArgb("#CC99FF");
    public static Color Xam { get; } = Color.FromArgb("#F5F5F5");
    public static Color XamTrang { get; } = Color.FromArgb("#E8E8E8");
    public static Color XanhDen { get; } = Color.FromArgb("#000055");
    public static Color LucDen { get; } = Color.FromArgb("#002200");
    public static Color XanhTrang { get; } = Color.FromArgb("#66FF66");
    public static Color Kem { get; } = Color.FromArgb("#EECFA1");
    public static Color TimXanh { get; } = Color.FromArgb("#CC99FF");
    public static Color Do { get; } = Color.FromArgb("#FF0000");
    public static Color XanhNhat { get; } = Color.FromArgb("#88FFCC");
    public static Color XanhNhatNhungDamHonTi { get; } = Color.FromArgb("#00FFCC");
    public static Color XanhDam { get; } = Color.FromArgb("#66CC99");



}
