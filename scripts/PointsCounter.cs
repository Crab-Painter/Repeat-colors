using Godot;

namespace Repeatcolors.scripts;

public partial class PointsCounter : Label
{   
    [Export] private string _baseText;
    public override void _Ready()
    {
        EventManager.ChangePointsEvent += ChangeText;
    }

    public override void _ExitTree()
    {
        EventManager.ChangePointsEvent -= ChangeText;
    }

    private void ChangeText(int points)
    {
        Text = _baseText + points.ToString() + "/5";
    }
}
