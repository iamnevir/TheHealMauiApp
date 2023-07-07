using MauiReactor;
using MauiReactor.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheHealMauiApp.Models;
using TheHealMauiApp.Services;

namespace TheHealMauiApp.Pages.Component.VideoPage;

class WatchPageState
{
    public IEnumerable<Category> Categories { get; set; }
}
 class WatchPage:Component<WatchPageState>
{
    TheMealServices _theMealServices ;

    async void GetCategory()
    {
        var categoryListTask = _theMealServices.GetCategoryAsync();
        var categoryList = await categoryListTask;
        State.Categories= categoryList;
    }
    protected override void OnMounted()
    {
        base.OnMounted();
    }
    public override VisualNode Render()
    {
        return new ContentPage
        {
            new Grid("230,200,*","*")
            {
                RenderWebView(),
                new Border
                {
                    new Grid
                    {
                        new Label("hehe"),
                        new Image("close").Aspect(Aspect.AspectFit).HeightRequest(20),
                        new Label("hehehehe")
                    }
                }.GridRow(1),
                new ScrollView
                {
                    new HStack
                    {
                       
                    }
                }
                
            }
        };
    }

    private VisualNode RenderCategoiryVideo(Category category)
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
            new WebView("https://www.youtube.com/embed/1IszT_guI08").HCenter().VCenter()
        }.HeightRequest(230).WidthRequest(395).VStart();
    }
}
