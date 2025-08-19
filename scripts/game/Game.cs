using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repeatcolors.scripts.game;

public partial class Game : Control
{
    private static bool _isGameOn = false;
    private static int _lives = 3;
    private static int _points = 0;

    private static readonly Random rand = new();
    private static readonly string RED = "#ff0000ff";
    private static readonly string GREEN = "#00ff00ff";
    private static readonly string BLUE = "#0000ffff";
    private List<string> _inputSequence = [];
    private List<string> _generatedSequence = [];

    [Export] private Button ReadyButton;
    [Export] private Button RedButton;
    [Export] private Button GreenButton;
    [Export] private Button BlueButton;
    [Export] private Button ResetButton;
    [Export] private Button DeleteButton;
    [Export] private Button EnterButton;
    [Export] private int RowCount;

    public override void _Ready()
    {
        base._Ready();

        ReadyButton.Pressed += SimonSays;
        RedButton.Pressed += EnterRed;
        GreenButton.Pressed += EnterGreen;
        BlueButton.Pressed += EnterBlue;
        ResetButton.Pressed += ResetPressed;
        DeleteButton.Pressed += DeletePressed;
        EnterButton.Pressed += EnterPressed;
        EventManager.SimonSadEvent += StartRound;

        ResetGame();
    }
    public override void _ExitTree()
    {
        EventManager.SimonSadEvent -= StartRound;
    }

    private void ResetGame()
    {
        _lives = 3;
        _points = 0;
        _generatedSequence.Clear();
        _inputSequence.Clear();

        EventManager.BroadcastChangeColorsInputEvent(_inputSequence);
        EventManager.BroadcastChangeLivesEvent(_lives);
        EventManager.BroadcastChangePointsEvent(_points);
    }

    private void SimonSays()
    {
        if (_isGameOn)
        {
            return;
        }
        _generatedSequence.Clear();
        _inputSequence.Clear();
        EventManager.BroadcastChangeColorsInputEvent(_inputSequence);

        List<string> options = [RED, BLUE, GREEN];

        for (int i = 0; i < RowCount; i++)
        {
            string randomColor = options[rand.Next(0, options.Count)];
            _generatedSequence.Add(randomColor);
        }
        EventManager.BroadcastRoundStartsEvent(_generatedSequence);
    }

    private void StartRound()
    {
        _isGameOn = true;
    }

    private void EnterRed()
    {
        ColorButtonPressed(RED);
    }

    private void EnterGreen()
    {
        ColorButtonPressed(GREEN);
    }

    private void EnterBlue()
    {
        ColorButtonPressed(BLUE);
    }

    private void ColorButtonPressed(string colour)
    {
        if ((_inputSequence.Count >= RowCount) || (!_isGameOn))
        {
            return;
        }

        _inputSequence.Add(colour);
        EventManager.BroadcastChangeColorsInputEvent(_inputSequence);
    }

    private void ResetPressed()
    {
        if (!_isGameOn)
        {
            return;
        }
        _inputSequence.Clear();
        EventManager.BroadcastChangeColorsInputEvent(_inputSequence);
    }

    private void DeletePressed()
    {
        if ((_inputSequence.Count == 0) || !_isGameOn)
        {
            return;
        }
        _inputSequence.RemoveAt(_inputSequence.Count - 1);
        EventManager.BroadcastChangeColorsInputEvent(_inputSequence);
    }

    private void EnterPressed()
    {
        if ((_inputSequence.Count != RowCount) || (!_isGameOn))
        {
            return;
        }

        if (_generatedSequence.SequenceEqual(_inputSequence))
        {
            _points++;
            EventManager.BroadcastChangePointsEvent(_points);
        }
        else
        {
            _lives--;
            EventManager.BroadcastChangeLivesEvent(_lives);
        }
        _isGameOn = false;

        CheckGameEnd();
    }
    
    private void CheckGameEnd()
    {
        bool isWin = _points >= 5;
        if ((_lives <= 0) || isWin)
        {
            GetTree().ChangeSceneToFile("scenes/endgame.tscn");
            EventManager.BroadcastGameEndedEvent(isWin);
        }
    }
}
