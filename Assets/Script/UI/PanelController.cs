using System.IO;
using UnityEngine;

public class PanelController : IUIState
{
    private readonly PanelView view;
    private readonly UISwitcher switcher;
    private readonly Score score;

    private readonly IFadeService fadeService;
    private readonly ISoundPlayerService soundPlayer;
    
    private readonly ISaverService saver;

    private readonly string jsonPath = Path.Combine(
        Application.persistentDataPath,
        "score.json"
        );

    public PanelController(
        PanelView view,
        UISwitcher switcher,
        Score score,
        IFadeService fadeService,
        ISoundPlayerService soundPlayer,
        ISaverService saver)
    {
        this.view = view;
        this.switcher = switcher;
        this.score = score;
        this.fadeService = fadeService;
        this.soundPlayer = soundPlayer;
        this.saver = saver;
    }

    public void Enter()
    {
        view.gameObject.SetActive(true);

        view.SubscribeCloseButton(ClosePanel);
        view.SubscribeCollectButton(CollectPoint);

        score.OnScoreChanged += view.UpdateScore;

        view.UpdateScore(score.CurrentScore);

        fadeService.FadeIn(view.PanelImage, 0.4f);
        soundPlayer.PlayOpenSound();
    }

    public void Exit()
    {
        view.UnsubscribeCloseButton(ClosePanel);
        view.UnsubscribeCollectButton(CollectPoint);

        score.OnScoreChanged -= view.UpdateScore;
        
        saver.SaveScore(jsonPath);

        fadeService.FadeOut(view.PanelImage, 0.4f);
        soundPlayer.PlayCloseSound();
    }

    private void CollectPoint()
    {
        score.AddPoint();
    }

    private void ClosePanel()
    {
        switcher.SwitchToMain();
    }
}
