using Godot;

namespace Repeatcolors.scripts.menu;

public partial class SceneChangeButton : Button
{
    [Export] string sceneClassName;
    public override void _Ready()
    {
        Pressed += SendEvent;
    }
    private void SendEvent()
    {
        EventManager.BroadcastChangeSceneRequestedEvent(sceneClassName);
    }
}
