namespace EquipManager.Presentation.ViewModels.UserControls.Employees;

/// <summary> Модель представления для <see cref="ChoiceEmployeeView"/>.</summary>
internal sealed class ChoiceEmployeeViewModel
    : BaseViewModel, IViewModel<ChoiceEmployeeView>
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

    public Employee? Employee
    {
        get => _employee;
        set
        {
            _employee = value;

            OnPropertyChanged(nameof(Employee));
        }
    }

    private Employee? _employee;

    private IList<Employee> _employees = new List<Employee>();

    private readonly IEmployeeFacadeService _repository;

    private static readonly SemaphoreSlim _semaphore = new(initialCount: 1, maxCount: 1);

    public ChoiceEmployeeViewModel(IEmployeeFacadeService repository)
    {
        _repository = repository;

        Task.Run(action: LoadData);
    }

    private async void LoadData()
    {
        //TODO Dirty Trick. A thread-safety issue. Two threads are fighting for one dbcontext.
        Thread.Sleep(5000);

        await _semaphore.WaitAsync();

        try
        {
            Employees = await _repository.GetEmployeeListAsync();
        }
        finally
        {
            _semaphore.Release();
        }
    }
}