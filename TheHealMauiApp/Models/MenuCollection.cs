using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheHealMauiApp.Resources.Styles;

namespace TheHealMauiApp.Models
{
    public record MenuCollection(string Title,string Description, string Icon,Color Background,Color Font)
    {
        public static MenuCollection[] Collections1 = new MenuCollection[]
        {
            new MenuCollection("Sách dạy nấu ăn","2,103,224 công thức","windows",Theme.Trang,Theme.Purple),
           
            new MenuCollection("Yêu thích","Danh sách công thức yêu thích của bạn", "heart",Theme.Cam,Colors.White),
            
            new MenuCollection("Lựa chọn nhanh","chọn gì đó cho bạn nào!", "settings",Theme.Hong,Colors.White),
            
        };
        public static MenuCollection[] Collections11 = new MenuCollection[]
        {
            
            new MenuCollection("Kế hoạch ăn uống","Tạo một kế hoạch cho bữa ăn của bạn", "calendar",Theme.Green,Colors.White),
           
            new MenuCollection("Giọng nói","Thử ngay", "microphone",Theme.Trang,Colors.Black),
           
            new MenuCollection("Videos","Công thức từ cộng đồng", "play",Theme.Tim,Colors.White),
        };
        public static MenuCollection[] Collections2 = new MenuCollection[]
        {
            new MenuCollection("Danh sách tạp hóa","Mua sắm với sách dạy nấu ăn","trolley",Theme.Purple,Colors.White),
          
            new MenuCollection("Bếp", "Hãy tạo một công thức của riêng bạn", "paste", Theme.Cam, Colors.White),
           
            new MenuCollection("Cài đặt", "Thay đổi ứng dụng của bạn", "settings", Theme.Hong, Colors.White),
        };
        public static MenuCollection[] Collections21 = new MenuCollection[]
        {
            
            new MenuCollection("Offline","Tải xuống công thức yêu thích của bạn", "download",Colors.Black,Colors.White),
            
            new MenuCollection("Bếp","Hãy tìm công thức bằng các thành phần", "noodles",Theme.Green,Colors.White),
            
        };
    }
}
