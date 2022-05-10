namespace EquipManager.Presentation.Views.UserControls.PPEContracts;

/// <summary> Представление.</summary>
public sealed partial class ViewPPEContractView : UserControl
{
    private readonly IViewModel<ViewPPEContractView>? _viewModel = (Application.Current as App)?
        .ServiceProvider?.GetService<IViewModel<ViewPPEContractView>>();

    public ViewPPEContractView()
    {
        InitializeComponent();

        DataContext = _viewModel ?? throw new ViewModelNotFoundException(nameof(ViewPPEContractViewModel));

        SetPage(number: 1);
    }

    private void SetGrid(Grid source)
    {
        PPEGrid1.Visibility = PPEGrid2.Visibility = PPEGrid3.Visibility = PPEGrid4.Visibility =
            PPEGrid5.Visibility = PPEGrid6.Visibility = PPEGrid7.Visibility = PPEGrid8.Visibility =
            PPEGrid9.Visibility = PPEGrid10.Visibility = PPEGrid11.Visibility = PPEGrid12.Visibility = Visibility.Collapsed;

        source.Visibility = Visibility.Visible;
    }

    private void SetPage(int number)
    {
        if (number < 1 || number > 12) throw new IndexOutOfRangeException();

        switch (number)
        {
            case 1:
                SetGrid(source: PPEGrid1);
                break;
            case 2:
                SetGrid(source: PPEGrid2);
                break;
            case 3:
                SetGrid(source: PPEGrid3);
                break;
            case 4:
                SetGrid(source: PPEGrid4);
                break;
            case 5:
                SetGrid(source: PPEGrid5);
                break;
            case 6:
                SetGrid(source: PPEGrid6);
                break;
            case 7:
                SetGrid(source: PPEGrid7);
                break;
            case 8:
                SetGrid(source: PPEGrid8);
                break;
            case 9:
                SetGrid(source: PPEGrid9);
                break;
            case 10:
                SetGrid(source: PPEGrid10);
                break;
            case 11:
                SetGrid(source: PPEGrid11);
                break;
            case 12:
                SetGrid(source: PPEGrid12);
                break;
        }

        NumberPPEPageTextBox.Text = $"{LanguageTranslator.Translate(key: "t_InfoAboutPPE")} №{number}";
    }

    private void Item1Button_Click(object sender, RoutedEventArgs e) => SetPage(number: 1);

    private void Item2Button_Click(object sender, RoutedEventArgs e) => SetPage(number: 2);

    private void Item3Button_Click(object sender, RoutedEventArgs e) => SetPage(number: 3);

    private void Item4Button_Click(object sender, RoutedEventArgs e) => SetPage(number: 4);

    private void Item5Button_Click(object sender, RoutedEventArgs e) => SetPage(number: 5);

    private void Item6Button_Click(object sender, RoutedEventArgs e) => SetPage(number: 6);

    private void Item7Button_Click(object sender, RoutedEventArgs e) => SetPage(number: 7);

    private void Item8Button_Click(object sender, RoutedEventArgs e) => SetPage(number: 8);

    private void Item9Button_Click(object sender, RoutedEventArgs e) => SetPage(number: 9);

    private void Item10Button_Click(object sender, RoutedEventArgs e) => SetPage(number: 10);

    private void Item11Button_Click(object sender, RoutedEventArgs e) => SetPage(number: 11);

    private void Item12Button_Click(object sender, RoutedEventArgs e) => SetPage(number: 12);
}