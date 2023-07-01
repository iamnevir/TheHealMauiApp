using MauiReactor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheHealMauiApp.Pages.Component.FavoritePage;

namespace TheHealMauiApp.Pages.Component;

class ParentPageState
{

}
 class ParentPage : Component<ParentPageState>
{
    public override VisualNode Render()
    {
        return new ContentPage
        {
            new Grid
            {
                new KeHoach(),
                new MainPage(),

            }
        };
    }
}
