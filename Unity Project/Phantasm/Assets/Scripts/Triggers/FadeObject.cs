using UnityEngine;
using System.Collections;

public class FadeObject : TriggerAction
{

    public float delay;
    public float fadeSpeed;

    public override void execute()
    {
        StartCoroutine(fadeObject());
    }

    private IEnumerator fadeObject()
    {
        yield return new WaitForSeconds(delay);
        for (var i = 1.0f; i > 0.0f; i -= 0.04f)
        {
            GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, i);
            yield return new WaitForSeconds(fadeSpeed);
        }
        Destroy(gameObject);
    }

}
