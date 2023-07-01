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

namespace TheHealMauiApp.Pages;

class SearchPageState
{
    public double TranslationY { get; set; }

}
 class SearchPage:Component<SearchPageState>
{
    private Action _onClose;
    private bool _show;

    public SearchPage OnClose(Action onClose)
    {
        _onClose = onClose;
        return this;
    }
    public SearchPage Show(bool show)
    {
        _show = show;
        return this;
    }
    protected override void OnMounted()
    {
        State.TranslationY = _show ? 0 : -DeviceDisplay.Current.MainDisplayInfo.Height;
        base.OnMounted();
    }

    protected override void OnPropsChanged()
    {
        State.TranslationY = _show ? 0 : -DeviceDisplay.Current.MainDisplayInfo.Height;
        base.OnPropsChanged();
    }
    public override VisualNode Render()
    {
        return new Grid("*","*")
        {
            new ScrollView
            {
                new Border
            {
                new Grid("Auto,50,300,50,160,50,300","*")
                {
                    RenderSearchBar()
                    ,
                    new Label("Featured")
                    .Margin(10,10,0,0)
                    .TextColor(Colors.Black)
                    .FontSize(20)
                    .GridRow(1)
                    .FontAttributes(MauiControls.FontAttributes.Bold),
                    RenderFeatured(),
                     new Label("For You")
                    .Margin(10,10,0,0)
                    .TextColor(Colors.Black)
                    .FontSize(20)
                    .GridRow(3)
                    .FontAttributes(MauiControls.FontAttributes.Bold),
                     RenderForYou(),
                      new Label("Gợi ý")
                    .Margin(10,10,0,0)
                    .TextColor(Colors.Black)
                    .FontSize(20)
                    .GridRow(5)
                    .FontAttributes(MauiControls.FontAttributes.Bold),
                     RenderSearchOption()
                }
            }.Background(Colors.White)
            }
            
        }.TranslationY(State.TranslationY)
        .WithAnimation(easing: ExtendedEasing.InOutCirc, duration: 1000).ZIndex(2);
    }

     VisualNode RenderSearchOption()
    {
        return new Grid
        {
           new HStack
           {
               new CollectionView().ItemsSource(SearchOption.AnKieng,RenderSearchOptionItem)
               .ItemsLayout(new VerticalLinearItemsLayout().ItemSpacing(10)),
               new CollectionView().ItemsSource(SearchOption.Protein,RenderSearchOptionItem)
               .ItemsLayout(new VerticalLinearItemsLayout().ItemSpacing(10)),
               new CollectionView().ItemsSource(SearchOption.MienPhi,RenderSearchOptionItem)
               .ItemsLayout(new VerticalLinearItemsLayout().ItemSpacing(10)),
           }.HCenter().Spacing(5)
            
        }.GridRow(6);
    }

    private VisualNode RenderSearchOptionItem(SearchOption option)
    {
        return new Border
        {
            new Label(option.Title).VCenter().HCenter()
                .TextColor(Colors.Black)
                .FontSize(15)
        }.BackgroundColor(Theme.XanhTrang)
        .HeightRequest(40)
        .WidthRequest(120)
        .StrokeShape(new RoundRectangle().CornerRadius(30))
        ;
    }

    VisualNode RenderForYou()
    {
        return new ScrollView
        {
            new CollectionView().ItemsSource(ForYou.ForYous,RenderForYouItem)
            .ItemsLayout(new HorizontalLinearItemsLayout().ItemSpacing(10)),
        }.GridRow(4);
    }

    private VisualNode RenderForYouItem(ForYou you)
    {
        return new Border
        {
            new Grid()
            {
                 new Image(you.BgImage).Aspect(Aspect.Fill),

                 new Grid
                 {
                     new Label(you.Title)
                        .FontSize(23)
                        .TextColor(Theme.LucDen)
                        .FontAttributes(Microsoft.Maui.Controls.FontAttributes.Bold)
                        .VStart()
                        
                        ,
                 }.WidthRequest(200).HStart().Margin(15,15,0,0),
            

            new Label("Khám phá ->")
            .VEnd()
            .FontSize(15)
             .TextColor(Colors.Black)
            .FontAttributes(Microsoft.Maui.Controls.FontAttributes.Bold)
            .Margin(15,0,0,15)
            }
           
        }.HeightRequest(160)
         .WidthRequest(300)
         .Stroke(Colors.Transparent)
         .StrokeShape(new RoundRectangle().CornerRadius(15));
    }

    VisualNode RenderFeatured()
    {
        return new VStack()
        {
               new CollectionView().ItemsSource(Featured.Featureds1,RenderFeaturedIcon)
                                   .ItemsLayout(new HorizontalLinearItemsLayout().ItemSpacing(50)),
                new CollectionView().ItemsSource(Featured.Featureds11,RenderFeaturedIcon)
                                   .ItemsLayout(new HorizontalLinearItemsLayout().ItemSpacing(50))
        }.GridRow(2).HCenter().Spacing(40);
    }

    private VisualNode RenderFeaturedIcon(Featured featured)
    {
        return new Border
        {
            new VStack()
            {
                new Image(featured.Image)
                .HeightRequest(60)
                .WidthRequest(60),
                new Label(featured.Name)
                .FontSize(17).TextColor(Theme.XanhDen)
            }.Spacing(10)
            
        };
    }

    VisualNode RenderSearchBar()
    {
        return new Border
        {
            new Grid("30,*","*")
            {
                 RenderCloseButton().GridRow(0).Margin(0,10,0,-10),
                new Border
            {
                new HStack
                {
                    new Image("close")
                    .HeightRequest(20)
                    ,
                    new Entry
                    {

                    }.Placeholder("Liu liu đói khum?")
                    .WidthRequest(230)
                    .Margin(10,0,0,0)
                    ,
                    new Image("searchbar")
                     .HeightRequest(25),
                    new Image("micro")
                     .HeightRequest(25),
                }.Margin(15,0,0,0)
            }.HCenter()
            .VEnd()
            .WidthRequest(350)
            .HeightRequest(55)
            .Stroke(Theme.XamTrang)
            .StrokeShape(new RoundRectangle().CornerRadius(30))
            .StrokeThickness(1)
            .Margin(0,0,0,20)
            .GridRow(1),
            }
    }.HeightRequest(120)
        .StrokeShape(new RoundRectangle().CornerRadius(0,0,50,50))
        .Stroke(Theme.XamTrang)
        .StrokeThickness(1).VStart()
        .Margin(0,0,0,0);
    }
    ImageButton RenderCloseButton() =>
        new ImageButton("close1.png")
                .Aspect(Aspect.AspectFit)
                .CornerRadius(18)
                .Shadow(new Shadow().Brush(Theme.ShadowBrush)
                    .Opacity(0.1f).Offset(5, 5))
                .HeightRequest(30)
                .WidthRequest(30)
                .HEnd()
                .VEnd()
                .Margin(24, 0)
                .BackgroundColor(Colors.White)
                .OnClicked(_onClose);
}
