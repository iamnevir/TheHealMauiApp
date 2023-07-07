using MauiReactor.Canvas;
using MauiReactor.Shapes;
using TheHealMauiApp.Models;
using TheHealMauiApp.Pages.Component;
using TheHealMauiApp.Pages.Component.CalculatorPage;
using TheHealMauiApp.Pages.Component.FavoritePage;
using TheHealMauiApp.Pages.Component.HomePage;
using TheHealMauiApp.Pages.Component.VideoPage;
using TheHealMauiApp.Resources.Styles;

namespace TheHealMauiApp.Pages;

class MainPageState
{
    public bool IsScrollDown { get; set; } = true;
    public bool ShowSearchPage { get; set; }
    public bool ShowOnboarding { get; set; } 

}

class MainPage : Component<MainPageState>
{

   private async void OpenKeHoach()
    {
         await Navigation.PushAsync<KeHoach>();
    }
    private async void OpenVideo()
    {
        await Navigation.PushAsync<VideoPage>();
    }
    private async void OpenCalc()
    {
        await Navigation.PushAsync<CalcPage>();
    }
    protected override void OnMounted()
    {
        State.IsScrollDown = true;
        base.OnMounted();
    }
    public override VisualNode Render()
    {
        return new NavigationPage()
        {
            new ContentPage
            {
                  new Grid("*","*")
                    {

                       new Onboarding()
                        .Show(State.ShowOnboarding)
                        .OnClose(()=>SetState(s => s.ShowOnboarding = false)),

                        new SearchPage()
                              .OnClose(()=>SetState(s => s.ShowSearchPage = false))
                              .Show(State.ShowSearchPage),

                          new Border
                             {
                                  new Grid()
                                  {
                                       new Label("The heal knowledge")
                                           .Margin(10,0)
                                           .FontSize(25)
                                           .FontFamily("OpenSansSemiBold")
                                           .TextColor(Colors.Black)
                                           .VerticalTextAlignment(TextAlignment.Center)
                                           .FontAttributes(MauiControls.FontAttributes.Bold)
                                           .VCenter(),

                                           new Border
                                           {
                                               new Label("Get premium")
                                                   .FontFamily("OpenSansSemiBold")
                                                   .FontSize (12)
                                                   .TextColor(Colors.White)
                                                   .HCenter()
                                                   .VCenter()
                                           }.BackgroundColor (Theme.Purple)
                                            .StrokeShape(new RoundRectangle().CornerRadius(20))
                                            .HEnd()
                                            .WidthRequest(100)
                                            .HeightRequest(30)
                                            .Margin(10,0,10,0)
                                            .OnTapped(()=>SetState(s=>s.ShowOnboarding=true)),
                                  }.BackgroundColor(Colors.Transparent)
                                   .HeightRequest(55)
                                   .VStart()
                             }.BackgroundColor(Colors.White)
                              .StrokeThickness(0)
                              .HeightRequest (55)
                              .Margin(0,-1,0,0)
                              .VStart()
                              .StrokeShape(new RoundRectangle().CornerRadius(4))
                              .ZIndex(1),
                          new ScrollView
                          {

                              new Grid("700,50,200,Auto,Auto,Auto,700,100","*")
                              {
                                  new MenuCollectionItem()
                                      .Collection1(MenuCollection.Collections1)
                                      .Collection2(MenuCollection.Collections11)
                                      .GridRow(0),

                                  new Label("Tin")
                                            .FontSize(20)
                                            .FontAttributes(MauiControls.FontAttributes.Bold)
                                            .GridRow(1)
                                            .HStart()
                                            .Margin(10,10,0,0)
                                            .FontFamily("OpenSansSemiBold")
                                            .BackgroundColor(Theme.XamTrang),

                                  new Grid
                                  {
                                      new ScrollView()
                                      {
                                          new Grid
                                          {
                                              new CollectionView()
                                                  .ItemsSource(StoriesCollection.Stories,RenderStory)
                                                  .ItemsLayout(new HorizontalLinearItemsLayout().ItemSpacing(10))
                                          }
                                      }
                                  }
                                  .GridRow(2)
                                  .Margin(10,0,0,0)
                                  .BackgroundColor(Theme.XamTrang),
                                  new Label("Mới và đáng chú ý")
                                            .FontSize(40)
                                            .FontAttributes(MauiControls.FontAttributes.Bold)
                                            .GridRow(3)
                                            .FontFamily("OpenSansSemiBold")
                                            .Margin(10,10,0,10),
                                   new Label("Đặc sắc")
                                            .FontSize(20)
                                            .FontAttributes(MauiControls.FontAttributes.Bold)
                                            .GridRow(4)
                                            .FontFamily("OpenSansSemiBold")
                                            .Margin(10,10,0,10),
                                    new Grid
                                    {
                                        new ScrollView()
                                        {
                                            new Grid
                                            {
                                                 new CollectionView()
                                                     .ItemsSource(CongThucNauAn.CongThucs,RenderCongThucNauAn)
                                                     .ItemsLayout(new HorizontalLinearItemsLayout().ItemSpacing(5))
                                            }
                                        }
                                    }
                                  .GridRow(5)
                                  .BackgroundColor(Theme.XamTrang)
                                  .Margin(10,0,0,30),
                                   new MenuCollectionItem()
                                      .Collection1(MenuCollection.Collections2)
                                      .Collection2(MenuCollection.Collections21)
                                      .GridRow(6),
                                   new Border()
                                   {
                                       new Label("Made with love by Nevir")
                                           .TextColor(Colors.Gray)
                                           .Margin(20,10,0,0)
                                   }.GridRow(7)
                                    .Stroke(Colors.Transparent)
                                    .StrokeThickness(0)
                              }.BackgroundColor(Theme.XamTrang)
                          }.Margin(0,10,0,0)
                           ,
                          new NavBar()
                              .Shown(State.IsScrollDown)
                              .OnShowSearchPage(()=>SetState(s=>s.ShowSearchPage=true))
                              .OnShowFavoritePage(OpenKeHoach)
                              .OnShowVideoPage(OpenVideo)
                              .OnShowCalcPage(OpenCalc)

                    }
            }.Set(MauiControls.NavigationPage.HasNavigationBarProperty, false)
        }
        .BarBackgroundColor(Colors.White);
    }

