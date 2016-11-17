using UnityEngine;
using System.Collections;

public class OrbDisappear : TriggerAction
{

    public int animationDelay;
    public int destroyDelay;

    public override void execute()
    {
        var globalState = GameObject.Find("Global State").GetComponent<GlobalState>().getInstance();
        globalState.orbsCollected += 1;
        globalState.orbsSinceLastDeath += 1;
        StartCoroutine(destroyOrb());
    }

    IEnumerator destroyOrb()
    {
        yield return new WaitForSeconds(animationDelay);
        GetComponent<Animator>().SetBool("Collected", true);
        yield return new WaitForSeconds(destroyDelay);
        Destroy(gameObject);
    }

}
