using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MIPlay : MenuItem
{

    public SceneTransitioner sceneTransitioner;

    public override void execute()
    {
        sceneTransitioner.changeScene(1);
    }

}
