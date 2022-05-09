namespace EquipManager.Presentation.Views.UserControls.PPEContracts;

/// <summary> Представление.</summary>
public sealed partial class CreatePPEContractView : UserControl
{
    private readonly ChoicePPEView[]? _controls = new ChoicePPEView[12];

    private readonly ChoiceEmployeeView _employeeControl = new();

    private readonly IViewModel<CreatePPEContractView>? _viewModel = (Application.Current as App)?
       .ServiceProvider?.GetService<IViewModel<CreatePPEContractView>>();

    private readonly IPPEContractFacadeService _ppeContractRepository;

    public CreatePPEContractView()
    {
        InitializeComponent();

        DataContext = _viewModel ?? throw new ViewModelNotFoundException(nameof(CreatePPEContractViewModel));

        _ppeContractRepository = (Application.Current as App)?.ServiceProvider?
            .GetService<IPPEContractFacadeService>() ?? throw new ArgumentNullException(nameof(IPPEContractFacadeService));

        EmployeeFrame.Content = _employeeControl;

        for (int i = 0; i < _controls?.Length;)
            _controls[i] = new ChoicePPEView(number: ++i);

        SetPage(number: 1);
    }

    private async void CreateButton_Click(object sender, RoutedEventArgs e)
    {
        if (_controls is null) return;

        Employee? employee = _employeeControl?.SelectedEmployee;

        if (employee is null)
        {
            MessageBox.Show(
                messageBoxText: LanguageTranslator.Translate(key: "tm_EmployeeIsNotSelected"),
                caption: LanguageTranslator.Translate(key: "tm_Information"),
                button: MessageBoxButton.OK,
                icon: MessageBoxImage.Exclamation);

            return;
        }

        if (_controls[0].SelectedPPE is null)
        {
            MessageBox.Show(
                messageBoxText: LanguageTranslator.Translate(key: "tm_PPEIsNotSelected"),
                caption: LanguageTranslator.Translate(key: "tm_Information"),
                button: MessageBoxButton.OK,
                icon: MessageBoxImage.Exclamation);

            return;
        }

        PPEContract contract = PPEContract.GetBuilder()
            .AddEmployee(employee.Id)
            .Build();

        var bodyBuilder = PPEContractBody.GetBuilder();

        for (int i = 0; i < _controls.Length; i++)
            bodyBuilder.AppendPPE(idPPE: _controls[i]?.SelectedPPE?.Id, number: i + 1);

        PPEContractBody contractBody = bodyBuilder.Build();

        await _ppeContractRepository.CreateAsync(contractModel: (contract, contractBody));

        MessageBox.Show(
            messageBoxText: LanguageTranslator.Translate(key: "t_TheContractHasBeenSuccessfullyCreated"),
            caption: LanguageTranslator.Translate(key: "tm_Success"),
            button: MessageBoxButton.OK,
            icon: MessageBoxImage.Information);

        Clear();

        SetPage(number: 1);
    }

    private void Clear()
    {
        for (int i = 0; i < _controls?.Length;) _controls[i++].Clear();

        _employeeControl?.Clear();
    }

    private void SetPage(int number)
    {
        if (_controls is null) return;

        --number;

        if (number < 0 || number > _controls.Length) return;

        SetFrame(source: _controls[number]);
    }

    private void SetFrame(ContentControl source) =>
        MenuFrame.Content = source ?? throw new NullReferenceException(nameof(source));

    private void Item1Button_Click(object sender, RoutedEventArgs e) => SetPage(number: 1);

    private void Item2Button_Click(object sender, RoutedEventArgs e)
    {
        if (_controls is null || _controls[0].SelectedPPE is null)
        {
            MessageBox.Show(
                messageBoxText: $"{LanguageTranslator.Translate(key: "tm_PPEIsNotSelected")} (№1)",
                caption: $"{LanguageTranslator.Translate(key: "tm_Information")}",
                button: MessageBoxButton.OK,
                icon: MessageBoxImage.Exclamation);

            return;
        }

        SetPage(number: 2);
    }

    private void Item3Button_Click(object sender, RoutedEventArgs e)
    {
        if (_controls is null || _controls[1].SelectedPPE is null)
        {
            MessageBox.Show(
               messageBoxText: $"{LanguageTranslator.Translate(key: "tm_PPEIsNotSelected")} (№2)",
               caption: $"{LanguageTranslator.Translate(key: "tm_Information")}",
               button: MessageBoxButton.OK,
               icon: MessageBoxImage.Exclamation);

            return;
        }

        SetPage(number: 3);
    }

