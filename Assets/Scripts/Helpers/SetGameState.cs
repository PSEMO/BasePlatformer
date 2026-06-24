using Unity.VisualScripting;
using UnityEngine;

public class SetGameState : MonoBehaviour
{
    [SerializeField] GameState StateToSet;

    void Start()
    {
        GameManager.Instance.UpdateGameState(StateToSet);
    }
}