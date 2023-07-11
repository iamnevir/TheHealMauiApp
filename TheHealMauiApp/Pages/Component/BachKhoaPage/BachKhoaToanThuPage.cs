
using MauiReactor;
using MauiReactor.Animations;
using MauiReactor.Shapes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheHealMauiApp.Models;
using TheHealMauiApp.Resources.Styles;

namespace TheHealMauiApp.Pages.Component.BachKhoaPage;

class BachKhoaToanThuPageState
{
    public int SelectedCategoryId { get; set; } = 1;
    public int? SelectedItemId { get; set; } = 0;
    public ObservableCollection<ThucPham> Item { get; set; } = BachKhoaToanThu.BachKhoaToanThus[1].ThucPhams;
}
 class BachKhoaToanThuPage:Component<BachKhoaToanThuPageState>
{
    protected override void OnPropsChanged()
    {
        base.OnPropsChanged();
    }
    void OnSelectedCategory(BachKhoaToanThu bachKhoaToanThu)
    {
        SetState(s => s.SelectedCategoryId = BachKhoaToanThu.BachKhoaToanThus.IndexOf(bachKhoaToanThu));
        State.Item = BachKhoaToanThu.BachKhoaToanThus[State.SelectedCategoryId].ThucPhams;
        
    }
    public override VisualNode Render()
    {
        return new ContentPage
        {
            new Grid("*", "*")
            {
                new ItemDetail()
                        .GetThucPham(State.SelectedItemId == null ? State.Item[0] : State.Item[State.SelectedItemId.Value])
                        ,
                new Border
                {
                    new Grid
                    {
                        new Border
                        {
                            new Grid
                            {
                                new Image("searchbar").HStart().HeightRequest(20).Margin(15,0,0,0),
                                new Entry().Placeholder("Tìm kiếm ...").FontSize(18).TextColor(Theme.XamTrang)
                                        .WidthRequest(290)
                                        .Margin(20,0,0,0)
                            }
                        }.WidthRequest(360)
                        .HeightRequest(55)
                        .StrokeShape(new RoundRectangle().CornerRadius(30))
                        .Stroke(Theme.XamTrang)
                        .StrokeThickness(1)
                        .VStart()
                        .Margin(0,15,0,0)
                        ,
                        new ScrollView
                        {
                             new CollectionView().ItemsSource(State.Item, RenderItem)
                            .ItemsLayout(new HorizontalLinearItemsLayout().ItemSpacing(5))
                        }.VCenter()
                        ,
                        new Border
                        {
                             new CollectionView().ItemsSource(BachKhoaToanThu.BachKhoaToanThus, RenderDanhMuc)
                            .ItemsLayout(new HorizontalLinearItemsLayout().ItemSpacing(0))
                        }.HeightRequest(55).VEnd().Stroke(Theme.XamTrang).StrokeThickness(1)
                    }
                }.VEnd()
                .StrokeShape(new RoundRectangle().CornerRadius(30,30,0,0))
                .HeightRequest(270)
                .WidthRequest(395)
                .ZIndex(1)
                ,
            }
        }.Set(MauiControls.NavigationPage.HasNavigationBarProperty,false);

    }
    private VisualNode RenderItem(ThucPham item)
    {
        return new Border
        {
            new VStack
            {
                new Image(item.Image).HeightRequest(80).VCenter().HCenter(),
                new Label(item.Name).HCenter().TextColor(Colors.Black),
            },
        }.WidthRequest(110)
        .HeightRequest(120)
        .Margin(0,10,0,0)
        .Stroke(State.SelectedItemId+1==item.Id? Theme.XanhDam : Colors.Transparent)
        .StrokeShape (new RoundRectangle().CornerRadius(15))
        .StrokeThickness(1)
        .OnTapped(()=>SetState(s => s.SelectedItemId = State.Item.IndexOf(item)));
    }

    private VisualNode RenderDanhMuc(BachKhoaToanThu item)
    {
        return new Border
        {
               new Image(item.Image).HeightRequest(25).VCenter().HCenter()
        }
        .WidthRequest(100)
        .HeightRequest(55)
        .VEnd()
        .BackgroundColor(State.SelectedCategoryId+1==item.Id? Theme.XamTrang:Colors.Transparent)
        .OnTapped(()=>OnSelectedCategory(item));
    }
}

