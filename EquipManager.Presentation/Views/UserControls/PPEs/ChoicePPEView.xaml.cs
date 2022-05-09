namespace EquipManager.Presentation.Views.UserControls.PPEs;

/// <summary> Представление.</summary>
public sealed partial class ChoicePPEView : UserControl
{
    public PPE? SelectedPPE => (DataContext as ChoicePPEViewModel)?.PPE;

    private readonly IViewModel<ChoicePPEView>? _viewModel = (Application.Current as App)?
       .ServiceProvider?.GetService<IViewModel<ChoicePPEView>>();

    public ChoicePPEView()
    {
        InitializeComponent();

        DataContext = _viewModel ?? throw new ViewModelNotFoundException(nameof(ChoicePPEViewModel));
    }

    public ChoicePPEView(int number) : this()
    {
        NumberTextBlock.Text = $"{NumberTextBlock.Text} №{number}";
    }

    public void Clear()
    {
        if (DataContext is null) return;

        (DataContext as ChoicePPEViewModel).PPE = null;
    }
}