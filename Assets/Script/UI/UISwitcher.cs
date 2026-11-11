using UnityEngine;

public class UISwitcher : MonoBehaviour
{
    [SerializeField] private MainScreenView mainScreenView;
    [SerializeField] private PanelView panelView;

    private IUIState currentState;

    private MainScreenController mainController;
    private PanelController panelController;

    private void Start()
    {
        mainController = new MainScreenController(
            mainScreenView,
            this
            );

        panelController = new PanelController(
            panelView,
            this,
            Bootstrapper.Score,
            Bootstrapper.Services.GetService<IFadeService>(),
            Bootstrapper.Services.GetService<ISoundPlayerService>(),
            Bootstrapper.Services.GetService<ISaverService>()
            );

        SwitchToMain();
    }

    public void SwitchToMain()
    {
        currentState?.Exit();
        currentState = mainController;
        currentState.Enter();
    }

    public void SwitchToPanel()
    {
        currentState?.Exit();
        currentState = panelController;
        currentState.Enter();
    }
}
