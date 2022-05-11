namespace EquipManager.Presentation.Configurations;

internal static class DependencyInjectionConfiguration
{
    public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(nameof(services));

        services.AddTransient<IEmployeeRepositoryService, EmployeeRepositoryService>();
        services.AddTransient<IEmployeeFacadeService, EmployeeFacadeService>();

        services.AddTransient<IEmployeeSizeChartsRepositoryService, EmployeeSizeChartsRepositoryService>();

        services.AddTransient<IPPERepositoryService, PPERepositoryService>();
        services.AddTransient<IPPEFacadeService, PPEFacadeService>();

        services.AddTransient<IPPEContractRepositoryService, PPEContractRepositoryService>();
        services.AddTransient<IPPEContractFacadeService, PPEContractFacadeService>();

        services.AddTransient<IPPEContractBodyRepositoryService, PPEContractBodyRepositoryService>();

        services.AddTransient<IMessageBoxService, WPFMessageBoxService>();

        services.AddTransient<WordDocumentService>();
    }

    public static void AddViewModelsConfiguration(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(nameof(services));

        services.AddTransient<IViewModel<MainView>, MainViewModel>();

        #region Menu

        services.AddTransient<IViewModel<CreateMenuView>, CreateMenuViewModel>();
        services.AddTransient<IViewModel<ViewMenuView>, ViewMenuViewModel>();
        services.AddTransient<IViewModel<UpdateMenuView>, UpdateMenuViewModel>();
        services.AddTransient<IViewModel<DeleteMenuView>, DeleteMenuViewModel>();
        services.AddTransient<IViewModel<SettingsMenuView>, SettingsMenuViewModel>();

        #endregion

        #region Employee

        services.AddTransient<IViewModel<CreateEmployeeView>, CreateEmployeeViewModel>();
        services.AddTransient<IViewModel<ViewEmployeeView>, ViewEmployeeViewModel>();
        services.AddTransient<IViewModel<UpdateEmployeeView>, UpdateEmployeeViewModel>();
        services.AddTransient<IViewModel<DeleteEmployeeView>, DeleteEmployeeViewModel>();
        services.AddTransient<IViewModel<ChoiceEmployeeView>, ChoiceEmployeeViewModel>();

        #endregion

        #region PPE

        services.AddTransient<IViewModel<CreatePPEView>, CreatePPEViewModel>();
        services.AddTransient<IViewModel<ViewPPEView>, ViewPPEViewModel>();
        services.AddTransient<IViewModel<UpdatePPEView>, UpdatePPEViewModel>();
        services.AddTransient<IViewModel<DeletePPEView>, DeletePPEViewModel>();
        services.AddTransient<IViewModel<ChoicePPEView>, ChoicePPEViewModel>();

        #endregion

        #region PPE Contract

        services.AddTransient<IViewModel<CreatePPEContractView>, CreatePPEContractViewModel>();
        services.AddTransient<IViewModel<ViewPPEContractView>, ViewPPEContractViewModel>();
        services.AddTransient<IViewModel<DeletePPEContractView>, DeletePPEContractViewModel>();
        services.AddTransient<IViewModel<ExportPPEContractView>, ExportPPEContractViewModel>();

        #endregion

        #region Settings

        services.AddTransient<IViewModel<ThemeSettingsView>, ThemeSettingsViewModel>();
        services.AddTransient<IViewModel<LanguageSettingsView>, LanguageSettingsViewModel>();

        #endregion
    }
}