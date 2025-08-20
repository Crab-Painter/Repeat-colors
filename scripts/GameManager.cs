using Godot;
using System;
using System.Collections.Generic;

namespace Repeatcolors.scripts;

public partial class GameManager : Node
{
    public static readonly List<string> mainSceneNames = [];//TODO
    private string currentScene;
    // private Scene
    public override void _Ready()
    {
        EventManager.ChangeSceneRequestedEvent += ChangeScene;
    }
    public override void _ExitTree()
    {
        EventManager.ChangeSceneRequestedEvent -= ChangeScene;
    }
    public void ChangeScene(string scenePath)
    {
        GetNode(scenePath);//todo
    }

    private static string GetMainScenePathByClassName(string sceneClassName)
    {
        return "scenes/mainScreens" + sceneClassName + ".tscn";
    }
}
