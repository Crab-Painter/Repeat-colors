using Godot;
using Repeatcolors.scripts.menu;

namespace Repeatcolors.scripts;

public partial class GameManager : Node
{
    public enum MainSceneNames
    {
        mainMenu,
        gameScreen,
        endGameScreen,
        settingsScreen

    }
    private Node currentScene;

    public override void _Ready()
    {
        Init();
        EventManager.GameEndedEvent += EndGame;
        EventManager.ChangeSceneRequestedEvent += ChangeScene;
        EventManager.ResolutionChangeRequestEvent += ChangeResolution;
    }
    public override void _ExitTree()
    {
        EventManager.GameEndedEvent -= EndGame;
        EventManager.ChangeSceneRequestedEvent -= ChangeScene;
        EventManager.ResolutionChangeRequestEvent -= ChangeResolution;
    }
    public void EndGame(bool isWin)
    {
        EndGameScreen endgameScene = GetMainScenePackedByClassName(MainSceneNames.endGameScreen).Instantiate<EndGameScreen>();
        endgameScene.IsWin = isWin;
        ChangeSceneTo(endgameScene);
    }

    public void ChangeScene(MainSceneNames sceneName)
    {
        Node endgameScene = GetMainScenePackedByClassName(sceneName).Instantiate<Node>();
        ChangeSceneTo(endgameScene);
    }
    private void Init()
    {
        Node mainMenuNode = GetMainScenePackedByClassName(MainSceneNames.mainMenu).Instantiate<Node>();
        ChangeSceneTo(mainMenuNode);
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

    public static PackedScene GetMainScenePackedByClassName(MainSceneNames sceneClassName)
    {
        string mainMenuPath = "scenes/mainScreens/" + sceneClassName.ToString() + ".tscn";
        PackedScene resultScene = ResourceLoader.Load<PackedScene>(mainMenuPath);
        return resultScene;
    }

    public void ChangeResolution(int width, int hight)
    {
        GetWindow().Size = new Vector2I(width, hight);
    }
}
