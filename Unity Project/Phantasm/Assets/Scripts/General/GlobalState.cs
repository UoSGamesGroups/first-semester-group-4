using UnityEngine;
using System.Collections;

public class GlobalState : MonoBehaviour
{

    public static GlobalState instance;

    public struct PlayerData
    {
        public bool needsPorting;
        public Vector2 startPosition;
    }

    public PlayerData playerData;

    public int puzzlesSolved = 0;

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        playerData = instance.playerData;
    }

    public void saveState()
    {
        instance.playerData = playerData;
    }

    public GlobalState getInstance()
    {
        return instance;
    }

}
