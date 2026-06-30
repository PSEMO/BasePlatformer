//TODO: REWORK

using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }

        CurrentGameState = initialGameState;
    }

    [HideInInspector] public SceneState CurrentGameState { get; private set; }

    [SerializeField] private SceneState initialGameState = SceneState.MainMenuScene;

    public void TryUpdateGameState(SceneState newState)
    {
        if (CurrentGameState != newState)
        {
            CurrentGameState = newState;
            Events.InvokeGameStateChanged(newState);
        }
    }
}