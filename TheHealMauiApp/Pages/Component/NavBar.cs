
using MauiReactor.Animations;
using MauiReactor;
using TheHealMauiApp.Models;
using MauiReactor.Canvas;
using System;
using Xe.AcrylicView.Controls;

namespace TheHealMauiApp.Pages.Component;



[Scaffold(typeof(Xe.AcrylicView.AcrylicView))]
partial class AcrylicView { }

class NavBarState
{
    public NavItem SelectedItem { get; set; }

    public double TranslationY { get; set; }
}

class NavBar : Component<NavBarState>
{
    private bool _show;
    Action _onShowSearchPage;
    Action _onShowFavoritePage;
    Action _onShowVideoPage;
    Action _onShowCalcPage;
    Action _onShowBachPage;

    public NavBar OnShowBachPage(Action action)
    {
        _onShowBachPage = action;
        return this;
    }
    public NavBar OnShowVideoPage(Action action)
    {
        _onShowVideoPage = action;
        return this;
    }
    public NavBar OnShowCalcPage(Action action)
    {
        _onShowCalcPage = action;
        return this;
    }
    public NavBar OnShowFavoritePage(Action action)
    {
        _onShowFavoritePage = action;
        return this;
    }
    public NavBar OnShowSearchPage(Action action)
    {
        _onShowSearchPage = action;
        return this;
    }
    
    public NavBar Shown(bool show)
    {
        _show = show;
        return this;
    }

    protected override void OnMounted()
    {
        State.TranslationY = _show ? 0 : 150;
        State.SelectedItem = NavItem.Home;
        base.OnMounted();
    }

    protected override void OnPropsChanged()
    {
        State.TranslationY = _show ? 0 : 150;
        State.SelectedItem = NavItem.Home;
        base.OnPropsChanged();
    }

    public override VisualNode Render()
    {
        return new AcrylicView
        {
                new CanvasView()
        {
               new Box
               {
                   new Row()
                        {
                            new NavBarButtonIcon()
                                .Icon("home.png")
                                .IsSelected(State.SelectedItem == NavItem.Home)
                                .OnSelected(()=>SetState(s => s.SelectedItem = NavItem.Home))
                                ,
                            new NavBarButtonIcon()
                                .Icon("dinner.png")
                                .IsSelected(State.SelectedItem == NavItem.Recipes)
                                .OnSelected(()=>SetState(s => s.SelectedItem = NavItem.Recipes))
                                .Selected(_onShowCalcPage),
                            new NavBarButtonIcon()
                                .Icon("search.png")
                                .IsSelected(State.SelectedItem == NavItem.Search)
                                .OnSelected(()=>SetState(s => s.SelectedItem = NavItem.Search))
                                .Selected(_onShowSearchPage),
                            new NavBarButtonIcon()
                                .Icon("apple.png")
                                .IsSelected(State.SelectedItem == NavItem.Favorites)
                                .OnSelected(()=>SetState(s => s.SelectedItem = NavItem.Favorites))
                                .Selected(_onShowFavoritePage),
                            new NavBarButtonIcon()
                                .Icon("play_button.png")
                                .IsSelected(State.SelectedItem == NavItem.Play)
                                .OnSelected(()=>SetState(s => s.SelectedItem = NavItem.Play))
                                .Selected(_onShowVideoPage),
                            new NavBarButtonIcon()
                                .Icon("book.png")
                                .IsSelected(State.SelectedItem == NavItem.Book)
                                .OnSelected(()=>SetState(s => s.SelectedItem = NavItem.Book))
                                .Selected(_onShowBachPage),
                        }
               }
               .Padding(22, 7)
               .BackgroundColor(Colors.Transparent)
               .CornerRadius(30)
        }
       .HeightRequest(55)
       .VCenter()
       .Shadow(new Shadow()
                   .Brush(Colors.Black)
                   .Opacity(0.4f)
                   .Radius(300)
                   .Offset(0.0, 10.0))
       .TranslationY(State.TranslationY)
       .WithAnimation(ExtendedEasing.InOutBack, duration: 400)
       .BackgroundColor(Colors.Transparent)
        }.EffectStyle(EffectStyle.ExtraLight)
        .HeightRequest (55)
        .BorderColor(Colors.White)
        .BorderThickness(0)
        .VEnd()
        .Margin(35, 0, 35, 50)
        .CornerRadius (30)
       ;
    
    }
}

class NavBarButtonIconState
{
    public float SelectionScaleX { get; set; }
    public Action Select { get; set; }
}

class NavBarButtonIcon : Component<NavBarButtonIconState>
{
    private string _icon;
    private bool _isSelected;
    private Action _onSelected;
    Action _select;
    public NavBarButtonIcon Selected(Action action)
    {
        _select = action;
        return this;
    }

    public NavBarButtonIcon Icon(string icon)
    {
        _icon = icon;
        return this;
    }

    public NavBarButtonIcon IsSelected(bool isSelected)
    {
        _isSelected = isSelected;
        return this;
    }

    public NavBarButtonIcon OnSelected(Action action)
    {
        _onSelected = action;
        return this;
    }

    protected override void OnMounted()
    {
        State.SelectionScaleX = _isSelected ? 1.0f : 0.0f;
        base.OnMounted();
    }

    protected override void OnPropsChanged()
    {
        State.SelectionScaleX = _isSelected ? 1.0f : 0.0f;
        base.OnPropsChanged();
    }

    public override VisualNode Render()
    {
        return new PointInteractionHandler
        {
            new Align
            {
                new Column("11, 24")
                {
                    new Align()
                    {
                        new Box()
                            .BackgroundColor(Color.FromArgb("#81B4FF"))
                            .CornerRadius(3)
                            
                    }
                    .VCenter()
                    .HCenter()
                    .Height(5)
                    .Width(20)
                    .AnchorX(0.5f)
                    .ScaleX(State.SelectionScaleX)
                    .WithAnimation(duration: 100),
                    
                         new AnimatedIcon()
                        .Icon(_icon)
                        .IsSelected(_isSelected)
                        .Selected(_select)
                        ,
                    
                   
                }
            }
            .Width(46)
        }
        .OnTap(_onSelected)
        ;
    }
}
