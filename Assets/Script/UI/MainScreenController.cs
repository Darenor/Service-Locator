public class MainScreenController : IUIState
{
    private readonly MainScreenView view;
    private readonly UISwitcher switcher;

    public MainScreenController(
        MainScreenView view,
        UISwitcher switcher)
    {
        this.view = view;
        this.switcher = switcher;
    }

    public void Enter()
    {
        view.SubscribeOpenButton(OpenPanel);
    }

    public void Exit()
    {
        view.UnsubscribeOpenButton(OpenPanel);
    }

    private void OpenPanel()
    {
        switcher.SwitchToPanel();
    }
}
