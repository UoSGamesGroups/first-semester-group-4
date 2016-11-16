using UnityEngine;
using System.Collections;

public class SceneChange : TriggerAction
{

    public SceneTransitioner sceneTransitioner;
    public int sceneIndex;
    public int delay;

    private IEnumerator reloadScene()
    {
        yield return new WaitForSeconds(delay);
        sceneTransitioner.changeScene(sceneIndex);
    }

    public override void execute() {
        StartCoroutine(reloadScene());
    }

}
