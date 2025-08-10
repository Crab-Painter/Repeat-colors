using Godot;

namespace Repeatcolors.scripts;

public partial class MainMenu : Control
{
    [Export] private Button StartGameButton;
    [Export] private Button OptionsButton;
    [Export] private Button ExitButton;

    public override void _Ready()
    {
        base._Ready();
        StartGameButton.Pressed += StartGame;
        ExitButton.Pressed += ExitGame;
    }

    private void StartGame()
    {
        GetTree().ChangeSceneToFile("scenes/game.tscn");
    }

    private void ExitGame()
    {
        GetTree().Quit();
    }
}
