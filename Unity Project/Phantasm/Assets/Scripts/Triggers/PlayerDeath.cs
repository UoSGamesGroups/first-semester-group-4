using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerDeath : TriggerAction
{

    public SceneTransitioner sceneTransitioner;
    public int delay;

    private IEnumerator reloadScene()
    {
        yield return new WaitForSeconds(delay);
        sceneTransitioner.changeScene(SceneManager.GetActiveScene().buildIndex);
    }

    public override void execute()
    {
        var globalState = GameObject.Find("Global State").GetComponent<GlobalState>().getInstance();
        globalState.orbsCollected -= globalState.orbsSinceLastDeath;
        globalState.orbsSinceLastDeath = 0;
        StartCoroutine(reloadScene());
    }

}
