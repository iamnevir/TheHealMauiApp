using MauiReactor.Animations;
using MauiReactor;
using Microsoft.Maui.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiReactor.Canvas;
using TheHealMauiApp.Resources.Styles;
using MauiReactor.Shapes;

namespace TheHealMauiApp.Pages.Component;


class OnboardingState
{
    public double TranslationY { get; set; }

    public bool ShowLogin { get; set; }
}

class Onboarding : Component<OnboardingState>
{
    private bool _show;
    private Action _onClose;

    public Onboarding Show(bool show)
    {
        _show = show;
        return this;
    }

    public Onboarding OnClose(Action onClose)
    {
        _onClose = onClose;
        return this;
    }

    protected override void OnMounted()
    {
        State.TranslationY = _show ? -50 : -DeviceDisplay.Current.MainDisplayInfo.Height;
        base.OnMounted();
    }

    protected override void OnPropsChanged()
    {
        State.TranslationY = _show ? -50 : -DeviceDisplay.Current.MainDisplayInfo.Height;
        base.OnPropsChanged();
    }

    public override VisualNode Render()
    {
        return new Grid("*", "*")
        {
            RenderBody(),

            new Login()
                .Show(State.ShowLogin)
                .OnClose(()=>SetState(s => s.ShowLogin = false)),
        }
        .TranslationY(State.TranslationY)
        .WithAnimation(easing: ExtendedEasing.InOutCirc, duration: 600)
        .ZIndex(5);
    }

    VisualNode RenderBody()
    {
        return new Border
        {
            new Grid("100, Auto, *, 100, 76", "*")
            {
                new Image("onboarding_background")
                    .Aspect(Aspect.Fill)
                    .GridRowSpan(5),

                RenderCloseButton(),

                new Label("Học chữa lành và đối mặt")
                    .GridRow(1)
                    .Margin(40, 32, 120, 30)
                    .FontFamily("Poppins")
                    .FontSize(60)
                    .FontAttributes(Microsoft.Maui.Controls.FontAttributes.Bold)
                    .TextColor(Colors.Black),

                new Label("Đừng bỏ qua nó. Đây có thể là cơ hội tốt cho bạn, chưa bao giờ là muộn để tiến bộ và phát triển. Hãy cùng chúng tôi đối mặt với khó khăn và thử thách.")
                    .FontSize(17)
                    .GridRow(2)
                    .Margin(40, 0, 120, 0)
                    .TextColor(Colors.Black),

                new StartCourseButton()
                    .OnTapped(()=>SetState(s => s.ShowLogin = true))
                    .GridRow(3),

                new Label("Hơn 30+ khóa học, 2000+ cuốn sách và công thức nấu ăn, 200 triệu lượt xem hàng tháng cùng bách khoa toàn thư về thực phẩm.")
                    .FontSize(12)
                    .GridRow(4)
                    .TextColor(Colors.Black)
                    .Margin(40, 0, 50, 31)

            }
        }
        .StrokeShape(new RoundRectangle().CornerRadius(30))
        .Margin(7, 0, 7, 10)
        .Background(Colors.White)
        .ZIndex(3);
    }

    ImageButton RenderCloseButton() =>
        new ImageButton("close_boarding")
                .Aspect(Aspect.AspectFit)
                .CornerRadius(18)
                .Shadow(new Shadow().Brush(Theme.ShadowBrush)
                    .Opacity(0.1f).Offset(5, 5))
                .HeightRequest(36)
                .WidthRequest(36)
                .HEnd()
                .VEnd()
                .Margin(24, 0)
                .OnClicked(_onClose);
}

class StartCourseButtonState
{
    public bool IsPressed { get; set; }
    public double MainScale { get; set; } = 1.0f;
    public double BorderScaleX { get; set; }
}

class StartCourseButton : Component<StartCourseButtonState>
{
    private Action _onTapped;

    public StartCourseButton OnTapped(Action action)
    {
        _onTapped = action;
        return this;
    }

    public override VisualNode Render()
    {
        return new CanvasView()
        {
            new Align
            {
                new Group
                {
                    new Align
                    {
                        new Box()
                            .CornerRadius(10,20,20,20)
                            .Background(
                                new MauiControls.LinearGradientBrush(
                                    new MauiControls.GradientStopCollection
                                    {
                                        new MauiControls.GradientStop(Color.FromArgb("#F6AAA2"), 0.1535f),
                                        new MauiControls.GradientStop(Color.FromArgb("#FF557C"), 0.8795f),
                                    }))
                    }
                    .HStart()
                    .VStart()
                    .Height(63)
                    .Width(69),

                    new Picture("TheHealMauiApp.Resources.Images.LoginPage.start_course_button.png")
                        .Margin(8,8,0,0),

                    new Align ()
                    {
                        new ClipRectangle
                        {
                            new Box
                            {
                                new Align
                                {
                                    new Box()
                                        .CornerRadius(25)
                                        .BorderColor(Color.FromUint(0xFF6792FF).WithLuminosity(0.6f))
                                        .BackgroundColor(Colors.Transparent)
                                        .BorderSize(2)
                                }
                                .HCenter()
                                .Width(228)
                            }
                            .Padding(9,10,2,2)
                            .IsVisible(State.IsPressed)
                            ,
                        }

                    }
                    .Width(() => 236.0f * (float)State.BorderScaleX)
                    .HCenter()
                    ,

                    new AnimationController
                    {
                        new SequenceAnimation
                        {
                            new DoubleAnimation()
                                .StartValue(1.0)
                                .TargetValue(0.8)
                                .Duration(200)
                                .Easing(Easing.CubicIn)
                                .OnTick(v=>SetState(s => s.MainScale = v, false)),

                            new DoubleAnimation()
                                .StartValue(0.8)
                                .TargetValue(1.0)
                                .Duration(200)
                                .Easing(Easing.CubicOut)
                                .OnTick(v=>SetState(s => s.MainScale = v, false)),

                            new DoubleAnimation()
                                .StartValue(0.0)
                                .TargetValue(1.0)
                                .Easing(Easing.CubicIn)
                                .Duration(300)
                                .OnTick(v=>SetState(s => s.BorderScaleX = v, false)),

                            new DoubleAnimation()
                                .StartValue(1.0)
                                .TargetValue(0.0)
                                .Easing(Easing.CubicIn)
                                .Duration(20)
                                .OnTick(v=>SetState(s => s.BorderScaleX = v, false))
                        }
                        .IterationCount(1)
                    }
                    .IsEnabled(State.IsPressed)
                    .OnIsEnabledChanged(isEnabled => SetState(s => s.IsPressed = isEnabled))
                }
            }
            .ScaleX(() => (float)State.MainScale)
            .ScaleY(() => (float)State.MainScale)
        }
        .HeightRequest(66)
        .WidthRequest(236)
        .BackgroundColor(Colors.Transparent)
        .OnTapped(() =>
        {
            SetState(s => s.IsPressed = true);
            MauiControls.Application.Current.Dispatcher.DispatchDelayed(TimeSpan.FromMilliseconds(800), _onTapped);
        })
        .Margin(40, 23)
        .HStart();
    }
}

