namespace EquipManager.Infra.Core.ViewModels;

public abstract class BaseMenuViewModel : BaseViewModel
{
    public RelayCommand? ShowPPEPageCommand { get; protected set; }

    public RelayCommand? ShowEmployeePageCommand { get; protected set; }

    public RelayCommand? ShowPPEContractPageCommand { get; protected set; }

    public object? FrameSource
    {
        get => _frameSource;
        set
        {
            _frameSource = value;

            OnPropertyChanged(nameof(FrameSource));

            MenuIsVisible = value switch
            {
                null => Visibility.Visible,
                _ => Visibility.Collapsed,
            };
        }
    }

    public Visibility FrameVisibility
    {
        get => _frameVisibility;
        set
        {
            _frameVisibility = value;

            OnPropertyChanged(nameof(FrameVisibility));
        }
    }

    public Visibility MenuIsVisible
    {
        get => _menuIsVisible;
        set
        {
            _menuIsVisible = value;

            OnPropertyChanged(nameof(MenuIsVisible));
        }
    }

    protected object? _frameSource;

    protected Visibility _frameVisibility;

    protected Visibility _menuIsVisible;
}