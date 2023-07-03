using MauiReactor;
using MauiReactor.Animations;
using MauiReactor.Canvas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHealMauiApp.Pages.Component;

class AnimatedIconState
{
    public PointF TranslatePoint { get; set; }
    public bool IsAnimating { get; set; }
    public bool IsSelected { get; set; }
    public Action Select { get; set; }
}

class AnimatedIcon : Component<AnimatedIconState>
{
    private string _icon;
    private bool _isSelected;
    Action _selected;
    public AnimatedIcon Selected(Action action)
    {
        _selected = action;
        return this;
    }
    public AnimatedIcon Icon(string icon)
    {
        _icon = icon;
        return this;
    }

    public AnimatedIcon IsSelected(bool selected)
    {
        _isSelected = selected;
        return this;
    }

    protected override void OnMounted()
    {
        State.IsSelected = _isSelected;
        State.IsAnimating = _isSelected;

        base.OnMounted();
    }

    protected override void OnPropsChanged()
    {
        if (_isSelected && !State.IsSelected)
        {
            State.IsAnimating = true;
            State.IsSelected = true;
            State.Select = _selected;
            State.Select?.Invoke();
        }
        else if (!_isSelected && State.IsSelected)
        {
            State.IsAnimating = false;
            State.IsSelected = false;
        }
        base.OnPropsChanged();
    }

    public override VisualNode Render()
    {
        return
            new Align
            {
                new Picture($"TheHealMauiApp.Resources.Images.NavBar.{(_isSelected ? string.Empty : "i" )}{_icon}")
                    .Aspect(Aspect.Fill)
                    ,  

                new AnimationController
                {
                    new SequenceAnimation
                    {
                        new CubicBezierPathAnimation()
                            .StartPoint(0,0)
                            .EndPoint(0,5)
                            .ControlPoint1(5,0)
                            .ControlPoint2(5,5)
                            .OnTick(v => SetState(s => s.TranslatePoint = v))
                            .Duration(200),

                        new CubicBezierPathAnimation()
                            .StartPoint(0,5)
                            .EndPoint(0,0)
                            .ControlPoint1(-5,5)
                            .ControlPoint2(-5,0)
                            .OnTick(v => SetState(s => s.TranslatePoint = v))
                            .Duration(200),
                    }
                    .IterationCount(1)
                }
                .IsEnabled(State.IsAnimating)
                .OnIsEnabledChanged(animating => State.IsAnimating = animating)
            }
        .Height(24)
        .Width(24)
        .TranslationX(() => State.TranslatePoint.X)
        .TranslationY(() => State.TranslatePoint.Y)
        .HCenter()
        .VCenter()
        
        ;
    }
}
