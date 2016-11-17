using UnityEngine;
using System.Collections;

public class GlobalState : MonoBehaviour
{

    public static GlobalState instance;

    public Vector2 respawnPoint;

    public int puzzlesSolved = 0;
    public int orbsCollected = 0;
    public int orbsSinceLastDeath = 0;

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
        respawnPoint = instance.respawnPoint;
        orbsCollected = instance.orbsCollected;
        orbsSinceLastDeath = instance.orbsSinceLastDeath;
        puzzlesSolved = instance.puzzlesSolved;
    }

    public void saveState()
    {
        instance.respawnPoint = respawnPoint;
        instance.orbsCollected = orbsCollected;
        instance.orbsSinceLastDeath = orbsSinceLastDeath;
        instance.puzzlesSolved = puzzlesSolved;
    }

    public GlobalState getInstance()
    {
        return instance;
    }

}
