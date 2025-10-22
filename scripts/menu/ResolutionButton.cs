using Godot;
using System;

namespace Repeatcolors.scripts.menu;

public partial class ResolutionButton : OptionButton
{
    public override void _Ready()
    {
        ItemSelected += SendEvent;
    }
    public void SendEvent(long index)
    {
        string[] dimensions = Text.Split("x");
        int width = dimensions[0].ToInt();
        int hight = dimensions[1].ToInt();
        EventManager.BroadcastResolutionChangeRequestEvent(width,hight);
    }
}
