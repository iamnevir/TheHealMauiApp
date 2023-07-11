using MauiReactor;
using MauiReactor.Animations;
using MauiReactor.Shapes;
using Microsoft.Maui.Devices;
using Microsoft.Maui.Graphics.Text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheHealMauiApp.Resources.Styles;

namespace TheHealMauiApp.Pages.Component.CalculatorPage;

class CalcPageState
{
    public string ChieuCao { get; set; } = "165";
    public string CanNang { get; set; } = "53";
    public string Tuoi { get; set; } ="20";
    public double Bmi { get; set; }
    public double Ibw { get; set; }
    public double Lit { get; set; }
    public double Protein { get; set; }
    public CuongDo CuongDo { get; set; }
    public bool Show { get; set; }
    public bool Tinh { get; set; }
    public GioiTinh GioiTinh { get; set; } = GioiTinh.nam;
}
 class CalcPage: Component<CalcPageState>
{
    public const double ibw = 0.39370;
    public const double pound = 2.20462262185;
    public const double oz = 0.03;
    public double cuongdo;
    public double protein;
    public string bmi;

    protected override void OnMounted()
    {
        base.OnMounted();
    }
    protected override void OnPropsChanged()
    {
        switch (State.CuongDo)
        {
            case CuongDo.it :
                 protein = 1.2;
                 cuongdo = 1;
                 break;
            case CuongDo.vua:
                protein = 1.5;
                cuongdo = 2;
                break;
            case CuongDo.cao:
                protein = 2;
                cuongdo = 3;
                break;
            case CuongDo.ratcao:
                protein = 2.5;
                cuongdo = 4;
                break;
            case CuongDo.asian:
                protein = 5;
                cuongdo = 10;
                break;
        }
        CalcBmi();
        CalcNuoc();
        CalcIbw();
        CalcProtein();
        base.OnPropsChanged();
    }
    void RunCalc()
    {
        OnPropsChanged();
        SetState(s => s.Tinh = !s.Tinh);
    }
    void CalcIbw()
    {
        if (State.GioiTinh == GioiTinh.nam) { State.Ibw = 52 + 1.9 * (int.Parse(State.ChieuCao) * ibw - 60); }
        else { State.Ibw = 49 + 1.7 * (int.Parse(State.ChieuCao) * ibw - 60); }
    }
    private void CalcBmi()
    {
        State.Bmi = int.Parse(State.CanNang)*Math.Pow(100,2) / Math.Pow(int.Parse(State.ChieuCao), 2);
        switch (State.Bmi)
        {
            case <= 16:
                bmi = "(Bạn gầy)";
                break;
            case <=18:
                bmi = "(Bạn thiếu cân)";
                break;
            case <= 24:
                bmi = "(Bạn cân đối)";
                break;
            case <= 30:
                bmi = "(Bạn thừa cân)";
                break;
            case > 30:
                bmi = "(Bạn béo phì)";
                break;
        }
        State.Show = true;
    }
    private void CalcNuoc()
    {
        State.Lit = int.Parse(State.CanNang) * pound * 2 / 3 * oz + (12 * oz * cuongdo);
    }
    private void CalcProtein()
    {
        State.Protein = int.Parse(State.CanNang)*protein;
    }
    public override VisualNode Render()
    {
        return new ContentPage("Tính chỉ số cơ thể")
        {
            new Grid("*","*")
            {
                new Label("Chỉ số cơ thể"),
                new Border
                {
                    new Grid("100,320,100,100,*","*")
                    {
                        new HStack
                        {
                            new Label("Giới tính")
                            .FontAttributes(Microsoft.Maui.Controls.FontAttributes.Bold)
                            .TextColor(Colors.Black),
                            new Border
                            {
                                new Image("male").HeightRequest(50).WidthRequest(100).HStart(),
                            }
                            .StrokeThickness(1)
                            .Stroke(Theme.XanhDen)
                            .StrokeShape(new RoundRectangle().CornerRadius(20))
                            .OnTapped(()=>SetState(s=>s.GioiTinh=GioiTinh.nam))
                            .BackgroundColor(State.GioiTinh==GioiTinh.nam? Theme.Hong: Colors.White),
                             new Border
                            {
                                new Image("female").HeightRequest(50).WidthRequest(100).HStart(),
                            }
                             .StrokeThickness(1)
                             .Stroke(Theme.XanhDen)
                             .StrokeShape(new RoundRectangle().CornerRadius(20))
                            .OnTapped(()=>SetState(s=>s.GioiTinh=GioiTinh.nu))
                            .BackgroundColor(State.GioiTinh==GioiTinh.nu? Theme.Hong: Colors.White)
                        }.GridRow(0).Spacing(30),
                        new Border
                        {
                            new Grid("Auto,Auto,Auto","*")
                            {  RenderEntry("Chiều cao", State.ChieuCao.ToString(),"height", v=>State.ChieuCao=v, true)
                                    .GridRow(0)
                                    .Margin(5,24,0,0),
                                RenderEntry("Cân nặng", State.CanNang.ToString(),"weight", v=>State.CanNang=v, true)
                                 .GridRow(1)
                                    .Margin(5,24,0,0),
                                 RenderEntry("Tuổi", State.Tuoi.ToString(),"year", v=>State.Tuoi=v, true)
                                  .GridRow(2)
                                    .Margin(5,24,0,0),
                            }

                        }.GridRow(1),
                         new HStack
                        {
                            RenderOption("Ít vận động(hầu như không)",Colors.Black,State.CuongDo == CuongDo.it ? Theme.Do : Colors.White)
                            .OnTapped(()=>SetState(s=>s.CuongDo=CuongDo.it)),
                            RenderOption("Vận động nhẹ(1-3 lần/tuần)",Colors.Black,State.CuongDo==CuongDo.vua? Theme.Lam : Colors.White)
                            .OnTapped(()=>SetState(s=>s.CuongDo=CuongDo.vua)),
                            RenderOption("Vận động vừa(4-5 lần/tuần)",Colors.Black,State.CuongDo == CuongDo.cao ? Theme.Green : Colors.White)
                            .OnTapped(()=>SetState(s=>s.CuongDo=CuongDo.cao)),
                            RenderOption("Năng động(hàng ngày)",Colors.Black,State.CuongDo==CuongDo.ratcao? Theme.Hong : Colors.White)
                            .OnTapped(()=>SetState(s=>s.CuongDo=CuongDo.ratcao)),
                            RenderOption("Mode Asia aka Gymer",Colors.Black,State.CuongDo==CuongDo.asian? Theme.Purple : Colors.White)
                            .OnTapped(()=>SetState(s=>s.CuongDo=CuongDo.asian))
                        }.GridRow(2).Spacing(5).Margin(10,0,0,0),
                             new Button("Tính")
                                 .FontSize(20)
                                 .FontAttributes(Microsoft.Maui.Controls.FontAttributes.Bold)
                                 .BackgroundColor(Theme.Green)
                                 .BorderColor(Theme.Hong)
                                 .TextColor(Theme.Trang)
                                 .WidthRequest(300)
                                 .CornerRadius(30)
                                 .OnClicked(RunCalc)
                                 .GridRow(3)
                                 .Margin(0,24,0,0)

                         
                         ,
                         new Border
                         {
                             new Grid("Auto,Auto,Auto,Auto","*")
                             {
                                 new Label(()=>$"Bmi = {State.Bmi:0.00} {bmi}")
                                 .GridRow(0)
                                 .TextColor(Theme.Luc)
                                 .FontAttributes(Microsoft.Maui.Controls.FontAttributes.Bold)
                                 .FontSize(17),
                                 new Label(()=>$"Cân nặng lý tưởng của bạn là {State.Ibw:0.00} kg")
                                 .GridRow(1)
                                 .TextColor(Theme.Luc)
                                 .FontAttributes(Microsoft.Maui.Controls.FontAttributes.Bold)
                                 .FontSize(17),
                                 new Label(()=>$"Lượng nước cần uống hàng ngày là  {State.Lit:0.00} lít")
                                 .GridRow(2)
                                 .TextColor(Theme.Luc)
                                 .FontAttributes(Microsoft.Maui.Controls.FontAttributes.Bold)
                                 .FontSize(17),
                                 new Label(() => $"Lượng protein cần hàng ngày là  {State.Protein:0.00} g")
                                 .GridRow(3)
                                 .TextColor(Theme.Luc)
                                 .FontAttributes(Microsoft.Maui.Controls.FontAttributes.Bold)
                                 .FontSize(17)
                             }.HCenter().VCenter()
                         }.Margin(10,10,0,0)
                         .GridRow(4)
                         .Stroke(
                                new MauiControls.LinearGradientBrush(
                                    new MauiControls.GradientStopCollection
                                    {
                                        new MauiControls.GradientStop(Color.FromArgb("#33FF33").WithAlpha(1.55f), 0),
                                        new MauiControls.GradientStop(Color.FromArgb("#66FF66").WithAlpha(1.20f), 1),
                                    }))
                         .StrokeThickness(4)
                         .StrokeShape(new RoundRectangle().CornerRadius(30,30,0,0))


                    }
                },

            }
        }.Set(MauiControls.NavigationPage.HasNavigationBarProperty,false);
    }


