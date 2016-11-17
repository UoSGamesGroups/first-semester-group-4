using UnityEngine;
using System.Collections;

public class DestroyObject : TriggerAction
{

    public float delay;

    public override void execute()
    {
        StartCoroutine(destroyObject());
    }

    private IEnumerator destroyObject()
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }

}
