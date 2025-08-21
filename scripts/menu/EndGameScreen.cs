using Godot;
using System;

namespace Repeatcolors.scripts.menu;

public partial class EndGameScreen : Control
{
    public bool IsWin
    {
        set
        {
            _isWin = value;
        }
    }
    private bool _isWin;
    public override void _Ready()
    {
        GameEndLabel label = GetNode<GameEndLabel>("CanvasLayer/Game End Message");
        label.Text = _isWin ? label.winMessage : label.loseMessage;
    }
}
