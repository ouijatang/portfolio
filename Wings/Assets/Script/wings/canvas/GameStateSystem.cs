using UnityEngine;

public enum GameState
{
    WaitInput,
    BlockInput,
}

public class GameStateSystem : MonoBehaviour
{
    public GameState state { get; private set; }

    public void SetState(GameState gs)
    {
        state = gs;
    }
}
