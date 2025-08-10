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


}
