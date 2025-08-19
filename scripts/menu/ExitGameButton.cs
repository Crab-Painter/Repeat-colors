using Godot;

namespace Repeatcolors.scripts.menu;

public partial class ExitGameButton : Button
{
    public override void _Ready()
    {
        Pressed += ExitGame;
    }
    private void ExitGame()
    {
        GetTree().Quit();
    }
}
