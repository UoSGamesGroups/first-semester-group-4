using UnityEngine;
using System.Collections;

public class AnimatorSetBool : TriggerAction
{

    public string paramaterName;
    public bool state;
    public int delay;

    private IEnumerator performAction() {
        yield return new WaitForSeconds(delay);
        GetComponent<Animator>().SetBool(paramaterName, state);
    }

    public override void execute() {
        StartCoroutine(performAction());
    }

}
