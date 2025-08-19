using Godot;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Repeatcolors.scripts.game;
public partial class Simon : Panel
{
    public override void _Ready()
    {
        EventManager.RoundStartsEvent += Display;
    }

    public override void _ExitTree()
    {
        EventManager.RoundStartsEvent -= Display;
    }

    private async void Display(List<string> coloursSequence)
    {
        StyleBoxFlat style = new();
        foreach (string color in coloursSequence)
        {
            style.BgColor = new Color("#ffffffff");
            AddThemeStyleboxOverride("panel", style);
            await ToSignal(GetTree().CreateTimer(1.0), "timeout");

            style.BgColor = new Color(color);
            AddThemeStyleboxOverride("panel", style);
            await ToSignal(GetTree().CreateTimer(1.0), "timeout");
        }
        style.BgColor = new Color("#ffffffff");
        AddThemeStyleboxOverride("panel", style);
        EventManager.BroadcastSimonSadEvent();
    }

}