class ItemDetailState
{
    
}
class ItemDetail : Component<ItemDetailState>
{
    ThucPham _thucPham;
    public ItemDetail GetThucPham(ThucPham thucPham)
    {
        _thucPham = thucPham;
        return this;
    }
    public override VisualNode Render()
    {
        return new Grid
        {
            new Label($"{_thucPham.Name} (100g)")
            .VStart()
            .HCenter()
            .TextColor(Colors.White)
            .FontSize(18)
            .Margin(0,25,0,0)
            .FontAttributes(MauiControls.FontAttributes.Bold),
            new HStack
            {
                new VStack
                {
                    new Label("Calo/Kcal")
                    .TextColor(Colors.White)
                    .FontSize(18),
                    new Label(_thucPham.Calo)
                    .TextColor(Colors.White)
                    .FontSize(30)
                    .FontAttributes(MauiControls.FontAttributes.Bold)
                }.Margin(10,70,0,0),
                new Border
                {
                    new Image(_thucPham.Image).Aspect(Aspect.AspectFit)
                }.HeightRequest(200).Margin(0,0,0,70).WidthRequest(300).BackgroundColor(Colors.Transparent)

            }.VCenter().Spacing(10),
            new HStack
            {
                new Border
                {
                    new VStack
                    {
                        new Label("Carb")
                        .TextColor(Colors.White)
                        .FontSize(14).HorizontalTextAlignment(TextAlignment.Center).Margin(0,10,0,0)
                        ,
                        new Label($"{_thucPham.Cab}g")
                        .TextColor(Colors.White)
                        .FontAttributes(MauiControls.FontAttributes.Bold)
                        .FontSize(17).HorizontalTextAlignment(TextAlignment.Center)
                    }.BackgroundColor(Colors.Transparent).HCenter().Spacing(10)
                }.BackgroundColor(Colors.Transparent).WidthRequest(100),
                 new Border
                {
                    new VStack
                    {
                        new Label("Chất xơ")
                        .TextColor(Colors.White)
                        .FontSize(14).HorizontalTextAlignment(TextAlignment.Center).Margin(0,10,0,0)
                        ,
                        new Label($"{_thucPham.ChatXo}g")
                        .TextColor(Colors.White)
                        .FontAttributes(MauiControls.FontAttributes.Bold)
                        .FontSize(17).HorizontalTextAlignment(TextAlignment.Center)
                    }.BackgroundColor(Colors.Transparent).HCenter().Spacing(10)
                }.BackgroundColor(Theme.XanhDam).WidthRequest(100),
                  new Border
                {
                    new VStack
                    {
                        new Label("Chất béo")
                        .TextColor(Colors.White)
                        .FontSize(14).HorizontalTextAlignment(TextAlignment.Center).Margin(0,10,0,0)
                        ,
                        new Label($"{_thucPham.Fat}g")
                        .TextColor(Colors.White)
                        .FontAttributes(MauiControls.FontAttributes.Bold)
                        .FontSize(17).HorizontalTextAlignment(TextAlignment.Center)
                    }.BackgroundColor(Colors.Transparent).HCenter().Spacing(10)
                }.BackgroundColor(Colors.Transparent).WidthRequest(100),
                   new Border
                {
                    new VStack
                    {
                        new Label("Chất đạm")
                        .TextColor(Colors.White)
                        .FontSize(14).HorizontalTextAlignment(TextAlignment.Center).Margin(0,10,0,0)
                        ,
                        new Label($"{_thucPham.Protein}g")
                        .TextColor(Colors.White)
                        .FontAttributes(MauiControls.FontAttributes.Bold)
                        .FontSize(17).HorizontalTextAlignment(TextAlignment.Center)
                    }.BackgroundColor(Colors.Transparent).HCenter().Spacing(10)
                }.BackgroundColor(Theme.XanhDam).WidthRequest(100)
            }.HeightRequest(140)
            .VEnd()
            .BackgroundColor(Colors.Transparent).Spacing(-1)

        }.ZIndex(0).HeightRequest(580).VStart().BackgroundColor(Theme.XanhNhat)
        ;
    }


}