    //private void OnChieuCao(object sender, Microsoft.Maui.Controls.ValueChangedEventArgs e)
    //{
    //    State.ChieuCao = (int)e.NewValue;
    //}
    static Border RenderOption(string label,Color textcolor,Color bg ) =>
        new Border
        {
            new Label(label).TextColor(textcolor)
            .FontSize(11)
            .HCenter()
            .VCenter()
            .HorizontalTextAlignment(TextAlignment.Center)
            .FontAttributes(MauiControls.FontAttributes.Bold)
        }.BackgroundColor(bg)
        .StrokeShape(new RoundRectangle().CornerRadius(20))
        .HeightRequest(70)
        .WidthRequest(70);
    static Grid RenderEntry(string label, string value,string image, Action<string> onSetValueAction, bool isEnabled, string secondaryLabel = null)
        => new("26, 50", "*, *")
        {
            new Label(label)
                .FontSize (15)
                .TextColor(Colors.Black)
                .FontAttributes(Microsoft.Maui.Controls.FontAttributes.Bold)
                .VStart()
                ,

            new Label(secondaryLabel)
                .FontSize (15)
                .VStart()
                .HEnd()
                .TextColor(Colors.Black.WithAlpha(0.3f))
                .FontAttributes(Microsoft.Maui.Controls.FontAttributes.Bold)
                .GridColumnSpan(2)
                ,

            new Border()
                .GridRow(1)
                .GridColumnSpan(2)
                .StrokeShape(new RoundRectangle().CornerRadius(15))
                .Stroke(
                    new MauiControls.LinearGradientBrush(
                        new MauiControls.GradientStopCollection
                        {
                            new MauiControls.GradientStop(Color.FromArgb("#C2CFF0").WithAlpha(1.55f), 0),
                            new MauiControls.GradientStop(Color.FromArgb("#98A4C1").WithAlpha(1.20f), 1),
                        })),

            new Image(image)
                .WidthRequest(44)
                .GridRow(1)
                .Margin(8)
                .HStart(),
             new BorderlessEntry()
                .Text(value)
                .FontSize(15)
                .IsEnabled(isEnabled)
                .OnTextChanged(onSetValueAction)
                .Margin(8+24+15+10, 5, 8, 8)
                .GridRow(1)
                .GridColumnSpan(2)

        };
}

public enum CuongDo
{
    it,
    vua,
    cao,
    ratcao,
    asian
}
public enum GioiTinh
{
    nam,
    nu
}