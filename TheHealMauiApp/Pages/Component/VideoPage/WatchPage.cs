using MauiReactor.Shapes;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using TheHealMauiApp.Models;
using TheHealMauiApp.Services;

namespace TheHealMauiApp.Pages.Component.VideoPage;

class WatchPageState
{
    public ObservableCollection<Category> Categories { get; set; }
    public bool IsLoading { get; set; }
}
 class WatchPage:Component<WatchPageState>
{
    protected override async void OnMountedOrPropsChanged()
    {
        var theMealServices = Services.GetRequiredService<ITheMealServices>();

        State.IsLoading = true;

        var categories = await theMealServices.GetCategoryAsync();
        SetState(s =>
        {
            s.Categories = new ObservableCollection<Category>(categories);
            s.IsLoading = false;

        });
        base.OnMountedOrPropsChanged();
    }
    public override VisualNode Render()
    {
        return new ContentPage
        {
            new Grid("*","*")
            {
                RenderWebView(),
                //new Border
                //{
                //    new Grid
                //    {
                //        new Label("hehe"),
                //        new Image("close").Aspect(Aspect.AspectFit).HeightRequest(20),
                //        new Label("hehehehe")
                //    }
                //}.GridRow(1),
                //new ScrollView
                //{
                //   new Grid
                //   {
                //       //new CollectionView()
                //       //             .ItemsSource(State.Categories,RenderCategoryVideo)
                //       //             .ItemsLayout(new HorizontalLinearItemsLayout().ItemSpacing(10))
                //   }
                //}.GridRow (2),
                
            }
        }.Set(MauiControls.NavigationPage.HasNavigationBarProperty,false);
    }

    private VisualNode RenderCategoryVideo(Category category)
    {
        return new Border
        {
            new Label(category.Name),
        }.StrokeShape(new RoundRectangle().CornerRadius(20)).HeightRequest(30).WidthRequest(50);
    }

    private VisualNode RenderWebView()
    {
        return new Border
        {
            new WebView("https://www.youtube.com/watch?v=4aZr5hZXP_s").HCenter().VCenter()
        };
    }
    static string RenderWebViewUrl(string url)
    {
        string u = url.Replace("https://www.youtube.com/watch?v=",string.Empty);
        return $"https://www.youtube.com/embed/{u}";
    }
}
