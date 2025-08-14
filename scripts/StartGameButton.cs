using Godot;

namespace Repeatcolors.scripts;

public partial class StartGameButton : Button
{
    public override void _Ready()
    {
        Pressed += StartGame;
    }
    private void StartGame()
    {
        GetTree().ChangeSceneToFile("scenes/game.tscn");
    }
}
