using System;
using Godot;

namespace Repeatcolors.scripts.menu;

public partial class SceneChangeButton : Button
{
    [Export] GameManager.MainSceneNames SceneClassName {get;set;}
    public override void _Ready()
    {
        Pressed += SendEvent;
    }
    private void SendEvent()
    {
        EventManager.BroadcastChangeSceneRequestedEvent(SceneClassName);
    }
}
