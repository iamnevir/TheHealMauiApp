using MauiReactor;
using MauiReactor.Animations;
using MauiReactor.Shapes;
using Microsoft.Maui.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheHealMauiApp.Models;
using TheHealMauiApp.Resources.Styles;

namespace TheHealMauiApp.Pages.Component.FavoritePage;

class KeHoachState
{
}
 class KeHoach:Component<KeHoachState>
{
    public override VisualNode Render()
    {
        return new ContentPage
        {
            new Grid("80,*", "*")
            {
                new Border
                {
                    new Grid()
                    {
                         new Label("Thứ bảy ngày 01 tháng 7".ToUpper())
                   .FontAttributes(Microsoft.Maui.Controls.FontAttributes.Bold)
                   .Margin(20,10,0,0)

                   ,
                   new Label("Các kế hoạch nổi bật")
                   .FontAttributes(Microsoft.Maui.Controls.FontAttributes.Bold)
                   .FontSize(30)
                   .TextColor(Colors.Black)
                   .VCenter()
                   .Margin(20,20,0,0)
                    }
                }
                   ,
                new ScrollView
                {
                   new CollectionView().ItemsSource(KeHoachCollection.KeHoachs,RenderKeHoach)
                   .ItemsLayout(new VerticalLinearItemsLayout().ItemSpacing(20)),
                }.GridRow(1)
            }
        }.Set(MauiControls.NavigationPage.HasNavigationBarProperty,false);
    }

    private VisualNode RenderKeHoach(KeHoachCollection collection)
    {
        return new Border
        {
            
            new Grid
            {
                new Image("locked").ZIndex(1)
                .Aspect(Aspect.AspectFit)
                .HeightRequest(35)
                .WidthRequest(35)
                .VStart()
                .HEnd()
                .Margin(0,10,10,0),
                new Image(collection.Image)
                .Aspect(Aspect.Fill),
                new Label(collection.Title.ToUpper())
                .TextColor(Theme.XamTrang)
                .Margin(10,10,0,0)
                .FontSize(16),
                new Label(collection.Ten)
                .VStart()
                .TextColor(Colors.White)
                .Margin(10,35,0,0)
                .FontAttributes(Microsoft.Maui.Controls.FontAttributes.Bold)
                .FontSize(30),
                new Label(collection.Mota)
                .VEnd()
                .Margin(15,0,10,25)
                .FontSize(15)
                .TextColor(Colors.Gray)

            }
        }.HeightRequest(500)
        .WidthRequest(350)
        .StrokeShape(new RoundRectangle().CornerRadius(15));
    }

}
