namespace EquipManager.Presentation.ViewModels.UserControls.Employees;

/// <summary> Модель представления для <see cref="ViewEmployeeView"/>.</summary>
internal sealed class ViewEmployeeViewModel
    : BaseViewModel, IViewModel<ViewEmployeeView>
{
    public IList<Employee> Employees
    {
        get => _employees;
        set
        {
            _employees = value is null
                ? new List<Employee>()
                : value;
            OnPropertyChanged(nameof(Employees));
        }
    }

    private IList<Employee> _employees = new List<Employee>();

    private readonly IEmployeeFacadeService _repository;

    public ViewEmployeeViewModel(IEmployeeFacadeService repository)
    {
        _repository = repository;

        Task.Run(action: LoadData);
    }

    private async void LoadData() =>
        Employees = await _repository.GetEmployeeListAsync();
}