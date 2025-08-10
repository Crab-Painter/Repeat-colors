using Godot;

namespace Repeatcolors.scripts;

public partial class LivesCounter : Label
{
    [Export] private string _baseText;
    public override void _Ready()
    {
        EventManager.ChangeLivesEvent += ChangeText;
    }

    public override void _ExitTree()
    {
        EventManager.ChangeLivesEvent -= ChangeText;
    }

    private void ChangeText(int lives)
    {
        Text = _baseText + lives.ToString();
    }
}
