using MauiReactor;
using MauiReactor.Animations;
using MauiReactor.Canvas;
using MauiReactor.Shapes;
using System;
using TheHealMauiApp.Models;
using TheHealMauiApp.Resources.Styles;

namespace TheHealMauiApp.Pages.Component.HomePage;

class MenuCollectionItemState
{
}
 class MenuCollectionItem:Component<MenuCollectionItemState>
{
    Action _onTapeed;
    MenuCollection[] _menuCollection1;
    MenuCollection[] _menuCollection2;
    public MenuCollectionItem OnTapped(Action action)
    {
        _onTapeed = action;
        return this;
    }
    public MenuCollectionItem Collection1(MenuCollection[] menuCollection)
    {
        _menuCollection1 = menuCollection;
        return this;
    }
    public MenuCollectionItem Collection2(MenuCollection[] menuCollection)
    {
        _menuCollection2 = menuCollection;
        return this;
    }
    public override VisualNode Render()
    {
        return new Grid()
        { 
            new HStack
            {
                new CollectionView()
                        .ItemsSource(_menuCollection1, RenderMenu)
                        .ItemsLayout(new VerticalLinearItemsLayout().ItemSpacing(10))
                        .BackgroundColor(Theme.Xam)
                        .GridRow(1)
                        .Margin(0,0,10,0),
                new CollectionView()
                        .ItemsSource(_menuCollection2, RenderMenu)
                        .ItemsLayout(new VerticalLinearItemsLayout().ItemSpacing(10))
                        .Margin(10,0,0,0)
                        .BackgroundColor(Theme.Xam)
                        .GridRow(1)
                        .GridColumn(1)
                        ,
            }.HCenter()
             
             .Margin(0,55,0,0)
        }.BackgroundColor(Theme.Xam);
    }
    private VisualNode RenderMenu(MenuCollection collection)
    {
       return new Grid
       {
           new Border
           {
               new Grid("30,*,30","*")
               {
                   new Label(collection.Title)
                   .FontSize(13)
                   .FontFamily("OpenSansSemiBold")
                   .TextColor(collection.Font)
                   .FontAttributes(MauiControls.FontAttributes.Bold)
                   .VStart()
                   .Margin(15,10,0,0)
               ,
                   new Label(collection.Description)
                   .FontFamily("OpenSansSemiBold")
                   .TextColor(collection.Font)
                   .FontAttributes(MauiControls.FontAttributes.Bold)
                   .FontSize(18)
                   .VStart()
                   .Margin(14,35,10,0),   
                   new Border
                   {
                        new Image(collection.Icon),
                   }.HEnd()
                    .VEnd()
                    .HeightRequest(30)
                    .WidthRequest(30)
                    .GridRow(2)
                    .Margin(0,0,10,10)
                    .BackgroundColor(Colors.Transparent)
                    .StrokeThickness(0)
                    ,

               }
           }
           .Background(new MauiControls.LinearGradientBrush(
                                    new MauiControls.GradientStopCollection
                                    {
                                        new MauiControls.GradientStop(collection.Background1, 0.1535f),
                                        new MauiControls.GradientStop(collection.Background2, 0.8795f),
                                    }))
           .HeightRequest(200)
           .WidthRequest(160)
           .StrokeShape(new RoundRectangle().CornerRadius(30))
           .StrokeThickness(1)
           .Stroke(Colors.Transparent)
           .Shadow(new Shadow().Brush(Theme.ShadowBrush).Offset(1,1).Opacity(0.2f))
           .OnTapped(_onTapeed)
       };
    }
}

