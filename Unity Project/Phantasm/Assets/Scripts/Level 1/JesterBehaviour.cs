using UnityEngine;
using System.Collections;

public class JesterBehaviour : MonoBehaviour {

    public void flyAway()
    {
        StartCoroutine(flyAndDie());
    }

    private IEnumerator flyAndDie()
    {
        yield return new WaitForSeconds(2.0f);
        GetComponent<Animator>().SetBool("Disappear", true);
        GetComponent<BoxCollider2D>().isTrigger = true;
    }

}
