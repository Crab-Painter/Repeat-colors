using Godot;
using System.Collections.Generic;

namespace Repeatcolors.scripts.game;

public partial class ColorInputBox : Panel
{
    [Export] private int _positionIndex;

    public override void _Ready()
    {
        EventManager.ChangeColorsInputEvent += ChangeColor;
    }

    public override void _ExitTree()
    {
        EventManager.ChangeColorsInputEvent -= ChangeColor;
    }

    private void ChangeColor(List<string> coloursInput)
    {
        string nodeColorString = "#ffffffff";
        if (coloursInput.Count >= _positionIndex + 1) {
            nodeColorString = coloursInput[_positionIndex];
        }

        StyleBoxFlat style = new()
        {
            BgColor = new Color(nodeColorString)
        };
        AddThemeStyleboxOverride("panel", style);
    }
}
