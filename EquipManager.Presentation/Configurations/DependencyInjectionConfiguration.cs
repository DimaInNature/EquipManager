namespace EquipManager.Presentation.Configurations;

internal static class DependencyInjectionConfiguration
{
    public static void AddDependencyInjectionConfiguration(this IServiceCollection services!!)
    {

    }

    public static void AddViewModelsConfiguration(this IServiceCollection services!!)
    {
        services.AddTransient<IMainViewModel, MainViewModel>();

        #region Menu

        services.AddTransient<ICreateMenuViewModel, CreateMenuViewModel>();
        services.AddTransient<IViewMenuViewModel, ViewMenuViewModel>();
        services.AddTransient<IUpdateMenuViewModel, UpdateMenuViewModel>();
        services.AddTransient<IDeleteMenuViewModel, DeleteMenuViewModel>();
        services.AddTransient<IExportMenuViewModel, ExportMenuViewModel>();
        services.AddTransient<ISettingsMenuViewModel, SettingsMenuViewModel>();

        #endregion

        #region Employee

        services.AddTransient<ICreateEmployeeViewModel, CreateEmployeeViewModel>();
        services.AddTransient<IViewEmployeeViewModel, ViewEmployeeViewModel>();
        services.AddTransient<IUpdateEmployeeViewModel, UpdateEmployeeViewModel>();
        services.AddTransient<IDeleteEmployeeViewModel, DeleteEmployeeViewModel>();

        #endregion

        #region PPE

        services.AddTransient<ICreatePPEViewModel, CreatePPEViewModel>();
        services.AddTransient<IViewPPEViewModel, ViewPPEViewModel>();
        services.AddTransient<IUpdatePPEViewModel, UpdatePPEViewModel>();
        services.AddTransient<IDeletePPEViewModel, DeletePPEViewModel>();

        #endregion

        #region PPE Contract

        services.AddTransient<ICreatePPEContractViewModel, CreatePPEContractViewModel>();
        services.AddTransient<IViewPPEContractViewModel, ViewPPEContractViewModel>();
        services.AddTransient<IUpdatePPEContractViewModel, UpdatePPEContractViewModel>();
        services.AddTransient<IDeletePPEContractViewModel, DeletePPEContractViewModel>();
        services.AddTransient<IExportPPEContractViewModel, ExportPPEContractViewModel>();

        #endregion

        #region Settings

        services.AddTransient<IThemeSettingsViewModel, ThemeSettingsViewModel>();
        services.AddTransient<ILanguageSettingsViewModel, LanguageSettingsViewModel>();
        services.AddTransient<IApplicationSettingsViewModel, ApplicationSettingsViewModel>();

        #endregion
    }
}