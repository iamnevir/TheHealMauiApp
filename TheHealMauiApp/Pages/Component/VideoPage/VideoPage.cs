
using MauiReactor;
using MauiReactor.Shapes;
using Microsoft.Maui.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheHealMauiApp.Models;
using TheHealMauiApp.Pages.Component.FavoritePage;
using TheHealMauiApp.Resources.Styles;

namespace TheHealMauiApp.Pages.Component.VideoPage;

 class VideoPageState
{
}
class VideoPage : Component<VideoPageState>
{
    public override VisualNode Render()
    {
        return new ContentPage
        {
            new ScrollView
            {
                 new Grid("430,1000,750,1000,400","*")
                {
                    new Border
                    {
                        new Grid
                        {
                            new Border
                            {
                                new Image("thitbo").Aspect(Aspect.AspectFill)
                            }.VStart().StrokeShape(new RoundRectangle().CornerRadius(25)).WidthRequest(350).HeightRequest(250).Margin(0,30,0,0)
                            ,
                            new Border
                            {
                                new Label("Featured").FontSize(15).TextColor(Colors.Black).FontAttributes(Microsoft.Maui.Controls.FontAttributes.Bold)
                                .VCenter().HCenter()
                            }.HeightRequest(30)
                            .WidthRequest(80)
                            .StrokeShape(new RoundRectangle().CornerRadius(5))
                            .BackgroundColor(Colors.White)
                            .HCenter()
                            .VEnd()
                            .Margin(0,0,260,90)
                            .OnTapped(async ()=> await  Navigation.PushAsync<WatchPage>())
                            ,
                            new Label("Beef Steak")
                            .TextColor(Colors.Black)
                            .FontAttributes(Microsoft.Maui.Controls.FontAttributes.Bold)
                            .FontSize(40)
                            .TextColor(Colors.Black)
                            .VEnd()
                            .HCenter()
                            .Margin(0,0,140,30)
                        }
                    }.BackgroundColor(Theme.Kem)
                    .HeightRequest(430)
                    .VStart()
                    .WidthRequest(DeviceDisplay.Current.MainDisplayInfo.Width)
                    .Margin(0,-2,0,0)
                    .GridRow(0)
                    ,
                    new Border
                    {
                        new HStack
                        {
                            new CollectionView().ItemsSource(KeHoachCollection.KeHoachs,RenderItem)
                            .ItemsLayout(new VerticalLinearItemsLayout().ItemSpacing(5)),
                         new CollectionView().ItemsSource(KeHoachCollection.KeHoachs,RenderItem)
                            .ItemsLayout(new VerticalLinearItemsLayout().ItemSpacing(5))
                        }.Spacing(15)
                         
                    }.GridRow(1).Margin(10,0,0,0),
                    new Border
                    {
                        new Grid("430,*","*")
                        {
                            new Border
                            {
                                new Image("thitbo").Aspect(Aspect.AspectFill)
                            }.VStart().StrokeShape(new RoundRectangle().CornerRadius(25)).WidthRequest(350).HeightRequest(250).Margin(0,30,0,0)
                            
                            ,
                            new Label("Beef Steak")
                            .TextColor(Colors.Black)
                            .FontAttributes(Microsoft.Maui.Controls.FontAttributes.Bold)
                            .FontSize(40)
                            .TextColor(Colors.Black)
                            .VEnd()
                            .HCenter()
                            .Margin(0,0,140,30),
                            new ScrollView
                            {
                                
                                new CollectionView().ItemsSource(KeHoachCollection.KeHoachs,RenderItem1)
                                .BackgroundColor(Theme.Tim)
                                
                                    .ItemsLayout(new HorizontalLinearItemsLayout().ItemSpacing(10)),
                            }.VEnd().BackgroundColor(Theme.Tim).GridRow(1).HCenter()
                             
                        }
                    }.BackgroundColor(Theme.Tim)
                    .HeightRequest(750)
                    .VStart()
                    .WidthRequest(395)
                    .Margin(0,-2,0,0)
                    .GridRow(2),
                     new Border
                    {
                        new HStack
                        {
                            new CollectionView().ItemsSource(KeHoachCollection.KeHoachs,RenderItem)
                            .ItemsLayout(new VerticalLinearItemsLayout().ItemSpacing(5)),
                         new CollectionView().ItemsSource(KeHoachCollection.KeHoachs,RenderItem)
                            .ItemsLayout(new VerticalLinearItemsLayout().ItemSpacing(5))
                        }.Spacing(15)

                    }.GridRow(3).Margin(10,0,0,0),
                      new Border
                    {
                        new Grid()
                        {
                            new Border
                            {
                                new Image("thitbo").Aspect(Aspect.AspectFill)
                            }.VStart().StrokeShape(new RoundRectangle().CornerRadius(25)).WidthRequest(350).HeightRequest(250).Margin(0,30,0,0)

                            ,
                            new Label("Beef Steak")
                            .TextColor(Colors.Black)
                            .FontAttributes(Microsoft.Maui.Controls.FontAttributes.Bold)
                            .FontSize(40)
                            .VCenter()
                            .HCenter()
                            .Margin(0,0,140,30),
                        }
                    }.BackgroundColor(Theme.TimXanh)
                    .HeightRequest(750)
                    .VStart()
                    .WidthRequest(395)
                    .Margin(0,-2,0,0)
                    .GridRow(4),
                }
            }
           
        }.Set(MauiControls.NavigationPage.HasNavigationBarProperty,false);
    }

    private VisualNode RenderItem(KeHoachCollection collection)
    {
        return new Border
        {
            new Grid
            {
                new Border
                {
                    new Image(collection.Image).Aspect(Aspect.AspectFill)
                }.HeightRequest(250).WidthRequest(180).StrokeShape(new RoundRectangle().CornerRadius(25)).VStart()
                ,
                new Label(collection.Ten)
                .TextColor(Colors.Black)
                        .FontSize(20)
                        .TextColor(Colors.Black)
                        .VEnd()
                        .HorizontalTextAlignment(TextAlignment.Start)
                        .HStart()
                        .Margin(5,0,0,25)
            }
        }.HeightRequest(320).WidthRequest(180);
    }
    private VisualNode RenderItem1(KeHoachCollection collection)
    {
        return new Border
        {
            new Grid
            {
                new Border
                {
                    new Image(collection.Image).Aspect(Aspect.AspectFill)
                }.HeightRequest(250).WidthRequest(180).StrokeShape(new RoundRectangle().CornerRadius(25)).VStart()
                ,
                new Label(collection.Ten)
                .TextColor(Colors.Black)
                        .FontSize(20)
                        .TextColor(Colors.Black)
                        .VEnd()
                        .HorizontalTextAlignment(TextAlignment.Start)
                        .HStart()
                        .Margin(5,0,0,25)
            }.BackgroundColor(Theme.Tim)
        }.HeightRequest(320).WidthRequest(180).BackgroundColor(Theme.Tim);
    }
}