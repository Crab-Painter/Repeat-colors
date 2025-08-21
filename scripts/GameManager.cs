using Godot;
using Repeatcolors.scripts.menu;
using System;
using System.Collections.Generic;

namespace Repeatcolors.scripts;

public partial class GameManager : Node
{
    enum MainSceneNames
    {
        mainMenu,
        gameScreen,
        endGameScreen

    }
    private Node currentScene;
    // private Scene
    public override void _Ready()
    {
        EventManager.GameEndedEvent += EndGame;
    }
    public override void _ExitTree()
    {
        EventManager.GameEndedEvent -= EndGame;
    }

    public void EndGame(bool isWin)
    {
        string scenePath = GetMainScenePathByClassName(MainSceneNames.endGameScreen.ToString());
        EndGameScreen endgameScene  = ResourceLoader.Load<PackedScene>(scenePath).Instantiate<EndGameScreen>();
        endgameScene.IsWin = isWin;
        ChangeSceneTo(endgameScene);
    }
    private void ChangeSceneTo(Node newScene)
    {
        if (currentScene != null)
        {
            RemoveChild(currentScene);
        }
        AddChild(newScene);
        currentScene = newScene;
    }

    private static string GetMainScenePathByClassName(string sceneClassName)
    {
        return "scenes/mainScreens/" + sceneClassName + ".tscn";
    }
}
