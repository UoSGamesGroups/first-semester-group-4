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

    public struct PuzzleData
    {
        public bool puzzle1Solved;
    }

    public PlayerData playerData;
    public PuzzleData puzzleData;

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
        puzzleData = instance.puzzleData;
    }

    public void saveState()
    {
        instance.playerData = playerData;
        instance.puzzleData = puzzleData;
    }

    public GlobalState getInstance()
    {
        return instance;
    }

}
