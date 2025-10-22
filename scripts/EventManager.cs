using System;
using System.Collections.Generic;

namespace Repeatcolors.scripts;

public class EventManager
{
    public static Action<List<string>> ChangeColorsInputEvent;
    public static Action<int> ChangeLivesEvent;
    public static Action<int> ChangePointsEvent;
    public static Action<List<string>> RoundStartsEvent;
    public static Action SimonSadEvent;
    public static Action<bool> GameEndedEvent;
    public static Action<GameManager.MainSceneNames> ChangeSceneRequestedEvent;
    public static Action<int, int> ResolutionChangeRequestEvent;


    public static void BroadcastChangeColorsInputEvent(List<string> colorsInput)
    {
        ChangeColorsInputEvent?.Invoke(colorsInput);
    }

    public static void BroadcastChangeLivesEvent(int lives)
    {
        ChangeLivesEvent?.Invoke(lives);
    }

    public static void BroadcastChangePointsEvent(int points)
    {
        ChangePointsEvent?.Invoke(points);
    }
    public static void BroadcastRoundStartsEvent(List<string> colorsSequence)
    {
        RoundStartsEvent?.Invoke(colorsSequence);
    }
    public static void BroadcastSimonSadEvent()
    {
        SimonSadEvent?.Invoke();
    }
    public static void BroadcastGameEndedEvent(bool message)//TODO rename
    {
        GameEndedEvent?.Invoke(message);
    }
    public static void BroadcastChangeSceneRequestedEvent(GameManager.MainSceneNames sceneName)
    {
        ChangeSceneRequestedEvent?.Invoke(sceneName);
    }

    public static void BroadcastResolutionChangeRequestEvent(int width, int hight)
    {
        ResolutionChangeRequestEvent?.Invoke(width, hight);
    }
}
