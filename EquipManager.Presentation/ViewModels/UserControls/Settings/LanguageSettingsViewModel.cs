namespace EquipManager.Presentation.ViewModels.UserControls.Settings;

/// <summary> Модель представления для <see cref="LanguageSettingsView"/>.</summary>
internal sealed class LanguageSettingsViewModel
    : BaseViewModel, IViewModel<LanguageSettingsView>
{
    public RelayCommand? SetRussianLanguageCommand { get; private set; }

    public RelayCommand? SetEnglishLanguageCommand { get; private set; }

    public LanguageSettingsViewModel() => InitializeCommands();

    private void ExecuteSetRussianLanguage(object obj) =>
        ApplicationSettingsManipulator.ApplyLanguage(language: "Russian");

    private void ExecuteSetEnglishLanguage(object obj) =>
        ApplicationSettingsManipulator.ApplyLanguage(language: "English");

    private bool CanExecuteSetRussianLanguage(object obj) =>
        ApplicationSettings.Language is not "Russian";

    private bool CanExecuteSetEnglishLanguage(object obj) =>
        ApplicationSettings.Language is not "English";

    private void InitializeCommands()
    {
        SetRussianLanguageCommand = new(executeAction: ExecuteSetRussianLanguage,
            canExecuteFunc: CanExecuteSetRussianLanguage);

        SetEnglishLanguageCommand = new(executeAction: ExecuteSetEnglishLanguage,
            canExecuteFunc: CanExecuteSetEnglishLanguage);
    }
}