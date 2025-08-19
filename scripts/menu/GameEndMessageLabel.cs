using Godot;

namespace Repeatcolors.scripts.menu;

public partial class GameEndMessageLabel : Label
{
    public override void _Ready()
    {
        EventManager.GameEndedEvent += ChangeText;
    }

    public override void _ExitTree()
    {
        EventManager.GameEndedEvent -= ChangeText;
    }

    private void ChangeText(bool isWin)
    {
        Text = isWin ? "You win!" : "You lose(";
    }
}