    private VisualNode RenderCongThucNauAn(CongThucNauAn collection)
    {
        return new Grid()
            {
                new Border()
                {
                    new Image(collection.Image)
                    .HeightRequest(160)
                    .WidthRequest(340)
                    .Aspect(Aspect.AspectFill)
                }.HeightRequest(160)
                    .WidthRequest(340)
                    .VStart(),
                new Label("Free")
                    .TextColor(Colors.Gray)
                    .FontSize(11)
                    .FontFamily("OpenSansSemiBold")
                    .HStart()
                    .VEnd()
                    .Margin(10,0,0,40)
                    ,
                new Label(collection.Title)
                    .FontFamily("OpenSansSemiBold")
                    .FontAttributes(MauiControls.FontAttributes.Bold)
                    .TextColor(Colors.Black)
                    .FontSize(16)
                    .HStart()
                    .VEnd()
                    .Margin(10,0,0,10)
                    ,

            }.HeightRequest(230)
                    .WidthRequest(340);
    }

    private VisualNode RenderStory(StoriesCollection collection)
    {
        return new Border()
        {
            new Grid()
            {
                 new Border
                 {
                        new Image(collection.Image),
                   }.HCenter()
                    .VCenter()
                    .HeightRequest(50)
                    .WidthRequest(50)
                    .Margin(0,0,0,10)
                    .StrokeThickness(0)
                    ,
                new Label(collection.Mota)
                    .FontFamily("OpenSansSemiBold")
                    .TextColor(Colors.Black)
                    .FontSize(11)
                    .GridRow(1)
                    .HorizontalTextAlignment(TextAlignment.Center)
                    .VerticalTextAlignment(TextAlignment.Center)
                    .Margin(0,90,0,0)
                    ,
                new Border()
                .HEnd()
                .BackgroundColor(collection.Mau)
                .HeightRequest(100)
                .WidthRequest(100)
                .VStart()
                .StrokeShape(new RoundRectangle().CornerRadius(0,0,60,0))
                .Margin(0,-55,-55,0)
                .Stroke(Colors.Transparent)

            }
            .Padding(8)
        }
        .WidthRequest(120)
        .HeightRequest(200)
        .StrokeShape(new RoundRectangle().CornerRadius(12))
        .Stroke(collection.Mau)
        .StrokeThickness(4)
        .BackgroundColor(Colors.White)
        ;
    }
}
