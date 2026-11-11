using System;
using System.Collections.Generic;
using UnityEngine;

public class ServiceLocator : IService
{
    private readonly Dictionary<Type, object> services = new();

    public ServiceLocator(
        AudioSource audioSource,
        AudioClip openClip,
        AudioClip closeClip,
        Score score,
        SaveModeService saveModeService)
    {
        services.Add(
            typeof(IFadeService),
            new FadeService()
            );

        services.Add(
            typeof(ISoundPlayerService),
            new SoundPlayerService(audioSource, openClip, closeClip)
            );
    
    
    ISaverService saver;

        switch (saveModeService)
    {
        case SaveModeService.PlayerPrefs:
        saver = new PlayerPrefsSaver(score);
        break;

        case SaveModeService.Json:
        saver = new JsonSaverService(score);
        break;

        default:
        throw new ArgumentOutOfRangeException(
            nameof(saveModeService),
            saveModeService,
            "Неизвестный способ сохранения"
            );
    }

    services.Add(typeof(ISaverService), saver);
    }

    public T GetService<T>()
    {
        if (services.TryGetValue(typeof(T), out object service))
            return (T)service;

        throw new Exception(
            $"Сервис {typeof(T).Name} не найден!"
            );
    }
}