    private void Item4Button_Click(object sender, RoutedEventArgs e)
    {
        if (_controls is null || _controls[2].SelectedPPE is null)
        {
            MessageBox.Show(
                messageBoxText: $"{LanguageTranslator.Translate(key: "tm_PPEIsNotSelected")} (№3)",
                caption: $"{LanguageTranslator.Translate(key: "tm_Information")}",
                button: MessageBoxButton.OK,
                icon: MessageBoxImage.Exclamation);

            return;
        }

        SetPage(number: 4);
    }

    private void Item5Button_Click(object sender, RoutedEventArgs e)
    {
        if (_controls is null || _controls[3].SelectedPPE is null)
        {
            MessageBox.Show(
               messageBoxText: $"{LanguageTranslator.Translate(key: "tm_PPEIsNotSelected")} (№4)",
               caption: $"{LanguageTranslator.Translate(key: "tm_Information")}",
               button: MessageBoxButton.OK,
               icon: MessageBoxImage.Exclamation);

            return;
        }

        SetPage(number: 5);
    }

    private void Item6Button_Click(object sender, RoutedEventArgs e)
    {
        if (_controls is null || _controls[4].SelectedPPE is null)
        {
            MessageBox.Show(
               messageBoxText: $"{LanguageTranslator.Translate(key: "tm_PPEIsNotSelected")} (№5)",
               caption: $"{LanguageTranslator.Translate(key: "tm_Information")}",
               button: MessageBoxButton.OK,
               icon: MessageBoxImage.Exclamation);

            return;
        }

        SetPage(number: 6);
    }

    private void Item7Button_Click(object sender, RoutedEventArgs e)
    {
        if (_controls is null || _controls[5].SelectedPPE is null)
        {
            MessageBox.Show(
               messageBoxText: $"{LanguageTranslator.Translate(key: "tm_PPEIsNotSelected")} (№6)",
               caption: $"{LanguageTranslator.Translate(key: "tm_Information")}",
               button: MessageBoxButton.OK,
               icon: MessageBoxImage.Exclamation);

            return;
        }

        SetPage(number: 7);
    }

    private void Item8Button_Click(object sender, RoutedEventArgs e)
    {
        if (_controls is null || _controls[6].SelectedPPE is null)
        {
            MessageBox.Show(
                messageBoxText: $"{LanguageTranslator.Translate(key: "tm_PPEIsNotSelected")} (№7)",
                caption: $"{LanguageTranslator.Translate(key: "tm_Information")}",
                button: MessageBoxButton.OK,
                icon: MessageBoxImage.Exclamation);

            return;
        }

        SetPage(number: 8);
    }

    private void Item9Button_Click(object sender, RoutedEventArgs e)
    {
        if (_controls is null || _controls[7].SelectedPPE is null)
        {
            MessageBox.Show(
                messageBoxText: $"{LanguageTranslator.Translate(key: "tm_PPEIsNotSelected")} (№8)",
                caption: $"{LanguageTranslator.Translate(key: "tm_Information")}",
                button: MessageBoxButton.OK,
                icon: MessageBoxImage.Exclamation);

            return;
        }

        SetPage(number: 9);
    }

    private void Item10Button_Click(object sender, RoutedEventArgs e)
    {
        if (_controls is null || _controls[8].SelectedPPE is null)
        {
            MessageBox.Show(
               messageBoxText: $"{LanguageTranslator.Translate(key: "tm_PPEIsNotSelected")} (№9)",
               caption: $"{LanguageTranslator.Translate(key: "tm_Information")}",
               button: MessageBoxButton.OK,
               icon: MessageBoxImage.Exclamation);

            return;
        }

        SetPage(number: 10);
    }

    private void Item11Button_Click(object sender, RoutedEventArgs e)
    {
        if (_controls is null || _controls[9].SelectedPPE is null)
        {
            MessageBox.Show(
               messageBoxText: $"{LanguageTranslator.Translate(key: "tm_PPEIsNotSelected")} (№10)",
               caption: $"{LanguageTranslator.Translate(key: "tm_Information")}",
               button: MessageBoxButton.OK,
               icon: MessageBoxImage.Exclamation);

            return;
        }

        SetPage(number: 11);
    }

    private void Item12Button_Click(object sender, RoutedEventArgs e)
    {
        if (_controls is null || _controls[10].SelectedPPE is null)
        {
            MessageBox.Show(
               messageBoxText: $"{LanguageTranslator.Translate(key: "tm_PPEIsNotSelected")} (№11)",
               caption: $"{LanguageTranslator.Translate(key: "tm_Information")}",
               button: MessageBoxButton.OK,
               icon: MessageBoxImage.Exclamation);

            return;
        }

        SetPage(number: 12);
    }
}