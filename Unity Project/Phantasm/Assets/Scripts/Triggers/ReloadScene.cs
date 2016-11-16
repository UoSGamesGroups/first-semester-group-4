using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ReloadScene : TriggerAction
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
        StartCoroutine(reloadScene());
    }

}
